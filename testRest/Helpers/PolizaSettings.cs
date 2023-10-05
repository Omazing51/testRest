namespace testRest.Helpers
{
    public class PolizaSettings : IPolizaSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
    }

    public interface IPolizaSettings
    {
        string Server { get; set; }
        string Database { get; set; }
    }
}
