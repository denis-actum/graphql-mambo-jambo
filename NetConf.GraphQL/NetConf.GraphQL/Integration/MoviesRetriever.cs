namespace NetConf.GraphQL.Integration
{
    internal class MoviesRetriever
    {
        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5221/movies");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<MovieDto>>();
        }
    }
}
