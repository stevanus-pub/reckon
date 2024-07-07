using Contracts;
using Models;

namespace Services
{
    public class TextSearchService : ITextSearchService
    {
        private readonly IAPIService _api;
        private readonly IStringSearch _stringSearch;

        public TextSearchService(IAPIService api, IStringSearch stringSearch)
        {
            _api = api;
            _stringSearch = stringSearch;
        }

        public async Task<TextSearchResult> SearchAndSubmit(string candidate)
        {
            var text = await _api.GetText();
            var subTexts = await _api.GetSubTexts();
            var subTextsSearchResult = new List<SubTextsSearchResult>();

            foreach (var subText in subTexts.SubTexts)
            {
                var indexes = _stringSearch.IndexesOf(text.Text, subText);

                subTextsSearchResult.Add(new SubTextsSearchResult(subText)
                {
                    Indexes = indexes.Select(a => ++a).ToArray()
                });
            }

            var textSearchResult = new TextSearchResult(candidate, text.Text, subTextsSearchResult.ToArray());

            await _api.SubmitResult(textSearchResult);

            return textSearchResult;
        }
    }
}
