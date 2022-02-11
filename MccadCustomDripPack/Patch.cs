using HarmonyLib;
using Player;
using SNetwork;
using System;
using System.Collections.Generic;
using System.Text;
using GameData;

namespace MccadCustomDripPack
{
    [HarmonyPatch]
    class Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(WardenObjectiveManager), nameof(WardenObjectiveManager.OnLocalPlayerStartExpedition))]
        public static void OnLocalPlayerStartExpedition()
        {
            DroppedIntoLevel?.Invoke();
            /*
            var vanityItemHelmetID = PlayerBackpackManager.GetBackpack(SNet.LocalPlayer).m_vanityItems[0];
            var vanityItemHelmetPath = VanityItemsTemplateDataBlock.GetBlock(vanityItemHelmetID).prefab;

            if (vanityItemHelmetPath != "CustomHeadgear/Mogus.prefab" &&
                vanityItemHelmetPath != "CustomHeadgear/Troll.prefab") return;
            DripLogger.Debug("Amogus helmet equipped, hiding FPS elements");

            var objPath = "";

            switch (vanityItemHelmetPath)
            {
                case "CustomHeadgear/Mogus.prefab": objPath = "Root/Hip/Spine1/Spine2/Spine3/Mask_Mogu(Clone)"; break;
                case "CustomHeadgear/Troll.prefab": objPath = "Root/Hip/Spine1/Spine2/Spine3/Neck/Head/Troll(Clone)"; break;
            }

            var localPlayer = PlayerManager.Current.m_localPlayerAgentInLevel;
            localPlayer.FPItemHolder.transform.FindChild("FPSBody_genericRigForClothes(Clone)/PlayerCharacter_rig/" + objPath).gameObject.active = false;
            localPlayer.FPSCamera.FlatTransform.FindChild("PlayerCharacter_rig(Clone)/PlayerCharacter_rig/" + objPath).gameObject.active = false;
            */
        }

        public static event Action DroppedIntoLevel;
    }
}
