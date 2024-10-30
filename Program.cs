using System;
using System.Collections.Generic;

class Hangman
{
    static void Main()
    {
        string selectedWord = GenerateRandomWord();
        HashSet<char> guessedLetters = new HashSet<char>();
        //making a list for non repeatable 
        int attemptsLeft = 6;

        while (attemptsLeft > 0)
        {
            DisplayWord(selectedWord, guessedLetters);
            Console.WriteLine($"Attempts left: {attemptsLeft}");
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
            Console.Write("Enter a letter: ");
            char guess = char.Parse(Console.ReadLine());
            Console.WriteLine();

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter. Try again.");
            }
            else
            {
                guessedLetters.Add(guess);
                if (!selectedWord.Contains(guess))
                {
                    attemptsLeft--;
                    Console.WriteLine("Wrong guess!");

                }

                if (IsWordGuessed(selectedWord, guessedLetters))
                {
                    Console.Clear();
                    DisplayWord(selectedWord, guessedLetters);
                    Console.WriteLine("Congratulations! You've guessed the word!");
                    break;
                }
            }

            if (attemptsLeft == 0)
            {
                Console.Clear();
                Console.WriteLine($"Game over! The word was: {selectedWord}");
            }
        }
    }

    public static void DisplayWord(string word, HashSet<char> guessedLetters)
    {
        foreach (char letter in word)
        {
            if (guessedLetters.Contains(letter))
            {
                Console.Write(letter + " ");
            }
            else
            {
                Console.Write("_ ");
            }
        }
        Console.WriteLine();
    }

    public static bool IsWordGuessed(string word, HashSet<char> guessedLetters)
    {
        foreach (char letter in word)
        {
            if (!guessedLetters.Contains(letter))
            {
                return false;
            }
        }
        return true;
    }
    public static string GenerateRandomWord()
    {
        string result = string.Empty;

        string[] words =
        {
          "apple", "baby", "ball", "beach", "bear", "bed", "bike", "bird", "book", "box",
          "boy", "bread", "cake", "car", "cat", "chair", "city", "cloud", "cold", "cow",
          "cup", "day", "dog", "door", "duck", "ear", "earth", "egg", "eye", "farm",
          "fish", "flag", "flower", "food", "foot", "fork", "frog", "game", "girl", "glass",
          "goat", "good", "grass", "green", "hat", "heart", "hill", "home", "horse", "hot",
          "house", "ice", "jar", "key", "kite", "lake", "leaf", "leg", "light", "lion",
          "man", "milk", "moon", "mouse", "night", "nose", "nut", "park", "pen", "pig",
          "plant", "rain", "red", "ring", "rock", "roof", "room", "rose", "sea", "ship",
          "shoe", "sky", "snow", "soap", "star", "stone", "sun", "table", "tree", "truck",
          "wall", "water", "wind", "window", "wolf", "wood", "work", "year", "yellow", "zoo"
        };


        Random random = new Random();
        int index = random.Next(0, words.Length);

        result = words[index];

        return result;
    }
}