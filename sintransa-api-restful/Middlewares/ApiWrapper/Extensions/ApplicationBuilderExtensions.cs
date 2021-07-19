﻿using Microsoft.AspNetCore.Builder;

namespace sintransa_api_restful.Middlewares.ApiWrapper
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiWrapperMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<ApiWrapperMiddleware>();
    }
}
