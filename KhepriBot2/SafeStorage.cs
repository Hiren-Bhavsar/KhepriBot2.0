using Newtonsoft.Json;

namespace KhepriBot2 {
    public class SafeStorage {

        [JsonProperty("safename")]
        public string safename { get; set; }

        [JsonProperty("khepris")]
        public int khepris { get; set; }

    }
}