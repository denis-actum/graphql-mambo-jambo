namespace NetConf.GraphQL.Integration
{
    internal class MoviesDetailsRetriever
    {
        public async Task<IEnumerable<MovieDetailsDto>> GetMoviesDetails(int[] ids)
        {
            Console.WriteLine($"{nameof(GetMoviesDetails)} call");

            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5221/movies/{string.Join(",", ids)}/details");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<MovieDetailsDto>>();
        }
    }
}
