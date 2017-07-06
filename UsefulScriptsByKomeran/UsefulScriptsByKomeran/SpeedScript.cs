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
    public class SpeedScript : MyGridProgram
    {
        #endregion
        Vector3D position = new Vector3D(0, 0, 0);

        public void Main(string argument)
        {
            List<IMyTextPanel> panels = new List<IMyTextPanel>();
            List<IMyRadioAntenna> antennas = new List<IMyRadioAntenna>();
            GridTerminalSystem.GetBlocksOfType(panels);
            GridTerminalSystem.GetBlocksOfType(antennas);
            Vector3D pos = Me.GetPosition();
            foreach (IMyTextPanel panel in panels)
            {
                if (panel.CustomData.ToLower().Equals("speed"))
                {
                    panel.WritePublicText("  Current Speed:" + get_speed().ToString("N2") + " m/s");
                }
            }
        }

        double get_speed()
        {
            Vector3D current_position = Me.GetPosition(); // the position of this programmable block
            double speed = (current_position - position).Length(); // how far the PB has moved since the last run (1s ago)
            position = current_position; // update the global variable, which will be used on the next run

            return speed;
        }
        #region post-script
    }
}
#endregion