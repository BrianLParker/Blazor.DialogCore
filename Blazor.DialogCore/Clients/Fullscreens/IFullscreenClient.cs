// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blazor.DialogCore.Clients.Fullscreens
{
    public interface IFullscreenClient
    {
        ValueTask<bool> IsElementInFullscreen(ElementReference elementReference);
        ValueTask RequestFullscreenAsync(ElementReference elementReference); 
        ValueTask ExitFullscreenAsync();
    }
}
