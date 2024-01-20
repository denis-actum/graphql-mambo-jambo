using NetConf.GraphQL.Integration;
using NetConf.GraphQL.Schema;

namespace NetConf.GraphQL.DataLoaders;

public class MoviesDetailsDataLoader : BatchDataLoader<int, MovieDetails>
{
    public MoviesDetailsDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    {
    }

    protected override async Task<IReadOnlyDictionary<int, MovieDetails>> LoadBatchAsync(
        IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var retriever = new MoviesDetailsRetriever();

        var moviesDetailsDtos = await retriever.GetMoviesDetails(keys.ToArray());

        var dictionary = moviesDetailsDtos.ToDictionary(
            k => k.Id,
            v => new MovieDetails
            {
                Id = v.Id,
                Description = v.Description,
                PosterUrl = v.PosterUrl,
                Rating = v.Rating
            });

        return dictionary;
    }
}
