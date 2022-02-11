using MTFO.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MccadCustomDripPack
{
    class DripSerializer
    {
        public static void Initialize()
        {
            DripLogger.Debug($"{EntryPoint.NAME} version {EntryPoint.VERSION} by Mccad00 | Setting up custom datablocks");

            FilePath = Path.Combine(ConfigManager.CustomPath, "mccad00");
            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);

            FilePath = Path.Combine(FilePath, "CustomPalettes.json");
            if (File.Exists(FilePath))
            {
                DripLogger.Debug($"Reading the custom datablock");
                FileContent = File.ReadAllText(FilePath);
                Config = JsonSerializer.Deserialize<List<CustomPalette>>(FileContent, JsonSerializerOptions);
            }
            else
            {
                DripLogger.Debug($"First time setup | Writing the custom datablock");

                Config = new();

                var blackOut = new CustomPalette()
                {
                    Name = "Black Out",
                    PrimaryColor = new(0.05f, 0.05f, 0.05f, 0),
                    SecondaryColor = new(0.05f, 0.05f, 0.05f, 0),
                    TertiaryColor = new(0.05f, 0.05f, 0.05f, 0),
                    QuaternaryColor = new(0.05f, 0.05f, 0.05f, 0),
                    QuinaryColor = new(0.05f, 0.05f, 0.05f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("blackOut");

                 var urbanOps = new CustomPalette()
                {
                    Name = "Urban Ops",
                    PrimaryColor = new(0.5f, 0.5f, 0.5f, 26),
                    SecondaryColor = new(0.3f, 0.3f, 0.3f, 26),
                    TertiaryColor = new(0.4f, 0.4f, 0.4f, 26),
                    QuaternaryColor = new(0.8f, 0.8f, 0.8f, 26),
                    QuinaryColor = new(0.489f, 0.2f, 0.01f, 0),
                     TextureTiling = 2f
                 }; DripLogger.Debug("urbanOps");

                var flatDarkEarth = new CustomPalette()
                {
                    Name = "Flat Dark Earth",
                    PrimaryColor = new(0.3811f, 0.3291f, 0.2268f, 24),
                    SecondaryColor = new(0.02f, 0.05f, 0.03f, 24),
                    TertiaryColor = new(0.2211f, 0.2f, 0.1668f, 24),
                    QuaternaryColor = new(0.2611f, 0.2189f, 0.1668f, 24),
                    QuinaryColor = new(0.5898f, 0.4977f, 0.3917f, 0),
                    TextureTiling = 2f
                }; DripLogger.Debug("flatDarkEarth");

                var oliveDrab = new CustomPalette()
                {
                    Name = "Olive Drab",
                    PrimaryColor = new(0.1773f, 0.2922f, 0.2111f, 25),
                    SecondaryColor = new(0.02f, 0.05f, 0.03f, 25),
                    TertiaryColor = new(0.1411f, 0.1811f, 0.1068f, 25),
                    QuaternaryColor = new(0.1011f, 0.1611f, 0.1068f, 25),
                    QuinaryColor = new(0.3898f, 0.5377f, 0.3717f, 0),
                    TextureTiling = 2f
                }; DripLogger.Debug("oliveDrab");

                var navalCommand = new CustomPalette()
                {
                    Name = "Aquatic Command",
                    PrimaryColor = new(0f, 0.0522f, 0.6711f, 3),
                    SecondaryColor = new(0.1036f, 0.2522f, 0.3254f, 2),
                    TertiaryColor = new(0f, 0.0522f, 0.0711f, 0),
                    QuaternaryColor = new(0.04f, 0.1322f, 0.2111f, 0),
                    QuinaryColor = new(0.1036f, 0.4322f, 0.9854f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("navalCommand");

                var lemonDrip = new CustomPalette()
                {
                    Name = "Lemon Activity",
                    PrimaryColor = new(0.7f, 0.9f, 0.1f, 23),
                    SecondaryColor = new(0.52f, 0.5f, 0.11f, 0),
                    TertiaryColor = new(0.65f, 0.53f, 0.2f, 0),
                    QuaternaryColor = new(0.9f, 0.8f, 0.06f, 0),
                    QuinaryColor = new(0.9f, 0.82f, 0.02f, 0),
                    TextureTiling = 2f
                }; DripLogger.Debug("lemonDrip");

                var mario = new CustomPalette()
                {
                    Name = "Mario",
                    PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                    SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                    TertiaryColor = new(0.4f, 0.12f, 0.15f, 0),
                    QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                    QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("mario");

                var luigi = new CustomPalette()
                {
                    Name = "Luigi",
                    PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                    SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                    TertiaryColor = new(0.1f, 0.45f, 0.15f, 0),
                    QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                    QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("luigi");

                var wario = new CustomPalette()
                {
                    Name = "Wario",
                    PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                    SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                    TertiaryColor = new(0.45f, 0.4f, 0.15f, 0),
                    QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                    QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("wario");

                var waluigi = new CustomPalette()
                {
                    Name = "Waluigi",
                    PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                    SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                    TertiaryColor = new(0.3f, 0.1f, 0.4f, 0),
                    QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                    QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("waluigi");

                var frog = new CustomPalette()
                {
                    Name = "Frog",
                    PrimaryColor = new(0.0f, 0.8f, 0.8f, 15),
                    SecondaryColor = new(0.2415f, 0.283f, 0.22f, 0),
                    TertiaryColor = new(0.1f, 0.277f, 0.15f, 0),
                    QuaternaryColor = new(0f, 0.1985f, 0f, 0),
                    QuinaryColor = new(0.7796f, 0.2325f, 0.4538f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("frog");

                var supremeDrip = new CustomPalette()
                {
                    Name = "Supreme Drip",
                    PrimaryColor = new(0.08f, 0.09f, 0.07f, 0),
                    SecondaryColor = new(1f, 1f, 1f, 22),
                    TertiaryColor = new(0.05f, 0.07f, 0.06f, 0),
                    QuaternaryColor = new(0.8057f, 0.8185f, 0.7479f, 0),
                    QuinaryColor = new(0.6396f, 0.14f, 0.0738f, 0),
                    TextureTiling = 2f
                }; DripLogger.Debug("supremeDrip");

                var virginity = new CustomPalette()
                {
                    Name = "Giga Virgin",
                    PrimaryColor = new(1f, 1f, 1f, 27),
                    SecondaryColor = new(1f, 1f, 1f, 27),
                    TertiaryColor = new(1f, 1f, 1f, 27),
                    QuaternaryColor = new(1f, 1f, 1f, 27),
                    QuinaryColor = new(1f, 1f, 1f, 27),
                    TextureTiling = 0.75f
                }; DripLogger.Debug("virginity");

                var nullRef = new CustomPalette()
                {
                    Name = "<color=red>Null Reference Exception</color>",
                    PrimaryColor = new(1f, 0f, 1f, 0),
                    SecondaryColor = new(1f, 0f, 1f, 0),
                    TertiaryColor = new(1f, 0f, 1f, 0),
                    QuaternaryColor = new(1f, 0f, 1f, 0),
                    QuinaryColor = new(1f, 0f, 1f, 0),
                    TextureTiling = 0.5f
                }; DripLogger.Debug("nullRef");

                Config.Add(blackOut); Config.Add(urbanOps); Config.Add(flatDarkEarth); Config.Add(oliveDrab); Config.Add(navalCommand);
                Config.Add(lemonDrip);
                Config.Add(mario); Config.Add(luigi); Config.Add(wario); Config.Add(waluigi);
                Config.Add(frog);
                Config.Add(supremeDrip); Config.Add(virginity);
                Config.Add(nullRef);

                FileContent = JsonSerializer.Serialize(Config, JsonSerializerOptions);
                File.WriteAllText(FilePath, FileContent);
            }

            if (Config == null)
            {
                DripLogger.Error("Error reading custom datablock content!");
            }
        }

        public static string FilePath;
        public static string FileContent;
        public static List<CustomPalette> Config;
        public static JsonSerializerOptions JsonSerializerOptions = new() { WriteIndented = true, AllowTrailingCommas = true };
    }
}
