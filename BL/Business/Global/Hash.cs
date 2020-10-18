using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BL.Business.Global
{
    public static class Hash
    {
        public static string SHA256(string strValue)
        {
            SHA256Managed sifre = new SHA256Managed();
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] arySifre = ByteConverter.GetBytes(strValue);
            byte[] aryHash = sifre.ComputeHash(arySifre);
            return BitConverter.ToString(aryHash);
        }
    }
}
