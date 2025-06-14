//Plan: Use arrays to make a tik tak toe board to gain experience using arrays. Start by setting up and outputting the board;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Transactions;

class TikTakToeGame
{
    static bool gamebreak = false;

    static int Dicity(int diceone, int dicetwo)
    {
        Random dice = new Random();
        return dice.Next(diceone, dicetwo);
    }
    static int PlayerInput(string Message, string errorMessage, int conditon = 0)
    {
        Console.WriteLine(Message);
        string? ThePlayer = "";
        bool properResponse = false;
        int outcome = 0;
        do
        {
            ThePlayer = Console.ReadLine();
            if (ThePlayer == "exit")
            {
                gamebreak = true;
                break;
            }
            switch (conditon)
            {
                case 0:
                    {
                        if (int.TryParse(ThePlayer, out outcome))
                        {
                            if (outcome < 10 && outcome > 0) { properResponse = true; }
                        }
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Something happened lol");
                        break;
                    }
            }
            if (!properResponse)
            {
                Console.WriteLine(errorMessage);
            }

        } while (!properResponse);
        return outcome;
    }


    public static void Main()
    {
        int gameCondition = 0; //0 = game is on, 1 means game is off with a tie, 2 means game is off with a win, 3 means game is off with a loss, error for anything else
        int spaceText = 0;
        int[,] tiktaktoe = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //3 rows and 3 columns
        int breakstuff = 0;
        int turn = Dicity(0, 2); //Decides who goes first
        if (turn == 0) { Console.WriteLine("Bot goes First!"); }
        else { Console.WriteLine("You go First!"); }
        Thread.Sleep(1000);
        do
        {
            bool validAction = false;
            if (turn == 0) //Bot Turn. Finished after a lot of bug testing (forgot to put the command that decides who goes first OUTSIDE the loop)
            {
                validAction = false;
                Console.WriteLine("Bot's turn");
                /*
                    1 0 1
                    0 2 0   <-- Priority Chart
                    1 0 1       each spot gets a spot, 0 = 1 spot, 1 = 2 spots, 2 = 3 spots, so from 0 - 15
                */
                do
                {
                    int computerChoice = Dicity(0, 15);
                    switch (computerChoice) //Im not sure how I would use something more efficient than a switch case. Im sorry for this hellish block
                    {
                        case 0 or 1: //1 0 1
                            {
                                if (tiktaktoe[0, 0] == 0)
                                {
                                    tiktaktoe[0, 0] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 2:
                            {
                                if (tiktaktoe[0, 1] == 0)
                                {
                                    tiktaktoe[0, 1] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 3 or 4:
                            {
                                if (tiktaktoe[0, 2] == 0)
                                {
                                    tiktaktoe[0, 2] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 5: //0 2 0
                            {
                                if (tiktaktoe[1, 0] == 0)
                                {
                                    tiktaktoe[1, 0] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 6 or 7 or 8:
                            {
                                if (tiktaktoe[1, 1] == 0)
                                {
                                    tiktaktoe[1, 1] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 9:
                            {
                                if (tiktaktoe[1, 2] == 0)
                                {
                                    tiktaktoe[1, 2] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 10 or 11: //1 0 1
                            {
                                if (tiktaktoe[2, 0] == 0)
                                {
                                    tiktaktoe[2, 0] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 12:
                            {
                                if (tiktaktoe[2, 1] == 0)
                                {
                                    tiktaktoe[2, 1] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                        case 13 or 14:
                            {
                                if (tiktaktoe[2, 2] == 0)
                                {
                                    tiktaktoe[2, 2] = 2;
                                    validAction = true;
                                }
                                break;
                            }
                    }
                } while (!validAction);
                turn = 1;
            }
            else if (turn == 1) //Player Turn (Finished!)
            {
                validAction = false;
                Console.WriteLine("Your turn");
                do
                {
                    int playerOutput = PlayerInput("Pick a number between 1-9 to decide what spot you choose (numberpad)", "Please input a number between 1-9");
                    if (gamebreak) { break; }
                    if (playerOutput < 4) //after like 5 minutes of thinking, this is the best way to do this without a huge switch case block
                    {
                        if (tiktaktoe[0, playerOutput - 1] == 0)
                        {
                            tiktaktoe[0, playerOutput - 1] = 1;
                            validAction = true;
                        }
                        else { Console.WriteLine("Space already occupied, pick another"); }
                    }
                    else if (playerOutput < 7)
                    {
                        if (tiktaktoe[1, playerOutput - 4] == 0)
                        {
                            tiktaktoe[1, playerOutput - 4] = 1;
                            validAction = true;
                        }
                        else { Console.WriteLine("Space already occupied, pick another"); }
                    }
                    else if (playerOutput < 10)
                    {
                        if (tiktaktoe[2, playerOutput - 7] == 0)
                        {
                            tiktaktoe[2, playerOutput - 7] = 1;
                            validAction = true;
                        }
                        else { Console.WriteLine("Space already occupied, pick another"); }
                    }
                    else
                    {
                        Console.WriteLine("HUGE ERROR WITH PLAYERINPUT!");
                        break;
                    }
                } while (!validAction);
                if (gamebreak) { break; }
                turn = 0;
            }


            int filledBoard = 0;
            foreach (int space in tiktaktoe) //displays the new board everytime
            {

                string piece = "";
                if (space == 0) //Nothing happened
                {
                    piece = space.ToString();
                }
                if (space == 1) //turn into x
                {
                    piece = "x";
                    filledBoard++;
                }
                if (space == 2) //turn into o
                {
                    piece = "o";
                    filledBoard++;
                }
                Console.Write(piece + "\t");
                spaceText++;
                if (spaceText % 3 == 0)
                {
                    Console.WriteLine("\n");
                }
            }
            breakstuff++; //breakity break break
            if (breakstuff > 10) { break; }
            Thread.Sleep(1000);


            //Win Condition here! I'm not sure how I'm supposed to register "3 in a row" on code, so I have to brute force it
            if (tiktaktoe[0, 0] == 1 && tiktaktoe[0, 1] == 1 && tiktaktoe[0, 2] == 1) { gameCondition = 2; } //Player wins 
            else if (tiktaktoe[1, 0] == 1 && tiktaktoe[1, 1] == 1 && tiktaktoe[1, 2] == 1) { gameCondition = 2; }
            else if (tiktaktoe[2, 0] == 1 && tiktaktoe[2, 1] == 1 && tiktaktoe[0, 2] == 1) { gameCondition = 2; }
            else if (tiktaktoe[0, 0] == 1 && tiktaktoe[1, 0] == 1 && tiktaktoe[2, 0] == 1) { gameCondition = 2; }
            else if (tiktaktoe[0, 1] == 1 && tiktaktoe[1, 1] == 1 && tiktaktoe[2, 1] == 1) { gameCondition = 2; }
            else if (tiktaktoe[0, 2] == 1 && tiktaktoe[1, 2] == 1 && tiktaktoe[2, 2] == 1) { gameCondition = 2; }
            else if (tiktaktoe[0, 0] == 1 && tiktaktoe[1, 1] == 1 && tiktaktoe[2, 2] == 1) { gameCondition = 2; }
            else if (tiktaktoe[2, 0] == 1 && tiktaktoe[1, 1] == 1 && tiktaktoe[0, 2] == 1) { gameCondition = 2; }

            if (tiktaktoe[0, 0] == 2 && tiktaktoe[0, 2] == 2 && tiktaktoe[0, 2] == 2) { gameCondition = 3; } //Bot wins 
            else if (tiktaktoe[1, 0] == 2 && tiktaktoe[1, 1] == 2 && tiktaktoe[1, 2] == 2) { gameCondition = 3; }
            else if (tiktaktoe[2, 0] == 2 && tiktaktoe[2, 1] == 2 && tiktaktoe[0, 2] == 2) { gameCondition = 3; }
            else if (tiktaktoe[0, 0] == 2 && tiktaktoe[1, 0] == 2 && tiktaktoe[2, 0] == 2) { gameCondition = 3; }
            else if (tiktaktoe[0, 1] == 2 && tiktaktoe[1, 1] == 2 && tiktaktoe[2, 1] == 2) { gameCondition = 3; }
            else if (tiktaktoe[0, 2] == 2 && tiktaktoe[1, 2] == 2 && tiktaktoe[2, 2] == 2) { gameCondition = 3; }
            else if (tiktaktoe[0, 0] == 2 && tiktaktoe[1, 1] == 2 && tiktaktoe[2, 2] == 2) { gameCondition = 3; }
            else if (tiktaktoe[2, 0] == 2 && tiktaktoe[1, 1] == 2 && tiktaktoe[0, 2] == 2) { gameCondition = 3; }

            if (filledBoard == 9)
            {
                gameCondition = 1;
            }
            /* for (int i = 0; i <= 3; i++) //columns  (OLD! COULDNT FIND A GOOD WAY TO USE A LOOP)
            {
                int j = 0;
                j
                if (tiktaktoe[i, 0] == 1 && tiktaktoe[i, 0] == 1 && tiktaktoe[i, 0] == 1) { gameCondition = 2; }
            }
            for (int i = 0; i <= 3; i++) //rows
            {
                if (tiktaktoe[])
            } */

        } while (gameCondition == 0);

        if (gameCondition == 0) { Console.WriteLine("Game ended forcefully"); }
        else if (gameCondition == 1) { Console.WriteLine("Game ended in a draw"); }
        else if (gameCondition == 2) { Console.WriteLine("You won the game!"); }
        else if (gameCondition == 3) { Console.WriteLine("The bot won the game!"); }
    }

}
