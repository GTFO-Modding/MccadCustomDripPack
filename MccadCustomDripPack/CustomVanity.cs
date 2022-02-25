using System;
using System.Collections.Generic;
using System.Text;

namespace MccadCustomDripPack
{
    class CustomVanity
    {
        public string Name { get; set; } = "";
        public ClothesType VanityItemType { get; set; } = ClothesType.Helmet;
        public string Icon { get; set; } = "";
        public string BaseVanityItemPrefab { get; set; } = "";
        public bool InternalEnabled { get; set; } = false;
        public bool HideAllSkinnedMeshes { get; set; } = false;
        public List<BaseGOCustomization> BaseVanityItemCustomization { get; set; } = new();
        public List<CustomAsset> AttachedPrefabs { get; set; } = new();
    }

    class CustomAsset
    {
        public string AssetPath { get; set; } = "";
        public bool GameObjectEnabled { get; set; } = true;
        public bool IsParentedToBone { get; set; } = true;
        public string ParentBone { get; set; } = "Root";
        public string Shader { get; set; } = "";
        public Transform AssetTransform { get; set; } = new();
    }

    class BaseGOCustomization
    {
        public string ChildObject { get; set; } = "";
        public bool GameObjectEnabled { get; set; } = false;
    }

    class Transform
    {
        public JsonVector3 LocalPosition { get; set; } = new();
        public JsonVector3 LocalEulerAngles { get; set; } = new();
        public JsonVector3 LocalScale { get; set; } = new(1, 1, 1);
    }

    class JsonVector3
    {
        public JsonVector3(float x = 0, float y = 0, float z = 0)
        {
            X = x; Y = y; Z = z;
        }
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Z { get; set; } = 0;
    }
}
