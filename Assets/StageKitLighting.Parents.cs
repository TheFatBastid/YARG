<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using System.Threading;

namespace StageKitLighting{

	public abstract class StageKitLighting {
		protected const byte NONE  = 0b00000000;
		protected const byte ZERO  = 0b00000001;
		protected const byte ONE   = 0b00000010;
		protected const byte TWO   = 0b00000100;
		protected const byte THREE = 0b00001000;
		protected const byte FOUR  = 0b00010000;
		protected const byte FIVE  = 0b00100000;
		protected const byte SIX   = 0b01000000;
		protected const byte SEVEN = 0b10000000;
		protected const byte ALL   = 0b11111111;

		protected bool Loop = true;

        protected CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

		protected virtual void HandleEvent(string eventName) {

		}


	}
	public abstract class StageKitLightingCues : StageKitLighting{
	    //This is the base class for all lighting patterns
	    protected const int BLUE = 0;
	    protected const int GREEN = 1;
	    protected const int YELLOW = 2;
	    protected const int RED = 3;

	    public List<StageKitLightingPrimitives> LightingPrimitives = new List<StageKitLightingPrimitives>();
	    protected void Start() {
		    StageKitLightingController.Instance.OnEventReceive += HandleEvent;
		    StageKitLightingController.Instance.CurrentLightingPattern?.Dispose();
            StageKitLightingController.Instance.CurrentLightingPattern = this;
		    CancellationTokenSource = new CancellationTokenSource();
	    }

	    public void Dispose(bool turnOffLeds = false) {
		    CancellationTokenSource?.Cancel();
		    Loop = false;
		    foreach (var primitive in LightingPrimitives) {
			    primitive.Dispose();
		    }

		    StageKitLightingController.Instance.CurrentLightingPattern = null;
		    StageKitLightingController.Instance.OnEventReceive -= HandleEvent;
		    if (turnOffLeds) {
			    SetAllLedsOff();
		    }
	    }

	    internal static void SetAllLedsOff() {
		    //set all LEDS off
		    StageKitLightingController.Instance.SetLed(RED, NONE);
		    StageKitLightingController.Instance.SetLed(GREEN, NONE);
		    StageKitLightingController.Instance.SetLed(BLUE, NONE);
		    StageKitLightingController.Instance.SetLed(YELLOW, NONE);
	    }
	}
	public abstract class StageKitLightingPrimitives : StageKitLighting{
	    //This is the base class for all lighting primitives

	    [Flags]
	    public enum ListenTypes {
		    None = 0,
		    Next = 1,
		    MajorBeat = 2,
		    MinorBeat = 4,
		    RedFretDrums = 8,
		    YellowFretDrums = 16,
		    BlueFretDrums = 32,
		    GreenFretDrums = 64,
		    KickFretDrums = 128,
		    RedFretBass = 256,
		    YellowFretBass = 512,
		    BlueFretBass = 1024,
		    GreenFretBass = 2048,
		    OrangeFretBass = 4096,
	    }

        protected void Start() {
		    StageKitLightingController.Instance.OnEventReceive += HandleEvent;
		    StageKitLightingController.Instance.CurrentLightingPattern.LightingPrimitives.Add(this);
		    CancellationTokenSource = new CancellationTokenSource();
	    }

	    public void Dispose() {
		    CancellationTokenSource?.Cancel();
		    Loop = false;
		    StageKitLightingController.Instance.OnEventReceive -= HandleEvent;
	    }
    }

=======
using System;
using System.Collections.Generic;
using System.Threading;

namespace StageKitLighting{

	public abstract class StageKitLighting {
		protected const byte NONE  = 0b00000000;
		protected const byte ZERO  = 0b00000001;
		protected const byte ONE   = 0b00000010;
		protected const byte TWO   = 0b00000100;
		protected const byte THREE = 0b00001000;
		protected const byte FOUR  = 0b00010000;
		protected const byte FIVE  = 0b00100000;
		protected const byte SIX   = 0b01000000;
		protected const byte SEVEN = 0b10000000;
		protected const byte ALL   = 0b11111111;

		protected bool Loop = true;

        protected CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

		protected virtual void HandleEvent(string eventName) {

		}


	}
	public abstract class StageKitLightingCues : StageKitLighting{
	    //This is the base class for all lighting patterns
	    protected const int BLUE = 0;
	    protected const int GREEN = 1;
	    protected const int YELLOW = 2;
	    protected const int RED = 3;

	    public List<StageKitLightingPrimitives> LightingPrimitives = new List<StageKitLightingPrimitives>();
	    protected void Start() {
		    StageKitLightingController.Instance.OnEventReceive += HandleEvent;
		    StageKitLightingController.Instance.CurrentLightingPattern?.Dispose();
            StageKitLightingController.Instance.CurrentLightingPattern = this;
		    CancellationTokenSource = new CancellationTokenSource();
	    }

	    public void Dispose(bool turnOffLeds = false) {
		    CancellationTokenSource?.Cancel();
		    Loop = false;
		    foreach (var primitive in LightingPrimitives) {
			    primitive.Dispose();
		    }

		    StageKitLightingController.Instance.CurrentLightingPattern = null;
		    StageKitLightingController.Instance.OnEventReceive -= HandleEvent;
		    if (turnOffLeds) {
			    SetAllLedsOff();
		    }
	    }

	    internal static void SetAllLedsOff() {
		    //set all LEDS off
		    StageKitLightingController.Instance.SetLed(RED, NONE);
		    StageKitLightingController.Instance.SetLed(GREEN, NONE);
		    StageKitLightingController.Instance.SetLed(BLUE, NONE);
		    StageKitLightingController.Instance.SetLed(YELLOW, NONE);
	    }
	}
	public abstract class StageKitLightingPrimitives : StageKitLighting{
	    //This is the base class for all lighting primitives

	    [Flags]
	    public enum ListenTypes {
		    None = 0,
		    Next = 1,
		    MajorBeat = 2,
		    MinorBeat = 4,
		    RedFretDrums = 8,
		    YellowFretDrums = 16,
		    BlueFretDrums = 32,
		    GreenFretDrums = 64,
		    KickFretDrums = 128,
		    RedFretBass = 256,
		    YellowFretBass = 512,
		    BlueFretBass = 1024,
		    GreenFretBass = 2048,
		    OrangeFretBass = 4096,
	    }

        protected void Start() {
		    StageKitLightingController.Instance.OnEventReceive += HandleEvent;
		    StageKitLightingController.Instance.CurrentLightingPattern.LightingPrimitives.Add(this);
		    CancellationTokenSource = new CancellationTokenSource();
	    }

	    public void Dispose() {
		    CancellationTokenSource?.Cancel();
		    Loop = false;
		    StageKitLightingController.Instance.OnEventReceive -= HandleEvent;
	    }
    }

>>>>>>> Stashed changes
}