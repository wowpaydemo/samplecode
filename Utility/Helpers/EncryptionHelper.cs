using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Helpers
{
    public static class EncryptionHelper
    {
        public static string EncryptRandomPassword(string info, string publicKey)
        {
            if (!string.IsNullOrWhiteSpace(publicKey))
            {
                //publicKey = publicKey.Replace(Environment.NewLine, "\n").Replace("\r\n", "");

                byte[] bytes = Encoding.ASCII.GetBytes(info);

                var publickey = GetPublicKey(publicKey);

                byte[] encBytes = RSAEncryption(bytes, publickey);

                var result = Convert.ToBase64String(encBytes).Trim();

                return result;
            }

            return string.Empty;
        }

        public static string DecryptRandomPassword(string data, string privatekey)
        {
            string DecryptedPassword = string.Empty;

            if (!string.IsNullOrWhiteSpace(data) && !string.IsNullOrWhiteSpace(privatekey))
            {
                if (privatekey == null)
                {
                    throw new Exception("private key is null");
                }

                var key = GetPrivateKey(privatekey);

                byte[] bytes = Convert.FromBase64String(data);

                byte[] decBytes = RSADecryption(bytes, key);

                DecryptedPassword = Encoding.ASCII.GetString(decBytes).Trim();
            }

            return DecryptedPassword;
        }

        private static byte[] RSADecryption(byte[] data, AsymmetricCipherKeyPair key)
        {
            try
            {
                var engine = new RsaEngine();
                engine.Init(false, key.Private);
                var blockSize = engine.GetInputBlockSize();
                return engine.ProcessBlock(data, 0, data.Length);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static byte[] RSAEncryption(byte[] data, AsymmetricKeyParameter key)
        {
            try
            {
                //var engine = new OaepEncoding(new RsaEngine());

                var engine = new RsaEngine();
                engine.Init(true, key);
                var blockSize = engine.GetInputBlockSize();
                return engine.ProcessBlock(data, 0, data.Length);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this ll return AsymmetricCipherKeyPair and its used to RSA decryption
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static AsymmetricCipherKeyPair GetPrivateKey(string key)
        {
            try
            {
                TextReader rs = new StringReader(key.Trim());
                var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(rs);
                var KeyParameter = (AsymmetricCipherKeyPair)pemReader.ReadObject();
                return KeyParameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// this ll return AsymmetricKeyParameter and its used to RSA encryption
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static AsymmetricKeyParameter GetPublicKey(string key)
        {
            try
            {
                TextReader rs = new StringReader(key.Trim());
                var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(rs);
                var KeyParameter = (AsymmetricKeyParameter)pemReader.ReadObject();
                return KeyParameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GenerateRandomPassword(string? salt = null, int bytelen = 32)
        {
            return GetHashSha256($"#{salt}{DateTime.Now:ddMMmYYyyHHmmss}{new Random().Next(100, 1000)}", bytelen);
        }

        public static string GetHashSha256(string text, int length = 32)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            SHA256 hashstring = SHA256.Create();

            byte[] hash = hashstring.ComputeHash(bytes);

            string hashString = string.Empty;

            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }

            if (length > hashString.Length || length <= 0)
            {
                return hashString;
            }
            else
            {
                return hashString.Substring(0, length);
            }
        }

        public static string EncryptJosn(string info, string passwordPhase, string ivVector)
        {
            string _result;
            try
            {
              

                byte[] keyBytes = Encoding.ASCII.GetBytes(passwordPhase);

                byte[] inputBytes = Encoding.ASCII.GetBytes(info);

                // Initialize AES CTR (counter) mode cipher from the BouncyCastle cryptography library
                IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");

                cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", keyBytes), Encoding.ASCII.GetBytes(ivVector)));
                byte[] encryptedBytes = cipher.DoFinal(inputBytes);
                _result = Convert.ToBase64String(encryptedBytes);

            }
            catch (Exception)
            {
                throw;
            }

            return _result;
        }

        public static string DecryptJson(string info, string passwordPhase, string ivVector)
        {
            string _result;

            try
            {
                
                byte[] inputBytes = Convert.FromBase64String(info);

                byte[] keyBytes = Encoding.ASCII.GetBytes(passwordPhase);

                IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");

                cipher.Init(false, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", keyBytes), Encoding.ASCII.GetBytes(ivVector)));
                byte[] encryptedBytes = cipher.DoFinal(inputBytes);
                _result = Encoding.ASCII.GetString(encryptedBytes);

            }
            catch (Exception)
            {
                throw;
            }

            return _result;

        }

        public static string CreateSha512Hash(string rawData)
        {
            var objSha512 = SHA512.Create();
            byte[] bytValue = Encoding.UTF8.GetBytes(rawData);
            byte[] bytHash = objSha512.ComputeHash(bytValue);
            string hashkey = BitConverter.ToString(bytHash).Replace("-", "");
            return hashkey;
        }


    }
}
