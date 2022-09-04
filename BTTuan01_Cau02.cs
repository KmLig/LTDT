using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01
{
    public class BTTuan01_Cau02
    {
        public void Cau2(string fileName)
        {
            AdjacencyMatrix g = new AdjacencyMatrix();
            g.ReadAdjacencyMatrix(fileName);
            g.ShowAdjacencyMatrix();
            if (IsCompleteGraph(g))
                Console.WriteLine($"Day la do thi day du K{g.n}");
            else
                Console.WriteLine("Day khong phai la do thi day du");
            int regular = 0;
            if (IsRegularGraph(ref regular, g))
                Console.WriteLine($"Day la do thi {regular}-chinh quy");
            else
                Console.WriteLine("Day khong phai la do thi chinh quy");
            if (IsCycleGraph(g))
                Console.WriteLine($"Day la do thi vong C{g.n}");
            else
                Console.WriteLine("Day khong phai la do thi vong");
            Console.WriteLine();
        }
        public bool IsCompleteGraph(AdjacencyMatrix g)
        {
            int i, j;
            bool IsComplete = true;
            for (i = 0; i < g.n && IsComplete; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == 1); ++j) ;
                if (j < g.n)
                    IsComplete = false;
            }
            return IsComplete;
        }
        public bool IsRegularGraph(ref int k, AdjacencyMatrix g)
        {
            k = 0;
            int i, j;
            bool IsRegular = true;
            for (i = 0; i < g.n; ++i)
                if (g.a[0, i] == 1)
                    k++;
            for (i = 1; i < g.n && IsRegular; ++i)
            {
                int count = 0;
                for (j = 0; j < g.n; ++j)
                    if (g.a[i, j] != 0)
                        count++;
                if (count != k)
                    IsRegular = false;
            }
            return IsRegular;
        }
        public bool IsCycleGraph(AdjacencyMatrix g)
        {
            int k = 0;
            IsRegularGraph(ref k, g);
            if (k != 2)
                return false;

            int[] marked = new int[g.n];
            int nm = 0;
            for (int i = 0; i < g.n; ++i)
                marked[i] = 0;

            bool IsCycle = true;
            int v = 0, j, next;
            while (nm < g.n && IsCycle)
            {
                for (j = 0; j < g.n && (g.a[v, j] == 0 || marked[j] != 0); ++j) ;
                if (j < g.n)
                {
                    next = j;
                    marked[next] = 1;
                    v = next;
                    nm++;
                }
                else
                    IsCycle = false;
            }
            return IsCycle;
        }
    }
}
