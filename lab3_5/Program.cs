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

            var clipper = new XORCipher();

            Console.WriteLine("Введите текст для шифрования");
            var text = Console.ReadLine();

            var encoded = clipper.Encrypt(text, bob.Key.ToString());
            Console.WriteLine($"encoded {encoded}");

            var decoded = clipper.Decrypt(encoded, alice.Key.ToString());
            Console.WriteLine($"decoded {decoded}");
        }
    }
    public class XORCipher
    {
        private string GetRepeatKey(string s, int n)
        {
            var r = s;
            while (r.Length < n)
            {
                r += r;
            }

            return r.Substring(0, n);
        }

        private string Cipher(string text, string secretKey)
        {
            var currentKey = GetRepeatKey(secretKey, text.Length);
            var res = string.Empty;

            for (var i = 0; i < text.Length; i++)
                res += ((char)(text[i] ^ currentKey[i])).ToString();

            return res;
        }

        public string Encrypt(string plainText, string password)
            => Cipher(plainText, password);

        public string Decrypt(string encryptedText, string password)
            => Cipher(encryptedText, password);
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
            return Generator.GetPublicKey(Seed);
        }

        public void InitPrivateKey(BigInteger publicKey)
        {
            this.Key = Generator.OneWayFunc(publicKey, Seed);
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

        private Random Rnd { get; } = new();
        public int GetRandom() => Rnd.Next(2, PrimeValue);
        public BigInteger GetPublicKey(int seed) => OneWayFunc(BasePublicKey, seed);
        public BigInteger OneWayFunc(BigInteger key, int seed) => BigInteger.ModPow(key, seed, PrimeValue);
    }
}
