
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AccountMicroservice.Configuration;
using AccountMicroservice.Model;

namespace AccountMicroservice.Utils {
    
    public class DBUtils {

        public async Task<List<User>> RetrieveUsers(AccountMicroservice.Configuration.IConfiguration configuration) {
            HttpClient client = new HttpClient();
            List<User>? res;

            string microservice = "/User";
            string connString = configuration.GetMicroserviceConnectionString();

            string endpoint = connString + microservice;

            var response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonSerializer.Deserialize<List<User>>(content);

                return res;
            }
            return null;
        }
        
        public async Task<bool> AddUser(AccountMicroservice.Configuration.IConfiguration configuration, User user) {
            HttpClient client = new HttpClient();
            List<User>? res;

            string microservice = "/User";
            string connString = configuration.GetMicroserviceConnectionString();

            string endpoint = connString + microservice;

            var response = await client.PostAsync(endpoint, new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, MediaTypeNames.Application.Json));

            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;
        }
    }
}
