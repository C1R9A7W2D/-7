using NUnit.Framework;
using Sieve_of_Eratosthenes;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUncrossIntegersUpTo_Simple()
        {
            Assert.Equals(PrimeGenerator.generatePrimes(10), new int[] { 2, 3, 5, 7 });
            Assert.Equals(PrimeGenerator.generatePrimes(20), new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });
        }

        [Test]
        public void TestUncrossIntegersUpTo_TooLittleNumber()
        {
            Assert.Equals(PrimeGenerator.generatePrimes(2), new int[0]);
            Assert.Equals(PrimeGenerator.generatePrimes(1), new int[0]);
            Assert.Equals(PrimeGenerator.generatePrimes(0), new int[0]);
            Assert.Equals(PrimeGenerator.generatePrimes(-2), new int[0]);
        }

        [Test]
        public void TestUncrossIntegersUpTo_SinglePrime()
        {
            Assert.Equals(PrimeGenerator.generatePrimes(3), new int[] { 3 });
        }
    }
}