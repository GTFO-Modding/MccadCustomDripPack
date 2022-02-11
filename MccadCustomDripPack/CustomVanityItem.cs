using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MccadCustomDripPack
{
    class CustomVanityItem : MonoBehaviour
    {
        public CustomVanityItem(IntPtr value) : base(value) { }

        public void Awake()
        {
            Patch.DroppedIntoLevel += OnLocalPlayerStartExpedition;
        }

        public void OnLocalPlayerStartExpedition()
        {
            foreach (var str in ObjPathHideOnLoad)
            {
                transform.FindChild(str).gameObject.active = false;
            }
        }

        public List<string> ObjPathHideOnLoad = new();
    }
}
