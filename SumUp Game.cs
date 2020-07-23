using System;
using System.Collections.Generic;
using System.Linq;

public class Program {
    public static class Global {
        public static int difficulty = 0;
        public static List<string> solutions = new List<string>();
    }
    public static int SumUp(int x) {
        Random rnd = new Random();
        int check = 4;
        int[] nums = new int[x];
        int[] numsSorted = new int[x];
        // reset solutions each SumUp game
        Global.solutions.Clear();

        Console.WriteLine("INPUT:");

        // load nums array with random numbers from 3-12
        for (int i = 0; i < x; i++) {
            nums[i] = rnd.Next(3,13);
        }
        
        // output sum starts as the first random number
        int sum = nums[0];

        for (int i = 0; i < x-1; i++) {
            // check if sum is divisible by the next term.
            // if true: division becomes an optional operator
            if (sum % nums[i+1] == 0) {
                check = 6;
            }
            // randomly picks an opertor, 1 = + | 2 = - | 3 = * | 4/5 = / (dividing is more likely if it's possible as to even it up a bit)
            // then adds the numbers and operators to the solution list
            int temp = rnd.Next(1,check);
            switch(temp) {
                case 1:
                    sum = sum + nums[i+1];
                    Global.solutions.Add($"{nums[i]}+");
                    break;
                case 2:
                    sum = sum - nums[i+1];
                    Global.solutions.Add($"{nums[i]}-");
                    break;
                case 3:
                    sum = sum * nums[i+1];
                    Global.solutions.Add($"{nums[i]}*");
                    break;
                case 4:
                    sum = sum / nums[i+1];
                    Global.solutions.Add($"{nums[i]}/");
                    break;
                case 5:
                    sum = sum / nums[i+1];
                    Global.solutions.Add($"{nums[i]}/");
                    break;
            }
            check = 4;
        }

        // add final number to solution list
        Global.solutions.Add($"{nums[nums.Length-1]}");
        //Console.WriteLine($"Solution: {string.Join("", Global.solutions.ToArray())}");

        // if global.difficulty is 1, then the list of random integers is sorted in order of size - thus making it harder to win
        if (Global.difficulty == 1) {
            Array.Sort(nums);
        }

        // output all random numbers
        for (int i = 0; i < x; i++) {
            Console.WriteLine(nums[i]);
        }
        
        Console.WriteLine("Target:");
        return(sum);
    }

    public static bool AnswersCheck(string answers) {
        // change global.solutions to a string
        string solutions = string.Join("", Global.solutions);
        // compare user's solution to the actual solution
        if (answers == solutions) {
            Console.WriteLine("Correct!");
            return true;
        }
        Console.WriteLine("Incorrect");
        return false;

    }

    public static void Main(String[] args) {
        int t = 0;
        // create 'while loop' which allows the user to keep repeating until they desire to quit program
        while (t == 0) {
            Console.Clear();
            Console.WriteLine("Enter how many numbers you'd like to play with.");

            try {
                // x = number of numbers used per game
                int x = Int32.Parse(Console.ReadLine().Trim());
                Console.WriteLine(SumUp(x));

                int y = 0;
                // another 'while loop' which allows user to repeat the same problem if they don't get it correct the first time
                while (y == 0) {
                    // input user's answers into a string
                    string answers = Console.ReadLine().Trim();
                    if (AnswersCheck(answers)) {
                        Console.WriteLine("Press enter to try another.\nEnter any key to quit.");
                        // if user is correct, gives user the choice of either quitting or trying another problem
                        string r = Console.ReadLine();
                        y = 1;
                        if (r != "") {
                            t = 1;
                        }
                        
                    } else {
                        Console.WriteLine("Enter r to retry.\nPress enter to try another.\nEnter any key to try another.");
                        // if user is incorrect, gives user the choice of either quitting, trying another problem or trying the same problem again
                        string r = Console.ReadLine();
                        if (r == "") {
                            y = 1;
                        } else if (r != "r") {
                            y = 1;
                            t = 1;
                        }
                    }
                }


            } catch (Exception e) {
                Console.WriteLine(e.Message);      
            }

        }
    }
}