using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.DialogCore.Brokers.JsRuntimes;
using Blazor.DialogCore.Clients.Fullscreens;
using Blazor.DialogCore.Services.Dialogs;
using Blazor.DialogCore.Services.Fullscreens;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.DialogCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDialogCore(this IServiceCollection services)
        {
            services.AddScoped<IJsRuntimeBroker, JsRuntimeBroker>();
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<IFullscreenService, FullscreenService>();
            services.AddScoped<IFullscreenClient, FullscreenClient>();
        }
    }
}