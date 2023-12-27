using System;

namespace Sieve_of_Eratosthenes
{
    public class PrimeGenerator
    {
        private static bool[] crossedOut;
        private static int[] result;

        public static int[] generatePrimes(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];
            else
            {
                uncrossIntegersUpTo(maxValue);
                crossOutMultiples();
                putUncrossedIntegersIntoResult();
                return result;
            }
        }

        private static void uncrossIntegersUpTo(int maxValue)
        {
            crossedOut = new bool[maxValue + 1];
            for (int i = 2; i < crossedOut.Length; i++)
                crossedOut[i] = false;
        }

        private static void crossOutMultiples()
        {
            int limit = determineIterationLimit();
            for (int i = 2; i <= limit; i++)
                if (notCrossed(i))
                    crossOutMultiplesOf(i);
        }

        private static int determineIterationLimit()
        {
            double iterationLimit = Math.Sqrt(crossedOut.Length);
            return (int)iterationLimit;
        }

        private static void crossOutMultiplesOf(int i)
        {
            for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
                crossedOut[multiple] = true;
        }

        private static bool notCrossed(int i)
        {
            return crossedOut[i] == false;
        }

        private static void putUncrossedIntegersIntoResult()
        {
            result = new int[numberOfUncrossedIntegers()];
            for (int j = 0, i = 2; i < crossedOut.Length; i++)
                if (notCrossed(i))
                    result[j++] = i;
        }

        private static int numberOfUncrossedIntegers()
        {
            int count = 0;
            for (int i = 2; i < crossedOut.Length; i++)
                if (notCrossed(i))
                    count++;

            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] res = PrimeGenerator.generatePrimes(100);
            foreach (int x in res)
                Console.Write(x + " ");
        }
    }
}
