using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentDBTestConsole
{
    public class AnalyzedMessage
    {
        public string userId { get; set; }

        public string message { get; set; }

        public double sentimentScore { get; set; }
    }
}
