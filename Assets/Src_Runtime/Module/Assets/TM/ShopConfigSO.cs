using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Hamdoku/Shop Config")]
    public sealed class ShopConfigSO : ScriptableObject {
        public ShopProductModel[] products;
        public float referenceWidth = 1080;
        public float columnWidth = 920;
        public float padSide = 36;
        public float padTop = 20;
        public float padBottom = 48;
        public float cardGap = 30;
        public float headerHeight = 410;
        public float offerCardH = 500;
        public float itemCardH = 420;
        public float adsCardH = 450;
        public float titleBannerWidth = 880;
        public float titleFs = 75;
        public float closeSize = 100;
        public float offerTitleFs = 45;
        public float offerArtSize = 260;
        public float offerTileW = 120;
        public float offerTileGap = 12;
        public float offerPriceFs = 42;
        public float adsTitleFs = 40;
        public float adsDescFs = 26;
        public float adsPriceFs = 30;
        public float dialogWidth = 850;
        public float dialogHeight = 1100;
        public float demoStepSeconds = 0.6f;
        public float minimumLayoutHeight = 960;
        public Color cardShadowColor = new Color(.42f, .30f, .16f, .19607843f);
        public Vector2 cardShadowOffset = new Vector2(0, -5);
        public float cardShadowSpread = 20;
        public Color tileShadowColor = new Color(.42f, .30f, .16f, .39215687f);
        public Vector2 tileShadowOffset = new Vector2(0, -3);
        public float tileShadowSpread = 14;
        public Color adsButtonShadowColor = new Color(.42f, .30f, .16f, .34f);
        public Vector2 adsButtonShadowOffset = new Vector2(0, -16);
        public float adsButtonShadowSpread = 13;
        public Color artShadowColor = new Color(.42f, .30f, .16f, .34f);
        public Vector2 artShadowOffset = new Vector2(0, -10);
        public float artShadowSpread = 7;
        public int artShadowSteps = 6;
    }
}
