using Models;

namespace Contracts
{
    public interface ITextSearchService
    {
        Task<TextSearchResult> SearchAndSubmit(string candidate);
    }
}
