using System;
using System.Collections.Generic;
using System.Drawing;

namespace PathfindingV1
{
    class Program
    {
        public static int platums = 4;
        public static int augstums = 6;
        static void Main(string[] args)
        {
            Labirints[,] grid = new Labirints[platums, augstums];

            for (int x = 0; x < platums; x++)
            {
                for (int y = 0; y < augstums; y++)
                {
                    Boolean siena = false;  // aizstāt ar faila sienu koordinātem
                    if (siena)
                    {
                        Console.WriteLine(x + " " +y);
                    }
                    grid[x, y] = new Labirints()
                    {
                        Siena = siena,
                        Platums = x,
                        Augstums = y,
                    };
                }
            }
            MySolver<Labirints, Object> aStar = new MySolver<Labirints, Object>(grid);
            LinkedList<Labirints> path = aStar.Search(new Point(2, 2), new Point(platums-1, augstums-1), null);
            aStar.Search(new Point(2, 2), new Point(platums-1, augstums-1), null);
            
            if (path != null)
            {
                foreach (Labirints node in path)
                    Console.Write("(" + node.Platums + " " + node.Augstums + ")");

                Console.WriteLine("\n");
            }
            
        }
    }
    public class MySolver<TPathNode, TUserContext> : PathfindingV1.SpatialAStar<TPathNode, TUserContext> where TPathNode : PathfindingV1.IPathNode<TUserContext>
    {
        protected override Double Heuristic(PathNode inStart, PathNode inEnd)
        {
            return Math.Abs(inStart.X - inEnd.X) + Math.Abs(inStart.Y - inEnd.Y);
        }

        protected override Double NeighborDistance(PathNode inStart, PathNode inEnd)
        {
            return Heuristic(inStart, inEnd);
        }

        public MySolver(TPathNode[,] inGrid)
            : base(inGrid)
        {
        }
    }
}
