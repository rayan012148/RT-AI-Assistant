using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RT_AI_Assistant
{
    public class GPTService
    {
        private readonly string apiKey = "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";

        public async Task<string> AskGPT(string prompt)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var json = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(json);
            return result.choices[0].message.content.ToString();
        }
    }
}
