using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nyous_mongo.Context
{
    public class NyousDatabaseSettings : INyousDatabaseSettings
    {
        public string EventoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface INyousDatabaseSettings
    {
        public string EventoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
