using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FindingWaysRobot
{
    class MapEdit
    {
        public static bool installRobot = false; // Установлен ли робот
        public static bool installFinish = false; //Установлен ли финиш
        public  byte RobotPosition = 2; //Позиция робота, использовать после searchRobotInstall

        public static string PatencyGood = Convert.ToString(Properties.Settings.Default.directMovement);
        public static string PatencyMedium = Convert.ToString(Properties.Settings.Default.directMovement2);
        public static string PatencyBad = Convert.ToString(Properties.Settings.Default.directMovement3);



        private  Color PatencyGoodColor= Color.FromArgb(192, 255, 192);
        private Color PatencyMediumColor = Color.FromArgb(255, 255, 160);
        private Color PatencyBadColor = Color.FromArgb(255, 192, 192);
        private Color FinishColor = Color.Gold;
        private Color RobotColor = Color.GreenYellow;
        private Color PatencyWallColor = Color.Black;

        /* Проверка, установлен робот на карту */
        public bool searchRobotInstall(string robotPosition, bool alert)
        {

            bool OK = false;
            if (robotPosition.IndexOf("▲") >= 0)
            {
                OK = true;
                RobotPosition = 2;
            } else
            if (robotPosition.IndexOf("►") >= 0)
            {
                OK = true;
                RobotPosition = 6;
            } else
            if (robotPosition.IndexOf("▼") >= 0)
            {
                OK = true;
                RobotPosition = 8;
            } else
            if (robotPosition.IndexOf("◄") >= 0)
            {
                OK = true;
                RobotPosition = 4;
            }

            if (OK == false && alert ==true)
            {
                MessageBox.Show("Выберете ячеку, где установлен робот");
            }
            return OK;
        }

        /* Установка робота на карту */
        public string InstallRobot(string cell, string robotPosition)
        {
            if (cell != "w" && SearchFinishInstall(cell,false)==false)
            {
                cell += robotPosition;
                installRobot = true;
            }
            else
            {
                MessageBox.Show("Невозможно установить робота на этой клетке!");
            }
            return cell;
        }
   
        /* Удаляет робота с карты */
        public string DeleteRobot(string robotPosition)
        {
            if (searchRobotInstall(robotPosition, true) == true)
            {

                if (robotPosition.IndexOf("▲") >= 0)
                {
                    int ind = robotPosition.IndexOf("▲");
                    robotPosition = robotPosition.Remove(ind);
                }
                else
            if (robotPosition.IndexOf("►") >= 0)
                {
                    int ind = robotPosition.IndexOf("►");
                    robotPosition = robotPosition.Remove(ind);
                }
                else
            if (robotPosition.IndexOf("▼") >= 0)
                {
                    int ind = robotPosition.IndexOf("▼");
                    robotPosition = robotPosition.Remove(ind);
                }
                else
            if (robotPosition.IndexOf("◄") >= 0)
                {
                    int ind = robotPosition.IndexOf("◄");
                    robotPosition = robotPosition.Remove(ind);
                }
                installRobot = false;
            }

            return robotPosition;
        }

        /* Проверка, установлен финиш на карту */
        public bool SearchFinishInstall(string cell, bool alert)
        {
            bool OK = false;
            if (cell.IndexOf("f") >= 0)
            {
                OK = true;
            }

            if (OK==false && alert==true)
            {
                MessageBox.Show("Выберете ячеку, где установлен финиш");
            }
            return OK;
        }

        /* Удаляет финиш с карты */
        public string DeleteFinish(string cell)
        {
            if (SearchFinishInstall(cell, true) == true)
            {
                if (cell.IndexOf("f") >= 0)
                {
                    int ind = cell.IndexOf("f");
                    cell = cell.Remove(ind, 1);
                    installFinish = false;
                }
            }
            return cell;
        }

        /* Установка финиша на карту */
        public string InstallFinish(string cell)
        {
            if (cell != "w" && searchRobotInstall(cell, false)==false)
            {
                cell += "f";
                installFinish = true;
            }
            else
            {
                MessageBox.Show("Невозможно установить финиш на этой клетке!");
            }
            return cell;
        }
   
        /* Цвет текущей ячейки*/
        public Color CellColor(string cell)
        {
            Color cellColor = PatencyGoodColor;

            if (cell == PatencyGood)
            {
                cellColor = PatencyGoodColor;
            }
            else

                if (cell == PatencyMedium)
            {
                cellColor = PatencyMediumColor;
            }
            else
                if (cell == PatencyBad)
            {
                cellColor = PatencyBadColor;
            }
            else
                if (cell == "w")
            {
                cellColor = PatencyWallColor;
            } else
            if (searchRobotInstall(cell, false) == true)
            {
                cellColor = RobotColor;
            } else
                
            if (SearchFinishInstall(cell,false)) { cellColor = FinishColor; }

            return (cellColor);
        }

    }//class 
}//namespace
