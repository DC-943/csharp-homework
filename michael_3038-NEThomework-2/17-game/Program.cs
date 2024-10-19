namespace _17_game
{
    internal class Program
    {

        const int MAP_SIZE = 10;
        const char EMPTY = ' ';
        const char PLAYER_A = 'A';
        const char PLAYER_B = 'B';
        const char MINE = 'X';
        const char TIME_PORTAL = 'O';
        const char LUCKY_WHEEL = 'L';
        const char PAUSE = 'P';

        static char[] map = new char[MAP_SIZE * MAP_SIZE];
        static int positionA = 1;
        static int positionB = 45;
        static int count = 3;
        static void Main(string[] args)
        {
            InitializeMap();
            while (true)
            {
                DrawMap();
                Console.WriteLine("input A or B: A playerA, B player B");
                char action = Console.ReadKey().KeyChar;
                //string action = Console.ReadLine();
                Console.WriteLine();
                if (action == 'A')
                {
                    MovePlayer(ref positionA, PLAYER_A, ref count);
                }
                else if (action == 'B')
                {
                    MovePlayer(ref positionB, PLAYER_B, ref count);
                }

                if (positionA == map.Length-1 || positionB == map.Length-1)
                {

                    Console.WriteLine("Reach the end of map, GAME OVER !");
                    break;

                }
                   
            }
          
        }
        static void InitializeMap()
        {
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = EMPTY;
            }

            map[80] = MINE;
            map[20] = TIME_PORTAL;
            map[30] = LUCKY_WHEEL;
            map[40] = PAUSE;

   
            map[positionA] = PLAYER_A;
            map[positionB] = PLAYER_B;
        }

        static void DrawMap()
        {
            Console.Clear();
            Console.WriteLine("Game map as follows, please start game by inputting A or B");
            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    Console.Write($"[{map[i * MAP_SIZE + j]}]");
                }
                Console.WriteLine();
            }
        }

        static void MovePlayer(ref int position, char player, ref int count)
        {
            map[position] = EMPTY; 
            position++;
            if (position >= map.Length)
            {
                position = map.Length - 1;

            }

            if (map[position] == PLAYER_B && map[position] == PLAYER_A)
                position -= 6;

            char eventAtPosition = map[position];
            Console.WriteLine("My map[position]:", map[position]);

            switch (eventAtPosition)
            {
                case MINE:
                    Console.WriteLine($"{player} step on a mine, back 6 steps");
                    if (count == 0)
                    {
                        position++;
                        count = 3;
                    }
                    else {
                        position -= 6;
                        count--;
                    }
                    break;
                case TIME_PORTAL:
                    Console.WriteLine($"{player} step on time portal, forword 10 steps");
                    position += 10;
                    break;
                case LUCKY_WHEEL:
                    Console.WriteLine($"{player} step on lucky wheel, swap positions");
                    SwapPositions();
                    break;
                case PAUSE:
                    Console.WriteLine($"{player} step on pause, stay still");
                    if (count == 0)
                    {
                        position++;
                        count = 3;
                    }
                    else
                    {
                        position--;
                        count--;
                    }
                    break;
                default:
                    break;
            }


            if (position < 0) position = 0;
            if (position >= map.Length)
                position = map.Length - 1;


            map[position] = player;
        }

        static void SwapPositions()
        {
            int temp = positionA;
            positionA = positionB;
            positionB = temp;

       
            map[positionA] = PLAYER_A;
            map[positionB] = PLAYER_B;
        }



    }
}
