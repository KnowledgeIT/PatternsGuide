using Microsoft.Extensions.Configuration;
using System;

namespace Sales.CrossCutting.Extensions
{
    public static class EnvironmentVariableExtension
    {
        public static string GetConnectionStringFromEnvironment(this ConfigurationBuilder configuration, string name) =>
            Environment.GetEnvironmentVariable(name);
    }
}