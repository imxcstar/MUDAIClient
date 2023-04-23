using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUDAIClient
{
    public class Config
    {
        public string Address { get; set; }
        public ushort Port { get; set; }
        public string Encoding { get; set; } = "GBK";
        public bool EnableAIParseGameMessage { get; set; } = false;
        public bool EnableAIParsePlayerCommand { get; set; } = false;
        public string OpenAIApiKey { get; set; }
        public string OpenAIProxy { get; set; }
    }
}
