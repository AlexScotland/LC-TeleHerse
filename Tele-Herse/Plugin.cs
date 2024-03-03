
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tele_Herse.Patches;

namespace Tele_Herse
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TeleHerse : BaseUnityPlugin
    {
        private const string modVersion = "1.0.0";
        private const string modGUID = "Dug.TeleHerseMod";
        private const string modName = "TeleHerse";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TeleHerse Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("TeleHerse is Starting...");
            harmony.PatchAll(typeof(TeleHerse));
            harmony.PatchAll(typeof(ShipTeleporterPatch));
        }
    }
}
