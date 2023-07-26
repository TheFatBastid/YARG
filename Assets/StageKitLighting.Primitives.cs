using System;
using YARG.PlayMode;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace StageKitLighting {
	internal class BeatPattern : StageKitLighting
    {
		private readonly bool _continuous;
		private int _patternIndex;
		private readonly float _noteTiming;
		private readonly List<(int, byte)> _patternList;

		public BeatPattern(List<(int, byte)> patternList, bool continuous = true, float timesPerBeat = 1.0f) {
			Start();
			_continuous = continuous;
			_patternList = patternList;
			_noteTiming = timesPerBeat;

			UpdateCurrentEventName(CancellationTokenSource.Token).Forget();
		}
        private async UniTask UpdateCurrentEventName(CancellationToken cancellationToken){
				var stopwatch = new Stopwatch();
				stopwatch.Start();

                while (!cancellationToken.IsCancellationRequested)
				{
					stopwatch.Restart(); // Restart the stopwatch for each iteration

					var delayInSeconds = 1.0f / (Play.Instance.CurrentBeatsPerSecond * _noteTiming);

					StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, _patternList[_patternIndex].Item2);

					_patternIndex++;
					if (_patternIndex >= _patternList.Count){
						if (!_continuous) break;
						_patternIndex = 0;
					}

					stopwatch.Stop(); // Stop the stopwatch after the loop logic

					// Calculate the elapsed time in seconds
					var elapsedTime = (float)stopwatch.Elapsed.TotalSeconds;

					// Subtract the elapsed time from the delay
					var remainingDelay = delayInSeconds - elapsedTime - (StageKitLightingController.Instance.sendDelay * (StageKitLightingController.Instance.CommandQueue.Count+5) ); // I have no idea why a hardcoded +5 works here. It just does.

					if (remainingDelay > 0){
						// Delay for the remaining time
						await UniTask.Delay(TimeSpan.FromSeconds(remainingDelay), cancellationToken: cancellationToken);
					}else{
						// No delay needed, immediately proceed to the next iteration
						await UniTask.Yield(PlayerLoopTiming.Update);
					}
				}
		}
    }
	internal class ListenPattern : StageKitLighting {
		private readonly ListenTypes _listenType;
		private int _patternIndex;
		private readonly List<(int, byte)> _patternList;
		private readonly bool _flash;
		private readonly bool _inverse;
		public ListenPattern(List<(int, byte)> patternList, ListenTypes listenType, bool flash = false, bool inverse = false) {
			Start();
			_flash = flash;
			_patternList = patternList;
			_listenType = listenType;
			_inverse = inverse;

            if (!_inverse) return;
            StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, _patternList[_patternIndex].Item2);
            _patternIndex++;
            if (_patternIndex >= _patternList.Count) {
                _patternIndex = 0;
            }

        }

		protected override void HandleEvent(string eventName) {
			if (((_listenType & ListenTypes.Next) == 0 || eventName != "venue_lightFrame_next") &&
			    ((_listenType & ListenTypes.MajorBeat) == 0 || eventName != "beatLine_major") &&
			    ((_listenType & ListenTypes.MinorBeat) == 0 || eventName != "beatLine_minor") &&
			    ((_listenType & ListenTypes.RedFretDrums) == 0 || eventName != "drumFret_0") &&
			    ((_listenType & ListenTypes.YellowFretDrums) == 0 || eventName != "drumFret_1") &&
			    ((_listenType & ListenTypes.BlueFretDrums) == 0 || eventName != "drumFret_2") &&
			    ((_listenType & ListenTypes.GreenFretDrums) == 0 || eventName != "drumFret_3") &&
			    ((_listenType & ListenTypes.KickFretDrums) == 0 || eventName != "drumFret_4") &&
			    ((_listenType & ListenTypes.GreenFretBass) == 0 || eventName != "bassFret_0") &&
			    ((_listenType & ListenTypes.RedFretBass) == 0 || eventName != "bassFret_1") &&
			    ((_listenType & ListenTypes.YellowFretBass) == 0 || eventName != "bassFret_2") &&
			    ((_listenType & ListenTypes.BlueFretBass) == 0 || eventName != "bassFret_3") &&
			    ((_listenType & ListenTypes.OrangeFretBass) == 0 || eventName != "bassFret_4")
			   )
            {
                return;
            }

            StageKitLightingController.Instance.SetStrobeSpeed(StageKitLightingController.StrobeSpeed.Off);

			if (_inverse)
            {
				StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, NONE);
			}
            else
            {
				StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, _patternList[_patternIndex].Item2);
			}

			if (_flash) {
				Flasher(CancellationTokenSource.Token).Forget();
			}

			_patternIndex++;
			if (_patternIndex >= _patternList.Count) {
				_patternIndex = 0;
			}
		}

		private async UniTask Flasher(CancellationToken cancellationToken) {
			await UniTask.Delay(TimeSpan.FromSeconds(0.5f / Play.Instance.CurrentBeatsPerSecond), cancellationToken: cancellationToken);
			if (_inverse) {
				StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, _patternList[_patternIndex].Item2);
			} else {
				StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, NONE);
			}


		}
	}
    internal class TimedPattern : StageKitLighting
    {
		private readonly float _seconds;
		private int _patternIndex;
		private readonly List<(int, byte)> _patternList;
        public TimedPattern(List<(int, byte)> patternList,  float seconds)
        {
			_seconds = seconds;
			_patternList = patternList;
			Start();
            TimedCircleCoroutine(CancellationTokenSource.Token).Forget();
        }

		private async UniTask TimedCircleCoroutine(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
				StageKitLightingController.Instance.SetLed(_patternList[_patternIndex].Item1, _patternList[_patternIndex].Item2);
				await UniTask.Delay(TimeSpan.FromSeconds(_seconds / _patternList.Count));
				_patternIndex++;
				if (_patternIndex >= _patternList.Count)
                {
					_patternIndex = 0;
				}
			}
		}
	}
}