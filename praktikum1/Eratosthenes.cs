using System;
using System.Collections.Generic;
using System.Linq;

namespace DN1 {
    public enum PrimeType { Prime, NotPrime };

    public class Eratosthenes {

        public PrimeType[] Sieve(int maxPrime) {
            PrimeType[] sieve = new PrimeType[maxPrime + 1];
            sieve[0] = PrimeType.NotPrime;
            sieve[1] = PrimeType.NotPrime;

            for (int i = 2; i <= maxPrime; i++) {
                sieve[i] = PrimeType.Prime;
            }

            for (int i = 2; i * i <= maxPrime; i++) {
                if (sieve[i] == PrimeType.Prime) {
                    for (int j = i * i; j <= maxPrime; j += i) {
                        sieve[j] = PrimeType.NotPrime;
                    }
                }
            }

            return sieve;
        }

        public int[] PrimesAsArray(PrimeType[] primes) {
            return primes.Select((value, index) => new { value, index })
                         .Where(x => x.value == PrimeType.Prime)
                         .Select(x => x.index)
                         .ToArray();
        }

        public List<int> PrimesAsList(PrimeType[] primes) {
            return primes.Select((value, index) => new { value, index })
                         .Where(x => x.value == PrimeType.Prime)
                         .Select(x => x.index)
                         .ToList();
        }

        public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes) {
            return primes.Select((value, index) => new { value, index })
                         .Where(x => x.value == PrimeType.Prime)
                         .Select((x, idx) => new { Key = idx, Value = x.index })
                         .ToDictionary(x => x.Key, x => x.Value);
        }

        public void printAll(IEnumerable<int> collection) {
            int i = 0;
            foreach (int p in collection) {
                Console.Write((i++) + "->" + p + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args) {
            int maxPrime = 100;
            Eratosthenes eratosthenes = new Eratosthenes();
            if (args.Length >= 1)
                maxPrime = Int32.Parse(args[0]);

            PrimeType[] primes = eratosthenes.Sieve(maxPrime);
            Console.WriteLine("Aufgabe 1");
            for (int i = 0; i <= maxPrime; i++) {
                Console.Write(i + ":" + primes[i] + " ");
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine("\nAufgabe 2");
            eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
            Console.WriteLine("\nAufgabe 3");
            eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
            Console.WriteLine("\nAufgabe 4");
            eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());

            Console.ReadLine();
        }
    }
}
