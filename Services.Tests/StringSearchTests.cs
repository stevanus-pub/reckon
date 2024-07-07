namespace Services.Tests
{
    public class StringSearchTests
    {
        [Theory]
        [InlineData("PeTer")]
        [InlineData("pick")]
        [InlineData("pipe")]
        [InlineData("W!")]
        [InlineData("DoNotExist")]
        public void IndexOf_ShouldMatch_DotNetIndexOf(string subText)
        {
            // Arrange
            var service = new StringSearch();
            var text = "Peter told me (actually he slurrred) that peter the pickle piper piped a pitted pickle before he petered out. Phew!";

            // Act
            var index1 = text.IndexOf(subText, StringComparison.OrdinalIgnoreCase);
            var index2 = service.IndexOf(text, subText);

            // Assert
            Assert.Equal(index1, index2);
        }

        [Theory]
        [InlineData("Peter", new int[] {0, 42, 97})]
        [InlineData("peter", new int[] {0, 42, 97})]
        [InlineData("Pick", new int[] {52, 80})]
        [InlineData("pi", new int[] { 52, 59, 65, 73, 80})]
        [InlineData("Z", new int[0])]
        public void IndexesOf_ShouldReturn_AllOccurrences(string subText, int[] output)
        {
            // Arrange
            var service = new StringSearch();
            var text = "Peter told me (actually he slurrred) that peter the pickle piper piped a pitted pickle before he petered out. Phew!";

            // Act
            var indexes = service.IndexesOf(text, subText);

            // Assert
            Assert.Equal(indexes, output);
        }
    }
}