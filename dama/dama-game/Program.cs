using System;

namespace dama_game
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Select 'P' if you want play against another player or 'C' if you want play againt computer");
                string choice = Console.ReadLine();
                
                if (choice == "P" || choice == "p")
                {
                    Player p1 = new Player("White");
                    Player p2 = new Player("Black");


                    IPlayer toMove = p1;

                    int xs, ys, xe, ye;
                    var b = new Chessboard(p1, p2);
                    do
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(b.ToString());

                            Console.WriteLine("Turn: {0}", toMove.Name);

                            Console.WriteLine("Let move from...");
                            Console.Write("V:");
                            xs = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("H:");
                            ys = int.Parse(Console.ReadLine());

                            Console.WriteLine("Let move to...");
                            Console.Write("V:");
                            xe = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("H:");
                            ye = int.Parse(Console.ReadLine());

                            b.MovePawn(toMove, xs, ys, xe, ye);

                            if (toMove == p1)
                                toMove = p2;
                            else
                                toMove = p1;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press to continue...");
                            Console.ReadLine();
                        }

                    } while (b.Winner == null);

                    Console.WriteLine("Press to simulate legal move (5,1) -> (4,2)...");
                    Console.ReadLine();

                    b.MovePawn(p2, 5, 1, 4, 2);

                    Console.WriteLine(b.ToString());

                    Console.WriteLine("Press to simulate play...");
                    Console.ReadLine();

                    b.SimulatePlay();

                    Console.WriteLine("Winner is {0} with score {1}", b.Winner.Name, b.Winner.Score);
                    Console.WriteLine("Loser is {0} with score {1}", b.Loser.Name, b.Loser.Score);
                }
            
                else if (choice == "C" || choice == "c")
                {
                    Console.WriteLine("You have chosen to play against COMPUTER. Which Difficulty level do you prefer? -> A, B, C");
                    string diff = Console.ReadLine();
                    switch (diff)
                    {
                        case "A":
                            diff = "new PlayerEasyComputer(\"Black\")";
                            break;
                        case "a":
                            diff = "new PlayerEasyComputer(\"Black\")";
                            break;
                        case "B":
                            diff = "new PlayerMediumComputer(\"Black\")";
                            break;
                        case "b":
                            diff = "new PlayerMediumComputer(\"Black\")";
                            break;
                        case "C":
                            diff = "new PlayerHardComputer(\"Black\")";
                            break;
                        case "c":
                            diff = "new PlayerHardComputer(\"Black\")";
                            break;

                    }

                    Player p1 = new Player("White");
                    Player p2 = diff;
                    IPlayer toMove = p1;

                    int xs, ys, xe, ye;
                    var b = new Chessboard(p1, p2);
                    do
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(b.ToString());

                            Console.WriteLine("Turn: {0}", toMove.Name);

                            Console.WriteLine("Let move from...");
                            Console.Write("V:");
                            xs = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("H:");
                            ys = int.Parse(Console.ReadLine());

                            Console.WriteLine("Let move to...");
                            Console.Write("V:");
                            xe = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.Write("H:");
                            ye = int.Parse(Console.ReadLine());

                            b.MovePawn(toMove, xs, ys, xe, ye);

                            if (toMove == p1)
                                toMove = p2;
                            else
                                toMove = p1;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press to continue...");
                            Console.ReadLine();
                        }

                    } while (b.Winner == null);

                    Console.WriteLine("Press to simulate legal move (5,1) -> (4,2)...");
                    Console.ReadLine();

                    b.MovePawn(p2, 5, 1, 4, 2);

                    Console.WriteLine(b.ToString());

                    Console.WriteLine("Press to simulate play...");
                    Console.ReadLine();

                    b.SimulatePlay();

                    Console.WriteLine("Winner is {0} with score {1}", b.Winner.Name, b.Winner.Score);
                    Console.WriteLine("Loser is {0} with score {1}", b.Loser.Name, b.Loser.Score);
                }
        
                    else
                    {
                        Console.WriteLine("ERROR!!! You can select only 'P' or 'C'. Try again.");
                    }
            }
        }


    }
}
