using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExam.Models;

namespace LabExam.IServices
{
    /// <summary>
    ///  处理用户投诉建议的类
    /// </summary>
    public interface IUserSuggestionService
    {
        /// <summary>
        ///  添加一个用户建议
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        Boolean AddUserSuggestion(UserSuggestion suggestion);

    }
}
