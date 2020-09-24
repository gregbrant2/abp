﻿using Microsoft.Extensions.DependencyInjection;
using MyCompanyName.MyProjectName.Blazor;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.Blazor.Menus;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.TenantManagement.Blazor
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpTenantManagementHttpApiClientModule)
        )]
    public class AbpTenantManagementBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpTenantManagementBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpTenantManagementBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new TenantManagementBlazorMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpTenantManagementBlazorModule).Assembly);
            });
        }
    }
}