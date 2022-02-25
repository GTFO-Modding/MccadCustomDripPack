using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Torso_Elite
    {
        public Torso_Elite()
        {
            var eliteTorso = AssetAPI.InstantiateAsset<GameObject>("Assets/AssetPrefabs/Characters/Players/Clothes/Torsos/Torso001c/Torso001c.prefab", "CustomTorso/EliteHeavy.prefab");

            var eliteTorsoChestAsset = GameObject.Instantiate<GameObject>(AssetAPI.GetLoadedAsset("Assets/Bundle/Drip/Content/ChestArmor.prefab").TryCast<GameObject>());
            eliteTorsoChestAsset.transform.parent = eliteTorso.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3");
            eliteTorsoChestAsset.transform.localPosition = new(0f, -0.11f, 0f);

            var eliteTorsoShoulderAsset = GameObject.Instantiate<GameObject>(AssetAPI.GetLoadedAsset("Assets/Bundle/Drip/Content/ShoulderArmor.prefab").TryCast<GameObject>());
            eliteTorsoShoulderAsset.transform.parent = eliteTorso.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3/LeftShoulder");
            eliteTorsoShoulderAsset.transform.localPosition = new(0f, 0f, 0f);

            foreach (var renderer in eliteTorsoChestAsset.GetComponentsInChildren<Renderer>()) renderer.sharedMaterial.shader = Shader.Find("Cell/Player/CustomGearShader");
            foreach(var renderer in eliteTorsoShoulderAsset.GetComponentsInChildren<Renderer>()) renderer.sharedMaterial.shader = Shader.Find("Cell/Player/CustomGearShader");
            foreach(var renderer in eliteTorsoShoulderAsset.transform.FindChild("ApplyPaletteShader").gameObject.GetComponentsInChildren<Renderer>()) renderer.sharedMaterial.shader = Shader.Find("GTFO/Persistence/Clothing");

            eliteTorso.name = "Torso_EliteHeavy";

            EntryPoint.GenerateVanityItemDBEntry("Kovac Pro-Car Heavy Elite", "CustomTorso/EliteHeavy.prefab", ClothesType.Torso, "Assets/Bundle/Drip/Content/IconEliteTorso.png");
        }
    }
}
