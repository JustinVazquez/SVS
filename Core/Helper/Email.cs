using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using Core.Access;

namespace SVS
{
    public static class Email
    {
        public static void sendMail(List<string> list, string text)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("SVS.Aenderung@gmail.com", "Projekttage123!"),
                EnableSsl = true
            };

            foreach (var item in list)
            {
                client.Send("SVS.Aenderung@gmail.com", item, "Änderung Stundenplan", text);
            }

            Console.WriteLine("Sent");
            Console.ReadLine();

        }
    }
}