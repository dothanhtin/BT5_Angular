using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DMS.Shared
{
    public static class StringExtension
    {
        private const string _privateKey = "vNPt@2019$iT*0215";
        private static JsonSerializerSettings GetSerializeSetting()
        {
            var setting = new JsonSerializerSettings
            {
                MaxDepth = 30,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return setting;
        }
        public static T GetObject<T>(this string source)
        {
            var settings = GetSerializeSetting();
            var result = JsonConvert.DeserializeObject<T>(source, settings);
            return result;
        }

        public static bool IsNullOrEmpty(this string source)
        {
            var result = string.IsNullOrEmpty(source);
            return result;
        }

        public static bool EqualsWithIgnoreCase(this string source, string dest)
        {
            if (string.IsNullOrEmpty(source)) return false;
            var result = source.Equals(dest, StringComparison.CurrentCultureIgnoreCase);
            return result;
        }

        public static string GetEncrypt(this string source, string key)
        {
            const string initVector = _privateKey;
            const int keysize = 256;
            var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            var plainTextBytes = Encoding.UTF8.GetBytes(source);
            var password = new PasswordDeriveBytes(key, null);
            var keyBytes = password.GetBytes(keysize / 8);
            var rijndaelManaged = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };
            var encryptor = rijndaelManaged.CreateEncryptor(keyBytes, initVectorBytes);
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    var cipherTextBytes = memoryStream.ToArray();
                    var result = Convert.ToBase64String(cipherTextBytes);
                    return result;
                }
            }
        }

        public static string GetDecrypt(this string source, string key)
        {
            const string initVector = _privateKey;
            const int keysize = 256;
            var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            var cipherTextBytes = Convert.FromBase64String(source);
            var password = new PasswordDeriveBytes(key, null);
            var keyBytes = password.GetBytes(keysize / 8);
            var symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            using (var memoryStream = new MemoryStream(cipherTextBytes))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    var plainTextBytes = new byte[cipherTextBytes.Length];
                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                    var result = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                    return result;
                }
            }
        }

        public static string GetEncrypt(this string source)
        {
            return GetEncrypt(source, "VnPtiT$Taan@2019&NgUyEENx");
        }

        public static string GetDecrypt(this string source)
        {
            return GetDecrypt(source, "VnPtiT$Taan@2019&NgUyEENx");
        }

        public static string GetMd5(this string source)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(source));
            var hashBytes = md5.Hash;
            var builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {

                builder.Append(hashBytes[i].ToString("x2"));
            }

            var result = builder.ToString();
            return result;
        }

        public static string GetPassword(this string source)
        {
            var result = $"{_privateKey}{source}".GetMd5();
            return result;
        }

        public static List<string> GetArray(this string source, params string[] splits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(source)) return result;
            result.AddRange(source.Split(splits, StringSplitOptions.RemoveEmptyEntries));
            return result;
        }
    }
}
