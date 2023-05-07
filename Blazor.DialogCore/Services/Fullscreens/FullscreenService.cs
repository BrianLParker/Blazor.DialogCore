// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Blazor.DialogCore.Brokers.JsRuntimes;
using Microsoft.AspNetCore.Components;

namespace Blazor.DialogCore.Services.Fullscreens
{
    internal class FullscreenService : IFullscreenService
    {
        private readonly IJsRuntimeBroker jsRuntimeBroker;

        public FullscreenService(IJsRuntimeBroker jsRuntimeBroker) =>
            this.jsRuntimeBroker = jsRuntimeBroker;

        public async ValueTask<bool> IsElementInFullscreen(ElementReference elementReference) =>
            await this.jsRuntimeBroker.IsElementInFullscreen(elementReference);

        public async ValueTask RequestFullscreenAsync(ElementReference elementReference) =>
            await this.jsRuntimeBroker.RequestFullscreenAsync(elementReference);

        public async ValueTask ExitFullscreenAsync() =>
            await this.jsRuntimeBroker.ExitFullscreenAsync();
    }
}
