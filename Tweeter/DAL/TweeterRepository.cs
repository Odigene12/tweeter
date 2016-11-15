﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Tweeter.Models;

namespace Tweeter.DAL
{
    public class TweeterRepository
    {
        

        public TweeterContext Context { get; set; }
        public UserManager<ApplicationUser> UserManagerContext { get; set; }
        public TweeterRepository(TweeterContext _context)
        {
            Context = _context;
        }

        public TweeterRepository()
        {

        }

        public List<string> GetUsernames()
        {
            return Context.TweeterUsers.Select(u => u.BaseUser.UserName).ToList();
        }

        public Twit UsernameExists(string username)
        {
            return Context.TweeterUsers.FirstOrDefault(u => u.BaseUser.UserName.ToLower() == username.ToLower());
        }
    }
}