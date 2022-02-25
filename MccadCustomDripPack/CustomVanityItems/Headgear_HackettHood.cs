using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Headgear_HackettHood
    {
        public Headgear_HackettHood()
        {
            var hacketthoodie = AssetAPI.InstantiateAsset<GameObject>("Assets/AssetPrefabs/Characters/Players/Clothes/Headgears/Headgear002Hackett/Headgear002Hackett.prefab", "CustomHeadgear/HackettHood.prefab");
            hacketthoodie.transform.FindChild("Headgear_Hackett/g_hackett_mask").gameObject.active = false;
            hacketthoodie.transform.FindChild("Headgear_Hackett/g_hackett_mask_1").gameObject.active = false;

            hacketthoodie.name = "Headgear_HackettHood";

            EntryPoint.GenerateVanityItemDBEntry("Hackett's Hood", "CustomHeadgear/HackettHood.prefab", ClothesType.Helmet, "Assets/Bundle/Drip/Content/hackettHoodIcon.png");
        }
    }
}
