namespace NetConf.GraphQL.Schema
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MovieDetails MovieDetails { get; set; }
    }
}
