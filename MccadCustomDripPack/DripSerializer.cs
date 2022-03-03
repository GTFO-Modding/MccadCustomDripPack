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

            RootFilepath = Path.Combine(ConfigManager.CustomPath, "mccad00");
            if (!Directory.Exists(RootFilepath)) Directory.CreateDirectory(RootFilepath);

            SetupCustomDB("CustomPalettes.json", FirstTimeSetup_Palette(), out var palConfig);
            SetupCustomDB("CustomVanityItems.json", FirstTimeSetup_Vanity(), out var vanityConfig);

            PaletteConfig = palConfig;
            VanityConfig = vanityConfig;
        }

        public static void SetupCustomDB<t>(string filename, t fileDefaults, out t dbContent)
        {
            string fileContent = "";

            var filepath = Path.Combine(RootFilepath, filename);
            if (File.Exists(filepath))
            {
                fileContent = File.ReadAllText(filepath);
                dbContent = JsonSerializer.Deserialize<t>(fileContent, JsonSerializerOptions);
            }
            else
            {
                dbContent = fileDefaults;
                File.WriteAllText(filepath, JsonSerializer.Serialize<t>(dbContent, JsonSerializerOptions));
            }
        }

        public static List<CustomPalette> FirstTimeSetup_Palette()
        {
            var paletteConfig = new List<CustomPalette>();

            var blackOut = new CustomPalette()
            {
                Name = "Black Out",
                PrimaryColor = new(0.05f, 0.05f, 0.05f, 0),
                SecondaryColor = new(0.05f, 0.05f, 0.05f, 0),
                TertiaryColor = new(0.05f, 0.05f, 0.05f, 0),
                QuaternaryColor = new(0.05f, 0.05f, 0.05f, 0),
                QuinaryColor = new(0.05f, 0.05f, 0.05f, 0),
                TextureTiling = 0.5f
            };

            var urbanOps = new CustomPalette()
            {
                Name = "Urban Ops",
                PrimaryColor = new(0.5f, 0.5f, 0.5f, 26),
                SecondaryColor = new(0.3f, 0.3f, 0.3f, 26),
                TertiaryColor = new(0.4f, 0.4f, 0.4f, 26),
                QuaternaryColor = new(0.8f, 0.8f, 0.8f, 26),
                QuinaryColor = new(0.489f, 0.2f, 0.01f, 0),
                TextureTiling = 2f
            };

            var flatDarkEarth = new CustomPalette()
            {
                Name = "Flat Dark Earth",
                PrimaryColor = new(0.3811f, 0.3291f, 0.2268f, 24),
                SecondaryColor = new(0.02f, 0.05f, 0.03f, 24),
                TertiaryColor = new(0.2211f, 0.2f, 0.1668f, 24),
                QuaternaryColor = new(0.2611f, 0.2189f, 0.1668f, 24),
                QuinaryColor = new(0.5898f, 0.4977f, 0.3917f, 0),
                TextureTiling = 2f
            };

            var oliveDrab = new CustomPalette()
            {
                Name = "Olive Drab",
                PrimaryColor = new(0.1773f, 0.2922f, 0.2111f, 25),
                SecondaryColor = new(0.02f, 0.05f, 0.03f, 25),
                TertiaryColor = new(0.1411f, 0.1811f, 0.1068f, 25),
                QuaternaryColor = new(0.1011f, 0.1611f, 0.1068f, 25),
                QuinaryColor = new(0.3898f, 0.5377f, 0.3717f, 0),
                TextureTiling = 2f
            };

            var navalCommand = new CustomPalette()
            {
                Name = "Aquatic Command",
                PrimaryColor = new(0f, 0.0522f, 0.6711f, 3),
                SecondaryColor = new(0.1036f, 0.2522f, 0.3254f, 2),
                TertiaryColor = new(0f, 0.0522f, 0.0711f, 0),
                QuaternaryColor = new(0.04f, 0.1322f, 0.2111f, 0),
                QuinaryColor = new(0.1036f, 0.4322f, 0.9854f, 0),
                TextureTiling = 0.5f
            };

            var lemonDrip = new CustomPalette()
            {
                Name = "Lemon Activity",
                PrimaryColor = new(0.7f, 0.9f, 0.1f, 23),
                SecondaryColor = new(0.52f, 0.5f, 0.11f, 0),
                TertiaryColor = new(0.65f, 0.53f, 0.2f, 0),
                QuaternaryColor = new(0.9f, 0.8f, 0.06f, 0),
                QuinaryColor = new(0.9f, 0.82f, 0.02f, 0),
                TextureTiling = 2f
            };

            var mario = new CustomPalette()
            {
                Name = "Mario",
                PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                TertiaryColor = new(0.4f, 0.12f, 0.15f, 0),
                QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                TextureTiling = 0.5f
            };

            var luigi = new CustomPalette()
            {
                Name = "Luigi",
                PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                TertiaryColor = new(0.1f, 0.45f, 0.15f, 0),
                QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                TextureTiling = 0.5f
            };

            var wario = new CustomPalette()
            {
                Name = "Wario",
                PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                TertiaryColor = new(0.45f, 0.4f, 0.15f, 0),
                QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                TextureTiling = 0.5f
            };

            var waluigi = new CustomPalette()
            {
                Name = "Waluigi",
                PrimaryColor = new(0.2f, 0.26f, 0.4f, 0),
                SecondaryColor = new(0.1f, 0.1f, 0.2f, 0),
                TertiaryColor = new(0.3f, 0.1f, 0.4f, 0),
                QuaternaryColor = new(0.5f, 0.4f, 0.13f, 0),
                QuinaryColor = new(0.78f, 0.75f, 0.76f, 0),
                TextureTiling = 0.5f
            };

            var frog = new CustomPalette()
            {
                Name = "Frog",
                PrimaryColor = new(0.0f, 0.8f, 0.8f, 15),
                SecondaryColor = new(0.2415f, 0.283f, 0.22f, 0),
                TertiaryColor = new(0.1f, 0.277f, 0.15f, 0),
                QuaternaryColor = new(0f, 0.1985f, 0f, 0),
                QuinaryColor = new(0.7796f, 0.2325f, 0.4538f, 0),
                TextureTiling = 0.5f
            };

            var supremeDrip = new CustomPalette()
            {
                Name = "Supreme Drip",
                PrimaryColor = new(0.08f, 0.09f, 0.07f, 0),
                SecondaryColor = new(1f, 1f, 1f, 22),
                TertiaryColor = new(0.05f, 0.07f, 0.06f, 0),
                QuaternaryColor = new(0.8057f, 0.8185f, 0.7479f, 0),
                QuinaryColor = new(0.6396f, 0.14f, 0.0738f, 0),
                TextureTiling = 2f
            };

            var virginity = new CustomPalette()
            {
                Name = "Giga Virgin",
                PrimaryColor = new(1f, 1f, 1f, 27),
                SecondaryColor = new(1f, 1f, 1f, 27),
                TertiaryColor = new(1f, 1f, 1f, 27),
                QuaternaryColor = new(1f, 1f, 1f, 27),
                QuinaryColor = new(1f, 1f, 1f, 27),
                TextureTiling = 0.75f
            };

            var nullRef = new CustomPalette()
            {
                Name = "<color=red>Null Reference Exception</color>",
                PrimaryColor = new(1f, 0f, 1f, 0),
                SecondaryColor = new(1f, 0f, 1f, 0),
                TertiaryColor = new(1f, 0f, 1f, 0),
                QuaternaryColor = new(1f, 0f, 1f, 0),
                QuinaryColor = new(1f, 0f, 1f, 0),
                TextureTiling = 0.5f
            };

            paletteConfig.Add(blackOut); paletteConfig.Add(urbanOps); paletteConfig.Add(flatDarkEarth); paletteConfig.Add(oliveDrab); paletteConfig.Add(navalCommand);
            paletteConfig.Add(lemonDrip);
            paletteConfig.Add(mario); paletteConfig.Add(luigi); paletteConfig.Add(wario); paletteConfig.Add(waluigi);
            paletteConfig.Add(frog);
            paletteConfig.Add(supremeDrip); paletteConfig.Add(virginity);
            paletteConfig.Add(nullRef);

            return paletteConfig;
        }

        public static List<CustomVanity> FirstTimeSetup_Vanity()
        {
            var vanityConfig = new List<CustomVanity>();

            var backpack_empty = new CustomVanity()
            {
                Name = "Empty", VanityItemType = ClothesType.Backpack, Icon = "AmongDrip/Empty.png", InternalEnabled = true,
                BaseVanityItemPrefab = "ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/BACKPACKS/BACKPACK001/BACKPACK001.PREFAB",
                HideAllSkinnedMeshes = true
            };

            var headgear_empty = new CustomVanity()
            {
                Name = "Empty", VanityItemType = ClothesType.Helmet, Icon = "AmongDrip/Empty.png", InternalEnabled = true,
                BaseVanityItemPrefab = "ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB",
                HideAllSkinnedMeshes = true
            };

            var headgear_elite = new CustomVanity()
            {
                Name = "Kovac Heavy Elite", VanityItemType = ClothesType.Helmet, Icon = "Assets/Bundle/Drip/Content/IconElite.png", InternalEnabled = true,
                BaseVanityItemPrefab = "ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB",
                AttachedPrefabs = new() { 
                    new() 
                    {
                        AssetPath = "Assets/Bundle/Drip/Content/CustomMask.prefab",
                        Shader = "Cell/Player/CustomGearShader",
                        IsParentedToBone = true,
                        ParentBone = "Root/Hip/Spine1/Spine2/Spine3/Neck/Head",
                        GameObjectEnabled = true,
                        AssetTransform = new()
                        {
                            LocalPosition = new(),
                            LocalEulerAngles = new(),
                            LocalScale = new(1, 1, 1)
                        }
                    },
                    new() {
                        AssetPath = "Assets/Bundle/Drip/Content/CustomMask_Visor.prefab",
                        Shader = "GTFO/Glass",
                        IsParentedToBone = true,
                        ParentBone = "Root/Hip/Spine1/Spine2/Spine3/Neck/Head",
                        GameObjectEnabled = true,
                        AssetTransform = new()
                        {
                            LocalPosition = new(0, -1.739f, -0.0592f),
                            LocalEulerAngles = new(270, 0, 0),
                            LocalScale = new(1, 1, 1)
                        }
                    }
                },
                VanityItemCustomization = new() 
                {
                    new() { ChildObject = "Headgear001/Headgear_7:Headgear_7_1", GameObjectEnabled = false},
                    new() { ChildObject = "Headgear001/Headgear_7:Headgear_Glass_7_1", GameObjectEnabled = false}
                },
            };

            var headgear_troll = new CustomVanity()
            {
                Name = "Troll",
                VanityItemType = ClothesType.Helmet,
                Icon = "Assets/Bundle/Drip/Content/Icon_Troll.png",
                InternalEnabled = true,
                BaseVanityItemPrefab = "ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB",
                AttachedPrefabs = new()
                {
                    new()
                    {
                        AssetPath = "Assets/Bundle/Drip/Content/Troll.prefab",
                        Shader = "",
                        IsParentedToBone = true,
                        ParentBone = "Root/Hip/Spine1/Spine2/Spine3/Neck/Head",
                        GameObjectEnabled = true,
                        AssetTransform = new()
                        {
                            LocalPosition = new(0, 0.06f, 0.06f),
                            LocalEulerAngles = new(),
                            LocalScale = new(1, 1, 1)
                        }
                    }
                },
                HideAllSkinnedMeshes = true
            };

            var headgear_mogu = new CustomVanity()
            {
                Name = "Amogus",
                VanityItemType = ClothesType.Helmet,
                Icon = "Assets/Bundle/Drip/Content/Icon_Mogu.png",
                InternalEnabled = true,
                BaseVanityItemPrefab = "ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB",
                AttachedPrefabs = new()
                {
                    new()
                    {
                        AssetPath = "Assets/Bundle/Drip/Content/Mask_Mogu.prefab",
                        Shader = "GTFO/Persistence/Clothing",
                        IsParentedToBone = true,
                        ParentBone = "Root/Hip/Spine1/Spine2/Spine3/Neck",
                        GameObjectEnabled = true,
                        AssetTransform = new()
                        {
                            LocalPosition = new(-0.0072f, -0.2527f, 0.1083f),
                            LocalEulerAngles = new(337.9162f, 337.0408f, 7.4414f),
                            LocalScale = new(1, 1.2f, 1.2f)
                        }
                    },
                    new()
                    {
                        AssetPath = "Assets/Bundle/Drip/Content/Mask_Mogu_Visor.prefab",
                        Shader = "",
                        IsParentedToBone = true,
                        ParentBone = "Root/Hip/Spine1/Spine2/Spine3/Neck",
                        GameObjectEnabled = true,
                        AssetTransform = new()
                        {
                            LocalPosition = new(-0.025f, 0.16f, 0.05f),
                            LocalEulerAngles = new(345, 0, 0),
                            LocalScale = new(0.25f, 0.05f, 0.25f)
                        }
                    }
                },
                HideAllSkinnedMeshes = true
            };

            var headgear_hackettHood = new CustomVanity()
            {
                Name = @"Hackett's Hood",
                VanityItemType = ClothesType.Helmet,
                Icon = "Assets/Bundle/Drip/Content/hackettHoodIcon.png",
                InternalEnabled = true,
                BaseVanityItemPrefab = "Assets/AssetPrefabs/Characters/Players/Clothes/Headgears/Headgear002Hackett/Headgear002Hackett.prefab",
                VanityItemCustomization = new()
                {
                    new() { ChildObject = "Headgear_Hackett/g_hackett_mask", GameObjectEnabled = false },
                    new() { ChildObject = "Headgear_Hackett/g_hackett_mask_1", GameObjectEnabled = false }
                },
            };

            var torso_mogu = new CustomVanity()
            {
                Name = "Amogus",
                VanityItemType = ClothesType.Torso,
                Icon = "Assets/Bundle/Drip/Content/Icon_Mogu.png",
                InternalEnabled = true,
                BaseVanityItemPrefab = "ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/TORSOS/TORSO003WOODS/TORSO003WOODS.PREFAB",
                VanityItemCustomization = new()
                {
                    new() { ChildObject = "Arms003Woods", GameObjectEnabled = false }
                },
            };

            vanityConfig.Add(backpack_empty);
            vanityConfig.Add(headgear_elite);
            vanityConfig.Add(headgear_hackettHood);
            vanityConfig.Add(headgear_troll);
            vanityConfig.Add(headgear_mogu);
            vanityConfig.Add(headgear_empty);
            vanityConfig.Add(torso_mogu);

            return vanityConfig;
        }

        public static string RootFilepath;
        public static List<CustomPalette> PaletteConfig;
        public static List<CustomVanity> VanityConfig;

        public static JsonSerializerOptions JsonSerializerOptions = new() { WriteIndented = true, AllowTrailingCommas = true };
    }
}
