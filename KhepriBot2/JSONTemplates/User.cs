using Newtonsoft.Json;

namespace KhepriBot2.JSONTemplates {
    public class User {

        [JsonProperty("username")]
        public string username { get; private set; }

        [JsonProperty("discrim")]
        public string discrim { get; private set; }

        [JsonProperty("khepris")]
        public int khepris { get; set; }

        [JsonProperty("id")]
        public string id { get; private set; }

        [JsonProperty("nickname")]
        public string nickname { get; set; }

        [JsonProperty("safename")]
        public string safename { get; set; }
    }
}