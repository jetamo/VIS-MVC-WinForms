using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DomainLayer
{
    public static class EmailSender
    {
        public static bool SendEmail(string _text, string _email)
        {
            try
            {
                //send email implementation
                Debug.WriteLine("Odesilani emailu na email: " + _email + " s textem: " + _text);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
