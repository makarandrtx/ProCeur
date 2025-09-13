using ProCeur.API.Shared.Interface;
using System.Security.Cryptography;
using System.Text;

namespace ProCeur.API.Shared.Helpers
{
    public class PasswordSecurityHelper : IPasswordSecurityHelper
    {
        // Encrypts the provided data using a key
        public string Encrypt(string key, string data)
        {
            try
            {
                var (encryptionKey, iv) = GetEncryptionKeys(key);
                return EncryptStringToBytes_Aes(data, encryptionKey, iv);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Decrypts the provided data using a key
        public string Decrypt(string key, string data)
        {
            try
            {
                var (encryptionKey, iv) = GetEncryptionKeys(key);
                return DecryptStringFromBytes_Aes(data, encryptionKey, iv);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Generates encryption keys and an IV (Initialization Vector) from the provided key
        private (byte[] encryptionKey, byte[] iv) GetEncryptionKeys(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] rawKey = Encoding.UTF8.GetBytes(key);
                byte[] keyHash = sha256.ComputeHash(rawKey);
                byte[] iv = new byte[16];

                Array.Copy(keyHash, iv, iv.Length);

                return (keyHash, iv);
            }
        }

        // Creates a random password
        public string CreateRandomPassword()
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            using (var rng = RandomNumberGenerator.Create())
            {
                var passwordLength = 12;
                var password = new char[passwordLength];
                byte[] randomBytes = new byte[passwordLength];

                rng.GetBytes(randomBytes);

                for (int i = 0; i < passwordLength; i++)
                {
                    password[i] = validChars[randomBytes[i] % validChars.Length];
                }

                return new string(password);
            }
        }

        // Encrypts the plain text using AES encryption
        private static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (Key == null || Key.Length == 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length == 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // Decrypts the cipher text using AES decryption
        private static string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Convert.FromBase64String(cipherTextString);
            if (cipherText == null || cipherText.Length == 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (Key == null || Key.Length == 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length == 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        private static string EnsureAlphanumeric(string input)
        {
            return new string(input.Where(char.IsLetterOrDigit).ToArray());
        }

        // Restore the Base64 string by adding padding characters
        private static string RestoreBase64String(string input)
        {
            // Add padding if necessary to restore the Base64 string
            int padding = 4 - (input.Length % 4);
            if (padding != 4)
            {
                input = input + new string('=', padding);
            }
            return input;
        }

        public string EncryptURL(string key, string data)
        {
            try
            {
                var (encryptionKey, iv) = GetEncryptionKeys(key);
                string encryptedData = EncryptStringToBytes_Aes(data, encryptionKey, iv);
                return EnsureAlphanumeric(encryptedData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string DecryptURL(string key, string data)
        {
            try
            {
                var (encryptionKey, iv) = GetEncryptionKeys(key);
                string restoredBase64 = RestoreBase64String(data);
                return DecryptStringFromBytes_Aes(restoredBase64, encryptionKey, iv);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
