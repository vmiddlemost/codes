using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace app {

    class Program {

        static void Main(String[] args) {
            List<string> alph = new List<string>() {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            Random rnd = new Random();

            while (1 == 1) {
                Console.WriteLine("How many charcters do you want?");
                string size = Console.ReadLine().Trim();
                try {
                    int intSize = int.Parse(size);
                    StringBuilder password = new StringBuilder("", intSize);
                    for (int i = 0; i < intSize; i++) {
                        int fifty = rnd.Next(0,2);
                        if (fifty == 0) {
                            int rNum = rnd.Next(0,10);
                            password.Append(rNum);
                        } else {
                            int rAlph = rnd.Next(0,52);
                            password.Append(alph[rAlph]);
                }
                    }
                Console.WriteLine(password);
                } 
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
                }
            }
}