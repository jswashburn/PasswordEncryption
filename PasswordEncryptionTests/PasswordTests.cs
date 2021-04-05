using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordEncryption;

namespace PasswordEncryptionTests
{
    // Tests for the Password class
    [TestClass]
    public class PasswordTests
    {
        Password password = new Password("C# is cool");
        string formatted = "35d44623bc02375a93dde8dde9ef4e784ad249717843dd0e93de2beb9530cb5a";

        [TestMethod]
        public void TestHashedFormatting()
        {
            // Hashed password should be a formatted hexadecimal string
            Assert.AreEqual(password.Hashed, formatted);
        }
    }
}
