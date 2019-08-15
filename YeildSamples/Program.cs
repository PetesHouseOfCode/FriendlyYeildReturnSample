using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YeildSamples
{
    class Program
    {
        private static string[] friends = {"Ross Geller", "Monica Geller", "Rachel Green", "Joey Tribbiani", "Chandler Bing", "Phoebe Buffay"};
        static void Main(string[] args)
        {
            Console.WriteLine("Processed using a foreach loop with a 1 second thread sleep each time through.");
            foreach (var name in ProcessFriendsInLoop())
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Done");
            Console.WriteLine("Press enter");
            Console.ReadLine();
            Console.WriteLine("Now processing using yield return with a 1 second thread sleep each time through");
            foreach (var  name in ProcessFriendsWithYeid())
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static List<string> ProcessFriendsInLoop()
        {
            List<string> friendsInitials = new List<string>();
            foreach (var friend in friends)
            {
                Thread.Sleep(1000);
                var friendNames = friend.Split(' ');
                friendsInitials.Add($"{friendNames[0].Substring(0, 1)}.{friendNames[1].Substring(0, 1)}.");
                
            }

            return friendsInitials;
        }

        private static IEnumerable<string> ProcessFriendsWithYeid()
        {
            foreach (var friend in friends)
            {
                Thread.Sleep(1000);
                var friendNames = friend.Split(' ');
                yield return $"{friendNames[0].Substring(0, 1)}.{friendNames[1].Substring(0, 1)}";
            }
        }
    }
}
