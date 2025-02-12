﻿using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace EasyOposUI
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
            builder.Services.AddMemoryCache();
            builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("jobTitle", "Admin");
                });
            });

            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddTransient<IBlockData, MongoBlockData>();
            builder.Services.AddTransient<IOptionData, MongoOptionData>();
            builder.Services.AddTransient<IQuestionData, MongoQuestionData>();
            builder.Services.AddTransient<IUnitData, MongoUnitData>();
            builder.Services.AddTransient<IUserData, MongoUserData>();
        }
    }
}
