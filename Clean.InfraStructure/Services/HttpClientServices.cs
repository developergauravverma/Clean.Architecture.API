using Clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Clean.InfraStructure.Services
{
    public class HttpClientServices(HttpClient httpClient): IHttpClientServices
    {
        public async Task<Posts> GetData()
        {
            var posts = await httpClient.GetFromJsonAsync<IEnumerable<Post>>("https://jsonplaceholder.typicode.com/posts");
            return new Posts { PostsList = posts?.ToList() };
        }
    }
}
