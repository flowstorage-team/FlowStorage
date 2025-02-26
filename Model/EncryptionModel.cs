﻿using System;
using System.Text;
using System.Security.Cryptography;

namespace FlowSERVER1 {
    public static class EncryptionModel {
        public static string Encrypt(String _value) {
            String toBase64 = "";

            try {

                byte[] iv = new byte[16]; 
                byte[] keyBytes = Encoding.UTF8.GetBytes("0123456789085746");
                byte[] plainBytes = Encoding.UTF8.GetBytes(_value); 

                using (Aes aes = Aes.Create()) {
                    aes.Key = keyBytes;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform encryptor = aes.CreateEncryptor()) {
                        byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                        toBase64 = Convert.ToBase64String(encryptedBytes);
                    }
                }

            } catch (Exception) {
                // TODO: Ignore exception since it's unecesary
            }

            return toBase64;
        }

        public static string Decrypt(String _value) {

            String toBase64 = "";

            try {
                
                byte[] iv = new byte[16]; 
                byte[] keyBytes = Encoding.UTF8.GetBytes("0123456789085746"); 
                byte[] encryptedBytes = Convert.FromBase64String(_value); 

                using (Aes aes = Aes.Create()) {
                    aes.Key = keyBytes;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor()) {
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                        toBase64 = Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            } catch (Exception) {
                // TODO: Ignore exception since it's unecesary
            }

            return toBase64;

        }

        static public string computeAuthCase(string inputStr) {

            SHA256 sha256 = SHA256.Create();

            string getAuthStrCase0 = inputStr;
            byte[] getAuthBytesCase0 = Encoding.UTF8.GetBytes(getAuthStrCase0);
            byte[] authHashCase0 = sha256.ComputeHash(getAuthBytesCase0);
            string authStrCase0 = BitConverter.ToString(authHashCase0).Replace("-", "");

            return authStrCase0;
        }

    }
}
