using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindingWaysRobot
{
    class AStar
    {
        public static bool robotGo=false;
        public int[,] AstarAlgoritm(int[,] map, int XStart, int YStart, int XFinish, int YFinish)
        {
            int matrixSize = map.GetLength(0) * map.GetLength(1); // размерность списка смежности
            List<int> routeOfMovement_x = new List<int>(); //Список движения будет хранить конечный маршрут
            List<int> routeOfMovement_y = new List<int>(); //Список движения будет хранить конечный маршрут

            int start = ((map.GetLength(1) * XStart) + (YStart));
            int finish = ((map.GetLength(1) * XFinish) + (YFinish));
            AdjacencyList[] adjacencyList = buildListAdjacencies(map);
            const int infinity = 999999999;// Бесконечность
            int currentVertex; // текущая вершина
            int[] way = new int[matrixSize]; // запоминает последнюю вершину для нахождения пути назад
            int[] vertex = new int[matrixSize];//хранит соседние вершиеы

            for (int i = 0; i < matrixSize; i++)
            {
                adjacencyList[i].vertexLabels = infinity;
                vertex[i] = infinity;
            }

            way[start] = 0;          // s - начало пути, поэтому этой вершине ничего не предшествует
            adjacencyList[start].vertexLabels = 0; // Кратчайший путь из start в start равен 0 /начальная метка как в википедии и норм статьях
            adjacencyList[start].visit = true;       // Вершина start посещена
            currentVertex = start;    // Делаем start текущей вершиной

            while (true)
            {
                // Перебираем все вершины, смежные v, и ищем для них кратчайший путь
                for (int i = 0; i < 4; i++)
                {
                    if (adjacencyList[currentVertex].G[i] == -1) continue; // Вершины u и v несмежные
                    if (
                        adjacencyList[adjacencyList[currentVertex].adjacentVertices[i]].visit == false &&
                        adjacencyList[adjacencyList[currentVertex].adjacentVertices[i]].vertexLabels >
                        adjacencyList[currentVertex].vertexLabels + adjacencyList[currentVertex].G[i]
                        )
                    {
                        adjacencyList[adjacencyList[currentVertex].adjacentVertices[i]].vertexLabels = adjacencyList[currentVertex].vertexLabels + adjacencyList[currentVertex].G[i]; //новая метка вершины
                        way[adjacencyList[currentVertex].adjacentVertices[i]] = currentVertex;//запоминаем, что v->u часть кратчайшего пути из s->u                        
                        int XCurrent = adjacencyList[adjacencyList[currentVertex].adjacentVertices[i]].adjacencyList_dataGridView[0];
                        int YCurrent= adjacencyList[adjacencyList[currentVertex].adjacentVertices[i]].adjacencyList_dataGridView[1];
                        int H = ManhattanDistance(XCurrent, YCurrent, XFinish, YFinish);
                        vertex[adjacencyList[currentVertex].adjacentVertices[i]] = adjacencyList[adjacencyList[currentVertex].adjacentVertices[i]].vertexLabels + H;
                    }
                }

                currentVertex = -1;// В конце поиска v - вершина, в которую будет найден новый кратчайший путь. Она станет текущей вершиной
                if (adjacencyList[Array.IndexOf(vertex, vertex.Min())].visit == false)
                {
                    currentVertex = Array.IndexOf(vertex, vertex.Min());
                    vertex[Array.IndexOf(vertex, vertex.Min())] = infinity;
                }

                if (currentVertex == -1)
                {
                    MessageBox.Show("Невозможно построить путь ☹");
                    break;
                }
                if (currentVertex == finish) // Найден кратчайший путь,
                {        // выводим его
                    int u = finish;
                    while (u != start)
                    {                     
                        routeOfMovement_x.Add(adjacencyList[u].adjacencyList_dataGridView[0]);
                        routeOfMovement_y.Add(adjacencyList[u].adjacencyList_dataGridView[1]);
                        u = way[u];
                    }
                    break;
                }
                adjacencyList[currentVertex].visit = true;
            }/// while 

            /* Формируем выходной массив */
            int[,] arRasult = new int[routeOfMovement_x.Count, 2];
            for (int i=0; i< routeOfMovement_x.Count; i++)
            {
                arRasult[i, 0] = routeOfMovement_x[i];
                arRasult[i, 1] = routeOfMovement_y[i];
            }

            return (arRasult);

        }//AstarAlgoritm

        /* Манхэттенское расстояние */
        private int ManhattanDistance(int XCurrent, int YCurrent, int XFinish, int YFinish)
        {
            return (Math.Abs(XCurrent - XFinish) + Math.Abs(YCurrent - YFinish));
        }

        /* Возвращает список смежности */
        private AdjacencyList[] buildListAdjacencies(int[,] map)
        {
            int matrixSize = map.GetLength(0) * map.GetLength(1); // размерность списка смежности
            AdjacencyList[] adjacencyList = new AdjacencyList[matrixSize]; // Создаем список смежности 
            for (int i=0; i<matrixSize; i++)
            {
                adjacencyList[i] = new AdjacencyList();
            }
            int stroka = 0;
            for (int i = 0; i < map.GetLength(0); i++)//строки
            {
                for (int j = 0; j < map.GetLength(1); j++)//столбцы
                {
                    int stolb = 0;
                    if (i + 1 < map.GetLength(0))
                    {
                        if (map[i + 1, j] != -5)
                        {
                            adjacencyList[stroka].G[stolb] = map[i + 1, j];
                            adjacencyList[stroka].adjacentVertices[stolb] = ((map.GetLength(1) * (i + 1)) + j);
                            stolb++;
                        }
                    }

                    if (i - 1 >= 0)
                    {
                        if (map[i - 1, j] != -5)
                        {
                            adjacencyList[stroka].G[stolb] = map[i - 1, j];
                            adjacencyList[stroka].adjacentVertices[stolb] = ((map.GetLength(1) * (i - 1)) + j);
                            stolb++;
                        }
                    }

                    if (j + 1 < map.GetLength(1))
                    {
                        if (map[i, j + 1] != -5)
                        {
                            adjacencyList[stroka].G[stolb] = map[i, j + 1];
                            adjacencyList[stroka].adjacentVertices[stolb] = ((map.GetLength(1) * i) + (j + 1));
                            stolb++;
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (map[i, j - 1] != -5)
                        {
                            adjacencyList[stroka].G[stolb] = map[i, j - 1];
                            adjacencyList[stroka].adjacentVertices[stolb] = ((map.GetLength(1) * i) + (j - 1));
                            stolb++;
                        }
                    }
                    adjacencyList[stroka].adjacencyList_dataGridView[0] = j;
                    adjacencyList[stroka].adjacencyList_dataGridView[1] = i;
                    stroka++;
                }//j
            }//i
            return (adjacencyList);
        }//buildListAdjacencies

    }//class
}//namespace
