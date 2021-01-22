using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace
{
    public static class User
    {
        static string _login, _email, _address;
        static int _balance, _id;
        static DateTime _date;
        static bool _kind, _admin;
        public static string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public static string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public static DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public static int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public static bool Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }
        public static bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }
        public static int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public static string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
