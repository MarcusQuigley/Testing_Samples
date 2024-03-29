﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TestableCodeDemos.Module5.After
{
    public class Security : ISecurity
    {
        private string _userName;
        private bool _isAdmin;

        private Security() { }

        public void SetUser(string userName, bool isAdmin)
        {
            _userName = userName;

            _isAdmin = isAdmin;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public bool IsAdmin()
        {
            return _isAdmin;
        }
    }
}
