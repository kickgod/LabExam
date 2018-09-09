using LabExam.IServices;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LabExam.Services
{
    public class EncryptionDataByDES : IEncryptionData
    {
        byte[] buffer;

        DESCryptoServiceProvider DesCSP = new DESCryptoServiceProvider();

        public string Encode(string Data)
        {
            MemoryStream ms = new MemoryStream();//先创建 一个内存流
            CryptoStream cryStream = new CryptoStream(ms, DesCSP.CreateEncryptor(), CryptoStreamMode.Write);//将内存流连接到加密转换流
            StreamWriter sw = new StreamWriter(cryStream);
            sw.WriteLine(Data);                     //将要加密的字符串写入加密转换流
            sw.Close();
            cryStream.Close();
            buffer = ms.ToArray();                  //将加密后的流转换为字节数组
            StringBuilder builder = new StringBuilder();
            foreach (var r in buffer)
            {
                builder.Append(r);
            }
            return builder.ToString();  //将加密后的字节数组转换为字符串
        }
    }
}