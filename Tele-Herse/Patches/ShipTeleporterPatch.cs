using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tele_Herse.Patches
{
    [HarmonyPatch(typeof(ShipTeleporter), "beamUpPlayer")]
    public class ShipTeleporterPatch
    {
        static bool Prefix(ref bool ___isInverseTeleporter)
        {
            PlayerControllerB playerToBeamUp = StartOfRound.Instance.mapScreen.targetedPlayer;
            if (playerToBeamUp.isPlayerDead == false && ___isInverseTeleporter == false)
            {
                return false;
            }
            return true;
        }
        
    }
}
