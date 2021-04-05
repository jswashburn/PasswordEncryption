using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordEncryption;

namespace PasswordEncryptionTests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void TestThrowsOutOfRange_100()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                UI.GetMenuOption("100");
            });
        }

        [TestMethod]
        public void TestThrowsOutOfRange_0()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                UI.GetMenuOption("0");
            });
        }

        [TestMethod]
        public void TestThrowsOutOfRange_neg100()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                UI.GetMenuOption("-100");
            });
        }
    }
}
