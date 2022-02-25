using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Headgear_Elite
    {
        public Headgear_Elite()
        {
            var eliteHeadgear = AssetAPI.InstantiateAsset<GameObject>("ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB", "CustomHeadgear/Elite.prefab");
            eliteHeadgear.transform.FindChild("Headgear001/Headgear_7:Headgear_7_1").gameObject.active = false;
            eliteHeadgear.transform.FindChild("Headgear001/Headgear_7:Headgear_Glass_7_1").gameObject.active = false;

            var shader = eliteHeadgear.transform.FindChild("Headgear001/Headgear_7:Headgear_7_1").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial.shader;

            var eliteAsset = GameObject.Instantiate(AssetAPI.GetLoadedAsset("Assets/Bundle/Drip/Content/CustomMask.prefab").TryCast<GameObject>());
            var protectedMat = eliteAsset.transform.FindChild("Headgear_Glass_3_1").GetComponent<MeshRenderer>().sharedMaterial;
            eliteAsset.transform.parent = eliteHeadgear.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3/Neck/Head");
            eliteAsset.transform.localPosition = Vector3.zero;
            foreach (var renderer in eliteAsset.GetComponentsInChildren<Renderer>())
            {
                if (renderer.sharedMaterial == protectedMat) continue;
                renderer.sharedMaterial.shader = shader;
            }

            eliteHeadgear.name = "Headgear_Elite";

            EntryPoint.GenerateVanityItemDBEntry("Elite", "CustomHeadgear/Elite.prefab", ClothesType.Helmet, "Assets/Bundle/Drip/Content/IconElite.png");
        }
    }
}
