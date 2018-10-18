using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LabExam.IServices;
using LabExam.Map;
using LabExam.Models;

namespace LabExam.Services
{
    public class UserSuggestionService : IUserSuggestionService
    {

        private LabContext db = new LabContext();

        public  bool AddUserSuggestion(UserSuggestion suggestion)
        {
            db.UserSuggestions.Add(suggestion);
            Boolean result =(db.SaveChanges() == 1);
            return result;
        }
    }
}