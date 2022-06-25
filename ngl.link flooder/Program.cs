using System;
using System.Net;
using System.Collections.Specialized;
using System.Threading;

namespace ngl.link_flooder
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.Title = "ngl.link Flooder By SkemiiL";
            string logo = @"             _   _ _       _       __ _                 _           
 _ __   __ _| | | (_)_ __ | | __  / _| | ___   ___   __| | ___ _ __ 
| '_ \ / _` | | | | | '_ \| |/ / | |_| |/ _ \ / _ \ / _` |/ _ \ '__|
| | | | (_| | |_| | | | | |   <  |  _| | (_) | (_) | (_| |  __/ |   
|_| |_|\__, |_(_)_|_|_| |_|_|\_\ |_| |_|\___/ \___/ \__,_|\___|_|   
       |___/                                      by SkemiiL
";

            var wb = new WebClient();
            var data = new NameValueCollection();

            Console.WriteLine(logo);

            Console.Write("User: ");
            string user = Console.ReadLine();
            Console.Write("Text: ");
            string text = Console.ReadLine();
            Console.Write("Amount: ");
            int amt = Convert.ToInt32(Console.ReadLine());

            string url = "https://ngl.link/" + user;
            data["question"] = text;

            for(int i = 1; i <= amt;)
            {
                try
                {
                    wb.UploadValues(url, "POST", data);
                    Console.WriteLine("[+] Sending " + text + " to " + url + " " + i + " out of " + amt);
                    i++;
                }
                catch(System.Net.WebException)
                {
                    Console.WriteLine("[+] Rate limited waiting 1.5 seconds");
                    Thread.Sleep(1500);
                }
            }
            Console.WriteLine("[-] Finished flood!\n--- Press Enter To Restart ---");
            Console.ReadLine();
            Main();
        }
    }
}