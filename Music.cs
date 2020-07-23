using System;
using System.Linq;
using System.Collections.Generic;

public class Program {
    public static class global {
        public static List<string> notes = new List<string>() {"A","A#","B","C","C#","D","D#","E","F","F#","G","G#","A","A#","B","C","C#","D","D#","E","F","F#","G","G#"};
        public static List<string> majNotes = new List<string>();
        public static List<string> minNotes = new List<string>();
        public static List<string> majChords = new List<string>();
        public static List<string> minChords = new List<string>();
        public static Random rand = new Random();
        public static bool isMajor = true;
    }

    public static void keyProperties(string n, string m) {
        
        global.majNotes.Clear();
        global.minNotes.Clear();
        global.majChords.Clear();
        global.minChords.Clear();

        // rootIndex = root note/name of the key
        int rootIndex = global.notes.IndexOf(n);
        // assigning the note intervals for both minor and major keys
        int[] majIntervals = new int[] {2,2,1,2,2,2,1};
        int[] minIntervals = new int[] {2,1,2,2,1,2,2};
        // assigning the names of chords for both minor and major keys
        List<string> majChordNames = new List<string>() {"Maj","min","min","Maj","Maj","min","dim"};
        List<string> minChordNames = new List<string>() {"min","dim","Maj","min","min","Maj","Maj"};

        // generating the notes for the user's key in both minor and major 
        int x = 0;
        int y = 0;
        for (int i = 0; i < 7; i++) {
            global.majNotes.Add(global.notes[rootIndex + x]);
            global.minNotes.Add(global.notes[rootIndex + y]);
            x += majIntervals[i];
            y += minIntervals[i];
        }

        // now generating the chords from the generated notes
        for (int i = 0; i < 7; i++) {
            global.majChords.Add(global.majNotes[i] + majChordNames[i]);
            global.minChords.Add(global.minNotes[i] + minChordNames[i]);
        }

        switch(m){
            case "M":
                Console.WriteLine($"\nNotes of {n} Major:\n[{string.Join(",", global.majNotes.ToArray())}]");
                Console.WriteLine($"Chords of {n} Major:\n[{string.Join(",", global.majChords.ToArray())}]");
                break;
            case "m":
                Console.WriteLine($"\nNotes of {n} Minor:\n[{string.Join(",", global.minNotes.ToArray())}]");
                Console.WriteLine($"Chords of {n} Minor:\n[{string.Join(",", global.minChords.ToArray())}]");
                global.isMajor = false;
                break;
        }

    }

    public static void chordProg() {
        if (global.isMajor) {
            Console.WriteLine("\nI-V-vi-IV (Pop)");
            Console.WriteLine($"{global.majChords[0]}, {global.majChords[4]}, {global.majChords[5]}, {global.majChords[3]}");
            Console.WriteLine("I-IV-V (Rock n Roll/Blues)");
            Console.WriteLine($"{global.majChords[0]}, {global.majChords[3]}, {global.majChords[4]}");
            Console.WriteLine("I-V-ii (Pop Jazz)");
            Console.WriteLine($"{global.majChords[0]}, {global.majChords[4]}, {global.majChords[1]}");
            Console.WriteLine("I-IV-vi-V (Sad Pop)");
            Console.WriteLine($"{global.majChords[0]}, {global.majChords[5]}, {global.majChords[3]}, {global.majChords[4]}");
        } else {
            Console.WriteLine("\nI-V-vi-IV (Pop)");
            Console.WriteLine($"{global.minChords[0]}, {global.minChords[4]}, {global.minChords[5]}, {global.minChords[3]}");
            Console.WriteLine("I-IV-V (Rock n Roll/Blues)");
            Console.WriteLine($"{global.minChords[0]}, {global.minChords[3]}, {global.minChords[4]}");
            Console.WriteLine("I-V-ii (Pop Jazz)");
            Console.WriteLine($"{global.minChords[0]}, {global.minChords[4]}, {global.minChords[1]}");
            Console.WriteLine("I-IV-vi-V (Sad Pop)");
            Console.WriteLine($"{global.minChords[0]}, {global.minChords[5]}, {global.minChords[3]}, {global.minChords[4]}");
        }
    }

