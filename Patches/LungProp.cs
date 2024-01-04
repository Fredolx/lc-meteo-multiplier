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
            var currentWeather = __instance.roundManager.currentLevel.currentWeather;

            if (Plugin.MultiplyApparatusEnabled.Value)
            {
                if (Plugin.Multipliers.ContainsKey(currentWeather))
                {
                    __instance.SetScrapValue((int)(__instance.scrapValue * Plugin.Multipliers[currentWeather].Value));
                }
                else
                {
                    __instance.SetScrapValue((int)(__instance.scrapValue * Plugin.Multipliers[Plugin.DEFAULT_WEATHER].Value));
                }
            }
        }
    }
}