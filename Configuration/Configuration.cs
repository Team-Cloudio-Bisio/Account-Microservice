using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AccountMicroservice.Configuration {
    public class Configuration : IConfiguration {

        private string MicroserviceConnString;

        public Configuration() {
            LoadMicroserviceConnectionString().Wait();
        }

        private async Task LoadMicroserviceConnectionString() {
            string connectionString;

            if (IsRunningOnAzure()) {
                connectionString = " ";
            }
            else {
                connectionString = "http://localhost:4000";
            }

            MicroserviceConnString = connectionString;
        }
        
        private bool IsRunningOnAzure() {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Release");
        }
        
        public string GetMicroserviceConnectionString() {
            return MicroserviceConnString;
        }
    }
}