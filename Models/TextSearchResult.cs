namespace Models
{
    public record TextSearchResult(string Candidate, string Text, SubTextsSearchResult[] Results);
}
