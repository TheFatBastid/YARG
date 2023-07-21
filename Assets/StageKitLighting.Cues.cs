<<<<<<< Updated upstream
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using YARG.PlayMode;

namespace StageKitLighting {

    internal class BigRockEnding : StageKitLightingCues
    {
        public BigRockEnding()
        {
            Start();
            new ManualPattern((RED, ALL));
            new ManualPattern((BLUE, ALL));
            new ManualPattern((GREEN, ALL));
            new ManualPattern((YELLOW, ALL));
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
            new BeatPattern(patternList1, true, 8.0f);
            new BeatPattern(patternList2, true, 8.0f);
            new BeatPattern(patternList3, true, 8.0f);
            new BeatPattern(patternList4, true, 8.0f);
        }

    }
    internal class LoopWarm : StageKitLightingCues
    {
        public LoopWarm()
        {
            Start();
            new ManualPattern((GREEN,NONE));
            new ManualPattern((BLUE,NONE));

            var patternList1 = new List<(int, byte)>
            {
                (RED, ZERO | FOUR),
                (RED, ONE | FIVE),
                (RED, TWO | SIX),
                (RED, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
        }

    }
    internal class LoopCool : StageKitLightingCues
    {
        public LoopCool()
        {
            Start();
            new ManualPattern((YELLOW,NONE));
            new ManualPattern((RED,NONE));
            var patternList1 = new List<(int, byte)>
            {
                (BLUE, ZERO | FOUR),
                (BLUE, ONE | FIVE),
                (BLUE, TWO | SIX),
                (BLUE, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
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
                new ManualPattern((BLUE, NONE));
                new ManualPattern((GREEN, NONE));
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

                new ManualPattern((RED, NONE));
                new ManualPattern((YELLOW, NONE));

            }
            new BeatPattern(patternList1, true, 1.0f);
            new BeatPattern(patternList2, true, 1.0f);
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

                new ManualPattern((YELLOW, NONE));
                new ManualPattern((BLUE, NONE));
                new ManualPattern((GREEN, NONE));
                new BeatPattern(patternList1);
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

                new ManualPattern((RED, NONE));
                new BeatPattern(patternList1);
                new BeatPattern(patternList2);
                new BeatPattern(patternList3, true, 2.0f);
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

                new ManualPattern((GREEN, NONE));
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
                new ManualPattern((YELLOW, NONE));
            }
            new BeatPattern(patternList1,true, 4.0f); //4 times a beats to control on and off because of the 2 different patterns on one color
			new BeatPattern(patternList2,true, 4.0f);
			new BeatPattern(patternList3,true, 4.0f);
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
                new ManualPattern((RED, NONE));
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
                new ManualPattern((BLUE, NONE));

            }
            new ManualPattern((GREEN, NONE));
            new BeatPattern(patternList1,true,4.0f);
            new BeatPattern(patternList2,true,4.0f);

		}
	}
	internal class FlareFast : StageKitLightingCues
    {
        private readonly StageKitLightingCues _thing = StageKitLightingController.Instance.CurrentLightingPattern;
		public FlareFast() {
            Start();
            new ManualPattern((YELLOW,NONE));
            new ManualPattern((RED,NONE));
            if (_thing?.ToString() ==  "StageKitLighting.ManualCool" || _thing?.ToString() ==  "StageKitLighting.LoopCool")
            {
                new ManualPattern((GREEN, ALL));
            }
            else
            {
                new ManualPattern((GREEN,NONE));
            }
            new ManualPattern((BLUE,ALL));
        }
	}
    internal class FlareSlow : StageKitLightingCues
    {
        public FlareSlow() {
            Start();
            new ManualPattern((BLUE,ALL));
            new ManualPattern((YELLOW,ALL));
            new ManualPattern((GREEN,ALL));
            new ManualPattern((RED,ALL));
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

			if (_thing?.ToString() ==  "StageKitLighting.Dischord")
            {
				new ManualPattern((RED,NONE));
				new ManualPattern((YELLOW,NONE));
				new ManualPattern((BLUE,ONE|THREE|FIVE|SEVEN));
				new ManualPattern((GREEN,ALL));
				//if first vocal note after major beat ends toggle blue on and off
				_nextVocalNoteEnd = StageKitLightingController.Instance.VocalsChart [StageKitLightingController.Instance.vocalsChartIndex].EndTime;
				Update().Forget();
			}
            else if (_thing?.ToString() ==  "StageKitLighting.Stomp")
            {
                //do nothing (for the chop suey ending at least)
			}
            else
            {
				SetAllLedsOff();
			}
		}

