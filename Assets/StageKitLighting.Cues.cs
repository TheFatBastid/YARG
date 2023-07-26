using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YARG.PlayMode;

namespace StageKitLighting {
    internal class BigRockEnding : StageKitLightingCues
    {
        public BigRockEnding()
        {
            Start();
            StageKitLightingController.Instance.SetLed(RED, ALL);
            StageKitLightingController.Instance.SetLed(BLUE, ALL);
            StageKitLightingController.Instance.SetLed(GREEN, ALL);
            StageKitLightingController.Instance.SetLed(YELLOW, ALL);
            var patternList1 = new List<(int, byte)>
            {
                (RED, ALL),
                (RED, NONE),
                (RED, NONE),
                (RED, NONE),
            };
            var patternList2 = new List<(int, byte)>
            {
                (YELLOW, NONE),
                (YELLOW, NONE),
                (YELLOW, ALL),
                (YELLOW, NONE),
            };
            var patternList3 = new List<(int, byte)>
            {
                (GREEN, NONE),
                (GREEN, ALL),
                (GREEN, NONE),
                (GREEN, NONE),
            };
            var patternList4 = new List<(int, byte)>
            {
                (BLUE, NONE),
                (BLUE, NONE),
                (BLUE, NONE),
                (BLUE, ALL),
            };
            CuePrimitives[0] = new BeatPattern(patternList1, true, 8.0f);
            CuePrimitives[1] = new BeatPattern(patternList2, true, 8.0f);
            CuePrimitives[2] = new BeatPattern(patternList3, true, 8.0f);
            CuePrimitives[3] = new BeatPattern(patternList4, true, 8.0f);
        }

    }
    internal class LoopWarm : StageKitLightingCues
    {
        public LoopWarm()
        {
            Start();
            StageKitLightingController.Instance.SetLed(GREEN,NONE);
            StageKitLightingController.Instance.SetLed(BLUE,NONE);

            var patternList1 = new List<(int, byte)>
            {
                (RED, ZERO | FOUR),
                (RED, ONE | FIVE),
                (RED, TWO | SIX),
                (RED, THREE | SEVEN),
            };
            CuePrimitives[0] = new BeatPattern(patternList1);

            var patternList2 = new List<(int, byte)>
            {
                (YELLOW, TWO),
                (YELLOW, ONE),
                (YELLOW, ZERO),
                (YELLOW, SEVEN),
                (YELLOW, SIX),
                (YELLOW, FIVE),
                (YELLOW, FOUR),
                (YELLOW, THREE),
            };
            CuePrimitives[1] = new BeatPattern(patternList2);
        }
    }
    internal class LoopCool : StageKitLightingCues
    {
        public LoopCool()
        {
            Start();
            StageKitLightingController.Instance.SetLed(YELLOW,NONE);
            StageKitLightingController.Instance.SetLed(RED,NONE);
            var patternList1 = new List<(int, byte)>
            {
                (BLUE, ZERO | FOUR),
                (BLUE, ONE | FIVE),
                (BLUE, TWO | SIX),
                (BLUE, THREE | SEVEN),
            };
            CuePrimitives[0] = new BeatPattern(patternList1);

            var patternList2 = new List<(int, byte)>
            {
                (GREEN, TWO),
                (GREEN, ONE),
                (GREEN, ZERO),
                (GREEN, SEVEN),
                (GREEN, SIX),
                (GREEN, FIVE),
                (GREEN, FOUR),
                (GREEN, THREE),
            };
            CuePrimitives[1] = new BeatPattern(patternList2);
        }
    }
    internal class Harmony : StageKitLightingCues
    {
        public Harmony()
        {
            List<(int, byte)> patternList2;
            List<(int, byte)> patternList1;
            Start();
            if (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (YELLOW, THREE),
                    (YELLOW, TWO),
                    (YELLOW, ONE),
                    (YELLOW, ZERO),
                    (YELLOW, SEVEN),
                    (YELLOW, SIX),
                    (YELLOW, FIVE),
                    (YELLOW, FOUR),
                };

                patternList2 = new List<(int, byte)>
                {
                    (RED, FOUR),
                    (RED, THREE),
                    (RED, TWO),
                    (RED, ONE),
                    (RED, ZERO),
                    (RED, SEVEN),
                    (RED, SIX),
                    (RED, FIVE),
                };
                StageKitLightingController.Instance.SetLed(BLUE, NONE);
                StageKitLightingController.Instance.SetLed(GREEN, NONE);
            }
            else
            {
                patternList1 = new List<(int, byte)>
                {
                    (GREEN, FOUR),
                    (GREEN, FIVE),
                    (GREEN, SIX),
                    (GREEN, SEVEN),
                    (GREEN, ZERO),
                    (GREEN, ONE),
                    (GREEN, TWO),
                    (GREEN, THREE),
                };

                patternList2 = new List<(int, byte)>
                {
                    (BLUE, FOUR),
                    (BLUE, FIVE),
                    (BLUE, SIX),
                    (BLUE, SEVEN),
                    (BLUE, ZERO),
                    (BLUE, ONE),
                    (BLUE, TWO),
                    (BLUE, THREE),
                };

                StageKitLightingController.Instance.SetLed(RED, NONE);
                StageKitLightingController.Instance.SetLed(YELLOW, NONE);

            }
            CuePrimitives[0] = new BeatPattern(patternList1);
            CuePrimitives[1] = new BeatPattern(patternList2);
        }
    }
    internal class Sweep : StageKitLightingCues
    {
        public Sweep()
        {
            List<(int, byte)> patternList1;
            Start();
            if  (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, SIX | TWO), (RED, FIVE | ONE), (RED, FOUR | ZERO), (RED, THREE | SEVEN),
                };

                StageKitLightingController.Instance.SetLed(YELLOW, NONE);
                StageKitLightingController.Instance.SetLed(BLUE, NONE);
                StageKitLightingController.Instance.SetLed(GREEN, NONE);
                CuePrimitives[0] = new BeatPattern(patternList1);
            }
            else
            {

                patternList1 = new List<(int, byte)>
                {
                    (YELLOW, SIX | TWO), (YELLOW, FIVE | ONE), (YELLOW, FOUR | ZERO), (YELLOW, THREE | SEVEN),
                };

                var patternList2 = new List<(int, byte)>
                {
                    (BLUE, ZERO),
                    (BLUE, ONE),
                    (BLUE, TWO),
                    (BLUE, THREE),
                    (BLUE, FOUR),
                    (BLUE, NONE),
                    (BLUE, NONE),
                };

                var patternList3 = new List<(int, byte)>
                {
                    (GREEN, NONE),
                    (GREEN, NONE),
                    (GREEN, NONE),
                    (GREEN, NONE),
                    (GREEN, FOUR),
                    (GREEN, THREE),
                    (GREEN, TWO),
                    (GREEN, ONE),
                    (GREEN, ZERO),
                };

                StageKitLightingController.Instance.SetLed(RED, NONE);
                CuePrimitives[0] = new BeatPattern(patternList1);
                CuePrimitives[1] = new BeatPattern(patternList2);
                CuePrimitives[2] = new BeatPattern(patternList3, true, 2.0f);
            }
        }
    }
	internal class Frenzy : StageKitLightingCues
    {
        public Frenzy() {
            List<(int, byte)> patternList3;
            List<(int, byte)> patternList2;
            List<(int, byte)> patternList1;
            Start();
            if  (StageKitLightingController.Instance.largeVenue)//red off blue yellow
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, ALL), (RED, NONE), (RED, NONE), (RED, NONE),
                };

                patternList2 = new List<(int, byte)>
                {
                    (BLUE, NONE), (BLUE, NONE), (BLUE, ALL), (BLUE, NONE),
                };

                patternList3 = new List<(int, byte)>
                {
                    (YELLOW, NONE), (YELLOW, NONE), (YELLOW, NONE), (YELLOW, ALL),
                };

                StageKitLightingController.Instance.SetLed(GREEN, NONE);
            }
            else
            {
                //Small venue: half red, other half red, 4 green , 2 side blue, other 6 blue

                patternList1 = new List<(int, byte)> {
                    (RED, NONE),
                    (RED,ALL),
                    (RED, ZERO | TWO | FOUR | SIX),
                    (RED, ONE| THREE | FIVE | SEVEN),
                };

                patternList2 = new List<(int, byte)> {
                    (GREEN, NONE),
                    (GREEN, NONE),
                    (GREEN, ONE| THREE | FIVE | SEVEN),
                    (GREEN, NONE),
                };

                patternList3 = new List<(int, byte)> {
                    (BLUE, ALL),
                    (BLUE, NONE),
                    (BLUE, NONE),
                    (BLUE, SIX |  TWO),
                };
                StageKitLightingController.Instance.SetLed(YELLOW, NONE);
            }
            CuePrimitives[0] = new BeatPattern(patternList1,true, 4.0f); //4 times a beats to control on and off because of the 2 different patterns on one color
            CuePrimitives[1] = new BeatPattern(patternList2,true, 4.0f);
            CuePrimitives[2] = new BeatPattern(patternList3,true, 4.0f);
        }
	}
	internal class SearchLight : StageKitLightingCues
    {
        private byte _secondLed;
        private int _secondColor;

        public SearchLight() {
            List<(int, byte)> patternList2;
            List<(int, byte)> patternList1;
            Start();
            //1 yellow@2 clockwise and 1 blue@0 counter clock.
            if  (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (YELLOW, TWO),
                    (YELLOW, THREE),
                    (YELLOW, FOUR),
                    (YELLOW, FIVE),
                    (YELLOW, SIX),
                    (YELLOW, SEVEN),
                    (YELLOW, ZERO),
                    (YELLOW, ONE),

                };
                patternList2 = new List<(int, byte)>
                {
                    (BLUE, ZERO),
                    (BLUE, SEVEN),
                    (BLUE, SIX),
                    (BLUE, FIVE),
                    (BLUE, FOUR),
                    (BLUE, THREE),
                    (BLUE, TWO),
                    (BLUE, ONE),
                };
                StageKitLightingController.Instance.SetLed(RED, NONE);
            }
            else
            {
                patternList1 = new List<(int, byte)> {
                    (YELLOW, ZERO),
                    (YELLOW, SEVEN),
                    (YELLOW, SIX),
                    (YELLOW, FIVE),
                    (YELLOW, FOUR),
                    (YELLOW, THREE),
                    (YELLOW, TWO),
                    (YELLOW, ONE),
                };

                patternList2 = new List<(int, byte)> {
                    (RED, ZERO),
                    (RED, SEVEN),
                    (RED, SIX),
                    (RED, FIVE),
                    (RED, FOUR),
                    (RED, THREE),
                    (RED, TWO),
                    (RED, ONE),
                };
                StageKitLightingController.Instance.SetLed(BLUE, NONE);

            }
            StageKitLightingController.Instance.SetLed(GREEN, NONE);
            CuePrimitives[0] = new BeatPattern(patternList1,true,4.0f);
            CuePrimitives[1] = new BeatPattern(patternList2,true,4.0f);

		}
	}
    internal class Intro : StageKitLightingCues
    {
        public Intro()
        {
            Debug.Log("shitbags");
            Start();
            StageKitLightingController.Instance.SetLed(YELLOW, NONE);
            StageKitLightingController.Instance.SetLed(RED, NONE);
            StageKitLightingController.Instance.SetLed(BLUE, NONE);
            StageKitLightingController.Instance.SetLed(GREEN, ALL);
        }
    }
	internal class FlareFast : StageKitLightingCues
    {
        private readonly StageKitLightingCues _thing = StageKitLightingController.Instance.CurrentLightingPattern;
		public FlareFast() {
            Start();
            StageKitLightingController.Instance.SetLed(YELLOW,NONE);
            StageKitLightingController.Instance.SetLed(RED,NONE);
            if (_thing?.ToString() ==  "StageKitLighting.ManualCool" || _thing?.ToString() ==  "StageKitLighting.LoopCool")
            {
                StageKitLightingController.Instance.SetLed(GREEN, ALL);
            }
            else
            {
                StageKitLightingController.Instance.SetLed(GREEN,NONE);
            }
            StageKitLightingController.Instance.SetLed(BLUE,ALL);
        }
	}
    internal class FlareSlow : StageKitLightingCues
    {
        public FlareSlow() {
            Start();
            StageKitLightingController.Instance.SetLed(BLUE,ALL);
            StageKitLightingController.Instance.SetLed(YELLOW,ALL);
            StageKitLightingController.Instance.SetLed(GREEN,ALL);
            StageKitLightingController.Instance.SetLed(RED,ALL);
        }
    }
	internal class SilhouetteSpot : StageKitLightingCues
    {
		private float _nextVocalNoteEnd = Play.Instance.SongLength;
		private bool _blueOn = true;
        private readonly StageKitLightingCues _thing = StageKitLightingController.Instance.CurrentLightingPattern;
		public SilhouetteSpot()
        {
			Start();
            Debug.Log(_thing);
            if (_thing?.ToString() ==  "StageKitLighting.Dischord")
            {
				StageKitLightingController.Instance.SetLed(RED,NONE);
				StageKitLightingController.Instance.SetLed(YELLOW,NONE);
				StageKitLightingController.Instance.SetLed(BLUE,ONE|THREE|FIVE|SEVEN);
				StageKitLightingController.Instance.SetLed(GREEN,ALL);
				//if first vocal note after major beat ends toggle blue on and off
				_nextVocalNoteEnd = StageKitLightingController.Instance.VocalsChart [StageKitLightingController.Instance.vocalsChartIndex].EndTime;
                Update(CancellationTokenSource.Token).Forget();
			}
            else if (_thing?.ToString() ==  "StageKitLighting.Stomp")
            {
                //do nothing (for the chop suey ending at least)
			}
            else if (_thing?.ToString() == "StageKitLighting.Intro")
            {
                CuePrimitives[0] = new ListenPattern(new List<(int, byte)>{(BLUE, ALL)}, ListenTypes.RedFretDrums,true);
            }
            else
            {
                StageKitLightingController.Instance.SetLed(RED, NONE);
                StageKitLightingController.Instance.SetLed(GREEN, NONE);
                StageKitLightingController.Instance.SetLed(BLUE, NONE);
                StageKitLightingController.Instance.SetLed(YELLOW, NONE);
			}
		}

		protected override void HandleEvent(string eventName)
        {
            if (eventName != "beatLine_major" || _thing?.ToString() !=  "StageKitLighting.Dischord") return;
            _nextVocalNoteEnd = StageKitLightingController.Instance.VocalsChart [StageKitLightingController.Instance.vocalsChartIndex].EndTime;
            Update(CancellationTokenSource.Token).Forget();
        }

		private async UniTask Update(CancellationToken cancellationToken)
		{
            while (!cancellationToken.IsCancellationRequested)
            {
				if (Play.Instance.SongTime >= _nextVocalNoteEnd)
				{
					if (_blueOn) {
						StageKitLightingController.Instance.SetLed(BLUE,NONE);
						_blueOn = false;
					} else {
						StageKitLightingController.Instance.SetLed(BLUE,ONE|THREE|FIVE|SEVEN);
						_blueOn = true;
					}
					_nextVocalNoteEnd = Play.Instance.SongLength;
					break;
				}
                await UniTask.Yield();
			}
		}
	}
	internal class Silhouettes: StageKitLightingCues
    {
		public Silhouettes()
        {
            Start();
			StageKitLightingController.Instance.SetLed(GREEN,ALL);
			StageKitLightingController.Instance.SetLed(YELLOW,NONE);
			StageKitLightingController.Instance.SetLed(BLUE,NONE);
			StageKitLightingController.Instance.SetLed(RED,NONE);
		}
	}
	internal class Blackout : StageKitLightingCues
    {
		public Blackout()
        {
            Start() ;
            StageKitLightingController.Instance.SetLed(GREEN,NONE);
			StageKitLightingController.Instance.SetLed(YELLOW,NONE);
			StageKitLightingController.Instance.SetLed(BLUE,NONE);
			StageKitLightingController.Instance.SetLed(RED,NONE);
		}
	}
	internal class ManualWarm : StageKitLightingCues
    {
        public ManualWarm()
        {
            Start();
            StageKitLightingController.Instance.SetLed(GREEN,NONE);
            StageKitLightingController.Instance.SetLed(BLUE,NONE);

            var patternList1 = new List<(int, byte)>
            {
                (RED, ZERO | FOUR),
                (RED, ONE | FIVE),
                (RED, TWO | SIX),
                (RED, THREE | SEVEN),
            };
            CuePrimitives[0] = new BeatPattern(patternList1);

            var patternList2 = new List<(int, byte)>
            {
                (YELLOW, TWO),
                (YELLOW, ONE),
                (YELLOW, ZERO),
                (YELLOW, SEVEN),
                (YELLOW, SIX),
                (YELLOW, FIVE),
                (YELLOW, FOUR),
                (YELLOW, THREE),
            };

            CuePrimitives[1] = new BeatPattern(patternList2);
            // I thought it listens to the next but it doesn't seem to. I'll save this for funky fresh mode
            //new ListenPattern(new List<(int, byte)>(), StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
	internal class ManualCool : StageKitLightingCues {
        public ManualCool()
        {
            Start();
            StageKitLightingController.Instance.SetLed(YELLOW,NONE);
            StageKitLightingController.Instance.SetLed(RED,NONE);
            var patternList1 = new List<(int, byte)>
            {
                (BLUE, ZERO | FOUR),
                (BLUE, ONE | FIVE),
                (BLUE, TWO | SIX),
                (BLUE, THREE | SEVEN),
            };
            CuePrimitives[0] = new BeatPattern(patternList1);

            var patternList2 = new List<(int, byte)>
            {
                (GREEN, TWO),
                (GREEN, ONE),
                (GREEN, ZERO),
                (GREEN, SEVEN),
                (GREEN, SIX),
                (GREEN, FIVE),
                (GREEN, FOUR),
                (GREEN, THREE),
            };

            CuePrimitives[1] = new BeatPattern(patternList2);
            //new ListenPattern(new List<(int, byte)>(), StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
	internal class Stomp : StageKitLightingCues {

		private bool _anythingOn;

		public Stomp()
        {
			Start();
            if  (StageKitLightingController.Instance.largeVenue)
            {
                StageKitLightingController.Instance.SetLed(BLUE, ALL);
            }
            else
            {
                StageKitLightingController.Instance.SetLed(BLUE, NONE);
            }
            StageKitLightingController.Instance.SetLed(RED, ALL);
            StageKitLightingController.Instance.SetLed(GREEN, ALL);
            StageKitLightingController.Instance.SetLed(YELLOW, ALL);

            _anythingOn = true;
		}

		protected override void HandleEvent(string eventName) {
			if (eventName != "venue_lightFrame_next") return;
			if (_anythingOn) {
                StageKitLightingController.Instance.SetLed(RED, NONE);
                StageKitLightingController.Instance.SetLed(GREEN, NONE);
                StageKitLightingController.Instance.SetLed(BLUE, NONE);
                StageKitLightingController.Instance.SetLed(YELLOW, NONE);
            } else {
				if (StageKitLightingController.Instance.largeVenue) {
                    StageKitLightingController.Instance.SetLed(BLUE, ALL);
				} else {
                    StageKitLightingController.Instance.SetLed(BLUE, NONE);
				}
                StageKitLightingController.Instance.SetLed(RED, ALL);
                StageKitLightingController.Instance.SetLed(GREEN, ALL);
                StageKitLightingController.Instance.SetLed(YELLOW, ALL);
			}
			_anythingOn = !_anythingOn;
		}
	}
	internal class Dischord : StageKitLightingCues
    {
		private float _nextVocalNoteEnd;
		private float _currentPitch;
        private bool _greenIsSpinning;
        private bool _blueOnTwo = true;
        private StageKitLighting _greenPattern;
        private byte _patternByte;
        private readonly List<(int, byte)> _patternList2;

		public Dischord()
        {
            Start();
			StageKitLightingController.Instance.SetLed(RED,NONE);
			var patternList1 = new List<(int, byte)>
            {
                (YELLOW, ZERO),
                (YELLOW, ONE),
                (YELLOW, TWO),
                (YELLOW, THREE),
                (YELLOW, FOUR),
                (YELLOW, FIVE),
                (YELLOW, SIX),
                (YELLOW, SEVEN),
            };
            CuePrimitives[0] = new ListenPattern(patternList1, ListenTypes.MajorBeat | ListenTypes.MinorBeat);

            _patternList2 = new List<(int, byte)>
            {
				(GREEN, ZERO),
				(GREEN, SEVEN),
				(GREEN, SIX),
				(GREEN, FIVE),
				(GREEN, FOUR),
				(GREEN, THREE),
				(GREEN, TWO),
				(GREEN, ONE),
			};
            CuePrimitives[1] = new BeatPattern(_patternList2, true, 4.0f);
            _greenIsSpinning = true;
            CuePrimitives[2] = new ListenPattern(new List<(int, byte)> { (RED, ALL) }, ListenTypes.RedFretDrums, true);
            StageKitLightingController.Instance.SetLed(BLUE, TWO | SIX);

        }

		protected override void HandleEvent(string eventName)
        {
            if (eventName == "venue_lightFrame_next")
            {
                if (_blueOnTwo)
                {
                    CuePrimitives[3] = new BeatPattern(new List<(int, byte)>{ (BLUE, NONE), (BLUE, ZERO | TWO | FOUR | SIX) }, false);
                    _blueOnTwo = false;
                }
                else
                {
                    CuePrimitives[3] = new BeatPattern(new List<(int, byte)>{ (BLUE, NONE), (BLUE, TWO | SIX) }, false);
                    _blueOnTwo = true;
                }
            }

            if ( StageKitLightingController.Instance.largeVenue || eventName != "beatLine_major") return;
            _greenPattern.Dispose();
            if (_greenIsSpinning)
            {
                CuePrimitives[1] = null;
                StageKitLightingController.Instance.SetLed(GREEN, ALL);
            }
            else
            {
                CuePrimitives[1] = new BeatPattern(_patternList2, true, 4.0f);
            }
            _greenIsSpinning = !_greenIsSpinning;
        }
    }
	internal class Default : StageKitLightingCues
    {
        public Default()
        {
            List<(int, byte)> patternList1;
            Start();
            StageKitLightingController.Instance.SetLed(GREEN, NONE);
            StageKitLightingController.Instance.SetLed(RED, NONE);
            StageKitLightingController.Instance.SetLed(YELLOW, NONE);
            StageKitLightingController.Instance.SetLed(BLUE, NONE);
            if  (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (BLUE, ALL),
                    (RED, ALL),
                } ;
                StageKitLightingController.Instance.SetLed(YELLOW, NONE);
            }
            else
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, ALL),
                    (BLUE, ALL),
                } ;
                CuePrimitives[0] = new ListenPattern(new List<(int, byte)>{(YELLOW, ALL)}, ListenTypes.RedFretDrums, true,true);
            }
            CuePrimitives[1] = new ListenPattern(patternList1, ListenTypes.Next);
        }
	}
    internal class MenuLighting : StageKitLightingCues {
		public MenuLighting()
        {
			Start();
            StageKitLightingController.Instance.SetLed(GREEN, NONE);
            StageKitLightingController.Instance.SetLed(RED, NONE);
            StageKitLightingController.Instance.SetLed(YELLOW, NONE);
			var patternList = new List<(int, byte)>
            {
				(BLUE, ZERO),
				(BLUE, ONE),
				(BLUE, TWO),
				(BLUE, THREE),
				(BLUE, FOUR),
				(BLUE, FIVE),
				(BLUE, SIX),
				(BLUE, SEVEN),
			} ;
            CuePrimitives[0] = new TimedPattern(patternList, 2f);
		}
	}
	internal class ScoreLighting : StageKitLightingCues
    {
        public ScoreLighting()
        {
            List<(int, byte)> patternList1;
            Start();
            StageKitLightingController.Instance.SetLed(GREEN, NONE);
            if  (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, SIX | TWO),
                    (RED, ONE | FIVE),
                    (RED, ZERO | FOUR),
                    (RED, SEVEN | THREE),
                };
                StageKitLightingController.Instance.SetLed(BLUE, NONE);
            }
            else
            {

                patternList1 = new List<(int, byte)>
                {
                    (BLUE, ZERO),
                    (BLUE, SEVEN),
                    (BLUE, SIX),
                    (BLUE, FIVE),
                    (BLUE, FOUR),
                    (BLUE, THREE),
                    (BLUE, TWO),
                    (BLUE, ONE),
                };
                StageKitLightingController.Instance.SetLed(RED, NONE);
            }

            CuePrimitives[0] = new TimedPattern(patternList1, 1f);

			var patternList2 = new List<(int, byte)> {
                (YELLOW, SIX | TWO),
                (YELLOW, SEVEN | THREE),
                (YELLOW, ZERO | FOUR),
                (YELLOW, ONE | FIVE),
            };
            CuePrimitives[1] = new TimedPattern(patternList2, 2f);
		}
	}
}