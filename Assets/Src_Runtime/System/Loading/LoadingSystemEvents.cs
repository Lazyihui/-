using System;

namespace Hamdoku {
    public sealed class LoadingSystemEvents {
        public Action readyHandle;
        public Action<Exception> errorHandle;
    }
}
