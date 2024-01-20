using NetConf.GraphQL.Resolvers;

namespace NetConf.GraphQL.Schema
{
    public class Query
    {
        public async Task<IEnumerable<Movie>> GetMovies() 
            => await new MoviesResolver().GetMovies();
    }

    public class MovieType : ObjectType<Movie>
    {
        protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
        {
            descriptor
                .Field(x => x.MovieDetails)
                .ResolveWith<MovieDetailsResolver>(x => x.Resolve(default, default));
        }
    }
}
