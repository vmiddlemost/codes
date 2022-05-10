# codes
Just a dumping ground for some codes I've worked on by myself

BlackJack.cs
 - A text-based card game following the rules of blackjack (or 21)
 - Contains a money system, whereby the player starts the game with £200 and buys in each hand
 - Can bet any amount of money inbetween turns if player chooses "hit"
 - Can instead "twist" to gain card without putting more money down
 - If player's wallet falls below the buy-in amount (£20), the game ends

Ceaser Cypher.cs
 - A simple ceaser cypher for both encrypting and decrypting messages
 - Works by using a key (an integer > 0) to shift the letters within the message either to encrypt or decrypt
 - If user has no key, there is a brute-force system in place which will use all keys available (1-25) on the encrypted message and will print out all of them

Connect 4.cs
 - A text-based version of the popular game, Connect 4
 - This is player vs player and uses "-" for an empty space, "|" for the borders, "X" for player 1's token and "O" for player 2's token
 - The game ends when one of the players gets 4 of their tokens lined up either vertically, horizontally or diagonally

Music.cs
 - A tool I developed to help me practise playing music
 - User enters the name of a key they wish to know more about (e.g C# Minor)
 - Then my code will determine all notes and chords within said key and print them out for the user to read
 - User can then:
  - Enter another key they wish to know more about
  - Generate commonly used chord progressions within their key
  - Generate a random chord progression
  - Generate commonly used scales within their key
  - Convert their key to the parrallel key (if in major, converts to minor and vise versa)
  - Generate all major modes from their key
 
Password Generator.cs
 - Generates a random string of letters (lower and upper case) for the user to use as a password

Password Validation.cs
 - A simple piece of code which determines if the user's password follows these rules:
  - Must contain only suitable characters (all suitable characters are at the top of the ValidatePassword method)
  - Length of password is between 6 and 24
  - no more than two of the same characters next to each other

Pig Latin.cs
 - Converts user's message into pig latin (e.g "What's up?" -> "At's-whay-up-way?")

Pokemon.cs
 - A text-based turn-based battle game inspired by - or rather, stolen from - the Pokemon video games
 - Just contains two pokemon and is player vs player
 - Each pokemon has 4 moves to choose from
 - Each move is either a damage move, or a status move and have the following properties:
  - Power -> How much damage the move will do (status moves do not have any power)
  - Accuracy -> How likely the attack is to hit
  - Type -> The elemental type of the attack (e.g Fire moves will do double damage to Grass type Pokemon but half damage to Water type Pokemon)
  - Crit -> How likely the attack is to deal critical (double) damage - most moves default to a crit chance of 1/16 and status moves do not use this property
 - Each pokemon also has different stats, such as health, speed, attack, defense etc.. which all get used in a damage calculating formula to determine how much they get hurt or how much they hurt
 - Status moves can either be used to hurt their opponent (e.g Thunder Wave paralyses its opponent if it hits, which slows the opponent's speed and may make it so they cannot attack that turn) or help theirselves (Roost heals half of the Pokemon's health but temporarily removes Flying as a type of the Pokemon - meaning Ground type attacks can now hit)
 
 Prime Number functions.cs
  - Code which contains some functions useful when dealing with prime numbers
  - isPrime method checks if the user's number is a prime number
  - printPrimes method prints all prime numbers up to and including a number the user inputs
  - printXPrimes method prints the first "x" number of prime numbers - "x" being an input from the user
  - nextPrime method finds the next prime number along from the user's input
  
 Simplify Fractions.cs
  - Piece of code which simplifies the user's fraction input (e.g if user inputs "-100/-400", the code prints out "1/4")

SumUp Game.cs
 - Based on the number game on the TV Show, Countdown
 - Program asks user how many numbers they wish to play with (the higher the number, the harder the game)
 - Then the program prints out a list of numbers between 3 and 12 and a sum number
 - The user then needs to work out, by using all listed numbers given exactly once, how to obtain the sum number using operators (+, -, * or /)
 - User can then input their answer and if it is correct, they can either play again or quit
 - If user's answer is incorrect, they can either retry, play another game or quit

Syllable Count.cs
 - Very simple code which determines how many syllables are within a given string (seperated by "-"s)

Tic Tac Toe.cs
 - A text-based game based on the real life game, Tic Tac Toe
 - Can either be played as player vs player or against a fairly simple bot
 - Game ends when either player wins or if there is a draw


