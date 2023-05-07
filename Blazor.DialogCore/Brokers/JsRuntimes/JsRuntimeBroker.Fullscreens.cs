// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.DialogCore.Brokers.JsRuntimes
{
    internal partial class JsRuntimeBroker
    {
        public async ValueTask RequestFullscreenAsync(ElementReference elementReference)
        {
            IJSObjectReference jsModule = await this.moduleTask.Value;

            await jsModule.InvokeVoidAsync(
                  identifier: "requestFullscreen",
                  elementReference);
        }

        public async ValueTask ExitFullscreenAsync()
        {
            IJSObjectReference jsModule = await this.moduleTask.Value;

            await jsModule.InvokeVoidAsync(
                  identifier: "exitFullscreen");
        }

        public async ValueTask<bool> IsElementInFullscreen(ElementReference elementReference)
        {
            IJSObjectReference jsModule = await this.moduleTask.Value;

            bool isInFullScreen = await jsModule.InvokeAsync<bool>(
                  identifier: "isElementInFullscreen",
                  elementReference);

            return isInFullScreen;
        }
    }
}
