
namespace Raycasting
{
    class RaycastingApp
    {
        static void Main(string[] args)
        {
            // Profiler.EnableAll();
            using (var game = new RaycastingGame())
            {
                game.Run();
            }
        }
    }
}
