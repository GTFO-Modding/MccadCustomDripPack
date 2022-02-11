using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Headgear_Mogu
    {
        public Headgear_Mogu()
        {
            var moguHeadgear = AssetAPI.InstantiateAsset<GameObject>("ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB", "CustomHeadgear/Mogus.prefab");
            foreach (var renderer in moguHeadgear.transform.FindChild("Headgear001").GetComponentsInChildren<SkinnedMeshRenderer>()) renderer.enabled = false;
            var moguAsset = GameObject.Instantiate(AssetAPI.GetLoadedAsset("Assets/Bundle/Drip/Content/Mask_Mogu.prefab").TryCast<GameObject>());
            moguAsset.transform.parent = moguHeadgear.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3");
            moguAsset.transform.localPosition = new(0, 0, 0.025f);
            moguAsset.transform.localEulerAngles = Vector3.zero;
            moguAsset.transform.localScale = new(1, 1.2f, 1.2f);
            moguAsset.transform.FindChild("Mask").GetComponent<MeshRenderer>().sharedMaterial.shader = moguHeadgear.transform.FindChild("Headgear001/Hood001").GetComponent<SkinnedMeshRenderer>().sharedMaterial.shader;
            moguHeadgear.name = "Headgear_Mogu";

            var comp = moguHeadgear.AddComponent<CustomVanityItem>();
            comp.ObjPathHideOnLoad.Add("Root/Hip/Spine1/Spine2/Spine3/Mask_Mogu(Clone)");
            //WHY DOESNT THIS WORK IM GONNA BLOW MY FUCKING LOAD

            EntryPoint.GenerateVanityItemDBEntry("Amogus", "CustomHeadgear/Mogus.prefab", ClothesType.Helmet, "Assets/Bundle/Drip/Content/Icon_Mogu.png");
        }
    }
}
