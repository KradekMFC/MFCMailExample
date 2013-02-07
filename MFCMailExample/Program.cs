using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper;
using HtmlAgilityPack;

namespace MFCMailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup parameters
            var mailUrl = "http://www.myfreecams.com/mfc2/php/message.php";
            var loginUrl = "http://www.myfreecams.com/mfc2/php/login.php";
            var username = "<replace with username>";
            var password = "<replace with password>";
            var loginParameters = new NameValueCollection 
            {
                { "submit_login", CharCode(username[0])}, //this is the only real tricky bit about logging into MFC
                { "profiles_login", "1"},                 //They expect the submit_login parameter, which is the unicode
                { "username", username },                 //number for the first letter of the users name
                { "password", password }, 
                { "action", "process_login" }
            };

            //create an authorized client
            var client = new SecureWebPage(loginUrl, loginParameters);

            //check the mail
            var msgs = client.Load(mailUrl).DocumentNode.SelectNodes("//tr[@class=\" message_new\"]");

            if (null != msgs)
                Console.WriteLine("You have new mail!");
            else
                Console.WriteLine("Bummer, no new mail.");
            Console.ReadLine();
 
        }

        //Used to mimic the charCodeAt Javascript method
        static String CharCode(char chr)
        {
            UTF32Encoding encoding = new UTF32Encoding();
            byte[] bytes = encoding.GetBytes(chr.ToString().ToCharArray());
            return BitConverter.ToInt32(bytes, 0).ToString();
        }
    }
}
