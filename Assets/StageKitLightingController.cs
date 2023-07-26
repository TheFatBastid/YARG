using System;
using UnityEngine;
using YARG.Input;
using PlasticBand.Haptics;
using YARG.PlayMode;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using YARG.Data;
using YARG.Song;
using YARG.UI;
using YARG.UI.PlayResultScreen;
using Random = UnityEngine.Random;

/*
 Bugs and notes:
 During official light shows (For example, using the stage kit with RB2, on a xbox 360) the lights will sometimes behave in unexpected, song specific, one-off ways.
 It is hard to say if this is a bug or complex intended behavior. Since there are known bugs with the stage kit as is, I am going to assume these are also bugs since the programming required to make these bespoke song effects is not trivial and doesn't seem to make sense.
 So stage shows will be slightly different than the official ones, but hopefully more consistent and predictable with what was intended (and even better!).

 Sometimes pause doesn't work for fast strobe?? I legit don't know why this happens. It seems to be a bug with the stage kit itself.

 Not sure how different patterns for the cues are chosen. Not random, the same songs in the same venue will have the same patterns for the cues each time.

 Setting light patterns based on venue size is currently just randomized between small and large venue. This is because there is no way to get venue size from the game, at the moment.


 Not implemented because these things don't exist YARG:

 "About to fail song" light cues are not implemented since we don't support failing songs right now.

 Intro "walk on" lighting before the song starts (where it says "<user name> as <character name>") is not implemented because that doesn't exist.


 Implemented by YARG but not in the original game:

 Menu lighting - half works.


NR = No visible response from Stage Kit
VR = Response changes based on venue size
RE = Response is the same regardless of venue size

LED numbers:
rockband logo
 7 0 1
  \|/
6 -+-  2
  /|\
 5 4 3
xbox button



This file is for the individual effects for the stage kit:
Keyframed calls:

	NR	verse						Doesn't seem to do anything.
	NR	chorus						Doesn't seem to do anything.

	RE	loop_cool                   2 blue LEDs 180 degrees apart rotating counter clockwise, 1 green led starting at 90 degrees rotating clockwise. To the beat.
	RE	loop_warm                   2 red LEDs 180 degrees apart rotating clockwise, 1 yellow led starting at 90 counter rotating counterclockwise. To the beat.
	RE	manual_cool					2 blue LEDs 180 degrees apart rotating counter clockwise, 1 green led starting at 90 degrees rotating clockwise. To the beat. Does not turn off strobe on initial call, turns it off on [next]
	RE	manual_warm					2 red LEDs 180 degrees apart rotating clockwise, 1 yellow led starting at 90 counter rotating counterclockwise. To the beat. Does not turn off strobe on initial call, turns it off on [next]

	VR	dischord					1 yellow led clock circles on major and minor beat.
									Red ring on drum red fret
	                                Blue follows [next], pattern is 6|2 ,off, 6|2|0|4. Turns off then on. (not 100% sure on this one)

	                                Small venue:
									1 Green led @ 0, counter-clockwise circles to beat

									Large Venue:
									On Major beat toggles between: 1 Green led@0 counter clock circles to beat , all green leds on.

	VR	stomp						Initial call turns on leds. Responds to the [next] event toggling lights on or off.

									Small Venue:
									Red, Green, Yellow

									Large Venue:
									All colors


	VR	Empty (i.e. [lighting ()])	Small Venue:
		Default lighting.			All red on, all blue on, changing on [next]. Yellow ring on, half beat flash on drum red fret
		                            Green, off

									Large Venue:
                                    All blue on,  all red on. changing on [next].

Automatic calls:

	RE	harmony             blue @4 clockwise on beat and green @4 clockwise on beat

	VR	frenzy				sequence of alternating patterns. I think each color is half a beat.
								Large venue: all red, off, all blue, all yellow
								Small venue: half red, other half red, 4 green , 2 side blue, other 6 blue

	RE	silhouettes			Turn on a green ring (doesn't seem to turn it off)

	NR	silhouettes_spot	Responses change depending on the cue before it.
	                        For Dischord, It turns on both blue and green rings, with the blue toggling on and off depending on the vocal note end after each major beat.
	                        Does nothing with Stomp
	                        Turns off all lights for everything else.

	VR	searchlights     	On beat.
	                        Small venue pattern:
						    	1 yellow and 1 red rotate together. Counter clock

							Large venue patterns:
								1 yellow@2 clockwise and 1 blue@0 counter clock.

								There are other patterns for both cues that change which leds start. I don't know how they are chosen yet.

	RE	sweep               On beat.
	                        small venue:
		                        Yellow@ 6 and 2, counter-clock
		                        Blue@0, clock

		                    Large venue:
		                        Red @6 and 2, counter-clock

	RE	strobe_slow			Strobe light that blinks every 16th note/120 ticks.
	RE	strobe_fast			Strobe light that blinks every 32nd note/60 ticks.
	                        While the strobe has 5 speeds, off, slow, medium, fast, fastest, only slow and fast are every used.
	                        Even the strobe_off call is exceedingly rare, the strobe is typically turned off by other cues starting.

	NR	blackout_fast		Turns off strobe. Turns of all LEDs
	NR	blackout_slow       Turns off strobe. Turns of all LEDs
	??	blackout_spot       (untested) Turns off strobe. Turns of all LEDs
	RE	flare_slow          All LEDS on. Turned off by other calls.
	RE	flare_fast			All 8 blue LEDS turn on. Turned off by other calls. Turns on greens after cool.
	RE	bre                 All Red, Green, Yellow, Blue leds turn on in sequence. Two times a beat.
	NR	bonusfx             Doesn't seem to do anything.
	NR	bonusfx_optional    Doesn't seem to do anything.

	RE	FogOn				Turns the fog machine on. No other cue interacts with the fog machine!
	RE	FogOff				Turns the fog machine off. No other cue interacts with the fog machine!

	RE	intro               Doesn't seem to do anything.

Extra calls:
    VR	Score card  		small venue
		                    2 yellow at 180 to each other clock 2 second starting on 6 and 2, 1 blue@0 counter clock 1 second

		                    large venue
		                    2 yellow at 180 to each other clock 2 second, 2 red at 180 counter clock 1 second

	RE Menu lighting        1 blue@0 rotates counter clock every two seconds. Made by me. Not in the original game.
 */
