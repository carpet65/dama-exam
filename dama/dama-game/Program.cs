using System;

namespace dama_game
{
    class Program
    {
       
        private static IPlayer p2;

        static void Main(string[] args)
        {

            


            Console.WriteLine("Do you want to play against another player or against the computer?");
            string choice;
            do
            {
                Console.WriteLine("Type 'G' for another player or 'C' for computers.");
                choice = Console.ReadLine();


                if (choice == "G" || choice == "g")
                {
                    var p2 = new Player("Black");
                }

                if (choice == "C" || choice == "c")
                {

                    Console.WriteLine("You chose to play against the computer. What degree of difficulty do you prefer?");

                    string difficulty;
                    do
                    {
                        Console.WriteLine("Digita 'E' per EASY, 'M' per MEDIUM o 'H' per HARD");
                        difficulty = Console.ReadLine();

                        if (difficulty == "E" || difficulty == "e")
                        {
                            var p2 = new PlayerEasyComputer("Black");
                        }
                        else if (difficulty == "M" || difficulty == "m")
                        {
                            var p2 = new PlayerMediumComputer("Black");
                        }
                        else if (difficulty == "H" || difficulty == "h")
                        {
                            var p2 = new PlayerHardComputer("Black");
                        }

                    } while (!(difficulty == "E" || difficulty == "e" || difficulty == "M" || difficulty == "m" || difficulty == "H" || difficulty == "h"));
                }

            } while (!(choice == "G" || choice == "g" || choice == "C" || choice == "c"));

            //Player p1 = new Player("White");
            //Player p2 = new PlayerMediumComputer("Black"); 

            var p1 = new Player("White");
           

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
        
           




    }
}
