using PrintPostALPL.Context;

namespace PrintPostALPL.Tests
{
    public class ModuleClient
    {
        [Theory]
        [InlineData(1_000)]
        [InlineData(5_000)]
        [InlineData(10_000)]
        [InlineData(25_000)]
        [InlineData(50_000)]
        public void NbCourriersOK(int nb)
        {
            Assert.True(Verifier.NbCourriers(nb));
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(999)]
        [InlineData(50_001)]
        [InlineData(int.MaxValue)]
        public void NbCourriersNOK(int nb)
        {
            Assert.False(Verifier.NbCourriers(nb));
        }


    }
}