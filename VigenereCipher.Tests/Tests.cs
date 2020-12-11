using NUnit.Framework;
using VigenereCipher.Tools;

namespace VigenereCipher.Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly char[] engAlph = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                                                'w', 'x', 'y', 'z' };

        private Cipher _encryptor;

        [SetUp]
        public void Setup()
        {
            _encryptor = new Cipher(engAlph);
        }

        [TestCase("ATTAC", "lemon", "lxfop")]
        [TestCase("sunахалайМахалай", "lemon", "dyzахалаймахалай")]
        [TestCase("ATTACK AT DAWN", "LEMON", "lxfopv ef rnhr")]
        public void EncryptionTest(string input, string keyword, string output)
        {
            Assert.AreEqual(_encryptor.Encrypt(input, keyword), output);
        }


        [TestCase("dyzахалайМахалай", "lemon", "sunахалаймахалай")]
        [TestCase("lxFoP", "lemon", "attac")]
        [TestCase("lxfopv ef RNHR", "LEMON", "attack at dawn")]
        public void DecryptionTest(string input, string keyword, string output)
        {
            Assert.AreEqual(_encryptor.Decrypt(input, keyword), output);
        }
    }
}