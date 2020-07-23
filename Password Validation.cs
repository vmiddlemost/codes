using System;
using System.Linq;

public class Program {
    public static bool ValidatePassword(string password) {
        char[] upper = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        char[] lower = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        char[] num = new char[] {'0','1','2','3','4','5','6','7','8','9'};
        char[] chars = new char[] {'!','@','#','$','%','^','&','*','(',')','+','=','_','-','{','}','[',']',':',';','?','<','>',',','.','\"','\''};
        char[] all = upper.Concat(lower).Concat(num).Concat(chars).ToArray();

        foreach (char x in password) {
            if (x.ToString().IndexOfAny(all) == -1) {
                return false;
            }
        }

        if  (password.Length > 24 || password.Length < 6) {
            return false;
        }

        if (password.IndexOfAny(upper) == -1 || password.IndexOfAny(lower) == -1 || password.IndexOfAny(num) == -1 || password.IndexOfAny(all) == -1) {
            return false;
        }

        for (int i = 0; i < password.Count()-1; i++) {
            if (password[i] == password[i+1] && password[i] == password[i+2]) {
                return false;
            }
        }
        return true;
    }
    public static void Main(String[] args) {
        Console.WriteLine(ValidatePassword("Fhg93@"));
    }
}