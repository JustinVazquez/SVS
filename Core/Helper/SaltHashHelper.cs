using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace Core.Helper
{
    /*
    *    Quelle: https://www.codeproject.com/Articles/704865/Salted-Password-Hashing-Doing-it-Right
    *            https://github.com/defuse/password-hashing/blob/master/PasswordStorage.cs
    */

    /// <summary>
    /// Helper für das Hashen und Validieren von Passwörtern.
    /// Hashing nach dem rfc2898 Standard mit der PBKDF2 Funktion.
    /// </summary>
    public static class SaltHashHelper
    {
        //Definierung der ByteArray Größen und Anzahl der Iterationen die, die PBKDF2 verwenden soll.
        public const int SaltByteSize = 24;
        public const int HashByteSize = 20;
        public const int Pbkdf2Iterations = 76238;
      
        /// <summary>
        /// Funktion die mit Hilfe eines RNG´s einen zufälligen Wert(Salt) generiert
        /// und diesen zusammen mit dem Password durch die PBKDF verschlüsselt
        /// </summary>
        /// <param name="password">User Password</param>
        /// <returns>Zwei Strings(Hash,Salt)</returns>
        public static (string,string) CreateHash(string password)
        {
            
            byte[] salt = new byte[SaltByteSize];
            try
            {
                //Generierung eines zufälligem Salts
                using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }
            }
            catch (CryptographicException ex)
            {
                throw new Exception(
                    "Random number generator not available.",
                    ex
                );
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(
                    "Invalid argument given to random number generator.",
                    ex
                );
            }

            //Hash generierung aus dem Salt und dem Pasword.
            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);

            return (Convert.ToBase64String(salt) + Convert.ToBase64String(hash), Convert.ToBase64String(salt));
                  
        }

        /// <summary>
        /// Funktion um das eingebene Password des Users mit dem Hash aus der Datenbank zu Validieren
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="hashString">Hash aus der Datenbank</param>
        /// <param name="saltString">Salt aus der Datenbank</param>
        /// <returns>Einen Booleschen Wert</returns>
        public static bool ValidatePassword(string password, string hashString,string saltString)
        {  
            //Konvertierung in ein ByteArrays um das gehashte Result (salt+password) mit dem hashString zu vergleichen.
            var salt = Convert.FromBase64String(saltString);          

            //Hash generierung aus dem Salt und dem Pasword.
            var testHash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);

            //Konvertierung der ByteArrays in einen string um diesen einfacher mit dem hashString zu vergleichen       
            if(hashString == (Convert.ToBase64String(salt) + Convert.ToBase64String(testHash)))           
                return true;

            return false;
        }

        /// <summary>
        /// Password-Based Key Derivation Function 2
        /// Internet Engineering Task Force
        /// https://tools.ietf.org/html/rfc2898
        /// 
        /// Rfc2898DeriveBytes nimmt ein Kennwort, einen Salt-Wert und eine Iterationsanzahl
        /// und generiert anschließend durch Aufrufen von Schlüssel die GetBytes Methode.
        /// 
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="salt">Random generated number</param>
        /// <param name="iterations">Iterationen</param>
        /// <param name="outputBytes">Größe des Output ByteArrays</param>
        /// <returns>Liefert ein ByteArray zurück</returns>
        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {           
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
