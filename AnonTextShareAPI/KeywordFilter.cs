﻿using System;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Net.Mime.MediaTypeNames;

namespace AnonTextShareAPI
{
    public class KeywordFilter
    {
        enum BannedKeyword
        {
            Fuck,
            Blatant,
            Bitch,
            Nigga,
            Shit
        }
        public bool FilterText(string text)
        {
            foreach (string bannedKeyword in Enum.GetNames(typeof(BannedKeyword)))
            {
                if (text.Contains(bannedKeyword, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }
    }
}