using System;
using System.Linq;

public class Program {

    public static int NumberSyllables(string word) {
        return word.Count(c => c == '-')+1;
    }
    public static void Main(String[] args) {
        Console.WriteLine(NumberSyllables("e-lec-tric-it-y"));
    }
}