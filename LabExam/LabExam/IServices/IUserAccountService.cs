﻿using LabExam.Map;
using LabExam.Models;
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
        Boolean ChangeUserPassword(UserAccout account, UserType userType, IEncryptionDataService service);

        /// <summary>
        ///  添加用户登录记录
        /// </summary>
        /// <param name="record">记录信息对象</param>
        /// <returns>是否添加成功</returns>
        Boolean AddLoginRecord(UserLoginRecord record);

        /// <summary>
        /// 判断用户账户和密码是否正确
        /// </summary>
        /// <param name="id">账户</param>
        /// <param name="pwd">密码</param>
        /// <param name="type">用户类型</param>
        /// <returns>是否能登录</returns>
        Boolean Login(String id, String pwd,UserType type, IEncryptionDataService service);
        /// <summary>
        /// 认证用户的身份证信息
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        Boolean ConfirmStudentIDNumber(String AccountID,String ID);

        String GetPrincipalByID(String ID);
        
    }
}
