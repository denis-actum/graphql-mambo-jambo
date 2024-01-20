using NetConf.GraphQL.DataLoaders;
using NetConf.GraphQL.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<MovieType>()
    .AddDataLoader<MoviesDetailsDataLoader>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