    public static void randomProg() {
        List<string> rProg = new List<string>();
        List<int> rList = new List<int>();

        Console.WriteLine("\nHow many chords?");
        try {
            int n = Int32.Parse(Console.ReadLine());

            // this chunk of code provides a random list of numbers from 0 to 6 and makes sure no two exact numbers are next to one another
            for (int i = 0; i < n; i++) {
                int r = global.rand.Next(0,7);
                if (rList.Count > 0) {
                    while (rList[i-1] == r) {
                        r = global.rand.Next(0,7);
                    }
                }
                rList.Add(r);
            }

            // convert list of random numbers into their key's respective chords
            foreach (int x in rList) {
                if (global.isMajor) {
                    rProg.Add(global.majChords[x]);
                } else {
                    rProg.Add(global.minChords[x]);
                }
            }

            Console.WriteLine($"[{string.Join(",", rProg.ToArray())}]");

        } catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    public static void modes() {
        Console.WriteLine("Ionian mode (1,2,3,4,5,6,7)");
        Console.WriteLine($"{global.majNotes[0]}, {global.majNotes[1]}, {global.majNotes[2]}, {global.majNotes[3]}, {global.majNotes[4]}, {global.majNotes[5]}, {global.majNotes[6]}");

        Console.WriteLine("Dorian mode (1,2,b3,4,5,6,b7)");
        string b7 = global.notes[(global.notes.IndexOf(global.majNotes[5]) + 1)];
        string b3 = global.notes[(global.notes.IndexOf(global.majNotes[1]) + 1)];
        Console.WriteLine($"{global.majNotes[0]}, {global.majNotes[1]}, {b3}, {global.majNotes[3]}, {global.majNotes[4]}, {global.majNotes[5]}, {global.majNotes[6]}");
        
        Console.WriteLine("Phrygian mode (1,b2,b3,4,5,b6,b7)");
        string b2 = global.notes[(global.notes.IndexOf(global.minNotes[0]) + 1)];
        Console.WriteLine($"{global.minNotes[0]}, {b2}, {global.minNotes[2]}, {global.minNotes[3]}, {global.minNotes[4]}, {global.minNotes[5]}, {global.minNotes[6]}");
        
        Console.WriteLine("Lydian mode (1,2,3,#4,5,6,7)");
        string s4 = global.notes[(global.notes.IndexOf(global.majNotes[2]) + 2)];
        Console.WriteLine($"{global.majNotes[0]}, {global.majNotes[1]}, {global.majNotes[2]}, {s4}, {global.majNotes[4]}, {global.majNotes[5]}, {global.majNotes[6]}");
        
        Console.WriteLine("Mixolydian mode (1,2,3,4,5,6,b7)");
        Console.WriteLine($"{global.majNotes[0]}, {global.majNotes[1]}, {global.majNotes[2]}, {global.majNotes[3]}, {global.majNotes[4]}, {global.majNotes[5]}, {b7}");
        
        Console.WriteLine("Aeolian mode (1,2,b3,4,5,b6,b7)");
        Console.WriteLine($"{global.minNotes[0]}, {global.minNotes[1]}, {global.minNotes[2]}, {global.minNotes[3]}, {global.minNotes[4]}, {global.minNotes[5]}, {global.minNotes[6]}");
        
        Console.WriteLine("Locrian mode (1,b2,b3,4,b5,b6,b7)");
        string b5 = global.notes[(global.notes.IndexOf(global.minNotes[3]) + 1)];
        Console.WriteLine($"{global.minNotes[0]}, {global.minNotes[1]}, {global.minNotes[2]}, {global.minNotes[3]}, {b5}, {global.minNotes[5]}, {global.minNotes[6]}");
    }

    public static void minScales() {
        Console.WriteLine("Minor Pentatonic Scale (1,b3,4,5,b7)");
        Console.WriteLine($"{global.minNotes[0]}, {global.minNotes[2]}, {global.minNotes[3]}, {global.minNotes[4]}, {global.minNotes[6]}");
        // blues scale makes use of a flat 5th note (b5) - which isn't included within the user's key's notes
        Console.WriteLine("Blues Scale (1,b3,4,b5,5,b7)");
        string b5 = global.notes[(global.notes.IndexOf(global.minNotes[0]) + 6)];
        Console.WriteLine($"{global.minNotes[0]}, {global.minNotes[2]}, {global.minNotes[3]}, {b5}, {global.minNotes[4]}, {global.minNotes[6]}");
    }

    public static void convert(string n) {
        if (global.isMajor) {
            global.isMajor = false;
            keyProperties(n, "m");
        } else {
            global.isMajor = true;
            keyProperties(n, "M");
        }
    }
    
    public static void Main(String[] args) {
        while (true) {
            Console.Clear();
            Console.WriteLine("Which key do you want to know about? (eg. enter \"B m\" for B minor or \"D# M\" for D# Major)\n(No flats (b), just sharps (#) are taken)");
            try {
                // asks user for name of key and splits the string into two (eg. C# m => "C#" & "m") and then uses the keyProperties method
                string key = Console.ReadLine();
                string[] keySplit = key.Split(' ');
                keyProperties(keySplit[0].ToUpper(),keySplit[1]);

                bool loop = true;
                while(loop) {
                    Console.WriteLine("\nEnter:\n\"X\" to pick another key\n\"C\" to generate common chord progressions\n\"R\" to generate a random chord progression");
                    Console.WriteLine("\"S\" to generate commonly used scales\n\"T\" to convert key between major/minor\n\"M\" to generate all modes of that key");
                    // now after giving the user all notes/chords within a key, allowing the user to make another key or give them more info about key
                    try {
                        string input = Console.ReadLine().ToUpper().Trim();
                        switch(input) {
                            case "X":
                                loop = false;
                                break;
                            case "C":
                                chordProg();
                                break;
                            case "R":
                                randomProg();
                                break;
                            case "T":
                                convert(keySplit[0].ToUpper());
                                break;
                            case "M":
                            Console.WriteLine($"\nAll modes in {keySplit[0].ToUpper()}");
                                modes();
                                break;
                            case "S":
                                switch(keySplit[1]) {
                                    case "m":
                                        minScales();
                                        break;
                                    case "M":
                                        //majScales();
                                        break;
                                }
                                break;
                        }
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
