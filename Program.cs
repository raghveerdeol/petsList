// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
int menuSelection = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i){
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default :
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// display the top-level menu options

Console.Clear();

Console.WriteLine(" 1. List all of our current pet information");
Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
Console.WriteLine(" 5. Edit an animal’s age");
Console.WriteLine(" 6. Edit an animal’s personality description");
Console.WriteLine(" 7. Display all cats with a specified characteristic");
Console.WriteLine(" 8. Display all dogs with a specified characteristic");
Console.WriteLine();
Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

do
{
    readResult = Console.ReadLine();
    if(readResult == "exit") break;
    bool isValid = int.TryParse(readResult, out menuSelection);
    if (!isValid || (menuSelection < 1 || menuSelection > 8))
    {
        menuSelection = 0;
        Console.WriteLine("Please enter a value between 1 and 8!");
    }
    
} while (menuSelection == 0);

switch (menuSelection)
{
    // 1. List all of our current pet information
    case 1:
        for (int i = 0; i < maxPets; i++)
        {
            if (ourAnimals[i, 0].Trim().ToLower() != "id #:")
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine(ourAnimals[i, j]);
                }
            }
        }
        break;
    // 2. Add a new animal friend to the ourAnimals array
    case 2:
        int countPets = 0;
        for (int i = 0; i < maxPets; i++)
        {
            if(ourAnimals[i, 0].Trim().ToLower() != "id #:")
            {
                countPets++;
            }
        }

        if (maxPets <= countPets) {
            Console.WriteLine("Sorry, you reached the max stored pets!");
            break;
        } else {
            Console.WriteLine($"We have {countPets} pets. You can add more {maxPets - countPets} {(maxPets - countPets == 1 ? "pet" : "pets")}!");
            Console.WriteLine("Do you want to add a pet? y/n");
            string addAPet = "";
            do
            {
                addAPet = Console.ReadLine().Trim().ToLower();
                if (addAPet != "n" && addAPet != "y")
                {
                    addAPet = "";
                    Console.WriteLine("Select an option between y or n!");
                }
            } while (addAPet != "n" && addAPet != "y");
            if( addAPet == "n")
                break;

        }
        string[] questions = ["Species: ", "Age: ", "Nickname: ", "Physical description: ", "Personality: "];

        for (int i = 0; i < questions.Count(); i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "";
                    do
                    {
                        Console.WriteLine(questions[i]);
                        string inputSpecies = Console.ReadLine().Trim().ToLower();
                        if (inputSpecies == "cat" || inputSpecies == "dog")
                        {
                            animalSpecies = inputSpecies;
                        }
                        else {
                            Console.WriteLine("Please insert cat or dog!");
                        }

                    } while (animalSpecies == "");
                    break;
                case 1:
                    animalAge = "";
                    do
                    {
                        Console.WriteLine(questions[i]);
                        string inputAge = Console.ReadLine().Trim();
                        if (int.TryParse(inputAge, out int age) || inputAge == "?")
                        {
                            animalAge = inputAge;
                        }
                        else 
                        {
                            Console.WriteLine("Please age number, if you don't know the age enter '?'!");
                        }
                    } while (animalAge == "");
                    break;
                case 2:
                    animalNickname = "";
                    do
                    {
                        Console.WriteLine(questions[i]);
                        animalNickname = Console.ReadLine().Trim();
                    } while (animalNickname == "");
                    break;
                case 3:
                    animalPhysicalDescription = "";
                    do
                    {
                        Console.WriteLine(questions[i]);
                        animalPhysicalDescription = Console.ReadLine().Trim();
                    } while (animalPhysicalDescription == "");
                    break;
                case 4:
                    animalPersonalityDescription = "";
                    do
                    {
                        Console.WriteLine(questions[i]);
                        animalPersonalityDescription = Console.ReadLine().Trim();
                    } while (animalPersonalityDescription == "");
                    break;
            }
        }
        ourAnimals[(countPets + 1), 0] = "ID #: " + (countPets + 1);
        ourAnimals[(countPets + 1), 1] = "Species: " + animalSpecies;
        ourAnimals[(countPets + 1), 2] = "Age: " + animalAge;
        ourAnimals[(countPets + 1), 3] = "Nickname: " + animalNickname;
        ourAnimals[(countPets + 1), 4] = "Physical description: " + animalPhysicalDescription;
        ourAnimals[(countPets + 1), 5] = "Personality: " + animalPersonalityDescription;
        for (int i = 0; i < maxPets; i++)
        {
            if (ourAnimals[i, 0].Trim().ToLower() != "id #:")
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine(ourAnimals[i, j]);
                }
            }
        }
        break;
    // 3. Ensure animal ages and physical descriptions are complete
    case 3:
        for (int i = 0; i < maxPets; i++)
        {
            if(ourAnimals[i, 0].Trim().ToLower() != "id #:")
            {
                if (ourAnimals[i, 2].Trim().ToLower() == "age:" || ourAnimals[i, 2].Trim().ToLower() == "age: ?")
                {
                    Console.WriteLine($"Add tha age for pet {ourAnimals[i, 0]}");
                    string inputAge = "";
                    do
                    {
                        inputAge = Console.ReadLine().Trim();
                        if (int.TryParse(inputAge, out int age))
                        {
                            ourAnimals[i, 2] = "Age: " + inputAge;
                        } 
                        else 
                        {
                            inputAge = "";
                            Console.WriteLine("Please insert a valid age");
                        }
                    } while (inputAge == "");
                    
                } 
                
                if (ourAnimals[i, 4].Trim().ToLower() == "physical description:")
                {
                    Console.WriteLine($"Add a physical description for pet {ourAnimals[i, 0]}");
                    string inputPhysical = "";
                    do
                    {
                        inputPhysical = Console.ReadLine().Trim();
                        if (inputPhysical.Count() > 3)
                        {
                            ourAnimals[i, 2] = "Physical description: " + inputPhysical;
                        } 
                        else 
                        {
                            inputPhysical = "";
                            Console.WriteLine("Please insert a valid physical description. Need to be more than 3 char!");
                        }
                    } while (inputPhysical == "" || inputPhysical.Count() <= 3);
                }
            }
        }
        Console.WriteLine("Age and physical description fields are complete for all");
        break;
    // 4. Ensure animal nicknames and personality descriptions are complete
    case 4:
        List<string> animalsNoData2 = new List<string>();
        for (int i = 0; i < maxPets; i++)
        {
            if(ourAnimals[i, 0].Trim().ToLower() != "id #:")
            {
                if (ourAnimals[i, 3].Trim().ToLower() == "nickname:" || ourAnimals[i, 5].Trim().ToLower() == "personality:")
                {
                    animalsNoData2.Add(ourAnimals[i, 0]);
                }
            }
        }
        if (animalsNoData2.Count() > 0)
        {
            Console.WriteLine($"The animals without nickname or personality are: ");
            foreach(string animal in animalsNoData2)
            {
                Console.WriteLine(animal);
            }
        }
        else
        {
            Console.WriteLine("No animal found without nickname or personality!");
        }
        break;
    // 5. Edit an animal’s age
    case 5:
        Console.WriteLine("Which animal's age do you want to change?");
        string searchedName = Console.ReadLine().Trim().ToLower();
        bool foundPet = false;
        for (int i = 0; i < maxPets; i++)
        {
            if (("nickname: " + searchedName) == ourAnimals[i, 3].Trim().ToLower())
            {
                foundPet = true;
                Console.WriteLine("Enter the age: ");
                string newAge = Console.ReadLine();
                ourAnimals[i, 2] = "Age: " + newAge;
            }
        }
        if (!foundPet)
        {
            Console.WriteLine("No animal found with this nickname!");
        }
        else
        {
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0].Trim().ToLower() != "id #:")
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
        }
        break;
    // 6. Edit an animal’s personality description
    case 6:
        Console.WriteLine("Which animal's personality do you want to change?");
        string searchedName2 = Console.ReadLine().Trim().ToLower();
        bool foundPet2 = false;
        for (int i = 0; i < maxPets; i++)
        {
            if (("nickname: " + searchedName2) == ourAnimals[i, 3].Trim().ToLower())
            {
                foundPet2 = true;
                Console.WriteLine("Enter the personality: ");
                string newPersonality = Console.ReadLine();
                ourAnimals[i, 2] = "Personality: " + newPersonality;
            }
        }
        if (!foundPet2)
        {
            Console.WriteLine("No animal found with this nickname!");
        }
        else
        {
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0].Trim().ToLower() != "id #:")
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
        }
        break;
    // 7. Display all cats with a specified characteristic
    case 7:
        for (int i = 0; i < maxPets; i++)
        {
            if (ourAnimals[i, 0].Trim().ToLower() != "id #:" && ourAnimals[i, 1].Trim().ToLower() == "species: cat")
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine(ourAnimals[i, j]);
                }
            }
        }
        break;
    // 8. Display all dogs with a specified characteristic
    case 8:
        for (int i = 0; i < maxPets; i++)
        {
            if (ourAnimals[i, 0].Trim().ToLower() != "id #:" && ourAnimals[i, 1].Trim().ToLower() == "species: dog")
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine(ourAnimals[i, j]);
                }
            }
        }
        break;
}

Console.WriteLine($"You selected menu option {menuSelection}.");
Console.WriteLine("Press the Enter key to continue");

// pause code execution
readResult = Console.ReadLine();
