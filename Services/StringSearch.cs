using Contracts;

namespace Services
{
    public class StringSearch : IStringSearch
    {
        public int IndexOf(string text, string subText)
        {
            // Pseudocode: https://johnlekberg.com/blog/2020-11-15-string-search.html

            var n = text.Length;
            var m = subText.Length;

            for (var i = 0; i < (n - m) + 1; i++)
            {
                var match = true;
                for (var j = 0; j < m; j++)
                {
                    if (char.ToUpper(text[i + j]) != char.ToUpper(subText[j]))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    return i;
                }
            }

            return -1;
        }

        public int[] IndexesOf(string text, string subText)
        {
            var currentIndex = 0;
            var indexesFound = new List<int>();

            while (currentIndex < text.Length)
            {
                var indexFound = IndexOf(text.Substring(currentIndex), subText);
                if (indexFound == -1)
                {
                    break;
                }

                indexesFound.Add(currentIndex + indexFound);
                currentIndex += indexFound == 0 ? subText.Length : indexFound + 1;
            }

            return indexesFound.ToArray();
        }

        /*public async Task SearchAndSubmit()
        {
            var text = await _api.GetText();
            var subTexts = await _api.GetSubTexts();
            var subTextsResult = new List<SubTextsSearchResult>();
            foreach (var subText in subTexts.SubTexts)
            {
                var indexes = IndexesOf(text.Text, subText);

                subTextsResult.Add(new SubTextsSearchResult(subText, indexes));
            }

        }*/
    }
}
