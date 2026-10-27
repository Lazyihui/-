using System;
namespace Hamdoku {
    [Serializable]
    public sealed class ShopProductModel {
        public int id;
        public string productId;
        public string sku;
        public ShopSectionType section;
        public UINameType name;
        public UINameType description;
        public UINameType duration;
        public string referencePrice;
        public int magnifiers;
        public int hints;
        public int adFreeHours;
        public bool adFreeForever;
        public bool autoMark;
        public int maxPurchases;
        public int offerHours;
        public int offerCooldownHours;
    }
}
