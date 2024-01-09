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
        public static Dictionary<LevelWeatherType, ConfigEntry<float>> SpawnMultipliers = new Dictionary<LevelWeatherType, ConfigEntry<float>>();
        public static ConfigEntry<bool> MultipliersEnabled;
        public static ConfigEntry<bool> SpawnMultipliersEnabled;
        public static ConfigEntry<bool> MultiplyApparatusEnabled;

        public const LevelWeatherType DEFAULT_WEATHER = LevelWeatherType.None;

        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            SetConfig();
            Logger.LogInfo($"MultipliersEnabled: {MultipliersEnabled}");
            Logger.LogInfo($"MultiplyApparatusEnabled: {MultiplyApparatusEnabled}");
            Logger.LogInfo($"Multipliers:\n{string.Join("\n", Multipliers.Select(x => $"{x.Key}:{x.Value.Value}"))}");
            Logger.LogInfo($"SpawnMultipliersEnabled: {SpawnMultipliersEnabled}");
            Logger.LogInfo($"SpawnMultipliers:\n{string.Join("\n", SpawnMultipliers.Select(x => $"{x.Key}:{x.Value.Value}"))}");
            harmony.PatchAll();
        }

        private void SetConfig()
        {
            MultipliersEnabled = Config.Bind("Multipliers", "Enabled", true, "Enables multipliers (scrap value according to meteo)");
            MultiplyApparatusEnabled = Config.Bind("Multipliers", "MultiplyApparatusEnabled", true, "Also multiply the value of the apparatus (power module) according to meteo");
            SetMultipliers();
            SpawnMultipliersEnabled = Config.Bind("Spawn Multipliers", "Enabled", false, "Enables spawn multipliers (amount of scrap in the map)");
            SetSpawnMultipliers();
        }

        private void SetMultipliers()
        {
            Multipliers.Add(LevelWeatherType.None, Config.Bind(
                "Multipliers",
                "None",
                0.4f,
                "No weather event")
            );
            Multipliers.Add(LevelWeatherType.DustClouds, Config.Bind(
                "Multipliers",
                "DustClouds",
                0.44f,
                "Dust Clouds")
            );
            Multipliers.Add(LevelWeatherType.Foggy, Config.Bind(
                "Multipliers",
                "Foggy",
                0.44f,
                "Foggy")
            );
            Multipliers.Add(LevelWeatherType.Rainy, Config.Bind(
                "Multipliers",
                "Rainy",
                0.44f,
                "Rainy")
            );
            Multipliers.Add(LevelWeatherType.Stormy, Config.Bind(
                "Multipliers",
                "Stormy",
                0.52f,
                "Stormy")
            );
            Multipliers.Add(LevelWeatherType.Flooded, Config.Bind(
                "Multipliers",
                "Flooded",
                0.56f,
                "Flooded")
            );
            Multipliers.Add(LevelWeatherType.Eclipsed, Config.Bind(
                "Multipliers",
                "Eclipsed",
                0.6f,
                "Eclipsed")
            );
        }
        private void SetSpawnMultipliers()
        {
            SpawnMultipliers.Add(LevelWeatherType.None, Config.Bind(
                "Spawn Multipliers",
                "None",
                1f,
                "No weather event")
            );
            SpawnMultipliers.Add(LevelWeatherType.DustClouds, Config.Bind(
                "Spawn Multipliers",
                "DustClouds",
                1.25f,
                "Dust Clouds")
            );
            SpawnMultipliers.Add(LevelWeatherType.Foggy, Config.Bind(
                "Spawn Multipliers",
                "Foggy",
                1.25f,
                "Foggy")
            );
            SpawnMultipliers.Add(LevelWeatherType.Rainy, Config.Bind(
                "Spawn Multipliers",
                "Rainy",
                1.25f,
                "Rainy")
            );
            SpawnMultipliers.Add(LevelWeatherType.Stormy, Config.Bind(
                "Spawn Multipliers",
                "Stormy",
                1.5f,
                "Stormy")
            );
            SpawnMultipliers.Add(LevelWeatherType.Flooded, Config.Bind(
                "Spawn Multipliers",
                "Flooded",
                1.5f,
                "Flooded")
            );
            SpawnMultipliers.Add(LevelWeatherType.Eclipsed, Config.Bind(
                "Spawn Multipliers",
                "Eclipsed",
                1.5f,
                "Eclipsed")
            );
        }

    }
}
