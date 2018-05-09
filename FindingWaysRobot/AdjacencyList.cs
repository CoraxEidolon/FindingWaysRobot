using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingWaysRobot
{
    class AdjacencyList
    {
        public int[] G = new int[4];// вес смежжных вершин *adjacencyList*
        public int[] adjacentVertices = new int[4];// смежные вершины *adjacencyList_adjacentVertices*
        public int[] adjacencyList_dataGridView = new int[2];// Соответствия вершин списка смежности dataGridView. 0-x, 1-y   *ertexMatrix* 

        public bool visit;//Посещена вершина или нет
        public int vertexLabels;//Мектка вершины




        public AdjacencyList()
        {
            for (int i=0; i<4; i++)
            {
                G[i] = -1;
                adjacentVertices[i] = -1;
            }
        }



    }
}