namespace StageKitLighting {
	internal class StageKitLightingController : MonoBehaviour
    {
		public enum StrobeSpeed
        {
			Off,
			Slow,
			Medium,
			Fast,
			Fastest
		}
        private enum FogState
        {
			Off = 0,
			On = 1,
        }
        public event Action<string> OnEventReceive;
        private bool _isSongPlaying;
        public bool largeVenue;
		public byte[] currentLedState = { 0x00, 0x00, 0x00, 0x00 }; //blue, green, yellow, red
		private readonly byte[] _previousLedState = { 0x00, 0x00, 0x00, 0x00 }; //this is only for the SendCommands() command to limit swamping the kit.
		public static StageKitLightingController Instance { get; private set; }

        // Stuff for the actual command sending to the unit
		public readonly Queue<(int, byte)> CommandQueue = new Queue<(int, byte)>();
		public bool isSendingCommands;
		public float sendDelay = 0.001f; //necessary to prevent the stage kit from getting overwhelmed and dropping commands. In seconds. 0.001 is the minimum. Preliminary testing indicated that 7ms was needed to prevent dropped commands, but it seems that most songs are slow enough to allow 1ms.

        private FogState _currentFogState = FogState.Off;
        private FogState _previousFogState = FogState.Off;

        private StrobeSpeed _currentStrobeState = StrobeSpeed.Off;
		private StrobeSpeed _previousStrobeState = StrobeSpeed.Off;

        public StageKitLightingCues CurrentLightingPattern;

