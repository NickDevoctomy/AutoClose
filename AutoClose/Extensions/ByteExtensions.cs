using System;

namespace AutoClose.Extensions
{

    public static class ByteExtensions
    {

        #region public methods

        public static String EncodeHex(this Byte[] iBytes)
        {
            return (BitConverter.ToString(iBytes).Replace("-", String.Empty).ToLower());
        }

        public static String EncodeUTF8(this Byte[] iBytes)
        {
            return (System.Text.Encoding.UTF8.GetString(iBytes));
        }

        #endregion

    }

}
