using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutoClose.Extensions
{
    public static class StringExtensions
    {

        #region public enums

        public enum StringEncoding
        {
            hex = 0,
            base64 = 1
        }

        #endregion

        #region public methods

        public static String EncodeHex(this String iString)
        {
            Byte[] pBytBytes = System.Text.Encoding.UTF8.GetBytes(iString);
            return (pBytBytes.EncodeHex());
        }

        public static Byte[] DecodeHex(this String iString)
        {
            MemoryStream pMSmOutput = new MemoryStream();
            using (pMSmOutput)
            {
                String pStrOutput = String.Empty;
                String pStrInput = iString;
                String pStrCurrentHex = String.Empty;
                while (!String.IsNullOrEmpty(pStrInput))
                {
                    pStrCurrentHex = pStrInput.Substring(0, 2);
                    pStrInput = pStrInput.Substring(2);
                    List<Byte> pLisByte = new List<Byte>();
                    pLisByte.Add(Byte.Parse(pStrCurrentHex.ToUpper(), System.Globalization.NumberStyles.HexNumber));
                    pMSmOutput.Write(pLisByte.ToArray(), 0, pLisByte.Count);
                }
                return (pMSmOutput.ToArray());
            }
        }

        public static Boolean AsBoolean(this String iString)
        {
            return (Boolean.Parse(iString));
        }

        public static Int32 AsInt32(this String iString)
        {
            return (Int32.Parse(iString));
        }

        #endregion

    }

}
