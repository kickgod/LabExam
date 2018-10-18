using LabExam.Map;
using LabExam.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam.IServices
{
    public interface IUserAccountService
    {
        /// <summary>
        ///  得到用户类型
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns>UserType 枚举 可选值 陌生人Anonymous, 学生 Student 管理员 Principal </returns>
        UserType GetUserType(String UserID);

        /// <summary>
        ///  判断用户是否登陆
        /// </summary>
        /// <returns>返回是否登陆 true/false </returns>
        Boolean UserIsLogin();

        /// <summary>
        ///  改变用户密码
        /// </summary>
        /// <param name="account">用户账号 UserAccout 类包含用户账号和它的新密码</param>
        /// <param name="userType">用户类型</param>
        /// <returns>返回是否改变成功 true/false</returns>
        Boolean ChangeUserPassword(UserAccout account, UserType userType);


        Boolean StudentIsRight();
        Boolean PrincipalIsRight();
    }
}
