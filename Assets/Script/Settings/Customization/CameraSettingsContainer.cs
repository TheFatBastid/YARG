﻿using System;
using System.Collections.Generic;
using YARG.Core.Game;

namespace YARG.Settings.Customization
{
    public class CameraSettingsContainer : CustomContent<CameraPreset>
    {
        public override IReadOnlyList<CameraPreset> DefaultPresets => CameraPreset.Defaults;

        public CameraSettingsContainer(string contentDirectory) : base(contentDirectory)
        {
        }

        public override void SetSettingsFromPreset(BasePreset preset)
        {
            if (preset is not CameraPreset p)
            {
                throw new InvalidOperationException("Invalid preset type!");
            }

            var s = SettingsManager.Settings;
            s.CameraPreset_FieldOfView.SetSettingNoEvents(p.FieldOfView);
            s.CameraPreset_PositionY.SetSettingNoEvents(p.PositionY);
            s.CameraPreset_PositionZ.SetSettingNoEvents(p.PositionZ);
            s.CameraPreset_Rotation.SetSettingNoEvents(p.Rotation);
            s.CameraPreset_FadeLength.SetSettingNoEvents(p.FadeLength);
            s.CameraPreset_CurveFactor.SetSettingNoEvents(p.CurveFactor);
        }

        public override void SetPresetFromSettings(BasePreset preset)
        {
            if (preset is not CameraPreset p)
            {
                throw new InvalidOperationException("Invalid preset type!");
            }

            var s = SettingsManager.Settings;
            p.FieldOfView = s.CameraPreset_FieldOfView.Data;
            p.PositionY   = s.CameraPreset_PositionY.Data;
            p.PositionZ   = s.CameraPreset_PositionZ.Data;
            p.Rotation    = s.CameraPreset_Rotation.Data;
            p.FadeLength  = s.CameraPreset_FadeLength.Data;
            p.CurveFactor = s.CameraPreset_CurveFactor.Data;
        }
    }
}