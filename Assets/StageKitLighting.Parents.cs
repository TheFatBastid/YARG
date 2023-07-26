using System;
using System.Threading;

namespace StageKitLighting{
    public abstract class StageKitLighting : IDisposable {
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

        protected CancellationTokenSource CancellationTokenSource;

		protected virtual void HandleEvent(string eventName)
        {

		}

        protected void Start() {
            StageKitLightingController.Instance.OnEventReceive += HandleEvent;
            CancellationTokenSource = new CancellationTokenSource();
        }

        public void Dispose() {
            CancellationTokenSource?.Cancel();
            StageKitLightingController.Instance.OnEventReceive -= HandleEvent;
        }

	}
	public abstract class StageKitLightingCues : StageKitLighting{
	    //This is the base class for all lighting patterns
	    protected const int BLUE = 0;
	    protected const int GREEN = 1;
	    protected const int YELLOW = 2;
	    protected const int RED = 3;

        protected StageKitLighting[] CuePrimitives = new StageKitLighting[4];

        public void Dispose(bool turnOffLeds = false) {
		    base.Dispose();
            CancellationTokenSource?.Cancel();

            CuePrimitives[0]?.Dispose();
            CuePrimitives[0] = null;

            CuePrimitives[1]?.Dispose();
            CuePrimitives[1] = null;

            CuePrimitives[2]?.Dispose();
            CuePrimitives[2] = null;

            CuePrimitives[3]?.Dispose();
            CuePrimitives[3] = null;

            StageKitLightingController.Instance.OnEventReceive -= HandleEvent;

            if (!turnOffLeds) return;
            StageKitLightingController.Instance.SetLed(RED, NONE);
            StageKitLightingController.Instance.SetLed(GREEN, NONE);
            StageKitLightingController.Instance.SetLed(BLUE, NONE);
            StageKitLightingController.Instance.SetLed(YELLOW, NONE);
        }
    }
}