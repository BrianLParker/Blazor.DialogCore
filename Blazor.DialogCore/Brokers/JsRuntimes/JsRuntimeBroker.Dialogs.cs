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
    internal partial class JsRuntimeBroker
    {
        public async ValueTask ShowDialogAsync(ElementReference dialogElementReference)
        {
            IJSObjectReference jsModule = await this.moduleTask.Value;

            await jsModule.InvokeVoidAsync(identifier: "showDialog", dialogElementReference);
        }

        public async ValueTask AddCloseDialogListenerAsync(
            ElementReference dialogElementReference,
            DotNetObjectReference<DialogCallState> dotNetObjectReference)
        {
            IJSObjectReference jsModule = await this.moduleTask.Value;

            await jsModule.InvokeVoidAsync(
                  identifier: "addCloseEventListener",
                  dialogElementReference,
                  dotNetObjectReference);
        }
    }
}
