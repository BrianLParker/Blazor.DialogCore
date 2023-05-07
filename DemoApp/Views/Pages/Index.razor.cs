// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using Blazor.DialogCore.Clients.Fullscreens;
using Microsoft.AspNetCore.Components;

namespace DemoApp.Views.Pages
{
    public partial class Index
    {
        private ElementReference myDiv;
        private ElementReference myDiv2;

        [Inject]
        private IFullscreenClient FullscreenClient { get; set; }

        private async Task ButtonClicked() =>
            await FullscreenClient.RequestFullscreenAsync(this.myDiv);

        private async Task Button2Clicked() =>
            await FullscreenClient.RequestFullscreenAsync(this.myDiv2);

        private async Task ButtonClosed() =>
            await FullscreenClient.ExitFullscreenAsync();

    }
}