        // charts to listen to. Guitar and bass could be listened to as well, maybe for a future update to funky fresh mode.
        private YargChart _chart;
        private int _eventIndex;
        private string _currentEventName;
        private List<NoteInfo> _drumsChart;
        private int _drumsChartIndex;
        public List<LyricInfo> VocalsChart;
        public int vocalsChartIndex;
        private void ResultsScreenHandler(bool active)
        {
            if (active)
            {
                CurrentLightingPattern = new ScoreLighting();
            }
            else
            {
                CurrentLightingPattern?.Dispose(true);
            }
        }
		//do stuff on song start
		private void SongStartHandler(SongEntry song)
        {
            Debug.Log("Song start");
            OnEventReceive += TrackHandler;
			_eventIndex = 0;
            _drumsChartIndex = 0;
            vocalsChartIndex = 0;
			_isSongPlaying = true;
			largeVenue = Random.Range(0, 2) != 0; //This should be read from the venue track eventually but right now let's just random it
			_chart = Play.Instance.chart;
			CurrentLightingPattern?.Dispose(true);
            CurrentLightingPattern = null;
            StageKitHapticsManager.Reset();
			_drumsChart = Play.Instance.chart.GetChartByName("drums")[3];
			VocalsChart = Play.Instance.chart.realLyrics;
		}
		//do stuff on song end
		private void SongEndHandler(SongEntry song)
        {
            Debug.Log("Song end");
			_isSongPlaying = false;
			CurrentLightingPattern?.Dispose(true);
            CurrentLightingPattern = null;
            SetStrobeSpeed(StrobeSpeed.Off);
            SetFogMachine(FogState.Off);
			OnEventReceive -= TrackHandler;
        }
		//do stuff at pause menu
		private void GamePauseHandler(bool pause)
        {
			if (pause) {
				_previousFogState = _currentFogState;
				_previousStrobeState = _currentStrobeState;
				SetFogMachine(FogState.Off);
				SetStrobeSpeed(StrobeSpeed.Off);
			} else {
				SetFogMachine(_previousFogState);
				SetStrobeSpeed(_previousStrobeState);
			}
		}
		private void Start()
        {
			Instance = this;
			//The kit remembers its last state which is neat but not needed on startup
			StageKitHapticsManager.Reset();
            CurrentLightingPattern = new MenuLighting();
            Play.OnSongStart += SongStartHandler;
			Play.OnSongEnd += SongEndHandler;
			Play.OnPauseToggle += GamePauseHandler;
			PlayResultScreen.OnEnabled += ResultsScreenHandler;
            PauseMenu.OnPauseEvent += SongRestartHandler;
		}
        private void SongRestartHandler()
        {
            Debug.Log("Song restart");
            SongEntry useless = null;
            SongEndHandler(useless);
        }
        private void Update()
        {
            if (!_isSongPlaying) return;
            if (vocalsChartIndex < VocalsChart.Count - 1 && VocalsChart[vocalsChartIndex].time <= Play.Instance?.SongTime)
            {
                vocalsChartIndex++;
            }

            if ( _drumsChartIndex < _drumsChart.Count- 1 && _drumsChart[_drumsChartIndex].time <= Play.Instance?.SongTime)
            {
                OnEventReceive?.Invoke("drumFret_" + _drumsChart[_drumsChartIndex].fret);
                _drumsChartIndex++;
            }

            if ( _eventIndex < _chart.events.Count - 1 && _chart.events[_eventIndex].time <= Play.Instance?.SongTime)
            {
                _currentEventName = _chart.events[_eventIndex].name;
                if (_currentEventName.Contains("venue_") || _currentEventName.Contains("beatLine_"))
                {
                    OnEventReceive?.Invoke(_currentEventName);
                }

                _eventIndex++;
            }
        }
		private void OnApplicationQuit() {
			StageKitHapticsManager.Reset();
		}
        private void TrackHandler(string trackName) {
			if (trackName.StartsWith("venue_")) {
				HandleVenue(trackName);
			}
		}
        private void HandleVenue(string lightingEvent)
        {
		    switch (lightingEvent)
            {
                //keyframed cues
                case "venue_light_manual_warm":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new ManualWarm();
                    break;

			    case "venue_light_manual_cool":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new ManualCool();
				    break;

			    case "venue_light_dischord":
                    SetStrobeSpeed(StrobeSpeed.Off);
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Dischord();
				    break;

			    case "venue_light_stomp":
                    SetStrobeSpeed(StrobeSpeed.Off);
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Stomp();
				    break;

			    case "venue_light_default":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Default();
				    break;

                //continuous cues
                case "venue_light_loop_warm":
                    CurrentLightingPattern?.Dispose();
                    SetStrobeSpeed(StrobeSpeed.Off);
                    CurrentLightingPattern = new LoopWarm();
                    break;

                case "venue_light_loop_cool":
                    CurrentLightingPattern?.Dispose();
                    SetStrobeSpeed(StrobeSpeed.Off);
                    CurrentLightingPattern = new LoopCool();
                    break;

                case "venue_light_bre":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new BigRockEnding();
                    break;

			    case "venue_light_searchlights":
                    CurrentLightingPattern?.Dispose();
                    SetStrobeSpeed(StrobeSpeed.Off);
                    CurrentLightingPattern = new SearchLight();
				    break;

			    case "venue_light_frenzy":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Frenzy();
				    break;

                case "venue_light_sweep":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Sweep();
                    break;

                case "venue_light_harmony":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Harmony();
                    break;

                //instant cues
                case "venue_light_flare_slow":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new FlareSlow();
                    break;

			    case "venue_light_flare_fast":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new FlareFast();
				    break;

			    case "venue_light_silhouettes_spot":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new SilhouetteSpot();
				    break;

			    case "venue_light_silhouettes":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Silhouettes();
				    break;

                case "venue_light_blackout_spot":
                case "venue_light_blackout_slow":
			    case "venue_light_blackout_fast":
                    CurrentLightingPattern?.Dispose();
                    SetStrobeSpeed(StrobeSpeed.Off);
                    CurrentLightingPattern = new Blackout();
				    break;

                case "venue_light_intro":
                    CurrentLightingPattern?.Dispose();
                    CurrentLightingPattern = new Intro();
                    break;

			    //Fog machine cues
			    case "venue_fog_on":
                    SetFogMachine(FogState.On);
				    break;

			    case "venue_fog_off":
				    SetFogMachine(FogState.Off);
				    break;

			    //strobe calls
			    case "venue_light_strobe_slow":
				    SetStrobeSpeed(StrobeSpeed.Slow);
				    break;

			    case "venue_light_strobe_medium":
				    SetStrobeSpeed(StrobeSpeed.Medium);
				    break;

			    case "venue_light_strobe_fast":
				    SetStrobeSpeed(StrobeSpeed.Fast);
				    break;

			    case "venue_light_strobe_fastest":
				    SetStrobeSpeed(StrobeSpeed.Fastest);
				    break;

			    case "venue_light_strobe_off":
				    SetStrobeSpeed(StrobeSpeed.Off);
				    break;

                //Ignored cues
                case "venue_lightFrame_next":     //these are handled in cues via their primitive calls
                case "venue_lightFrame_previous": //no cue listens to this.

                //In-game lighting calls we currently ignore but might do something with in an extended "funky fresh" mode.
                case "venue_light_verse":
                case "venue_light_chorus":

                case "venue_spotlight_guitar":
                case "venue_spotlight_vocals":
                case "venue_spotlight_drums":
                case "venue_spotlight_bass":

                case "venue_postProcess_contrast_a":
                case "venue_postProcess_ProFilm_a":
                case "venue_postProcess_photocopy":
                case "venue_postProcess_video_security":
                case "venue_postProcess_video_trails":
                case "venue_postProcess_video_bw":
                case "venue_postProcess_film_16mm":
                case "venue_postProcess_bright":
                case "venue_postProcess_film_contrast_blue":
                case "venue_postProcess_film_contrast_green":
                case "venue_postProcess_film_contrast_red":
                case "venue_postProcess_desat_blue":
                case "venue_postProcess_bloom":
                case "venue_postProcess_clean_trails":

                case "venue_singalong_bassOrKeys":
                case "venue_singalong_guitarOrKeys":
                case "venue_singalong_drums":

                case "venue_bonus_fx":
                    //Currently do nothing
				    break;

			    default:
				    Debug.Log("Unhandled lighting event: " + lightingEvent);
				    break;
		    }
	    }
        //Stage kit Queue stuff
		private void EnqueueCommand(int color, byte ledByte)
        {
			CommandQueue.Enqueue((color, ledByte));
			if (isSendingCommands)
            {
                return;
            }

            SendCommands().Forget();
		}
        private async UniTask SendCommands()
		{
			isSendingCommands = true;
            var things = CurrentLightingPattern;
			while (CommandQueue.Count > 0)
			{
                var curCommand = CommandQueue.Dequeue();

				switch (curCommand.Item1)
				{
					case 0:
					case 1:
					case 2:
					case 3:
						if (currentLedState[curCommand.Item1] == _previousLedState[curCommand.Item1])
						{
							await UniTask.Yield();
						}

						var iToStageKitLedColor = curCommand.Item1 switch
						{
							0 => StageKitLedColor.Blue,
							1 => StageKitLedColor.Green,
							2 => StageKitLedColor.Yellow,
							3 => StageKitLedColor.Red,
							_ => StageKitLedColor.All
						};
						StageKitHapticsManager.SetLeds(iToStageKitLedColor, (StageKitLed)curCommand.Item2);
						_previousLedState[curCommand.Item1] = currentLedState[curCommand.Item1];
						break;
					case 4:
						StageKitHapticsManager.SetFogMachine(curCommand.Item2 == 1);
						break;
					case 5:
						StageKitHapticsManager.SetStrobeSpeed((StageKitStrobeSpeed)curCommand.Item2);
						break;
					default:
						Debug.Log("Unknown command: " + curCommand.Item1);
						break;
				}

                if (things != CurrentLightingPattern && CommandQueue.Count > 50 ) //Queue has been cleared every time the pattern changes. Really fast songs can swamp the machine in BRE or Frenzy. 50 commands * 1ms delay = 1/20th of a second aka the blink of eye.
                {
                    CommandQueue.Clear();
                    things = CurrentLightingPattern;
                }

				await UniTask.Delay(TimeSpan.FromSeconds(sendDelay));
			}

			isSendingCommands = false;
		}
        public void SetLed(int color, byte led)
        {
			currentLedState[color] = led;
			EnqueueCommand(color, currentLedState[color]);
		}
        private void SetFogMachine(FogState fogState)
        {
			if (_currentFogState == fogState)
            {
				return;
			}
			EnqueueCommand(4, (byte)fogState  );
			_currentFogState = fogState;
		}
        internal void SetStrobeSpeed(StrobeSpeed strobeSpeed)
        {
			if (_currentStrobeState == strobeSpeed)
            {
				return;
			}

			switch (strobeSpeed)
            {
				case StrobeSpeed.Off:
					EnqueueCommand(5, (byte)StageKitStrobeSpeed.Off);
					break;

				case StrobeSpeed.Slow:
					EnqueueCommand(5, (byte)StageKitStrobeSpeed.Slow);
					break;

				case StrobeSpeed.Medium:
					EnqueueCommand(5, (byte)StageKitStrobeSpeed.Medium);
					break;

				case StrobeSpeed.Fast:
					CurrentLightingPattern?.Dispose(true);
					EnqueueCommand(5, (byte)StageKitStrobeSpeed.Fast);
					break;

				case StrobeSpeed.Fastest:
					EnqueueCommand(5, (byte)StageKitStrobeSpeed.Fastest);
					break;

				default:
					Debug.LogWarning("Unknown strobe speed.");
					break;
			}
			_currentStrobeState = strobeSpeed;
		}
    }

}