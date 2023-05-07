// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.DialogCore.Services.Fullscreens
{
    internal interface IFullscreenService
    {
        ValueTask ExitFullscreenAsync();
        ValueTask<bool> IsElementInFullscreen(ElementReference elementReference);
        ValueTask RequestFullscreenAsync(ElementReference elementReference);
    }
}
