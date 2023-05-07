// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Blazor.DialogCore.Models.Foundations.Dialogs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.DialogCore.Brokers.JsRuntimes
{
    internal interface IJsRuntimeBroker
    {
        ValueTask AddCloseDialogListenerAsync(
            ElementReference dialogElementReference,
            DotNetObjectReference<DialogCallState> dotNetObjectReference);
        ValueTask ExitFullscreenAsync();
        ValueTask<bool> IsElementInFullscreen(ElementReference elementReference);

        ValueTask RequestFullscreenAsync(ElementReference elementReference);

        ValueTask ShowDialogAsync(ElementReference dialogElementReference);
    }
}
