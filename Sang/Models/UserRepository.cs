using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace Sang.Models
{
    public class UserRepository
    {
        //
        //Create User
        //

        public MembershipUser CreateUser(string username, string password, string email)
        {
            using (SangDBContext _db = new SangDBContext())
            {
                SangUser user = new SangUser();
                user.Email = email;
                user.Pass = EncodePassword(password);
                user.tempWarranty = "";
                user.IsActived = false;
                user.RegisterDate = DateTime.Now;
                //user.PasswordSalt = "1234";
                //user.CreatedDate = DateTime.Now;
                //user.IsActivated = false;
                //user.IsLockedOut = false;
                //user.LastLockedOutDate = DateTime.Now;
                //user.LastLoginDate = DateTime.Now;
                _db.SangUsers.Add(user);
                _db.SaveChanges();

                return GetUser(username);
            }
        }

        public string EncodePassword(string userpassword)
        {
            Byte[] originalPwdBytes;
            Byte[] encodedPwdBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for user's original password and encode      password in MD5 format.
            md5 = new MD5CryptoServiceProvider();
            originalPwdBytes = ASCIIEncoding.Default.GetBytes(userpassword);
            encodedPwdBytes = md5.ComputeHash(originalPwdBytes);
            //Convert encoded user password in 'readable" format.
            return BitConverter.ToString(encodedPwdBytes);
        }

        public string GetUserNameByEmail(string email)
        {
            using (SangDBContext _db = new SangDBContext())
            {
                var result = from u in _db.SangUsers where (u.Email == email) select u;

                if (result.Count() != 0)
                {
                    var dbuser = result.FirstOrDefault();

                    return dbuser.Email;
                }
                else
                {
                    return "";
                }
            }
        }

        public MembershipUser GetUser(string username)
        {
            using (SangDBContext _db = new SangDBContext())
            {
                var result = from u in _db.SangUsers where (u.Email == username) select u;

                if (result.Count() != 0)
                {
                    var dbuser = result.FirstOrDefault();

                    string _username = dbuser.Email;
                    int _providerUserKey = dbuser.SangUserID;
                    string _email = dbuser.Email;
                    string _passwordQuestion = "";
                    string _comment = "";
                    bool _isApproved = true;
                    bool _isLockedOut = false;
                    DateTime _creationDate = dbuser.RegisterDate;
                    DateTime _lastLoginDate = dbuser.RegisterDate;
                    DateTime _lastActivityDate = DateTime.Now;
                    DateTime _lastPasswordChangedDate = DateTime.Now;
                    DateTime _lastLockedOutDate = dbuser.RegisterDate;

                    MembershipUser user = new MembershipUser("CustomMembershipProvider",
                                                              _username,
                                                              _providerUserKey,
                                                              _email,
                                                              _passwordQuestion,
                                                              _comment,
                                                              _isApproved,
                                                              _isLockedOut,
                                                              _creationDate,
                                                              _lastLoginDate,
                                                              _lastActivityDate,
                                                              _lastPasswordChangedDate,
                                                              _lastLockedOutDate);

                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}