using System;
using Newtonsoft.Json;

namespace KhepriBot2.JSONTemplates {
    public struct ConfigJson {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
    }
}