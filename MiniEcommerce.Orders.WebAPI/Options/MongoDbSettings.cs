namespace MiniEcommerce.Orders.WebAPI.Options
{
    public sealed record MongoDbSettings
    {
        public MongoDbSettings()
        {
        }

        public string ConnectioNString { get; init; }
        public string DatabaseName { get; init; }


    }
}