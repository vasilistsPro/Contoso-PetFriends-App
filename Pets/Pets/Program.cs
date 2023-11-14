using System;
using System.Threading;

class Pets
{
    static void Main()
    {
        // Declare and initialize animalsArray
        string[] animalsArray = {
            "Dog: Jake is a friendly and playful dog.",
            "Dog: Lola is a fast and energetic dog.",
            "Cat: Whiskers is an independent cat.",
            "Dog: Max is a loyal and well-behaved dog."
        };

        // Display main menu options
        Console.WriteLine("1. List all of our current pet information");
        Console.WriteLine("2. Display all dogs with a specified characteristic");
        Console.WriteLine("Enter menu item selection or type 'Exit' to exit the program");

        // Read user input
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                // Display all animals
                foreach (string animal in animalsArray)
                {
                    Console.WriteLine(animal);
                }
                break;

            case "2":
                // Dog multiple attribute search
                Console.WriteLine("Enter dog characteristics separated by commas:");
                string userInputTerms = Console.ReadLine();

                // Validate input
                if (string.IsNullOrEmpty(userInputTerms) || userInputTerms.Trim().Length == 0)
                {
                    Console.WriteLine("Invalid input. Please enter at least one search term.");
                    break;
                }

                // Gather multiple search terms from the user
                string[] searchTerms = userInputTerms.Split(',');
                Array.Sort(searchTerms, StringComparer.OrdinalIgnoreCase);

                Console.WriteLine("\nSearching for dogs with specified characteristics...\n");

                bool anyMatches = false;

                // Searching animation
                string[] searchingIcons = { "⠋ ", "⠙ ", "⠹ ", "⠸ ", "⠼ ", "⠴ ", "⠦ ", "⠧ ", "⠇ ", "⠏ " };

                // Countdown loop
                for (int countdown = 2; countdown >= 0; countdown--)
                {
                    // Animation loop
                    for (int i = 0; i < searchingIcons.Length; i++)
                    {
                        Console.Write($"\rSearching {searchingIcons[i]} / {countdown}");
                        Thread.Sleep(100); // Adjust the delay as needed
                    }
                }

                // Identify dogs with descriptions with matches for one, or more, user search term
                foreach (string animal in animalsArray)
                {
                    if (animal.StartsWith("Dog"))
                    {
                        bool dogMatch = false;

                        // Search for matches for each term the user has entered
                        foreach (string term in searchTerms)
                        {
                            if (animal.IndexOf(term.Trim(), StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                // Output a message with the dog's name and the term that is matched
                                Console.WriteLine($"\nOur dog {GetDogName(animal)} is a match for your search for {term}!");
                                dogMatch = true;
                                anyMatches = true;
                            }
                        }

                        // After all term searches complete for the current dog description
                        if (dogMatch)
                        {
                            // Output the nickname and description for the current dog
                            Console.WriteLine($"{GetDogName(animal)}: {GetDogDescription(animal)}\n");
                        }
                    }
                }

                // After all dog searches complete with no matches, display a message
                if (!anyMatches)
                {
                    Console.WriteLine("\nNo matches found for any available dogs.");
                }
                break;

            case "Exit":
                // Exit the program
                Console.WriteLine("Exiting the program...");
                break;

            default:
                // Invalid input
                Console.WriteLine("Invalid input. Please enter a valid menu option.");
                break;
        }
    }

    // Helper function to extract dog name from the animal description
    static string GetDogName(string animal)
    {
        int colonIndex = animal.IndexOf(':');
        return animal.Substring(colonIndex + 2, animal.IndexOf(" is", colonIndex) - colonIndex - 2);
    }

    // Helper function to extract dog description from the animal description
    static string GetDogDescription(string animal)
    {
        int colonIndex = animal.IndexOf(':');
        return animal.Substring(colonIndex + 2);
    }
}
