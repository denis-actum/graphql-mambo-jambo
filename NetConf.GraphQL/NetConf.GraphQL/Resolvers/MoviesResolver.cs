using NetConf.GraphQL.Integration;
using NetConf.GraphQL.Schema;

namespace NetConf.GraphQL.Resolvers
{
    public class MoviesResolver
    {
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var retriever = new MoviesRetriever();

            var moviesDtos = await retriever.GetMovies();

            return moviesDtos.Select(x => new Movie { Id = x.Id, Name = x.Title });
        }
    }
}
