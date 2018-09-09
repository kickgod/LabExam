using LabExam.IServices;
using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace LabExam.Services
{
    /// <summary>
    ///  <remarks> 通过MD5的方法对数据进行加密  </remarks>
    ///  <Create> 2018/9/6 19:55 </Create>
    ///  <Author> 2016110418 蒋星 </Author>
    ///  <LastAlterTimeAndAuthor>  </LastAlterTimeAndAuthor>
    /// </summary>
    public class EncryptionDataByMd5 : IEncryptionData
    {
        public string Encode(string Data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] palindata = Encoding.Default.GetBytes(Data);//将要加密的字符串转换为字节数组
            byte[] encryptdata = md5.ComputeHash(palindata);      //将字符串加密后也转换为字符数组
            return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为加密字符串
        }
    }
}