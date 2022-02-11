using GTFO.API;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    public class Torso_Mogu
    {
        public Torso_Mogu()
        {
            var moguTorso = AssetAPI.InstantiateAsset<GameObject>("ASSETS/ASSETPREFABS/CHARACTERS/PLAYERS/CLOTHES/TORSOS/TORSO003WOODS/TORSO003WOODS.PREFAB", "CustomTorso/Mogus.prefab");
            moguTorso.transform.FindChild("Arms003Woods").gameObject.active = false;
            moguTorso.name = "Torso_Mogu";
            moguTorso.AddComponent<CustomVanityItem>();

            EntryPoint.GenerateVanityItemDBEntry("Amogus", "CustomTorso/Mogus.prefab", ClothesType.Torso, "Assets/Bundle/Drip/Content/Icon_Mogu.png");
        }
    }
}
