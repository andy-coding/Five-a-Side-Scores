using System;
using System.IO;


/* 
this program inputs values for x games of 5 a side soccer and displays them 
either on screen or into a text file along with total score.
*/

namespace Five_a_Side_Scores 
{
    class Program
    {

        const int team = 5;
        const int minscore = 0;
        const int maxscore = 20; 
        const int mingames = 1;
        const int maxgames = 10;

        static int enterInteger(int min, int max) // allows entry of an integer value which it then checks and returns
        {
             

            int i = 0;

            do
            {
                try
                {
                    string input = Console.ReadLine();
                    i = int.Parse(input);

                }
                catch
                {
                    Console.WriteLine("Have another go.");
                }
            } while (i < min || i > max);

            return i;
        }

        static void Main()
        {
            
            int totgames;
            
            Console.Write("How many games in this series? (Enter a value between " + mingames + " and " + maxgames + ")2\n\n");
            totgames = enterInteger(mingames,maxgames);

            int[,] scores = new int[totgames + 1 , team + 1];
            int[] totscores = new int[totgames + 1];
            int[] highscorer = new int[totgames + 1];


            for ( int game = 1; game < totgames+1; game=game+1) // game loop
            {
                Console.Write("Enter the scores for game " + game + "\n");

                highscorer[game] = 0;

                for (int player = 1; player < team+1; player=player+1)   // player loop
                {

                    Console.Write("Enter score for player " + player + " between 0 and 20 : ");
                    scores[game, player] = enterInteger(minscore, maxscore);
                    totscores[game] = totscores[game] + scores[game, player];

                }

                Console.WriteLine("\r");
            }

// Now return scores via whichever method the user requires

            Console.Write("How would you like a summary:\n\n");
            Console.Write("1 = screen\n");
            Console.Write("2 = text file\n");

            int selection = enterInteger(1,2);
            do
            { switch (selection)
                {
                    case 1:
                        outputScreen();
                        break;
                    case 2:
                        outputText();
                        break;
                    default:
                        Console.Write("Invalid number");
                        break;
                }
                
            } while (selection < 1 || selection > 2);



             void outputScreen()        //   output scores to screen

            {
                Console.WriteLine("game      player1   player2   player3   player4   player5   Total Score    High Scoring Player");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                for (int i = 1; i < totgames + 1; i++)
                {
                    if (highscorer[i] == 0)
                    {
                        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-15}{7,-10}", i, scores[i, 1], scores[i, 2], scores[i, 3], scores[i, 4], scores[i, 5], totscores[i], "no scorer");
                    }
                    else
                    {
                        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-15}{7,-10}", i, scores[i, 1], scores[i, 2], scores[i, 3], scores[i, 4], scores[i, 5], totscores[i], highscorer[i]);
                    }
                }
            }


            void outputText()  //   output scores to text file
            {
                string path = @"D:\Users\Andy\OneDrive\Documents\Docs - Andy\Training\C#\Projects\Five-a-Side-Scores\Five-a-Side-Scores\scores.txt";
                StreamWriter writer;
                writer = new StreamWriter(path);

                {

                    writer.WriteLine("game      player1   player2   player3   player4   player5   Total Score    High Scoring Player\n");
                    writer.WriteLine("----------------------------------------------------------------------------------------------\n");
                    for (int i = 1; i < totgames + 1; i++)
                    {
                        if (highscorer[i] == 0)
                        {
                            writer.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-15}{7,-10}", i, scores[i, 1], scores[i, 2], scores[i, 3], scores[i, 4], scores[i, 5], totscores[i], "no scorer");
                        }
                        else
                        {
                            writer.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-15}{7,-10}", i, scores[i, 1], scores[i, 2], scores[i, 3], scores[i, 4], scores[i, 5], totscores[i], highscorer[i]);
                        }
                    }
                }
                writer.Close();

            }


            Console.WriteLine("\nPress Enter key to end.");

            Console.ReadLine();
        }
    }
}
