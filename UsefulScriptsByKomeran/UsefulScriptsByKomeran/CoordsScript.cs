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
    public class CoordsScript : MyGridProgram
    {
        #endregion
        public void Main(string argument)
        {
            List<IMyTextPanel> panels = new List<IMyTextPanel>();
            List<IMyRadioAntenna> antennas = new List<IMyRadioAntenna>();
            GridTerminalSystem.GetBlocksOfType(panels);
            GridTerminalSystem.GetBlocksOfType(antennas);
            Vector3D pos = Me.GetPosition();
            foreach (IMyTextPanel panel in panels)
            {
                if(panel.CustomData.ToLower().Equals("coords"))
                {
                    panel.WritePublicText("  Current Coords:" + '\n'
                        + "  X: "+(int)pos.X + '\n'
                        + "  Y: "+(int)pos.Y + '\n'
                        + "  Z: "+(int)pos.Z);
                }
            }
        }
        #region post-script
    }
}
#endregion