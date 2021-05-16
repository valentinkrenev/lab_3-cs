using System;
using System.Numerics;
using System.Xml;

namespace lab3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new DiffiHelmanGenerator(2002681, 34657434);
            var alice = new Client(generator);
            var bob = new Client(generator);
            bob.InitPrivateKey(alice.GetPublicKey());
            alice.InitPrivateKey(bob.GetPublicKey());
        }
    }

    class Client
    {
        public DiffiHelmanGenerator Generator { get; }

        public Client(DiffiHelmanGenerator generator)
        {
            Generator = generator;
            this.Seed = Generator.GetRandom();
        }

        public BigInteger GetPublicKey()
        {
            return Generator.GetKey(Seed);
        }

        public void InitPrivateKey(BigInteger publicKey)
        {
            this.Key = Generator.GetSecretKey(Seed, publicKey);
            var str = Key.ToString();
        }

        public BigInteger Key { get; set; }
        private int Seed { get; }
    }

    class DiffiHelmanGenerator
    {
        public DiffiHelmanGenerator(int primeValue, int basePublicKey)
        {
            PrimeValue = primeValue;
            BasePublicKey = basePublicKey;
        }

        private int PrimeValue { get; }
        private int BasePublicKey { get; }

        private Random Rnd = new Random();
        public int GetRandom() => Rnd.Next(2, PrimeValue);

        public BigInteger GetKey(int seed)
        {
            return BigInteger.ModPow(BasePublicKey, seed, PrimeValue);
        }

        public BigInteger GetSecretKey(int seed, BigInteger publicKey)
        {
            return BigInteger.ModPow(publicKey, seed, PrimeValue);
        }

    }
}
