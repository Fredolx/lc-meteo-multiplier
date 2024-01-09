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

            if (Plugin.MultipliersEnabled.Value)
            {
                if (Plugin.Multipliers.ContainsKey(currentWeather))
                {
                    __instance.scrapValueMultiplier = Plugin.Multipliers[currentWeather].Value;
                }
                else
                {
                    __instance.scrapValueMultiplier = Plugin.Multipliers[Plugin.DEFAULT_WEATHER].Value;
                }
            }

            if (Plugin.SpawnMultipliersEnabled.Value)
            {
                if (Plugin.SpawnMultipliers.ContainsKey(currentWeather))
                {
                    __instance.scrapAmountMultiplier = Plugin.SpawnMultipliers[currentWeather].Value;
                }
                else
                {
                    __instance.scrapAmountMultiplier = Plugin.SpawnMultipliers[Plugin.DEFAULT_WEATHER].Value;
                }
            }
        }
    }
}
