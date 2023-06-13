using System;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AnonTextShareAPI
{
    public class RuntimeConfig
    {
        public int MaxTitleChars { get; set; }
        public int MaxTextChars { get; set; }

        public RuntimeConfig(int MaxTitleChars, int MaxTextChars)
        {
            this.MaxTitleChars = MaxTitleChars;
            this.MaxTextChars = MaxTextChars;
        }
    }
}

