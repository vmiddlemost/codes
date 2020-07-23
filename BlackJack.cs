using System;
using System.Collections.Generic;
using System.Linq;
public class Program {
    public static class Global {
        public static List<string> player = new List<string>();
        public static List<string> dealer = new List<string>();
        public static int wallet = 200;
        public static int cash = 0;
        public static Random rand = new Random();
        public static int playerSum = 0;
        public static int dealerSum = 0;
        public static int aceCount = 0;
    }

    public enum Cards {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13

    }

    public static void aceCheck(List<string> x) {
        if (x == Global.player) {
            if (x.Contains("Ace") && Global.playerSum > 21 && Global.aceCount > 0) {
                Global.playerSum -= 10;
                Global.aceCount = 0;
            }
        } else {
            if (x.Contains("Ace") && Global.dealerSum > 21 && Global.aceCount > 0) {
                Global.dealerSum -= 10;
                Global.aceCount = 0;
            }
        }
    }

    public static void draw(List<string> x) {
        // generate rInt to be any number between (and including) 1 and 13
        int rInt = Global.rand.Next(1,14);
        // add the randomized index number of the Cards enum to the hand
        string card = Enum.GetName(typeof(Cards), rInt);
        x.Add(card);
        // Jack, Queen and King has a value of 10 in Blackjack 
        if (card == "Jack" || card == "Queen" || card == "King") {
            rInt = 10;
        } else if (card == "Ace") {
            Global.aceCount = 1;
            rInt = 11;
        }
        // Adds the card value to the hand's total sum
        if (x == Global.player) {
            Console.WriteLine($"You draw a {card}.");
            Global.playerSum += rInt;
            aceCheck(x);
        } else {
            Console.WriteLine($"Dealer draws a {card}.");
            Global.dealerSum += rInt;
            aceCheck(x);
        }

    }

    public static void hit() {
        int t = 0;
        while (t == 0) {
            Console.WriteLine("Enter how much:");
            int c = System.Math.Abs(Convert.ToInt32(Console.ReadLine().Trim()));
            if (c <= Global.wallet) {
                Global.wallet -= c;
                Global.cash += c;
                draw(Global.player);
                t = 1;
            } else {
                Console.WriteLine("You haven't got the gwop, buddy.");
            }
        }
        
    }

    public static void dealersTurn() {
        draw(Global.dealer);
        draw(Global.dealer);
        Console.WriteLine($"\nDealer has {Global.dealerSum}.\n");
        while (Global.dealerSum <= 15) {
            draw(Global.dealer);
            Console.ReadLine();
            Console.WriteLine($"\nDealer has {Global.dealerSum}.\n");
        }
        if (Global.dealerSum > 21) {
            Console.WriteLine($"Dealer has bust!\nYou win £{Global.cash}.");
            Global.wallet += 2*Global.cash;
            Console.ReadLine();
        } else if (Global.dealerSum >= Global.playerSum) {
            Console.WriteLine("Dealer sticks.");
            Console.WriteLine($"Dealer has won.");
            Console.ReadLine();
        } else {
            Console.WriteLine("Dealer sticks.");
            Console.WriteLine($"Dealer has lost! You've won £{Global.cash}.");
            Global.wallet += 2*Global.cash;
            Console.ReadLine();
        }        
    }

    public static void Main(String[] args) {
        int x = 0;
        Console.WriteLine("Welcome to BlackJack. Ace is high or low.");
        Console.ReadLine();
        while (x == 0) {
            Console.Clear();
            Console.WriteLine($"You have: £{Global.wallet}");
            Console.WriteLine("Press 'enter' to buy-in this round. Enter any other key to quit. \n(buy-in is £20)");
            string a = Console.ReadLine().Trim();
            if (a == "") {
                // clear the hands and cash pot for new round
                Global.cash = 0;
                Global.player.Clear();
                Global.dealer.Clear();
                Global.playerSum = 0;
                Global.dealerSum = 0;

                int round = 0;
                if (Global.wallet < 20) {
                    Console.WriteLine("Insufficient funds. No more poker for you tonight, pal.");
                    x = 1;
                    round = 1;
                } else {
                    draw(Global.player);
                    draw(Global.player);
                }
                Global.wallet -= 20;
                Global.cash += 20;
                if (Global.player.Contains("Jack") && Global.player.Contains("Ace")) {
                    Console.WriteLine("That's blackjack.\nYou win!");
                    Global.wallet = 2*Global.cash;
                    round = 1;
                }
                while (round == 0) {
                    Console.WriteLine($"\n£{Global.wallet}    Hand: {string.Join(",", Global.player.ToArray())} = {Global.playerSum}\nCash Pot: £{Global.cash}");
                    if (Global.playerSum > 21) {
                        Console.WriteLine("Bust! Dealer wins.");
                        round = 1;
                    } else {
                        Console.WriteLine("(H)it, (t)wist or (s)tick?");
                    }
                    try {
                        string b = Console.ReadLine().Trim();

                        if (b == "h" || b == "H" || b == "Hit" || b == "hit") {
                            hit();

                        } else if (b == "t" || b == "T" || b == "Twist" || b == "twist") {
                            draw(Global.player);

                        } else if (b == "s" || b == "S" || b == "Stick" || b == "stick") {
                            dealersTurn();
                            round = 1;
                            
                        }
                            
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                }
            } else {
                Console.WriteLine("Hope to see you again!");
                x = 1;
                Console.ReadLine();
            }
        }
    }
}