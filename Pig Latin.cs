using System;
using System.Linq;
using System.Collections.Generic;

public class Program {
    public static class Globals {
        public static char[] vowels = {'a','e','i','o','u','A','E','I','O','U'};
        public static char[] specials = {'!','.','?',','};
    }
    public static string TranslateWord(string word) {
        bool check1 = false;
        string special = "";
        string Squote = "";
        string Mquote = "";
        string Equote = "";

        if (word == "") {
            return word;
        }
        // check if quotation mark is at the start and save to Squote if true
        if (word.Substring(0,1) == "\"" || word.Substring(0,1) == "\'") {
            Squote = Squote + word[0];
            word = word.Remove(0,1);
        }
        // check if quotation mark is at the end and save to Equote if true
        if (word.Substring(word.Length - 1,1) == "\"" || word.Substring(word.Length - 1,1) == "\'") {
            Equote = Equote + word[word.Length-1];
            word = word.Remove(word.Length - 1,1);
        }
        // check if quotation mark is just before the end (eg. He said "No"?) and save to Mquote if true
        if (word.Length > 1) {
            if (word.Substring(word.Length - 2,1) == "\"" || word.Substring(word.Length - 2,1) == "\'") {
            Mquote = Mquote + word[word.Length-2];
            word = word.Remove(word.Length - 1,1);
            }
        }

        foreach (char x in word) {
            if (x.ToString().IndexOfAny(Globals.specials) != -1) {
                special = special + word[word.Length-1];
                word = word.Remove(word.Length - 1, 1);
            }
        }

        if (Globals.vowels.Contains(word[0])) {
            return(Squote+word+"yay"+Mquote+special+Equote);
        }

        if (Char.IsUpper(word[0]) && word.Length > 1) {
            word = word.ToLower();
            check1 = true;
        }

        for (int i = 0; i < word.Length; i++) {
            if (!Globals.vowels.Contains(word[0])) {
                word = word.Substring(1) + word[0];
            } else {
                i = word.Length;
            }
        }

        if (check1) {
            String altWord = word.Substring(0, 1).ToUpper() + word.Substring(1);
            return(Squote+altWord+"ay"+Mquote+special+Equote);
        }

        return(Squote+word+"ay"+Mquote+special+Equote);
    }

    public static string TranslateSentence(string sentence) {
        string[] words = sentence.Split(' ');
        string pigSentence = "";
        int x = 0;

        foreach (string word in words) {
            if (x == 0) {
                pigSentence = pigSentence + Program.TranslateWord(word);
                x = 1;
            } else {
                pigSentence = pigSentence + " " + Program.TranslateWord(word);
            }
        }

        return pigSentence;
    }

    public static void Main(String[] args) {
        Console.WriteLine(TranslateSentence("I like to eat honey waffles"));
    }
}