using System;
namespace Hamdoku {
    public sealed class ShopModule {
        bool disposed;
        // Reserved service entry points. Future SDK/transport callbacks must use Unity's main thread.
        // No orders, receipts, grants or ownership changes are simulated by this implementation.
        public void FetchCatalog(ShopRequest request, Action<ShopResultStatus> completed) {
            CheckAvailable();
            completed(ShopResultStatus.ServiceUnavailable);
        }
        public void Purchase(ShopRequest request, Action<ShopResultStatus> completed) {
            CheckAvailable();
            completed(ShopResultStatus.ServiceUnavailable);
        }
        public void Restore(ShopRequest request, Action<ShopResultStatus> completed) {
            CheckAvailable();
            completed(ShopResultStatus.ServiceUnavailable);
        }
        void CheckAvailable() {
            if (disposed) {
                throw new ObjectDisposedException(nameof(ShopModule));
            }
        }
        public void Dispose() {
            disposed = true;
        }
    }
}
