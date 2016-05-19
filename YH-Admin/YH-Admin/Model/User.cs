using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string PassWord { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Name { get { return $"{Firstname} {Lastname}"; } }

        public User(int uId, string username, string password, string firstname, string lastname)
        {
            UserId = uId;
            Username = username;
            PassWord = password;
            Firstname = firstname;
            Lastname = lastname;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            User sc = obj as User;
            if ((System.Object)sc == null)
                return false;

            // Return true if the fields match:
            return (UserId == sc.UserId) && (Firstname == sc.Firstname) && (Lastname == sc.Lastname);
        }

        public override int GetHashCode()
        {
            return UserId ^ Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return UserId + " " + Name;
        }
    }
}
