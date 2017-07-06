#region pre-script
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using VRageMath;
using VRage.Game;
using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Ingame;
using Sandbox.Game.EntityComponents;
using VRage.Game.Components;
using VRage.Collections;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;

namespace IngameScript
{
    public class AntennaScript : MyGridProgram
    {
        #endregion
        public void Main(string argument)
        {
            IMyLaserAntenna antenna = null;
            IMyLaserAntenna antenna2 = null;
            antenna.SetTargetCoords(antenna2.GetPosition().ToString());
        }
        #region post-script
    }
}
#endregion