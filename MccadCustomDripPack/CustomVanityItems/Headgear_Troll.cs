using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Headgear_Troll
    {
        public Headgear_Troll()
        {
            var troll = AssetAPI.InstantiateAsset<GameObject>("ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/HEADGEARS/HEADGEAR001/HEADGEAR001.PREFAB", "CustomHeadgear/Troll.prefab");
            foreach (var renderer in troll.GetComponentsInChildren<SkinnedMeshRenderer>()) renderer.enabled = false;
            var trollAsset = GameObject.Instantiate(AssetAPI.GetLoadedAsset("Assets/Bundle/Drip/Content/Troll.prefab").TryCast<GameObject>());
            trollAsset.transform.parent = troll.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3/Neck/Head");
            trollAsset.transform.localPosition = new(0, 0.06f, 0.06f);
            trollAsset.transform.localEulerAngles = Vector3.zero;
            troll.name = "Headgear_Troll";

            var comp = troll.AddComponent<CustomVanityItem>();
            comp.ObjPathHideOnLoad.Add("Root/Hip/Spine1/Spine2/Spine3/Neck/Head/Troll(Clone)");

            EntryPoint.GenerateVanityItemDBEntry("Troll", "CustomHeadgear/Troll.prefab", ClothesType.Helmet, "Assets/Bundle/Drip/Content/Icon_Troll.png");
        }
    }
}
