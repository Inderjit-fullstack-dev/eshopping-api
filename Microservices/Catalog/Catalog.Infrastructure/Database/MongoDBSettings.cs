namespace Catalog.Infrastructure.Database
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatbaseName { get; set; }
        public string ProductCollection { get; set; }
        public string BrandCollection { get; set; }
        public string ProductTypeCollection { get; set; }
    }
}
