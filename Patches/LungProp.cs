using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoMultiplier.Patches
{
    [HarmonyPatch(typeof(LungProp), "DisconnectFromMachinery")]
    public class MultiplyApparatus
    {
        private static void Prefix(LungProp __instance)
        {
            if(Plugin.MultiplyApparatusEnabled.Value)
            {
                var currentWeather = __instance.roundManager.currentLevel.currentWeather;
                __instance.SetScrapValue((int)(__instance.scrapValue * Plugin.Multipliers[currentWeather].Value));
            }
        }
    }
}