		protected override void HandleEvent(string eventName)
        {
            if (eventName != "beatLine_major" || _thing?.ToString() !=  "StageKitLighting.Dischord") return;
            _nextVocalNoteEnd = StageKitLightingController.Instance.VocalsChart [StageKitLightingController.Instance.vocalsChartIndex].EndTime;
            Update().Forget();
        }

		private async UniTask Update()
		{
			while (Loop)
			{
				if (Play.Instance.SongTime >= _nextVocalNoteEnd)
				{
					if (_blueOn) {
						new ManualPattern((BLUE,NONE));
						_blueOn = false;
					} else {
						new ManualPattern((BLUE,ONE|THREE|FIVE|SEVEN));
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
			new ManualPattern((GREEN,ALL));
			new ManualPattern((YELLOW,NONE));
			new ManualPattern((BLUE,NONE));
			new ManualPattern((RED,NONE));
		}
	}
	internal class Blackout : StageKitLightingCues
    {
		public Blackout()
        {
            Start() ;
            new ManualPattern((GREEN,NONE));
			new ManualPattern((YELLOW,NONE));
			new ManualPattern((BLUE,NONE));
			new ManualPattern((RED,NONE));
		}
	}
	internal class ManualWarm : StageKitLightingCues
    {
        public ManualWarm()
        {
            Start();
            new ManualPattern((GREEN,NONE));
            new ManualPattern((BLUE,NONE));

            var patternList1 = new List<(int, byte)>
            {
                (RED, ZERO | FOUR),
                (RED, ONE | FIVE),
                (RED, TWO | SIX),
                (RED, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
            new ListenPattern(new List<(int, byte)>(), StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
	internal class ManualCool : StageKitLightingCues {
        public ManualCool()
        {
            Start();
            new ManualPattern((YELLOW,NONE));
            new ManualPattern((RED,NONE));
            var patternList1 = new List<(int, byte)>
            {
                (BLUE, ZERO | FOUR),
                (BLUE, ONE | FIVE),
                (BLUE, TWO | SIX),
                (BLUE, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
            new ListenPattern(new List<(int, byte)>(), StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
	internal class Stomp : StageKitLightingCues {

		private bool _anythingOn = false;

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
				SetAllLedsOff();
            } else {
				if (StageKitLightingController.Instance.largeVenue == true) {
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
        private StageKitLightingPrimitives _greenPattern;
        private byte _patternByte;
        private readonly List<(int, byte)> _patternList2;

		public Dischord()
        {
            Start();
			new ManualPattern((RED,NONE));
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
			new ListenPattern(patternList1, StageKitLightingPrimitives.ListenTypes.MajorBeat | StageKitLightingPrimitives.ListenTypes.MinorBeat);

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
            _greenPattern = new BeatPattern(_patternList2, true, 4.0f);
            _greenIsSpinning = true;
            new ListenPattern(new List<(int, byte)> { (RED, ALL) }, StageKitLightingPrimitives.ListenTypes.RedFretDrums, true);
            new ManualPattern((BLUE, TWO | SIX));

        }

		protected override void HandleEvent(string eventName)
        {
            if (eventName == "venue_lightFrame_next")
            {
                if (_blueOnTwo)
                {
                    new BeatPattern(new List<(int, byte)>{ (BLUE, NONE), (BLUE, ZERO | TWO | FOUR | SIX) }, false);
                    _blueOnTwo = false;
                }
                else
                {
                    new BeatPattern(new List<(int, byte)>{ (BLUE, NONE), (BLUE, TWO | SIX) }, false);
                    _blueOnTwo = true;
                }
            }

            if ( StageKitLightingController.Instance.largeVenue || eventName != "beatLine_major") return;
            _greenPattern.Dispose();
            if (_greenIsSpinning)
            {
                _greenPattern = new ManualPattern((GREEN, ALL));
            }
            else
            {
                _greenPattern = new BeatPattern(_patternList2, true, 4.0f);
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
            new ManualPattern((GREEN, NONE));
            new ManualPattern((RED, NONE));
            new ManualPattern((YELLOW, NONE));
            new ManualPattern((BLUE, NONE));
            if  (StageKitLightingController.Instance.largeVenue == true)
            {
                patternList1 = new List<(int, byte)>
                {
                    (BLUE, ALL),
                    (RED, ALL),
                } ;
                new ManualPattern((YELLOW, NONE));
            }
            else
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, ALL),
                    (BLUE, ALL),
                } ;
                new ListenPattern(new List<(int, byte)>{(YELLOW, ALL)}, StageKitLightingPrimitives.ListenTypes.RedFretDrums, true,true);
            }
            new ListenPattern(patternList1, StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
    internal class MenuLighting : StageKitLightingCues {
		public MenuLighting()
        {
			Start();
            new ManualPattern((GREEN, NONE));
            new ManualPattern((RED, NONE));
            new ManualPattern((YELLOW, NONE));
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
			new TimedPattern(patternList, 2f);
		}
	}
	internal class ScoreLighting : StageKitLightingCues
    {
        public ScoreLighting()
        {
            List<(int, byte)> patternList1;
            Start();
            new ManualPattern((GREEN, NONE));
            if  (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, SIX | TWO),
                    (RED, ONE | FIVE),
                    (RED, ZERO | FOUR),
                    (RED, SEVEN | THREE),
                };
                new ManualPattern((BLUE, NONE));
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
                new ManualPattern((RED, NONE));
            }

            new TimedPattern(patternList1, 1f);

			var patternList2 = new List<(int, byte)> {
                (YELLOW, SIX | TWO),
                (YELLOW, SEVEN | THREE),
                (YELLOW, ZERO | FOUR),
                (YELLOW, ONE | FIVE),
            };
			new TimedPattern(patternList2, 2f);
		}
	}
=======
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using YARG.PlayMode;

namespace StageKitLighting {

    internal class BigRockEnding : StageKitLightingCues
    {
        public BigRockEnding()
        {
            Start();
            new ManualPattern((RED, ALL));
            new ManualPattern((BLUE, ALL));
            new ManualPattern((GREEN, ALL));
            new ManualPattern((YELLOW, ALL));
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
            new BeatPattern(patternList1, true, 8.0f);
            new BeatPattern(patternList2, true, 8.0f);
            new BeatPattern(patternList3, true, 8.0f);
            new BeatPattern(patternList4, true, 8.0f);
        }

    }
    internal class LoopWarm : StageKitLightingCues
    {
        public LoopWarm()
        {
            Start();
            new ManualPattern((GREEN,NONE));
            new ManualPattern((BLUE,NONE));

            var patternList1 = new List<(int, byte)>
            {
                (RED, ZERO | FOUR),
                (RED, ONE | FIVE),
                (RED, TWO | SIX),
                (RED, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
        }

    }
    internal class LoopCool : StageKitLightingCues
    {
        public LoopCool()
        {
            Start();
            new ManualPattern((YELLOW,NONE));
            new ManualPattern((RED,NONE));
            var patternList1 = new List<(int, byte)>
            {
                (BLUE, ZERO | FOUR),
                (BLUE, ONE | FIVE),
                (BLUE, TWO | SIX),
                (BLUE, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
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
                new ManualPattern((BLUE, NONE));
                new ManualPattern((GREEN, NONE));
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

                new ManualPattern((RED, NONE));
                new ManualPattern((YELLOW, NONE));

            }
            new BeatPattern(patternList1, true, 1.0f);
            new BeatPattern(patternList2, true, 1.0f);
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

                new ManualPattern((YELLOW, NONE));
                new ManualPattern((BLUE, NONE));
                new ManualPattern((GREEN, NONE));
                new BeatPattern(patternList1);
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

                new ManualPattern((RED, NONE));
                new BeatPattern(patternList1);
                new BeatPattern(patternList2);
                new BeatPattern(patternList3, true, 2.0f);
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

                new ManualPattern((GREEN, NONE));
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
                new ManualPattern((YELLOW, NONE));
            }
            new BeatPattern(patternList1,true, 4.0f); //4 times a beats to control on and off because of the 2 different patterns on one color
			new BeatPattern(patternList2,true, 4.0f);
			new BeatPattern(patternList3,true, 4.0f);
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
                new ManualPattern((RED, NONE));
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
                new ManualPattern((BLUE, NONE));

            }
            new ManualPattern((GREEN, NONE));
            new BeatPattern(patternList1,true,4.0f);
            new BeatPattern(patternList2,true,4.0f);

		}
	}
	internal class FlareFast : StageKitLightingCues
    {
        private readonly StageKitLightingCues _thing = StageKitLightingController.Instance.CurrentLightingPattern;
		public FlareFast() {
            Start();
            new ManualPattern((YELLOW,NONE));
            new ManualPattern((RED,NONE));
            if (_thing?.ToString() ==  "StageKitLighting.ManualCool" || _thing?.ToString() ==  "StageKitLighting.LoopCool")
            {
                new ManualPattern((GREEN, ALL));
            }
            else
            {
                new ManualPattern((GREEN,NONE));
            }
            new ManualPattern((BLUE,ALL));
        }
	}
    internal class FlareSlow : StageKitLightingCues
    {
        public FlareSlow() {
            Start();
            new ManualPattern((BLUE,ALL));
            new ManualPattern((YELLOW,ALL));
            new ManualPattern((GREEN,ALL));
            new ManualPattern((RED,ALL));
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

			if (_thing?.ToString() ==  "StageKitLighting.Dischord")
            {
				new ManualPattern((RED,NONE));
				new ManualPattern((YELLOW,NONE));
				new ManualPattern((BLUE,ONE|THREE|FIVE|SEVEN));
				new ManualPattern((GREEN,ALL));
				//if first vocal note after major beat ends toggle blue on and off
				_nextVocalNoteEnd = StageKitLightingController.Instance.VocalsChart [StageKitLightingController.Instance.vocalsChartIndex].EndTime;
				Update().Forget();
			}
            else if (_thing?.ToString() ==  "StageKitLighting.Stomp")
            {
                //do nothing (for the chop suey ending at least)
			}
            else
            {
				SetAllLedsOff();
			}
		}

		protected override void HandleEvent(string eventName)
        {
            if (eventName != "beatLine_major" || _thing?.ToString() !=  "StageKitLighting.Dischord") return;
            _nextVocalNoteEnd = StageKitLightingController.Instance.VocalsChart [StageKitLightingController.Instance.vocalsChartIndex].EndTime;
            Update().Forget();
        }

		private async UniTask Update()
		{
			while (Loop)
			{
				if (Play.Instance.SongTime >= _nextVocalNoteEnd)
				{
					if (_blueOn) {
						new ManualPattern((BLUE,NONE));
						_blueOn = false;
					} else {
						new ManualPattern((BLUE,ONE|THREE|FIVE|SEVEN));
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
			new ManualPattern((GREEN,ALL));
			new ManualPattern((YELLOW,NONE));
			new ManualPattern((BLUE,NONE));
			new ManualPattern((RED,NONE));
		}
	}
	internal class Blackout : StageKitLightingCues
    {
		public Blackout()
        {
            Start() ;
            new ManualPattern((GREEN,NONE));
			new ManualPattern((YELLOW,NONE));
			new ManualPattern((BLUE,NONE));
			new ManualPattern((RED,NONE));
		}
	}
	internal class ManualWarm : StageKitLightingCues
    {
        public ManualWarm()
        {
            Start();
            new ManualPattern((GREEN,NONE));
            new ManualPattern((BLUE,NONE));

            var patternList1 = new List<(int, byte)>
            {
                (RED, ZERO | FOUR),
                (RED, ONE | FIVE),
                (RED, TWO | SIX),
                (RED, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
            //new ListenPattern(new List<(int, byte)>(), StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
	internal class ManualCool : StageKitLightingCues {
        public ManualCool()
        {
            Start();
            new ManualPattern((YELLOW,NONE));
            new ManualPattern((RED,NONE));
            var patternList1 = new List<(int, byte)>
            {
                (BLUE, ZERO | FOUR),
                (BLUE, ONE | FIVE),
                (BLUE, TWO | SIX),
                (BLUE, THREE | SEVEN),
            };
            new BeatPattern(patternList1);

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

            new BeatPattern(patternList2);
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
				SetAllLedsOff();
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
        private StageKitLightingPrimitives _greenPattern;
        private byte _patternByte;
        private readonly List<(int, byte)> _patternList2;

		public Dischord()
        {
            Start();
			new ManualPattern((RED,NONE));
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
			new ListenPattern(patternList1, StageKitLightingPrimitives.ListenTypes.MajorBeat | StageKitLightingPrimitives.ListenTypes.MinorBeat);

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
            _greenPattern = new BeatPattern(_patternList2, true, 4.0f);
            _greenIsSpinning = true;
            new ListenPattern(new List<(int, byte)> { (RED, ALL) }, StageKitLightingPrimitives.ListenTypes.RedFretDrums, true);
            new ManualPattern((BLUE, TWO | SIX));

        }

		protected override void HandleEvent(string eventName)
        {
            if (eventName == "venue_lightFrame_next")
            {
                if (_blueOnTwo)
                {
                    new BeatPattern(new List<(int, byte)>{ (BLUE, NONE), (BLUE, ZERO | TWO | FOUR | SIX) }, false);
                    _blueOnTwo = false;
                }
                else
                {
                    new BeatPattern(new List<(int, byte)>{ (BLUE, NONE), (BLUE, TWO | SIX) }, false);
                    _blueOnTwo = true;
                }
            }

            if ( StageKitLightingController.Instance.largeVenue || eventName != "beatLine_major") return;
            _greenPattern.Dispose();
            if (_greenIsSpinning)
            {
                _greenPattern = new ManualPattern((GREEN, ALL));
            }
            else
            {
                _greenPattern = new BeatPattern(_patternList2, true, 4.0f);
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
            new ManualPattern((GREEN, NONE));
            new ManualPattern((RED, NONE));
            new ManualPattern((YELLOW, NONE));
            new ManualPattern((BLUE, NONE));
            if  (StageKitLightingController.Instance.largeVenue == true)
            {
                patternList1 = new List<(int, byte)>
                {
                    (BLUE, ALL),
                    (RED, ALL),
                } ;
                new ManualPattern((YELLOW, NONE));
            }
            else
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, ALL),
                    (BLUE, ALL),
                } ;
                new ListenPattern(new List<(int, byte)>{(YELLOW, ALL)}, StageKitLightingPrimitives.ListenTypes.RedFretDrums, true,true);
            }
            new ListenPattern(patternList1, StageKitLightingPrimitives.ListenTypes.Next);
        }
	}
    internal class MenuLighting : StageKitLightingCues {
		public MenuLighting()
        {
			Start();
            new ManualPattern((GREEN, NONE));
            new ManualPattern((RED, NONE));
            new ManualPattern((YELLOW, NONE));
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
			new TimedPattern(patternList, 2f);
		}
	}
	internal class ScoreLighting : StageKitLightingCues
    {
        public ScoreLighting()
        {
            List<(int, byte)> patternList1;
            Start();
            new ManualPattern((GREEN, NONE));
            if  (StageKitLightingController.Instance.largeVenue)
            {
                patternList1 = new List<(int, byte)>
                {
                    (RED, SIX | TWO),
                    (RED, ONE | FIVE),
                    (RED, ZERO | FOUR),
                    (RED, SEVEN | THREE),
                };
                new ManualPattern((BLUE, NONE));
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
                new ManualPattern((RED, NONE));
            }

            new TimedPattern(patternList1, 1f);

			var patternList2 = new List<(int, byte)> {
                (YELLOW, SIX | TWO),
                (YELLOW, SEVEN | THREE),
                (YELLOW, ZERO | FOUR),
                (YELLOW, ONE | FIVE),
            };
			new TimedPattern(patternList2, 2f);
		}
	}
>>>>>>> Stashed changes
}