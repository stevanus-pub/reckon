using System.Text.Json.Serialization;

namespace Models
{
    public record SubTextsSearchResult(string subtext)
    {
        public string Result
        {
            get
            {
                return Indexes?.Length > 0 ? string.Join(", ", Indexes) : "<No Output>";
            }
        }

        [JsonIgnore]
        public int[]? Indexes
        {
            private get; init;
        }
    }
}
