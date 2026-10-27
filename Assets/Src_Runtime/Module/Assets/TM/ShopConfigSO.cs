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
    }
}
