using Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/textsearch")]
    [ApiController]
    public class TextSearchController : ControllerBase
    {
        private readonly IAPIService _apiService;
        private readonly ITextSearchService _textSearchService;

        public TextSearchController(IAPIService apiService, ITextSearchService textSearchService)
        {
            _apiService = apiService;
            _textSearchService = textSearchService;
        }

        /// <summary>
        /// Get text for search.
        /// </summary>
        /// <returns>Text for search.</returns>
        [HttpGet("text")]
        [ProducesResponseType(typeof(TextToSearch), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetText()
        {
            var text = await _apiService.GetText();

            return Ok(text);
        }

        /// <summary>
        /// Get subtexts for search.
        /// </summary>
        /// <returns>Array of subtext for search.</returns>
        [HttpGet("subtexts")]
        [ProducesResponseType(typeof(SubTextsToSearch), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubTexts()
        {
            var subTexts = await _apiService.GetSubTexts();

            return Ok(subTexts);
        }

        /// <summary>
        /// Search and submit result.
        /// </summary>
        /// <returns>Search result.</returns>
        [HttpPost("submit")]
        [ProducesResponseType(typeof(TextSearchResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> Submit()
        {
            var result = await _textSearchService.SearchAndSubmit("Stevanus Wibowo");

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
