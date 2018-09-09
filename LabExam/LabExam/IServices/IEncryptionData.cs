using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.IServices
{
    /// <summary>
    ///  提供一个数据加密的接口
    /// </summary>
    public interface IEncryptionData
    {
        String Encode(String Data);
    }
}