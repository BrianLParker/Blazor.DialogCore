// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.DialogCore.Views.Components.Bases
{
    public partial class DialogBase : ComponentBase, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private DotNetObjectReference<DialogBase> dotNetObjectReference;
        private ElementReference dialogElement;

        public DialogBase()
        {
            moduleTask = new(() => jsRuntime!.InvokeAsync<IJSObjectReference>(
                identifier: "import",
                args: "./_content/Blazor.DialogCore/Views/Components/Bases/DialogBase.razor.js").AsTask());

            dotNetObjectReference = DotNetObjectReference.Create(this);
        }

        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> CapturedAttributes { get; set; }

        [Parameter]
        public EventCallback<bool> DialogClosed { get; set; }

        public bool IsDialogVisible { get; private set; } = false;

        public async ValueTask ShowDialogAsync()
        {
            IJSObjectReference jsModule = await moduleTask.Value;

            await jsModule.InvokeVoidAsync(identifier: "showDialog", dialogElement);

            this.IsDialogVisible = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(
                    identifier: "addCloseEventListener",
                    dialogElement,
                    dotNetObjectReference);
            }
        }

        public async ValueTask CloseDialogAsync()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(identifier: "closeDialog", dialogElement);
            this.IsDialogVisible = false;
        }

        [JSInvokable]
        public void OnDialogClosed()
        {
            IsDialogVisible = false;
            DialogClosed.InvokeAsync(IsDialogVisible);
            StateHasChanged();
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
