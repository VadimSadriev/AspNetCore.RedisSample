using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisSample.Configuration
{
    public class RedisCacheSettings
    {
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }
    }
}
