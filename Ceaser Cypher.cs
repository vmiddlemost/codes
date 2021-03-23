using System;
using System.Collections.Generic;

class program {
    public class global {
        public static char[] alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
    }
    public static string Cypher(int key, string message, bool coded) {
        // convert message to all caps
        message = message.ToUpper();
        // initialize the char array version of the message
        char[] messageArray = message.ToCharArray();
        for (int i = 0; i < messageArray.Length; i++) {
            // convert message into char array
            char letter = messageArray[i];
            // spaces are not encrypted so are ignored for this program
            if (letter != ' ') {
                // find numerical value of each letter using the global alphabet
                int index = Array.IndexOf(global.alphabet, letter);
                // if coded == true; the key is now used to decrypt the message
                // if coded == false; the key is used to now encrypt the message
                if (coded) {
                    messageArray[i] = global.alphabet[index + (26 - key)];
                }
                else
                    messageArray[i] = global.alphabet[index + key];
                }

            
        }
        // convert char array into string
        string newMessage = new string(messageArray);

        return(newMessage);
    }

    // if you want to brute-force a cyphered message but don't have the key to go with it
    public static void CypherNoKey(string message) {
        for (int i = 1; i < 26; i++) {
            Console.WriteLine($"Key = {i}: {Cypher(i, message, true)}\n");
        }
    }

    public static void Main(String[] args) {
        // make sure: 0 < int key < 26
        Console.WriteLine(Cypher(5, "MJQQT RD KWNJSI", true));
        CypherNoKey("MJQQT RD KWNJSI");
    }
}
