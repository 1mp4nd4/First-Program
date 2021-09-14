using System;
using System.Collections.Generic;

namespace DogApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> Questions = new Dictionary<int, string>();
            Questions.Add(0, "Are their ears clean? (No bad odor, rediness or excessive wax)");
            Questions.Add(1, "Are their eyes bright and clear? (No cloudiness or redness, no watery eyes)");
            Questions.Add(2, "Is their breath bad? (No discolored teeth or swollen/red gums)");
            Questions.Add(3, "Is their skin and healthy looking, bright? (No red, flaky or dry skin, no lumps or scabs)");
            Questions.Add(4, "Is their behavior normal? (No limping or motor trouble, no hesitating while walking or use stairs)");
            Questions.Add(5, "Is there no abnormal Weight gain? (No pronounced belly behind the ribs)");
            List<int> questionsAsked = new List<int>();
            List<int> badAnswers = new List<int>();
            //introduction
            Console.WriteLine("Dog App v0.5");
            Console.WriteLine("Welcome, Proud Owner. How old is your canine friend?");
            string Years = Console.ReadLine();
            DogYear();
            //First segment
            Console.WriteLine("We should do a checkup to make sure your friend is allright.");
            Console.WriteLine("\n");
            QuestionMaker(Questions, questionsAsked);


            //Dog year converter
            void DogYear()
            {
                if (int.TryParse(Years, out _) == true)
                {
                    int dogAge = Convert.ToInt32(Years) * 7;
                    Console.WriteLine("Your dog is actually " + dogAge + " dog years old!");
                    Console.WriteLine("\n");
                }
                else if(int.TryParse(Years, out _) == false)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Please enter a number");
                    DogYear();
                }

            }
            //Method that makes questions and checks if asked
            void QuestionMaker(Dictionary<int, string> Questions, List<int> questionsAsked)
            {
                Console.WriteLine(Questions[questionsAsked.Count]);
                AnswerCounter(badAnswers);
                void AnswerCounter(List<int> badAnswers)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Type in yes or no");
                    Console.WriteLine("\n");
                    string input1 = Console.ReadLine();
                    if (input1 == "no" && questionsAsked.Count <= 4)
                    {
                        badAnswers.Add(badAnswers.Count + 1);
                        questionsAsked.Add(questionsAsked.Count + 1);
                        Console.WriteLine(Questions[questionsAsked.Count]);
                        AnswerCounter(badAnswers);
                    }
                    else if (input1 == "yes" && questionsAsked.Count <= 4)
                    {
                        Console.WriteLine("\n");
                        questionsAsked.Add(questionsAsked.Count + 1);
                        Console.WriteLine(Questions[questionsAsked.Count]);
                        AnswerCounter(badAnswers);
                    }
                    else if (input1 != "yes" && input1 != "no")
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Can´t process answer, did you write \"yes\" or \"no\"");
                        Console.WriteLine("\n");
                        Console.WriteLine(Questions[questionsAsked.Count]);
                        AnswerCounter(badAnswers);
                    }
                    else if (badAnswers.Count <= 2 && badAnswers.Count != 0)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("You should probably do a checkup, here are the closest vets in your area https://www.google.com.ar/maps/search/veterinario/");
                        Console.WriteLine("Press any Key to exit...");
                        Console.ReadLine();
                    }
                    else if (badAnswers.Count >= 3)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("You should get your pet to the vet ASAP, here are the closest vets in your area https://www.google.com.ar/maps/search/veterinario/");
                        Console.WriteLine("\n");
                        Console.WriteLine("Press any Key to exit...");
                        Console.ReadLine();
                    }
                    else if (badAnswers.Count == 0)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("Your pet is just fine! Congratulations!");
                        Console.WriteLine("\n");
                        Console.WriteLine("Press any Key to exit...");
                        Console.ReadLine();
                    }

                }
                
            }

        }
    }
}
