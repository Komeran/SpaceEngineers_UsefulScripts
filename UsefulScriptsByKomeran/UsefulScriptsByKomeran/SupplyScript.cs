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
using VRage;

namespace IngameScript
{
    public class SupplyScript : MyGridProgram
    {
        #endregion
        public void Main(string argument)
        {
            // Calculate Power Storage
            List<IMyBatteryBlock> batteries = new List<IMyBatteryBlock>();
            GridTerminalSystem.GetBlocksOfType(batteries);
            float maxVal = 0;
            float val = 0;
            foreach(IMyBatteryBlock battery in batteries)
            {
                maxVal += battery.MaxStoredPower;
                val += battery.CurrentStoredPower;
            }
            // p = A * 100 / G
            float pBatteries = val * 100 / maxVal;

            // Calculate Hydrogen Storage
            List<IMyGasTank> gasTanks = new List<IMyGasTank>();
            GridTerminalSystem.GetBlocksOfType(gasTanks);
            maxVal = 0;
            val = 0;
            foreach (IMyGasTank tank in gasTanks)
            {
                if (tank.BlockDefinition.SubtypeId.ToLower().Contains("hydrogentank"))
                {
                    maxVal += tank.Capacity;
                    val += tank.FilledRatio * tank.Capacity;
                }
            }
            // p = A * 100 / G
            float pHydrogen = val * 100 / maxVal;

            // Calculate Storage Capacity
            List<IMyCargoContainer> cargoContainers = new List<IMyCargoContainer>();
            GridTerminalSystem.GetBlocksOfType(cargoContainers);
            MyFixedPoint cargoMaxVal = 0;
            MyFixedPoint cargoVal = 0;
            foreach(IMyCargoContainer cargoContainer in cargoContainers)
            {
                cargoMaxVal += cargoContainer.GetInventory().MaxVolume;
                cargoVal += cargoContainer.GetInventory().CurrentVolume;
            }
            // p = A * 100 / G
            float pCargo = cargoVal.RawValue * 100 / cargoMaxVal.RawValue;

            // Build string to show
            string supplyString = "SUPPLY" + '\n'
                        + "Energy: [";

            for (int i = 0; i < 20; i++)
            {
                if (i < pBatteries / 5)
                    supplyString += '#';
                else
                    supplyString += '-';
            }

            supplyString += "] " + (int)pBatteries + "%" + '\n';

            supplyString += "Hydrogen: [";

            for (int i = 0; i < 20; i++)
            {
                if (i < pHydrogen / 5)
                    supplyString += '#';
                else
                    supplyString += '-';
            }

            supplyString += "] " + (int)pHydrogen + "%" + '\n';

            supplyString += "Cargo: [";

            for (int i = 0; i < 20; i++)
            {
                if (i < pCargo / 5)
                    supplyString += '#';
                else
                    supplyString += '-';
            }

            supplyString += "] " + (int)pCargo + "%" + '\n';
            supplyString += "" + cargoVal + '/' + cargoMaxVal + " L" + '\n';

            List<IMyTextPanel> panels = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType(panels);

            foreach(IMyTextPanel panel in panels)
            {
                if (panel.CustomData.ToLower().Equals("supply"))
                    panel.WritePublicText(supplyString);
            }
        }
        #region post-script
    }
}
#endregion