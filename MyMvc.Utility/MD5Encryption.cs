using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Utility
{
    public class MD5Encryption
    {
        private const string sign = "YFSVJFDFLSFJ";
        
        public static string Md5(string str,int codelength = 32)
        {
            var key = string.Empty;
            switch (codelength)
            {
                case 16:
                    key= MD5Encryption16(str);
                    break;
                case 32:
                    key = MD5Encryption32(str);
                    break;
                case 64:
                    key = MD5Encryption64(str);
                    break;
            }
            return key;
        }
        
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encryption16(string str)
        {
            var md5 = new MD5CryptoServiceProvider();
            var key = Encoding.ASCII.GetBytes(str + sign);
            //开始加密
            var newkey = md5.ComputeHash(key, 4, 8);
            var strkey = BitConverter.ToString(newkey).Replace("-", "");
            return strkey;
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encryption32(string str) 
        {
            StringBuilder sb = new StringBuilder();
            //实例化md5对象
            using(MD5 md5 = MD5.Create())
            {
                //将字符串转成字节数组
                var key = Encoding.UTF8.GetBytes(str + sign);
                //开始加密
                var newkey = md5.ComputeHash(key);
                for (int i = 0; i < newkey.Length; i++)
                {
                    //字节转成十六进制
                    //X2和x2表示不省略首位为0的十六进制
                    sb.Append(newkey[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 64位MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encryption64(string str)
        {
            using(MD5 md5 = MD5.Create())
            {
                var key = Encoding.UTF8.GetBytes(str);
                var newkey = md5.ComputeHash(key);
                return Convert.ToBase64String(newkey);
            }
        }
    }
}
