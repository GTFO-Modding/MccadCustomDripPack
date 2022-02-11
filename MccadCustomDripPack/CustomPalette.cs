using System;
using System.Collections.Generic;
using System.Text;

namespace MccadCustomDripPack
{
    public class CustomPalette
    {
        public string Name { get; set; } = "name";
        public JsonColor PrimaryColor { get; set; } = new(0, 0, 0, 0);
        public JsonColor SecondaryColor { get; set; } = new(0, 0, 0, 0);
        public JsonColor TertiaryColor { get; set; } = new(0, 0, 0, 0);
        public JsonColor QuaternaryColor { get; set; } = new(0, 0, 0, 0);
        public JsonColor QuinaryColor { get; set; } = new(0, 0, 0, 0);
        public float TextureTiling { get; set; } = 0.5f;
    }

    public class JsonColor
    {
        public JsonColor() {}
        public JsonColor(float r, float g, float b, int texture) { R = r; G = g; B = b; Texture = (ToneTexture)texture; }
        public float R { get; set; } = 0;
        public float G { get; set; } = 0;
        public float B { get; set; } = 0;
        public ToneTexture Texture { get; set; } = ToneTexture.None;
    }

    public enum ToneTexture
    {
        None = 0, 
        [TextureMap(TextureName = "UI_Pattern_A")]
        Plaid = 1,
        [TextureMap(TextureName = "AlphaBlob")]
        CamoLarge1 = 2,
        [TextureMap(TextureName = "mask_F_mt")]
        PaintSplash = 3,
        [TextureMap(TextureName = "Scanline")]
        Scanlines = 4,
        [TextureMap(TextureName = "T_Noise_Directional_Horizontal2")]
        GradientStripes = 5,
        [TextureMap(TextureName = "cortex_256")]
        Cortex = 6,
        [TextureMap(TextureName = "henke_face_mt")]
        DustedPaint = 7,
        [TextureMap(TextureName = "T_SmokeLong_01")]
        Polkadots1 = 8,
        [TextureMap(TextureName = "TestGlass")]
        BigStainedGlass = 9,
        [TextureMap(TextureName = "WarpDust")]
        TinyDust = 10,
        [TextureMap(TextureName = "Nanobot")]
        HeatGradient = 11,
        [TextureMap(TextureName = "MuzzleFlash_Synced")]
        Pizza = 12,
        [TextureMap(TextureName = "FireSprite")]
        Fireballs = 13,
        [TextureMap(TextureName = "CellularNormal_blurred")]
        Scales = 14,
        [TextureMap(TextureName = "Water_Droplets")]
        SmallStainedGlass = 15,
        [TextureMap(TextureName = "fx_tex_smoke_swirly_01_Diffuse")]
        CamoLarge2 = 16,
        [TextureMap(TextureName = "080_PolyesterHoles_Masks")]
        BlueGreenDots = 17,
        [TextureMap(TextureName = "symbol_hazard_high_bg")]
        BlueRedPattern = 18,
        [TextureMap(TextureName = "Intro_Scare1")]
        GreenBluePattern = 19,
        [TextureMap(TextureName = "TrailFalloff_a")]
        SubtleGradient = 20,
        [TextureMap(TextureName = "GUI_Structure")]
        Stripes = 21,
        [TextureMap(TextureName = "supremedrip")]
        GokuDrip = 22,
        [TextureMap(TextureName = "emoji")]
        Emoji = 23,
        [TextureMap(TextureName = "camo1")]
        WoodlandCamo = 24,
        [TextureMap(TextureName = "camo2")]
        AlpineCamo = 25,
        [TextureMap(TextureName = "camo3")]
        DigitalCamo = 26,
        [TextureMap(TextureName = "virgin")]
        Anime = 27
    }
    public class TextureMapAttribute : Attribute
    {
        public string TextureName { get; set; }
    }
}
