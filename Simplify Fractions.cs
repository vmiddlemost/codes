using System;


public class Program {
    public static string Simplify(string str) {
        string[] sum = str.Split("/");
        int x = Int32.Parse(sum[0]);
        int y = Int32.Parse(sum[1]);
        int largestDivider = 1;

        for (int i = 1; i <= y; i++) {
            if (x % i == 0 && y % i == 0)
                largestDivider = i;
        }

        if (x > y && x % y == 0) 
            return($"{x / y}");

        return($"{x / largestDivider}/{y / largestDivider}");        
    }




    public static void Main(String[] args) {
        Console.WriteLine(Simplify("-100/-400"));
    }
}