using System;

namespace OOPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём игрока пробного с более быстрым повышением уровня для теста повышения уровня
            // expRule -- правило повышения. Стандартное 1000, здесь 10
            Character hero = new Character("Player", 25, 50, 1, 10);
            Character npc = new Character("Enemy", 25, 50);

            string command = string.Empty;

            Console.WriteLine();
            Console.WriteLine($"Enemy have {npc.Coordinates}");
            while (command != "exit")
            {
                while (hero.Collide(npc) && npc.isAlive)
                {
                    Console.WriteLine("You can now attack the enemy. Attack? (y/n)");
                    command = Console.ReadLine();
                    if (command == "exit" || command.ToLower() == "no" || command.ToLower() == "n")
                        break;
                    else if (command.ToLower() == "yes" || command.ToLower() == "y")
                        Console.WriteLine(hero.Attack(npc));
                }
                Console.WriteLine($"You are at {hero.Coordinates}. Where to go?");
                command = Console.ReadLine();
                hero.Move(command);
            }

            Console.ReadKey();
        }
    }
}