using System;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Console_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today's Date is, {0}", DateTime.Now);

            //-?\d+(?:\.\d+)?\s*°\s*f(?:\s*-\s*-?\d+(?:\.\d+)?\s*°\s*c)?
            //for temperature as one string with farhenheit in case you want to use a different website

            //-?\d+(?:\.\d+)?\s*°\s*c(?:\s*-\s*-?\d+(?:\.\d+)?\s*°\s*c)?
            //for temperature as one string with celcius in case you want to use a different website

            //-?\d+(?:\.\d+)?\s*°
            //temperature only displaying degrees notation

            var client = new WebClient();
            var text = client.DownloadString("https://www.foreca.com/");
            
            string weatherfinder = @"-?\d+(?:\.\d+)?\s*°";
            Regex regexWeather = new Regex(weatherfinder);
            MatchCollection matchcollectionWeather = regexWeather.Matches(text);

            //Display the first item from the regex using the web scraper, unless this site changes its HTML
            //code the first hit will always be the current temperature
            Console.WriteLine("It is Currently {0}", matchcollectionWeather[0].Value);
            Console.WriteLine("Estimated temperture tommorrow will be {0}", matchcollectionWeather[10].Value);

            //Console.ReadKey();
        }

    }
}
