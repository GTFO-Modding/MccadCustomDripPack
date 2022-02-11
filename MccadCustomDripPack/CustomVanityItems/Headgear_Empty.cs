using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Headgear_Empty
    {
        public Headgear_Empty()
        {
            AssetAPI.RegisterAsset("AmongDrip/Empty.png", new Texture2D(0, 0));

            var safetyHazard = AssetAPI.InstantiateAsset<GameObject>("ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB", "CustomHeadgear/Empty.prefab");
            foreach (var renderer in safetyHazard.transform.FindChild("Headgear001").GetComponentsInChildren<SkinnedMeshRenderer>()) renderer.enabled = false;
            safetyHazard.name = "Headgear_Empty";
            safetyHazard.AddComponent<CustomVanityItem>();

            EntryPoint.GenerateVanityItemDBEntry("Empty", "CustomHeadgear/Empty.prefab", ClothesType.Helmet);
        }
    }
}
