using PrintPostALPL.Context;

namespace PrintPostALPL.Tests
{
    public class ModuleClient
    {
        [Theory]
        [InlineData(1_000, true)]
        [InlineData(5_000, true)]
        [InlineData(10_000, true)]
        [InlineData(25_000, true)]
        [InlineData(50_000, true)]
        [InlineData(int.MinValue, false)]
        [InlineData(0, false)]
        [InlineData(999, false)]
        [InlineData(50_001, false)]
        [InlineData(int.MaxValue, false)]
        public void NbCourriers(int nb, bool attendu)
        {
            Assert.True(attendu == Verifier.NbCourriers(nb));
        }

        [Theory]
        [InlineData(short.MinValue, false)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(short.MaxValue, false)]
        public void TypeFeuilles(short type, bool attendu)
        {
            Assert.True(attendu == Verifier.TypeFeuille(type));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(10, true)]
        [InlineData(11, false)]
        public void NbFeuillesParCourrier(int nb, bool attendu)
        {
            Assert.True(attendu == Verifier.NbFeuillesParCourriers(nb));
        }
    }
}