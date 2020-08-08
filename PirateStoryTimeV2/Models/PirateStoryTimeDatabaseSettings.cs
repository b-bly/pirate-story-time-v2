using System;
namespace PirateStoryTimeV2.Models
{
    public class PirateStoryTimeDatabaseSettings: IPirateStoryTimeDatabaseSettings
    {
        public string CardCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPirateStoryTimeDatabaseSettings
    {
        string CardCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
