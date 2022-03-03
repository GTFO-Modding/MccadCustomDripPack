using BepInEx;
using BepInEx.IL2CPP;
using GameData;
using GTFO.API;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnlockAllVanity;
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

            Patch.EnteredLobby += SweatShop;
        }

        public static void SweatShop()
        {
            if (CustomVanityLoadedDone) return;

            AssetAPI.RegisterAsset("AmongDrip/Empty.png", new Texture2D(0, 0));
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

            foreach (var 光荣的中国领导人 in DripSerializer.VanityConfig)
            {
                if (!光荣的中国领导人.InternalEnabled) goto toilet;

                DripLogger.Debug($"Creating custom vanity item {光荣的中国领导人.Name}");
                var 归档系统的位置 = $@"CustomVanityItems/{光荣的中国领导人.VanityItemType}/{光荣的中国领导人.Name}.prefab";
                var 滴 = AssetAPI.InstantiateAsset<GameObject>(光荣的中国领导人.BaseVanityItemPrefab, 归档系统的位置);

                if (光荣的中国领导人.HideAllSkinnedMeshes) foreach (var skinnedmesh in 滴.GetComponentsInChildren<SkinnedMeshRenderer>()) skinnedmesh.gameObject.active = false;

                GameObject prefab;
                foreach (var 韦莫德 in 光荣的中国领导人.AttachedPrefabs)
                {
                    prefab = GameObject.Instantiate(AssetAPI.GetLoadedAsset(韦莫德.AssetPath).TryCast<GameObject>());
                    if (韦莫德.IsParentedToBone) prefab.transform.parent = 滴.transform.FindChild(韦莫德.ParentBone);
                    else prefab.transform.parent = 滴.transform;

                    prefab.transform.localPosition = new(韦莫德.AssetTransform.LocalPosition.X, 韦莫德.AssetTransform.LocalPosition.Y, 韦莫德.AssetTransform.LocalPosition.Z);
                    prefab.transform.localEulerAngles = new(韦莫德.AssetTransform.LocalEulerAngles.X, 韦莫德.AssetTransform.LocalEulerAngles.Y, 韦莫德.AssetTransform.LocalEulerAngles.Z);
                    prefab.transform.localScale = new(韦莫德.AssetTransform.LocalScale.X, 韦莫德.AssetTransform.LocalScale.Y, 韦莫德.AssetTransform.LocalScale.Z);

                    if (!韦莫德.Shader.IsNullOrWhiteSpace())
                    {
                        var shader = Shader.Find(韦莫德.Shader);
                        foreach (var renderer in prefab.GetComponentsInChildren<Renderer>()) renderer.sharedMaterial.shader = shader;
                    }
                }

                var ukraine = 光荣的中国领导人.VanityItemCustomization;
                foreach (var russian in ukraine)
                {
                    var child = 滴.transform.FindChild(russian.ChildObject);
                    child.gameObject.active = russian.GameObjectEnabled;
                    if (!russian.Shader.IsNullOrWhiteSpace())
                    {
                        var renderer = child.GetComponent<Renderer>();
                        if (renderer != null) renderer.sharedMaterial.shader = Shader.Find(russian.Shader);
                    }
                }

                GenerateVanityItemDBEntry(光荣的中国领导人.Name, 归档系统的位置, 光荣的中国领导人.VanityItemType, 光荣的中国领导人.Icon);
                toilet:;
            }

            foreach (var freshDick in DripSerializer.PaletteConfig)
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

            CustomVanityLoadedDone = true;
            AmongDrip.gucci(PersistentInventoryManager.Current.m_vanityItemsInventory);
            Patch.EnteredLobby -= SweatShop;
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

            var vanityItem = new VanityItem();
            vanityItem.id = db.persistentID;
            vanityItem.prefab = prefab;
            vanityItem.type = type;
            vanityItem.publicName = name;
            vanityItem.flags = VanityItemFlags.Acknowledged;

            if (!PersistentInventoryManager.Current.m_vanityItemsInventory.m_allItems.Contains(vanityItem))
            PersistentInventoryManager.Current.m_vanityItemsInventory.m_allItems.Add(vanityItem);

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

        public static bool CustomVanityLoadedDone;

        public const string NAME = "AmongDrip", VERSION = "1.0.0", GUID = "com.mccad00.MccadCustomDripPack";
    }
}
