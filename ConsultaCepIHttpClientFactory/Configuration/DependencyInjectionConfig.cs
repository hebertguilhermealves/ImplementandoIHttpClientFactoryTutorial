using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Polly;
using Integrations;
using System.Net.Http;
using Domains.Interfaces;
using Polly.Extensions.Http;
using System.Net.Http.Headers;

namespace ConsultaCepIHttpClientFactory.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            //aplicando configurações de Polly
            services.AddTransient<IHttpInstance, HttpInstance>();

            services.AddHttpClient("ViaCep", client =>
            {
                client.BaseAddress = new Uri("https://viacep.com.br/ws/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddPolicyHandler(GetRetryPolicy());

        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
