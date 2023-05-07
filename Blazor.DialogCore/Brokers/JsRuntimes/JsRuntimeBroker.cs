// ------------------------------------------------------------
// Copyright (c) 2022, Brian Parker All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.DialogCore.Brokers.JsRuntimes
{
    internal partial class JsRuntimeBroker : IJsRuntimeBroker
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsRuntimeBroker(IJSRuntime jsRuntime)
        {
            this.moduleTask = new(() => jsRuntime!.InvokeAsync<IJSObjectReference>(
                identifier: "import",
                args: "./_content/Blazor.DialogCore/JsRuntimeBroker.js").AsTask());
        }
    }
}
