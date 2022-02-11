using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Backpack_Empty
    {
        public Backpack_Empty()
        {
            var noBackpack = AssetAPI.InstantiateAsset<GameObject>("ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/BACKPACKS/BACKPACK001/BACKPACK001.PREFAB", "CustomBackpack/Empty.prefab");
            foreach (var renderer in noBackpack.GetComponentsInChildren<SkinnedMeshRenderer>()) renderer.enabled = false;
            noBackpack.name = "Backpack_Empty";
            noBackpack.AddComponent<CustomVanityItem>();

            EntryPoint.GenerateVanityItemDBEntry("Empty", "CustomBackpack/Empty.prefab", ClothesType.Backpack);
        }
    }
}
