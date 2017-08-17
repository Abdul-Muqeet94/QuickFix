using System;
using System.Security.Cryptography;
using System.Security.Cryptography;

namespace Fixit.Utils
{
    public class Constant
    {
        public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        public const bool USER_ACTIVE = true;
        public const bool USER_INACTIVE = false;

        public const string TABLE_CUSTOMER="Customer";
        public const string TABLE_BILLER="Biller";
        public const string TABLE_PRODUCT="Product";
        public const bool TRANSATION_SUCCESS = true;
        public const bool TRANSACTION_FAIL = false;

        public const string MAIL_FROM_ADDRESS_NAME="SimplInvoices";
        public const string MAIL_FROM_ADDRESS_EMAIL="M.Fahad2015@outlook.com";
        public const string MAIL_HOST_ADDRESS = "smtp-mail.outlook.com";
        public const int MAIL_HOST_PORT = 587;


        public const string SENDGRID_API_TOKEN="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";
        public const string MAIL_AUTHENTICAITON_USER = "M.Fahad2015@outlook.com";
        public const string MAIL_AUTHENTICATION_PASSWORD = "king0341";


    }


     public class Passwords
        {
            public static string[] generatePasswordAndSalt(string value)
            {
                // generate a 128-bit salt using a secure PRNG
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                string sal = Convert.ToBase64String(salt);

                string password = System.Text.Encoding.UTF8.GetString(getHash(value, sal));

                return new string[] { password,sal };
            }

            public static void setPassword(Fixit.Models.Employee emp, string value)
            {
                // generate password and salt for the requested values.
                string[] passwordAndSalt = generatePasswordAndSalt(value);

                // If there was no error in generation.
                // proceed and assign password and salt.
                if (passwordAndSalt.Length == 2)
                {
                    // emp.password = passwordAndSalt[0];

                    // emp.salt = passwordAndSalt[1];
                }
            }

            public static bool validateHash(string attemptedPassword, string storedHash, string storedSalt)
            {
                string hashed = System.Text.Encoding.UTF8.GetString(getHash(attemptedPassword, storedSalt));

                return storedHash.Equals(hashed);
            }

            public static bool validate(Fixit.Models.Employee emp,string attemptedPassword)
            {
                return validateHash(attemptedPassword, "", "");
            }

            #region Helpers
            private static byte[] getHash(string password, string salt)
            {
                byte[] unhashedBytes = System.Text.Encoding.Unicode.GetBytes(String.Concat(salt, password));

                var sha256 =  SHA256.Create();
                byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

                return hashedBytes;
            }

            private static bool compareHash(string attemptedPassword, byte[] hash, string salt)
            {
                string base64Hash = Convert.ToBase64String(hash);
                string base64AttemptedHash = Convert.ToBase64String(getHash(attemptedPassword, salt));

                return base64Hash == base64AttemptedHash;
            }
            #endregion
        }
}