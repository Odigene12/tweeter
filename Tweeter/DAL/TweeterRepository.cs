using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweeter.DAL
{
    public class TweeterRepository
    {
        public TweeterContext context { get; }

        public TweeterRepository (TweeterContext mycontext)
        {
            context = mycontext;
        }

        public TweeterRepository()
        {
        }

        public List<string> GetAllUsernames()
        {
            return context.TweeterUsers.Select(u => u.BaseUser.UserName).ToList();
        }

        public object UserNameExists(string v)
        {
            throw new NotImplementedException();
        }
    }
}