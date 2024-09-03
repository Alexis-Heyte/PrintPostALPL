namespace PrintPostALPL.Tests
{
    public class Module1
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(1000)]
        [InlineData(1001)]
        [InlineData(50000)]
        [InlineData(50001)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void VerifierNbCourriers(int nbCourriers)
        {
            int min = 1000;
            int max = 50000;
            Assert.True(nbCourriers >= min, "Le nombre de courriers est inférieur au minimum : " + min);
            Assert.True(nbCourriers <= max, "Le nombre de courriers est supérieur au maximum : " + max);
        }
    }
}