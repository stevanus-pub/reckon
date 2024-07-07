using Contracts;
using Models;
using Polly;
using Polly.Retry;
using System.Net.Http.Json;
using System.Text.Json;

namespace Services
{
    public class APIService : IAPIService
    {
        private readonly IHttpClientFactory _factory;

        public APIService(IHttpClientFactory factory)
        {
            _factory = factory;
        }


        public async Task<TextToSearch> GetText()
        {
            var client = _factory.CreateClient();

            // I have not used Polly before so the following codes are based on below examples.
            // https://enlear.academy/implementing-retry-pattern-using-polly-in-net-core-application-9cf30262258b

            var retryPolicy = GetRetryPolicy();

            // Apply the retry policy to an API call
            var result = await retryPolicy.ExecuteAsync(async () =>
            {
                var response = await client.GetAsync("https://join.reckon.com/test2/textToSearch");

                // Check if the request was successful
                response.EnsureSuccessStatusCode();

                // Process the response if successful
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<TextToSearch>(content, GetJsonDeserializeOption());

                return model;
            });

            return result ?? new TextToSearch("");
        }

        public async Task<SubTextsToSearch> GetSubTexts()
        {
            var client = _factory.CreateClient();

            // I have not used Polly before so the following codes are based on below examples.
            // https://enlear.academy/implementing-retry-pattern-using-polly-in-net-core-application-9cf30262258b

            var retryPolicy = GetRetryPolicy();

            // Apply the retry policy to an API call
            var result = await retryPolicy.ExecuteAsync(async () =>
            {
                var response = await client.GetAsync("https://join.reckon.com/test2/subTexts");

                // Check if the request was successful
                response.EnsureSuccessStatusCode();

                // Process the response if successful
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<SubTextsToSearch>(content, GetJsonDeserializeOption());

                return model;
            });

            return result ?? new SubTextsToSearch([]);
        }


        public async Task SubmitResult(TextSearchResult result)
        {
            var client = _factory.CreateClient();

            // I have not used Polly before so the following codes are based on below examples.
            // https://enlear.academy/implementing-retry-pattern-using-polly-in-net-core-application-9cf30262258b

            var retryPolicy = GetRetryPolicy();

            // Apply the retry policy to an API call
            await retryPolicy.ExecuteAsync(async () =>
            {
                var response = await client.PostAsJsonAsync("https://join.reckon.com/test2/submitResults", result);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();
            });

            return;
        }

        private AsyncRetryPolicy GetRetryPolicy()
        {
            return Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(5),
                onRetryAsync: (exception, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine($"Retry attempt {retryAttempt} after {timespan.TotalSeconds} seconds due to: {exception.Message}");

                    return Task.CompletedTask;
                });
        }

        private JsonSerializerOptions GetJsonDeserializeOption()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
    }
}
