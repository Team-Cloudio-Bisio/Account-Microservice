
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AccountMicroservice.Model;

namespace AccountMicroservice.Utils {
    
    public class DBUtils {

        public async Task<List<User>> RetrieveUsers() {
            HttpClient client = new HttpClient();
            List<User>? res;
            string endpoint = "";

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development")) endpoint = "http://localhost:4000/User";
            else endpoint = "http://dmbicroservice:80/User";

            var response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonSerializer.Deserialize<List<User>>(content);

                return res;
            }
            return null;
        }
        
        public async Task<bool> AddUser(User user) {
            HttpClient client = new HttpClient();
            List<User>? res;
            string endpoint = "";

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development")) endpoint = "http://localhost:4000/User";
            else endpoint = "http://dmbicroservice:80/User";
            
            var response = await client.PostAsync(endpoint, new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, MediaTypeNames.Application.Json));

            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;
        }
    }
}
