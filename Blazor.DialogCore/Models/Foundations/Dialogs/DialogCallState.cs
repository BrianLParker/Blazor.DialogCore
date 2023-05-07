// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.DialogCore.Models.Foundations.Dialogs
{
    internal class DialogCallState
    {
        public DotNetObjectReference<DialogCallState> DotNetObjectReference { get; set; }

        public ElementReference DialogElement { get; set; }

        public TaskCompletionSource<bool> TaskCompletionSource { get; set; }

        [JSInvokable]
        public void OnDialogClosed() => TaskCompletionSource.SetResult(true);

        public async ValueTask WaitForDialogClosedEventAsync() => await TaskCompletionSource.Task;
    }
}
