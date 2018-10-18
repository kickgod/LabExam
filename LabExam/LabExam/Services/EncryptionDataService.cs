using LabExam.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LabExam.Services
{
    /// <summary>
    ///   使用RSA加密
    /// </summary>
    public sealed class EncryptionDataService : IEncryptionDataService
    {
        private const String EncodeKey = "sicnu_lab_505";
        /// <summary>
        ///  使用对称加密 密钥为上面
        /// </summary>
        /// <param name="Data">待加密数据</param>
        /// <returns>已经加密数据</returns>
        public string Encode(string Data)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = EncodeKey;//密匙容器的名称，保持加密解密一致才能解密成功
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = Encoding.Default.GetBytes(Data);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
            }
        }

        /// <summary>
        /// 对RSA加密后的数据进行解密
        /// </summary>
        /// <param name="EncodedData">已经加密数据</param>
        /// <returns>原来的数据</returns>
        public string Decrypt(string EncodedData)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = EncodeKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(EncodedData);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
        }
    }
}