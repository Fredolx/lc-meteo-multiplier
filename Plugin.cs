using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace MeteoMultiplier
{
    [BepInPlugin("com.github.fredolx.meteomultiplier", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Dictionary<LevelWeatherType, ConfigEntry<float>> Multipliers = new Dictionary<LevelWeatherType, ConfigEntry<float>>();
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

            Multipliers.Add(LevelWeatherType.None, Config.Bind("Multipliers",
                "None",
                1f,
                "No weather event"));
            Multipliers.Add(LevelWeatherType.DustClouds, Config.Bind("Multipliers",
                "DustClouds",
                1.1f,
                "Dust Clouds"));
            Multipliers.Add(LevelWeatherType.Foggy, Config.Bind("Multipliers",
                "Foggy",
                1.1f,
                "Foggy"));
            Multipliers.Add(LevelWeatherType.Rainy, Config.Bind("Multipliers",
                "Rainy",
                1.2f,
                "Rainy"));
            Multipliers.Add(LevelWeatherType.Stormy, Config.Bind("Multipliers",
                "Stormy",
                1.5f,
                "Stormy"));
            Multipliers.Add(LevelWeatherType.Flooded, Config.Bind("Multipliers",
                "Flooded",
                1.6f,
                "Flooded"));
            Multipliers.Add(LevelWeatherType.Eclipsed, Config.Bind("Multipliers",
                "Eclipsed",
                1.7f,
                "Eclipsed"));
            Logger.LogInfo($"Multipliers:\n{string.Join("\n", Multipliers.Select(x => $"{x.Key}:{x.Value.Value}"))}");
            harmony.PatchAll();
        }
    }
}
