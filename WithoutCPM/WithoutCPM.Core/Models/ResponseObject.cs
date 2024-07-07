using Newtonsoft.Json;

namespace WithoutCPM.Core
{
    public class ResponseObject
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "data")]
        public ObjectDetail Data { get; set; }
    }

    public class ObjectDetail
    {
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "Capacity")]
        public string Capacity { get; set; }

        [JsonProperty(PropertyName = "capacity GB")]
        public string CapacityGB { get; set; }

        [JsonProperty(PropertyName = "Generation")]
        public string Generation { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "CPU model")]
        public string CPUModel { get; set; }

        [JsonProperty(PropertyName = "Hard disk size")]
        public string HardDiskSize { get; set; }

        [JsonProperty(PropertyName = "Screen size")]
        public decimal ScreenSize { get; set; }

        [JsonProperty(PropertyName = "Strap Colour")]
        public string StrapColour { get; set; }
    }
}
