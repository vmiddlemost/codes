using System;

class Program {
    // checks if number is prime
    public static bool isPrime(int x) {
        if (x <= 1)
            return false;
        else if (x == 2)
            return true;
        else
            for (int i = 2; i < x; i++) {
                if (x % i == 0)
                    return false;
            }
        return true;
    }
    // prints all primes up to and including y - starting from x
    public static void printPrimes(int x, int y) {
        for (int i = x; i < y; i++) {
            if (Program.isPrime(i))
                Console.WriteLine(i);
        }
    }
    // prints first x primes
    public static void printXPrimes(int x) {
        int n = 0;
        int t = 0;
        while (n < x) {
            if (Program.isPrime(t)) {
                Console.WriteLine(t);
                n += 1;
            }
            t += 1;
        }
    }
    // finds the next prime after any integer x
    public static int nextPrime(int x) {
        for (int i = x; i < x*10000; i++) {
            if (Program.isPrime(i))
                return i;
        }
        return x;
    }

    public static void Main(String[] args) {
        //printPrimes(0, 1000);
        //printXPrimes(100);
        Console.WriteLine(nextPrime(14));
    }
}