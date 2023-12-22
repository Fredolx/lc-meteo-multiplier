using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoMultiplier.Patches
{
    [HarmonyPatch(typeof(RoundManager), "SpawnScrapInLevel")]
    public class SpawnScrapInLevelPatches
    {
        private static void Prefix(RoundManager __instance)
        {
            LevelWeatherType currentWeather = __instance.currentLevel.currentWeather;
            __instance.scrapValueMultiplier = Plugin.Multipliers[currentWeather].Value;
        }
    }
}
