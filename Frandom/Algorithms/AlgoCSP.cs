using System;
using System.Security.Cryptography;

namespace Frandom.Algorithms
{
    /// <summary>
    /// 使用 RNGCryptoServiceProvider 產生由密碼編譯服務供應者 (CSP) 提供的亂數產生器。
    /// 參考自 https://blog.miniasp.com/post/2008/05/13/Random-vs-RNGCryptoServiceProvider
    /// </summary>
    internal class AlgoCSP : Algorithm
    {
        private static RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
        private static byte[] rb = new byte[4];

        public override string Name => "Default";

        public override uint Next()
        {
            csp.GetBytes(rb);
            return BitConverter.ToUInt32(rb, 0);
        }
    }
}