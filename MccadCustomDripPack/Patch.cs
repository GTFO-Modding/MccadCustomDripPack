using HarmonyLib;
using Player;
using SNetwork;
using System;
using System.Collections.Generic;
using System.Text;
using GameData;
using RigTools;
using UnityEngine;
using AssetShards;

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
            localPlayer = PlayerManager.Current.m_localPlayerAgentInLevel;
            localPlayer.AnimatorArms.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3/Neck").gameObject.active = false;
            localPlayer.AnimatorBody.transform.FindChild("PlayerCharacter_rig/Root/Hip/Spine1/Spine2/Spine3/Neck").gameObject.active = false;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(GS_Lobby), nameof(GS_Lobby.Enter))]
        public static void GS_Lobby_Enter()
        {
            EnteredLobby?.Invoke();
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(GS_AfterLevel), nameof(GS_AfterLevel.Enter))]
        public static void GS_AfterLevel_Enter()
        {
            AfterLevel?.Invoke();
            if (localPlayer == null) return;
            localPlayer.AnimatorArms.transform.FindChild("Root/Hip/Spine1/Spine2/Spine3/Neck").gameObject.active = true;
            localPlayer.AnimatorBody.transform.FindChild("PlayerCharacter_rig/Root/Hip/Spine1/Spine2/Spine3/Neck").gameObject.active = true;
        }

        public static PlayerAgent localPlayer;
        public static event Action EnteredLobby;
        public static event Action DroppedIntoLevel;
        public static event Action AfterLevel;
    }
}
