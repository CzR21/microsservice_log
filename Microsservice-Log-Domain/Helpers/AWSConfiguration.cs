using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Domain.Helpers
{
    public class AWSConfiguration
    {
        public string AWSAccessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string AWSRegion { get; set; }
        public string LogGroupName { get; set; }
        public string LogStreamName { get; set; }
    }
}
