
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AccountMicroservice.Configuration;
using AccountMicroservice.Model;

namespace AccountMicroservice.Utils {
    
    public class DBUtils {

        public async Task<List<User>> RetrieveUsers(IConfiguration configuration) {
            HttpClient client = new HttpClient();
            List<User>? res;

            string microservice = "/User/get";
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
    }
}
