using System;

namespace EliteKnightsGame
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (GameLoop game = new GameLoop())
            {
                game.Run();
            }
        }
    }
#endif
}

