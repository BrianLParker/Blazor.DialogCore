// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Blazor.DialogCore.Brokers.JsRuntimes;
using Blazor.DialogCore.Models.Foundations.Dialogs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.DialogCore.Services.Dialogs
{
    internal class DialogService : IDialogService
    {
        private readonly IJsRuntimeBroker jsRuntimeBroker;

        internal DialogService(IJsRuntimeBroker jsRuntimeBroker) =>
            this.jsRuntimeBroker = jsRuntimeBroker;

        public async ValueTask ShowDialogAsync(ElementReference dialogElementReference)
        {
            DialogCallState dialogCallState = new DialogCallState
            {
                TaskCompletionSource = new TaskCompletionSource<bool>()
            };

            DotNetObjectReference<DialogCallState> dotNetObjectReference =
                DotNetObjectReference.Create(dialogCallState);

            dialogCallState.DotNetObjectReference = dotNetObjectReference;
            await this.jsRuntimeBroker.AddCloseDialogListenerAsync(dialogElementReference, dotNetObjectReference);
            await this.jsRuntimeBroker.ShowDialogAsync(dialogElementReference);

            await dialogCallState.WaitForDialogClosedEventAsync();
        }
    }
}
