namespace Contracts
{
    public interface IStringSearch
    {
        /// <summary>
        /// Find first index of a substring in larger string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subText"></param>
        /// <returns>First index found.</returns>
        int IndexOf(string text, string subText);

        /// <summary>
        /// Find all indexes of a substrinfg in larger string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subText"></param>
        /// <returns>Indexes found.</returns>
        int[] IndexesOf(string text, string subText);
    }
}
