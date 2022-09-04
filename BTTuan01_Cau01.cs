using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan01
{
    public class BTTuan01_Cau01
    {
                
        private bool IsUndirectedGraph(AdjacencyMatrix g)
        {
            int i, j;
            bool isSymmetric = true;
            for (i = 0; i < g.n && isSymmetric; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j) ;
                if (j < g.n)
                    isSymmetric = false;
            }
            return isSymmetric;
        }

        private void UndirectedGraph(AdjacencyMatrix g)
        {
            Console.WriteLine("Do thi vo huong");
            Console.WriteLine($"So dinh cua do thi: {g.n}");
            int[] VertexDeg = new int[g.n];
            CountVertexDegrees(ref VertexDeg, g);
            int SoCanh = CountEdges(VertexDeg, true);
            Console.WriteLine($"So canh cua do thi: {SoCanh}");
            int SoCanhBoi = CountParallelEdges(true, g);
            Console.WriteLine($"So cap dinh xuat hien canh boi: {SoCanhBoi}");
            int SoCanhKhuyen = CountLoopEdges(g);
            Console.WriteLine($"So canh khuyen: {SoCanhKhuyen}");
            int SoDinhTreo = CountHangingVertex(VertexDeg);
            Console.WriteLine($"So dinh treo: {SoDinhTreo}");
            int SoDinhCoLap = CountIsoVertex(VertexDeg);
            Console.WriteLine($"So dinh co lap: {SoDinhCoLap}");
            Console.WriteLine("Bac cua tung dinh: ");
            for (int i = 0; i < g.n; ++i)
                Console.Write($"{i}({VertexDeg[i]}) ");
            Console.WriteLine();
            if (SoCanhKhuyen > 0)
                Console.WriteLine("Gia do thi");
            else
            {
                if (SoCanhBoi > 0)
                    Console.WriteLine("Da do thi");
                else
                    Console.WriteLine("Don do thi");
            }
        }

        private void CountVertexDegrees(ref int[] VertexDeg, AdjacencyMatrix g)
        {
            for (int i = 0; i < g.n; ++i)
            {
                int count = 0;
                for (int j = 0; j < g.n; ++j)
                    if (g.a[i, j] != 0)
                    {
                        count += g.a[i, j];
                        if (i == j)
                            count += g.a[i, i];
                    }
                VertexDeg[i] = count;
            }
        }
        private int CountEdges(int[] VertexDeg, bool isUndirected)
        {
            int sumVerDeg = 0;
            for (int i = 0; i < VertexDeg.Length; ++i)
            {
                sumVerDeg += VertexDeg[i];
            }
            if (isUndirected == true)
            {
                return sumVerDeg / 2;
            }
            else
            {
                return sumVerDeg;
            }
        }
        private int CountParallelEdges(bool isUndirected, AdjacencyMatrix g)
        {
            int num = 0;
            if (isUndirected == true)
            {
                for (int i = 0; i < g.n; ++i)
                    for (int j = i; j < g.n; ++j)
                        if (g.a[i, j] > 1)
                            num++;
            }
            else
            {
                for (int i = 0; i < g.n; ++i)
                    for (int j = 0; j < g.n; ++j)
                        if (g.a[i, j] > 1)
                            num++;
            }
            return num;
        }
        private int CountLoopEdges(AdjacencyMatrix g)
        {
            int num = 0;
            for (int i = 0; i < g.n; ++i)
            {
                num += g.a[i, i];
            }
            return num;
        }
        private int CountHangingVertex(int[] VertexDeg)
        {
            int count = 0;
            for (int i = 0; i < VertexDeg.Length; ++i)
            {
                if (VertexDeg[i] == 1)
                {
                    count++;
                }
            }
            return count;
        }
        private int CountIsoVertex(int[] VertexDeg)
        {
            int count = 0;
            for (int i = 0; i < VertexDeg.Length; ++i)
            {
                if (VertexDeg[i] == 0)
                {
                    count++;
                }
            }
            return count;
        }
        private void CountVertexDegrees(ref int[] DegIn, ref int[] DegOut, AdjacencyMatrix g)
        {
            for (int i = 0; i < g.n; ++i)
            {
                int countDegIn = 0;
                int countDegOut = 0;
                for (int j = 0; j < g.n; ++j)
                {
                    if (g.a[i, j] != 0)
                        countDegOut += g.a[i, j];
                    if (g.a[j, i] != 0)
                        countDegIn += g.a[j, i];
                }
                DegIn[i] = countDegIn;
                DegOut[i] = countDegOut;
            }
        }

        private void DirectedGraph(AdjacencyMatrix g)
        {
            Console.WriteLine("Do thi co huong");
            Console.WriteLine($"So dinh cua do thi: {g.n}");
            int[] DegIn = new int[g.n];
            int[] DegOut = new int[g.n];
            CountVertexDegrees(ref DegIn, ref DegOut, g);
            int SoCanh = CountEdges(DegIn, false);
            Console.WriteLine($"So canh cua do thi: {SoCanh}");
            int SoCanhBoi = CountParallelEdges(false, g);
            Console.WriteLine($"So cap dinh xuat hien canh boi: {SoCanhBoi}");
            int SoCanhKhuyen = CountLoopEdges(g);
            Console.WriteLine($"So canh khuyen: {SoCanhKhuyen}");
            int[] VertexDeg = new int[g.n];
            for (int i = 0; i < g.n; ++i)
                VertexDeg[i] = DegIn[i] + DegOut[i];
            int SoDinhTreo = CountHangingVertex(VertexDeg);
            Console.WriteLine($"So dinh treo: {SoDinhTreo}");
            int SoDinhCoLap = CountIsoVertex(VertexDeg);
            Console.WriteLine($"So dinh co lap: {SoDinhCoLap}");
            Console.WriteLine("(Bac vao - Bac ra) cua tung dinh: ");
            for (int i = 0; i < g.n; ++i)
                Console.Write($"{i}({DegIn[i]}-{DegOut[i]}) ");
            Console.WriteLine();
            if (SoCanhBoi > 0)
                Console.WriteLine("Da do thi co huong");
            else
                Console.WriteLine("Do thi co huong");
        }
        public void Cau1(string fileName)
        {
            string file_path = Environment.CurrentDirectory;
            AdjacencyMatrix g = new AdjacencyMatrix();
            g.ReadAdjacencyMatrix(fileName);
            g.ShowAdjacencyMatrix();
            if (IsUndirectedGraph(g) == true)
                UndirectedGraph(g);
            else
                DirectedGraph(g);
        }
    }
}
