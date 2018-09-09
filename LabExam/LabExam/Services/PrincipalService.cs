using LabExam.IServices;
using LabExam.Map;
using LabExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabExam.Services
{
    public class PrincipalService : IPrincipalService
    {
        private LabContext db = new LabContext();
        public bool IsHavaPrincipal(string UserID)
        {
            Principal p = new Principal();
            return db.Principals.Find(UserID) == null ;
        }
    }
}