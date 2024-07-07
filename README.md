# Text Search API

Searching sub texts in text and submitting the search result to API.

## Installation

Built with .NET SDK 8.0.302: https://github.com/dotnet/core/blob/main/release-notes/8.0/8.0.6/8.0.302.md

## API

There are 3 API endpoints viewable through Swagger UI when the API project is launch (http://localhost:9000/swagger/index.html).
1. api/textsearch/text: get text for search.
2. api/textsearch/subtexts: get subtexts for search.
3. api/textsearch/submit: search and submit result.

## Nuget Packages

1. Polly: https://www.nuget.org/packages/polly/
2. Hellang ProblemDetails Middleware: https://github.com/khellang/Middleware
