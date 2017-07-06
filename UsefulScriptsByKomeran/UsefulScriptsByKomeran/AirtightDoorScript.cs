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
    public class AirtightDoorScript : MyGridProgram
    {
        #endregion
        public void Main(string argument)
        {
            List<IMyDoor> doors = new List<IMyDoor>();
            GridTerminalSystem.GetBlocksOfType(doors);
            IMyDoor insideDoor = null;
            IMyDoor outsideDoor = null;
            foreach(IMyDoor door in doors)
            {
                if (door.CustomData.ToLower().Equals("insideairhatch"))
                    insideDoor = door;
                if (door.CustomData.ToLower().Equals("outsideairhatch"))
                    outsideDoor = door;
            }
            if(insideDoor == null || outsideDoor == null)
                return;
            if(insideDoor.Status == DoorStatus.Closed && outsideDoor.Status == DoorStatus.Closed)
            {
                outsideDoor.Enabled = true;
                insideDoor.Enabled = true;
            }
            else if(insideDoor.Status == DoorStatus.Closed)
            {
                insideDoor.Enabled = false;
                outsideDoor.Enabled = true;
            }
            else if(outsideDoor.Status == DoorStatus.Closed)
            {
                insideDoor.Enabled = true;
                outsideDoor.Enabled = false;
            }
        }
        #region post-script
    }
}
#endregion