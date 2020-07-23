using System;

class Program {
    public static class global {
        public static int turn = 0;
        public static string[] row6 = new string[] {" "," "," "," "," "," "," "};
        public static string[] row5 = new string[] {" "," "," "," "," "," "," "};
        public static string[] row4 = new string[] {" "," "," "," "," "," "," "};
        public static string[] row3 = new string[] {" "," "," "," "," "," "," "};
        public static string[] row2 = new string[] {" "," "," "," "," "," "," "};
        public static string[] row1 = new string[] {" "," "," "," "," "," "," "};
    }

    public static void visual() {
        Console.WriteLine($" 1 2 3 4 5 6 7\n|{string.Join("|", global.row6)}|\n---------------\n|{string.Join("|", global.row5)}|\n---------------\n|{string.Join("|", global.row4)}|\n---------------\n|{string.Join("|", global.row3)}|\n---------------\n|{string.Join("|", global.row2)}|\n---------------\n|{string.Join("|", global.row1)}|");
    }

    public static void turn(int x, string y) {

        if (global.row1[x-1] == " ") 
            global.row1[x-1] = y;
        else if (global.row2[x-1] == " ")
            global.row2[x-1] = y;
        else if (global.row3[x-1] == " ")
            global.row3[x-1] = y;
        else if (global.row4[x-1] == " ")
            global.row4[x-1] = y;
        else if (global.row5[x-1] == " ")
            global.row5[x-1] = y;
        else 
            global.row6[x-1] = y;

    }

    public static bool hasWon(string y) {
        int n = 0;
        for (int i = 0; i < 7; i++) {
            // verical win conditions
            if (global.row1[i] == y && global.row2[i] == y && global.row3[i] == y && global.row4[i] == y) 
                return true;
            else if (global.row2[i] == y && global.row3[i] == y && global.row4[i] == y && global.row5[i] == y)
                return true;
            else if (global.row3[i] == y && global.row4[i] == y && global.row5[i] == y && global.row6[i] == y)
                return true;
            // horizontal win conditions
            if (i % 2 == 0) {
                if (global.row1[n] == y && global.row1[n+1] == y && global.row1[n+2] == y && global.row1[n+3] == y)
                    return true;
                else if (global.row2[n] == y && global.row2[n+1] == y && global.row2[n+2] == y && global.row2[n+3] == y)
                    return true;
                else if (global.row3[n] == y && global.row3[n+1] == y && global.row3[n+2] == y && global.row3[n+3] == y)
                    return true;
                else if (global.row4[n] == y && global.row4[n+1] == y && global.row4[n+2] == y && global.row4[n+3] == y)
                    return true;
                else if (global.row5[n] == y && global.row5[n+1] == y && global.row5[n+2] == y && global.row5[n+3] == y)
                    return true;
                else if (global.row6[n] == y && global.row6[n+1] == y && global.row6[n+2] == y && global.row6[n+3] == y)
                    return true;
                // diagonal win conditions
                else if (global.row1[n] == y && global.row2[n+1] == y && global.row3[n+2] == y && global.row4[n+3] == y)
                    return true;
                else if (global.row2[n] == y && global.row3[n+1] == y && global.row4[n+2] == y && global.row5[n+3] == y)
                    return true;
                else if (global.row3[n] == y && global.row4[n+1] == y && global.row5[n+2] == y && global.row6[n+3] == y)
                    return true;
                else if (global.row4[n] == y && global.row3[n+1] == y && global.row2[n+2] == y && global.row1[n+3] == y)
                    return true;
                else if (global.row5[n] == y && global.row4[n+1] == y && global.row3[n+2] == y && global.row2[n+3] == y)
                    return true;
                else if (global.row6[n] == y && global.row5[n+1] == y && global.row4[n+2] == y && global.row3[n+3] == y)
                    return true;
                
                n += 1;
            }
        }

        return false;
    }

    public static void Main(String[] args) {
        while (true) {
            Console.Clear();
            visual();
            Console.WriteLine($"Player {(global.turn % 2) + 1}'s Turn. Enter a number.");

            try {
               int input = Int32.Parse(Console.ReadLine());

                // enter 99 to force quit
               if (input == 99) 
                    break;
                
               if (global.turn % 2 == 0) {
                    turn(input, "X");
                    if (hasWon("X")) {
                        visual();
                        Console.WriteLine("Player 1 Wins!");
                        break;
                    }
               }
               else {
                    turn(input, "O");
                    if (hasWon("O")) {
                        visual();
                        Console.WriteLine("Player 2 Wins!");
                        break;
                    }
               }
                
                global.turn += 1;

            } catch (Exception e) {
               Console.WriteLine(e.Message);
            }

        }
    }
}