using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks.Sources;
using System.Xml.Schema;

namespace ScrabbleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            String playAgain;
            int numberOfGames =0;
            int score = 0;
            Console.WriteLine("Welcome to the scrabble word score calculator!");

            do
            {
                

                //Take user input for word
                Console.WriteLine("Enter your word: ");
                var word = Console.ReadLine();
                word.ToLower();
                

                //Convert our string input to char array to calculate score easier.
                char[] byLetter = word.ToCharArray();

                //call a method to calculate how much points to get for each letter in the word.
                score = PointsForLetters(byLetter);

                Console.WriteLine($"Your points for this word are: {score}");
                Console.WriteLine("|_|_|_|_|_|_|_|_|_|_|_|_|");

                //call a method to find out if a player is getting a bonus based on a random number
                score = BonusFinder(score);

                Console.WriteLine($"Your score after bonus is: {score}");
                Console.WriteLine("|_|_|_|_|_|_|_|_|_|_|_|_|");

                //Total points calculator method
                //var total= AddPoints(score, numberOfGames);


                //invoking a method to add to array all game attempts
                AddToArray(word, numberOfGames);
               

                
                AddToArray(word, numberOfGames);
                //Total points calculator method
               // Console.WriteLine($" Total game points are: {total}");
                //ask the user to play again
                Console.WriteLine("Would you like to enter another word? Yes/No");
                playAgain = Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------------------");
                numberOfGames++;


            } while (playAgain == "yes");

            Console.WriteLine("Thank you! Bye-bye.");




        }
        public static int PointsForLetters(char[] byLetter)
        {
            int gain = 0;
            for(int i=0; i<byLetter.Length; i++)
            {
                switch (byLetter[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'l':
                    case 'n':
                    case 'o':
                    case 't':
                    case 'u':
                        gain += 1;
                        break;
                    case 'd':
                    case 'g':
                        gain+=2;
                        break;
                    case 'b':
                    case 'c':
                    case 'm':
                    case 'p':
                        gain += 3;
                        break;
                    case 'f':
                    case 'h':
                    case 'v':
                    case 'w':
                    case 'y':
                    
                        gain += 4;
                        break;
                    case 'k':
                        gain += 5;
                        break;
                    case 'j':
                    case 'x':
                        gain += 8;
                        break;
                    case 'q':
                    case 'z':
                        gain += 10;
                        break;

                    default:
                        gain += 0;
                        break;
                        
                }
                
            }
            
            return gain;
        }
        public static int BonusFinder(int score)
        {
            int bonus=score;
            Random rnd = new Random();
            var num = rnd.Next(1,197);
            if (num <197 && num>136)
            {
                Console.WriteLine("No bonus for this word.");
                bonus += 0;
            }
            else if  (num <196 && num > 16)
            {
                Console.WriteLine("Double bonus!!");
                bonus =bonus * 2;

            }
           
            return bonus;
        }
        public static string[] AddToArray(String word, int numberOfGames)
        {
            String[] gameData = new String[numberOfGames];
            for (int i=0; i<numberOfGames; i++)
            {
                gameData[i] = word;
            }
            return gameData;
        }
        public static int AddPoints(int total, int numberOfGames)
        {
            
            int[] arrayPoints = new int[numberOfGames];
            for(int i=0; i<numberOfGames; i++)
            {
                Console.WriteLine(total);
                arrayPoints[i]=total;
                total += arrayPoints[i];
                Console.WriteLine(arrayPoints[i]);
                Console.WriteLine(arrayPoints[i]);
            }


            return total;
        }
    }
}
