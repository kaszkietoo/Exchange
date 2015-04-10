using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Net;
using Exchange.Web.Security.Helpers;
using Exchange.Web.Security;

namespace Exchange.Web.Tests.Security
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void FindCertificate()
        {
            var cryptographyHelper = new CryptographyHelper();
            X509Certificate2 certificate = cryptographyHelper.GetX509Certificate("CN=WebAPI-Token");

            Assert.IsNotNull(certificate);
        }

        [TestMethod]
        public void EncryptAndDecrypt()
        {
            var cryptographyHelper = new CryptographyHelper();
            X509Certificate2 certificate = cryptographyHelper.GetX509Certificate("CN=WebAPI-Token");
            string plainToken = "UserId: Ninja, IP: 127.0.0.1";

            string encrypted = cryptographyHelper.Encrypt(certificate, plainToken);
            string decrypted = cryptographyHelper.Decrypt(certificate, encrypted);

            Assert.AreEqual(plainToken, decrypted);
        }

        [TestMethod]
        public void CreateToken()
        {
            var token = new Token("peter", "127.0.0.1");
            string encrypted = token.Encrypt();

            Token recreatedToken = Token.Decrypt(encrypted);

            Assert.AreEqual(token.UserId, recreatedToken.UserId);
            Assert.AreEqual(token.IP, recreatedToken.IP);

        }
    }
}
