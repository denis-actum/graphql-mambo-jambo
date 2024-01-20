using NetConf.GraphQL.DataLoaders;
using NetConf.GraphQL.Integration;
using NetConf.GraphQL.Schema;

namespace NetConf.GraphQL.Resolvers
{
    public class MovieDetailsResolver
    {
        public async Task<MovieDetails?> Resolve(
            [Service] MoviesDetailsDataLoader dataLoader,
            [Parent] Movie movie)
        {
            return await dataLoader.LoadAsync(movie.Id);
        }
    }
}
