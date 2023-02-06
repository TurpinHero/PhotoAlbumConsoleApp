using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace PhotoAlbumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Select a photo album: ");
            sendLine();

        }

        private static void sendLine()
        {

            String number = Console.ReadLine();
            if(number.ToLower().Equals("quit"))
            {
                Environment.Exit(0);
            }
            var json = new WebClient().DownloadString("https://jsonplaceholder.typicode.com/photos?albumId=" + number);
            String[] list = json.Split('{');
            if (list.Length > 1)
            {
                Console.WriteLine("\nHere is a list of the IDs and Titles of photo album " + number + ":\n");
                foreach (string st in list)
                {
                    if (st.Contains(","))
                    {

                        String id = st.Split(',')[1];
                        String title = st.Split(',')[2];
                        id = id.Substring(11);
                        title = title.Split('"')[3];

                        Console.WriteLine(id + ": " + title);

                    }
                }
                Console.Write("\nInput another photo album or write quit to quit: ");
                sendLine();
            }
            else
            {
                Console.Write("\nThe Photo album " + number + " does not exist. \nPlease input a different photo album or write quit to quit: ");
                sendLine();
            }
            Console.ReadLine();
        }
    }
}
