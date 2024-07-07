using Models;

namespace Contracts
{
    public interface IAPIService
    {
        Task<TextToSearch> GetText();
        Task<SubTextsToSearch> GetSubTexts();
        Task SubmitResult(TextSearchResult result);
    }
}
