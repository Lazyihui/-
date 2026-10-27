namespace Hamdoku {
    public sealed class ShopState {
        public bool isOpen;
        public bool openedFromGame;
        public bool disposed;
        public bool requestPending;
        public int requestId;
        public ShopRequestType requestType;
        public ShopResultStatus result;
        public bool dialogOpen;
        public bool autoDemo;
        public int selectedProductId;
    }
}
