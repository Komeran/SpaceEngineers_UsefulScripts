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
    public class ConnectorPanelScript : MyGridProgram
    {
        #endregion
        public void Main(string argument)
        {
            if (argument.ToLower().Equals("left"))
            {
                IMyShipConnector con = GridTerminalSystem.GetBlockWithName("Left Connector") as IMyShipConnector;
                // Left side
                List<IMyTextPanel> panels = new List<IMyTextPanel>();
                GridTerminalSystem.GetBlocksOfType(panels);
                if (con.Status == MyShipConnectorStatus.Connected)
                {
                    IMyTimerBlock timer = GridTerminalSystem.GetBlockWithName("Left Timer") as IMyTimerBlock;
                    timer.StopCountdown();
                    foreach (IMyTextPanel panel in panels)
                    {
                        if(panel.CustomData.ToLower().Equals("leftcon"))
                            panel.ShowPublicTextOnScreen();
                    }
                }
                else
                {
                    foreach (IMyTextPanel panel in panels)
                    {
                        if (panel.CustomData.ToLower().Equals("leftcon"))
                        {
                            if (panel.ShowText)
                            {
                                panel.ShowTextureOnScreen();
                            }
                        }
                    }
                }
            }

            if (argument.ToLower().Equals("right"))
            {
                IMyShipConnector con = GridTerminalSystem.GetBlockWithName("Right Connector") as IMyShipConnector;
                // Right Side
                List<IMyTextPanel> panels = new List<IMyTextPanel>();
                GridTerminalSystem.GetBlocksOfType(panels);
                if (con.Status == MyShipConnectorStatus.Connected)
                {
                    IMyTimerBlock timer = GridTerminalSystem.GetBlockWithName("Right Timer") as IMyTimerBlock;
                    timer.StopCountdown();
                    foreach (IMyTextPanel panel in panels)
                    {

                        if (panel.CustomData.ToLower().Equals("rightcon"))
                            panel.ShowPublicTextOnScreen();
                    }
                }
                else
                {
                    foreach (IMyTextPanel panel in panels)
                    {

                        if (panel.CustomData.ToLower().Equals("rightcon"))
                        {
                            if (panel.ShowText)
                            {
                                panel.ShowTextureOnScreen();
                            }
                        }
                    }
                }
            }
        }
        #region post-script
    }
}
#endregion