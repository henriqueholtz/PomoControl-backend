using EscNet.Cryptography.Interfaces;
using System;

namespace PomoControl.Core.Helpers
{
    public class CryptographyHelper
    {
        private readonly IRijndaelCryptography _rijndaelCryptography;
        public CryptographyHelper(IRijndaelCryptography rijndaelCryptography)
        {
            _rijndaelCryptography = rijndaelCryptography;
        }

        public string Encrypt(string text)
        {
            try
            {
                return _rijndaelCryptography.Encrypt(text);
            }
            catch(Exception ex)
            {
                throw; //Create a CryptographyException
            }
        }
        public string Decrypt(string text)
        {
            try
            {
                return _rijndaelCryptography.Decrypt(text);
            }
            catch (Exception ex)
            {
                throw; //Create a CryptographyException
            }
        }
    }
}
