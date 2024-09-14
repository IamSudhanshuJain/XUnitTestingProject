using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SiteAnalyzer
    {
        private readonly HttpClient _httpClient;
        public SiteAnalyzer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetContentSize(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            return content.Length;
        }

    }
}
