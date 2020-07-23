using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    public static class global {
        public static string[] grid = new string[9] {"1","2","3","4","5","6","7","8","9"};
        public static int turn = 1;
        public static Random rand = new Random();
    }

    public static void visual() {
        // outputs the current O's and X's grid
        Console.WriteLine($"| {global.grid[0]} , {global.grid[1]} , {global.grid[2]} |\n| {global.grid[3]} , {global.grid[4]} , {global.grid[5]} |\n| {global.grid[6]} , {global.grid[7]} , {global.grid[8]} |");
    }

    public static void pTurn(string n) {
        while (true) {
            Console.WriteLine("Enter a number");

            try {
                int input = Int32.Parse(Console.ReadLine().Trim());
                if (global.grid[input - 1] == "O" || global.grid[input - 1] == "X") {
                    Console.WriteLine("That space is already taken");
                } else {
                    global.grid[input - 1] = n;
                    break;
                }

            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }

    public static int AImove() {
        string[] tempGrid = global.grid;
        // checks for winning move
        for (int i = 0; i < 9; i++) {
            if (global.grid[i] != "O" && global.grid[i] != "X") {
                tempGrid[i] = "O";
                if (hasWon("O", tempGrid)) {
                    return(i);
                } else
                    tempGrid[i] = (i+1).ToString();
            }
        }
        // checks to block player's winning move
        for (int i = 0; i < 9; i++) {
            if (global.grid[i] != "O" && global.grid[i] != "X") {
                tempGrid[i] = "X";
                if (hasWon("X", tempGrid))
                    return(i);
                else
                    tempGrid[i] = (i+1).ToString();
            }
        }
        // if no winning/block move are possible, choose random spot
        while (true) {
            int rInt = global.rand.Next(0,9);
            if (global.grid[rInt] != "O" && global.grid[rInt] != "X")
                return(rInt);
        }
    }

    public static bool Draw() {
        int check = 0;
        // cycles through grid and adds 1 to "check" if space is occupied by a player
        for (int i = 0; i < 9; i++) {
            if (global.grid[i] == "O" || global.grid[i] == "X")
                check += 1;
        }
        // check == 9 if all spaces are occupied
        if (check == 9)
            return true;
        else 
            return false;
    }

    public static bool hasWon(string n, string[] grid) {
        // checks for winning conditions
        if (grid[0] == n && grid[1] == n && grid[2] == n) {
            return true;
        } else if (grid[3] == n && grid[4] == n && grid[5] == n) {
            return true;
        } else if (grid[6] == n && grid[7] == n && grid[8] == n) {
            return true;
        } else if (grid[0] == n && grid[3] == n && grid[6] == n) {
            return true;
        } else if (grid[1] == n && grid[4] == n && grid[7] == n) {
            return true;
        } else if (grid[2] == n && grid[5] == n && grid[8] == n) {
            return true;
        } else if (grid[0] == n && grid[4] == n && grid[8] == n) {
            return true;
        } else if (grid[6] == n && grid[4] == n && grid[2] == n) {
            return true;
        } else {
            return false;
        }
    }

    public static void Main(String[] args) {
        // if AI is playing, set to true. Else if it's PvP, set to false
        bool AI = true;

        while (true) {
            // if turn is not even (odd) then it's player 1's turn
            if (global.turn % 2 != 0) {
                Console.WriteLine("\nPlayer 1's Turn\n");
                visual();
                pTurn("X");
                visual();
                if (hasWon("X", global.grid)) {
                    visual();
                    Console.WriteLine("Player 1 Wins!");
                    break;
                }
            } else {
                Console.WriteLine("\nPlayer 2's Turn\n");
                switch (AI) {
                    case true:
                        global.grid[AImove()] = "O";
                        break;
                    case false:
                        visual();
                        pTurn("O");
                        break;
                }
                if (hasWon("O", global.grid)) {
                    visual();
                    Console.WriteLine("Player 2 Wins!");
                    break;
                }
            }
            if (Draw()) {
                Console.WriteLine("Draw.");
                visual();
                break;
            }
            global.turn += 1;
        }
    }
} 