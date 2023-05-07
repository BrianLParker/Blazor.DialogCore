// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Blazor.DialogCore.Services.Fullscreens;
using Microsoft.AspNetCore.Components;

namespace Blazor.DialogCore.Clients.Fullscreens
{

    internal class FullscreenClient : IFullscreenClient
    {
        private readonly IFullscreenService fullscreenService;

        public FullscreenClient(IFullscreenService fullscreenService) =>
            this.fullscreenService = fullscreenService;

        public ValueTask ExitFullscreenAsync() =>
            this.fullscreenService.ExitFullscreenAsync();

        public async ValueTask<bool> IsElementInFullscreen(ElementReference elementReference) =>
            await this.fullscreenService.IsElementInFullscreen(elementReference);

        public async ValueTask RequestFullscreenAsync(ElementReference elementReference) =>
            await this.fullscreenService.RequestFullscreenAsync(elementReference);
    }
}
