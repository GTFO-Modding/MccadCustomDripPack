using BepInEx;
using BepInEx.IL2CPP;
using GameData;
using GTFO.API;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using static ClothesPalette;
using UnhollowerRuntimeLib;

namespace MccadCustomDripPack
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class EntryPoint : BasePlugin
    {
        // The method that gets called when BepInEx tries to load our plugin
        public override void Load()
        {
            m_Harmony = new Harmony("com.mccad00.MccadCustomDripPack");
            m_Harmony.PatchAll();
            DripLogger.Verbose($"zamn");

            AssetAPI.OnStartupAssetsLoaded += SweatShop;
        }

        public static void SweatShop()
        {
            ClassInjector.RegisterTypeInIl2Cpp<CustomVanityItem>();

            DripSerializer.Initialize();

            var enumType = typeof(ToneTexture);
            var enumNames = System.Enum.GetNames(enumType);

            foreach (var enumName in enumNames)
            {
                var attr = enumType.GetMember(enumName)[0].GetCustomAttribute<TextureMapAttribute>();
                if (attr == null) continue;
                s_TextureMap.Add(attr.TextureName, System.Enum.Parse<ToneTexture>(enumName));
            }

            foreach (var texture in Object.FindObjectsOfTypeAll(UnhollowerRuntimeLib.Il2CppType.Of<Texture2D>()))
            {
                if (!s_TextureMap.TryGetValue(texture.name, out var texType)) continue;
                if (s_ToneTextureCache.ContainsKey(texType)) continue;
                s_ToneTextureCache.Add(texType, texture.TryCast<Texture2D>());
            }

            new Headgear_HackettHood();
            new Headgear_Mogu();
            new Headgear_Troll();
            new Headgear_Empty();
            new Backpack_Empty();
            new Torso_Mogu();

            foreach (var freshDick in DripSerializer.Config)
            {
                DripLogger.Debug($"Creating custom palette {freshDick.Name}");
                var pal = AssetAPI.InstantiateAsset<GameObject>("Assets/AssetPrefabs/Characters/Players/Clothes/Palettes/Palette020pSon-EA.prefab", $"CustomPalettes/{freshDick.Name}.prefab").GetComponent<ClothesPalette>();
                pal.name = freshDick.Name;

                ModifyTone(freshDick, pal.m_primaryTone, 0);
                ModifyTone(freshDick, pal.m_secondaryTone, 1);
                ModifyTone(freshDick, pal.m_tertiaryTone, 2);
                ModifyTone(freshDick, pal.m_quaternaryTone, 3);
                ModifyTone(freshDick, pal.m_quinaryTone, 4);
                pal.m_textureTiling = freshDick.TextureTiling;

                GenerateVanityItemDBEntry(freshDick.Name, $"CustomPalettes/{freshDick.Name}.prefab", ClothesType.Palette);
            }
        }

        public static void GenerateVanityItemDBEntry(string name, string prefab, ClothesType type, string icon = "AmongDrip/Empty.png")
        {
            var db = GameDataBlockBase<VanityItemsTemplateDataBlock>.AddNewBlock();
            db.name = name; db.publicName = name;
            db.prefab = prefab;
            db.type = type;
            db.DropWeight = 1.0f;
            db.icon = icon;
            db.internalEnabled = true;
            DripLogger.Debug($"Added {name} to the datablocks");
        }

        public static void ModifyTone(CustomPalette config, Tone tone, int toneIndex)
        {
            JsonColor toneConfig;

            switch (toneIndex)
            {
                default: toneConfig = config.PrimaryColor; break;
                case 1: toneConfig = config.SecondaryColor; break;
                case 2: toneConfig = config.TertiaryColor; break;
                case 3: toneConfig = config.QuaternaryColor; break;
                case 4: toneConfig = config.QuinaryColor; break;
            }

            tone.m_color = new Color(toneConfig.R, toneConfig.G, toneConfig.B);
            if (toneConfig.Texture != 0 && s_ToneTextureCache.TryGetValue(toneConfig.Texture, out var texture))
            {
                DripLogger.Debug($"Applied texture {texture.name} to tone index{toneIndex} on {config.Name}");
                tone.m_texture = texture;
            }
        }

        private Harmony m_Harmony;

        public static Dictionary<string, ToneTexture> s_TextureMap = new();

        public static Dictionary<ToneTexture, Texture2D> s_ToneTextureCache = new();

        public const string NAME = "AmongDrip", VERSION = "1.0.0", GUID = "com.mccad00.MccadCustomDripPack";
    }
}
