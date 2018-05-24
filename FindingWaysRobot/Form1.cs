using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;
using System.IO.Ports;

namespace FindingWaysRobot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int GLOBAL_cellSize = 31; // Размер ячеек
        int[,] GLOBAL_way;
        string[] GLOBAL_robotPosition;
        List<int> GLOBAL_robotRoute = new List<int>(); // готовый маршрут робота. Глобальный, чтобы иметь к нему доступ из любого метода

        int GLOBAL_buf_timerPlus = 0;
        int GLOBAL_initialPositionRobot_timer = 0;
        int GLOBAL_X_timer = 0;
        int GLOBAL_Y_timer = 0;

        int GLOBAL_X_finish_stop = 0;
        int GLOBAL_Y_finish_stop = 0;


        SerialPort SerialPort;//серийный порт
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = GLOBAL_cellSize;
            standardClearMap();       
            SetNullInTextBox(this.Controls);        
            /* ПОДКЛЮЧЕНИЕ К БД */
            DataBase.connectionString = Properties.Settings.Default.connectionDatabase;
            textBoxConnectingDatabase.Text = Properties.Settings.Default.connectionDatabase;
            RobotPosition.SelectedIndex = 0;
            loadAllMapInSelectTable(true);
            /* Прозрачность кнопок */
            trackBarTransparency.Value = Properties.Settings.Default.Transparency;
            labelTransparency.Text = "Прозрачность: " + trackBarTransparency.Value;
           

        }

        /* Перебор контролов и вложенных в них контролы и делаем кнопки круглыми. С нулевой вложенностью не работает */
        private void SetNullInTextBox(Control.ControlCollection control)
        {
            foreach (Control _control in control)
            {
                if (_control is Button & String.IsNullOrEmpty(_control.Text))
                {
                    ((Button)_control).BackColor = Color.FromArgb(Properties.Settings.Default.Transparency, Properties.Settings.Default.ButtonColor); // цвет кнопки
                    System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
                    myPath.AddEllipse(0, 0, ((Button)_control).Width, ((Button)_control).Height);
                    Region myRegion = new Region(myPath);
                    ((Button)_control).Region = myRegion;
                    ((Button)_control).FlatAppearance.BorderSize = 0;
                    ((Button)_control).FlatStyle = FlatStyle.Flat;
                }
                if (_control.Controls.Count > 0)
                {
                    SetNullInTextBox(_control.Controls);
                }
            }
        }

        /* Очистка dataGridView до стандартных значений 2x2 */
        private void standardClearMap()
        {
            numberOfСolumns.Value = 2;
            numberOfLines.Value = 2;
            dataGridView1.RowCount = Convert.ToInt32(numberOfСolumns.Value);
            dataGridView1.ColumnCount = Convert.ToInt32(numberOfСolumns.Value);
            dataGridView1.Width = Convert.ToInt32(numberOfСolumns.Value) * GLOBAL_cellSize + 3;
            dataGridView1.Height = Convert.ToInt32(numberOfСolumns.Value) * GLOBAL_cellSize + 3;
            for (int i = 0; i < Convert.ToInt32(numberOfСolumns.Value); i++)
            {
                dataGridView1.Columns[i].Width = GLOBAL_cellSize;
            }
            MapEdit CurrentCell = new MapEdit();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = MapEdit.PatencyGood;
                    dataGridView1.Rows[j].Cells[i].Style.BackColor = CurrentCell.CellColor(MapEdit.PatencyGood);
                }
            }
        }

        /* Кнопка прибавляет/убавляет колличество строк */
        private void numberOfLines_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Convert.ToInt32(numberOfLines.Value);
            dataGridView1.Height = Convert.ToInt32(numberOfLines.Value) * GLOBAL_cellSize + 3;
            MapEdit CurrentCellColor = new MapEdit();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[i].Value = MapEdit.PatencyGood;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[i].Style.BackColor = CurrentCellColor.CellColor(MapEdit.PatencyGood);
            }
        }

        /* Кнопка прибавляет/убавляет колличество столбцов */
        private void numberOfСolumns_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(numberOfСolumns.Value);
            for (int i = Convert.ToInt32(numberOfСolumns.Value) - 1; i < Convert.ToInt32(numberOfСolumns.Value); i++)
            {
                dataGridView1.Columns[i].Width = GLOBAL_cellSize;
            }
            MapEdit CurrentCellColor = new MapEdit();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value = MapEdit.PatencyGood;
                dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = CurrentCellColor.CellColor(MapEdit.PatencyGood);
            }
            dataGridView1.Width = Convert.ToInt32(numberOfСolumns.Value) * GLOBAL_cellSize + 3;
        }

        /* Сохраняет карту */
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (DataBase.checkСonnection(DataBase.connectionString) == true)
            {
                DataBase DB = new DataBase();
                if (DB.verificationMap(textBoxMapName.Text) == true)
                {
                    if (DataBase.editTable == false)
                    {
                        DB.InquiryNOReturnValue("create table " + textBoxMapName.Text + " (map varchar(100));");
                    }
                    else
                    {
                        if (DataBase.currentTableName != textBoxMapName.Text)
                        {
                            DB.InquiryNOReturnValue("ALTER TABLE " + DataBase.currentTableName + " RENAME TO " + textBoxMapName.Text + ";");
                        }
                        DB.InquiryNOReturnValue("DELETE FROM " + textBoxMapName.Text + ";");
                    }
                    DB.InquiryNOReturnValue("INSERT INTO " + textBoxMapName.Text + " (map) VALUES ('" + dataGridView1.RowCount + "');");
                    DB.InquiryNOReturnValue("INSERT INTO " + textBoxMapName.Text + " (map) VALUES ('" + dataGridView1.ColumnCount + "');");
                    /* Сохраняем карту */
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            DB.InquiryNOReturnValue("INSERT INTO " + textBoxMapName.Text + " (map) VALUES ('" + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + "');");
                        } // for j
                    }// for i

                    statusBar.SelectionColor = Color.Green;
                    statusBar.AppendText("● Сохранена карта «" + textBoxMapName.Text + "»\n");
                    DataBase.editTable = true;//включаем режим редактирования
                    DataBase.currentTableName = textBoxMapName.Text;
                }//verification
                loadAllMapInSelectTable(false);
            }
            else
            {
                statusBar.SelectionColor = Color.Red;
                statusBar.AppendText("● Не удалось выполнить подключение к БД \n");
            } 
        }//buttonSave

        /* Устанавливает/убирает точку финиша на карте */
        private void buttonSetRemoveFinish_Click(object sender, EventArgs e)
        {        
            MapEdit finish = new MapEdit();

            if (MapEdit.installFinish == true)
            {
                dataGridView1.CurrentCell.Value = finish.DeleteFinish(Convert.ToString(dataGridView1.CurrentCell.Value));
                dataGridView1.CurrentCell.Style.BackColor = finish.CellColor(Convert.ToString(dataGridView1.CurrentCell.Value));
            }
            else
            {
                dataGridView1.CurrentCell.Value = finish.InstallFinish(Convert.ToString(dataGridView1.CurrentCell.Value));
                dataGridView1.CurrentCell.Style.BackColor = finish.CellColor(Convert.ToString(dataGridView1.CurrentCell.Value));
            }
            imageButtonRobotFinish();
        }//buttonSetRemoveFinish

        /* Устанавливает/убирает робота на карту */
        private void buttonInstallOrRemoveRobot_Click(object sender, EventArgs e)
        {
            MapEdit robot = new MapEdit();
            if (MapEdit.installRobot == true)
            {
                dataGridView1.CurrentCell.Value = robot.DeleteRobot(Convert.ToString(dataGridView1.CurrentCell.Value));
                dataGridView1.CurrentCell.Style.BackColor = robot.CellColor(Convert.ToString(dataGridView1.CurrentCell.Value));
            }
            else
            {
                dataGridView1.CurrentCell.Value = robot.InstallRobot(Convert.ToString(dataGridView1.CurrentCell.Value), RobotPosition.Text);
                dataGridView1.CurrentCell.Style.BackColor = robot.CellColor(Convert.ToString(dataGridView1.CurrentCell.Value));
            }
            imageButtonRobotFinish();
        }//InstallOrRemoveRobot

        /* Меняет картинки кнопок робота и финиша */
        private void imageButtonRobotFinish()
        {
            if (MapEdit.installRobot == true)
            {
                buttonInstallOrRemoveRobot.Image = Properties.Resources.robotDel;
            }
            else
            {
                buttonInstallOrRemoveRobot.Image = Properties.Resources.robot;
            }


            if (MapEdit.installFinish == true)
            {
                buttonSetRemoveFinish.Image = Properties.Resources.finishDel;
            }
            else
            {
                buttonSetRemoveFinish.Image = Properties.Resources.finish;
            }
            NumericUpDownEnabled();
        }//imageButtonRobotFinish

        /* Запрет на изменение размера карты при установленном роботе или финише*/
        private void NumericUpDownEnabled()
        {
            numberOfLines.Enabled = (!MapEdit.installFinish & !MapEdit.installRobot);
            numberOfСolumns.Enabled = (!MapEdit.installFinish & !MapEdit.installRobot);         
        }

        /* Разрешенные значения dataGridView */
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AStar.robotGo == false)
            {
                MapEdit currentCellColor = new MapEdit();
                if (
                     currentCellColor.searchRobotInstall(Convert.ToString(dataGridView1.CurrentCell.Value), false) == false &&
                     currentCellColor.SearchFinishInstall(Convert.ToString(dataGridView1.CurrentCell.Value), false) == false
                    )
                {
                    if (e.KeyChar == '1')
                    {
                        dataGridView1.CurrentCell.Value = MapEdit.PatencyGood;
                        dataGridView1.CurrentCell.Style.BackColor = currentCellColor.CellColor(MapEdit.PatencyGood);
                    }
                    else
                    if (e.KeyChar == '2')
                    {
                        dataGridView1.CurrentCell.Value = MapEdit.PatencyMedium;
                        dataGridView1.CurrentCell.Style.BackColor = currentCellColor.CellColor(MapEdit.PatencyMedium);
                    }
                    else
                    if (e.KeyChar == '3')
                    {
                        dataGridView1.CurrentCell.Value = MapEdit.PatencyBad;
                        dataGridView1.CurrentCell.Style.BackColor = currentCellColor.CellColor(MapEdit.PatencyBad);
                    }
                    else
                    if (e.KeyChar == 'w')
                    {
                        dataGridView1.CurrentCell.Value = "w";
                        dataGridView1.CurrentCell.Style.BackColor = currentCellColor.CellColor("w");
                    }
                }
            }//robotGo==false

        }

        /* Запред на ввод кирилицы. Разрешены только [a-z,A-Z, 0-9] и "_" */
        private void textBoxMapName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        /* Загружает ВСЕ имеющиеся таблицы в SelectTable а так же задает Enabled кнопок на панели panelMapSelection */
        private void loadAllMapInSelectTable(bool firstMap)
        {
            DataBase DB = new DataBase();
            string[] allMap= DB.AllTable();
            SelectTable.Items.Clear();
            if (allMap.Length > 0)
            {
                for (int i = 0; i < allMap.Length; i++)
                {
                    SelectTable.Items.Add(allMap[i]);
                }
                if (firstMap == true)
                {
                    SelectTable.SelectedIndex = 0;
                }
                buttonMapEdit.Enabled = true;
                buttonMapEdit.Image = Properties.Resources.edit;
                buttonDeleteMap.Enabled = true;
                buttonDeleteMap.Image = Properties.Resources.delete;
                buttonLoadMapIntoRobot.Enabled = true;
                buttonLoadMapIntoRobot.Image = Properties.Resources.robotConnect;
            }else
            {
                buttonMapEdit.Enabled = false;
                buttonMapEdit.Image = Properties.Resources.editLock;
                buttonDeleteMap.Enabled = false;
                buttonDeleteMap.Image = Properties.Resources.deleteLock;
                buttonLoadMapIntoRobot.Enabled = false;
                buttonLoadMapIntoRobot.Image = Properties.Resources.robotConnectLock;
            }
        }
        
        /* При нажатие на элемент ComboBox автоматически показывается выбранная таблица */
        private void SelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();
            if (SelectTable.Items.Count > 0)
            {          
                List<string> map = new List<string>();
                map = DB.InquiryReturnValue("select map from " + Convert.ToString(SelectTable.SelectedItem) + ";").ToList();
                int line = Convert.ToInt32(map[0]);
                int column = Convert.ToInt32(map[1]);
                map.RemoveAt(0);
                map.RemoveAt(0);
                OpenNewMap(line, column, map.ToArray());
                MapEdit.installRobot = true;
                MapEdit.installFinish = true;
                imageButtonRobotFinish();
                statusBar.SelectionColor = Color.WhiteSmoke;
                statusBar.AppendText("● Открыта карта «" + SelectTable.SelectedItem + "»\n");

            } else
            {
                standardClearMap();
                MapEdit.installRobot = false;
                MapEdit.installFinish = false;
                panelCreateEditMap.Visible = true;
                panelMapSelection.Visible = false;
                imageButtonRobotFinish();
            }         
        }

        /* Открывает новую карту и загружает ее в  dataGridView */
        public void OpenNewMap(int line, int column, string[] map)
        {
            numberOfСolumns.Value = column;
            numberOfLines.Value = line;
            dataGridView1.RowCount = line;
            dataGridView1.ColumnCount = column;
            dataGridView1.Width = column * GLOBAL_cellSize + 3;
            dataGridView1.Height = line * GLOBAL_cellSize + 3;
            for (int i = 0; i < column; i++)
            {
                dataGridView1.Columns[i].Width = GLOBAL_cellSize;
            }
            int counter = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = map[counter];
                    MapEdit currentCellColor = new MapEdit();
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = currentCellColor.CellColor(map[counter]);
                    counter++;
                }
            }
        }

        /* Кнопка перейти на панель выбора карт*/
        private void buttonMapSelection_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Все несохраненные изменения будут утеряны, вы уверены ?", "Предупреждение",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panelCreateEditMap.Visible = false;
                panelMapSelection.Visible = true;
                if (DataBase.editTable == true)
                {
                    DataBase.editTable = false;
                }
                loadAllMapInSelectTable(true);
            }
        }

        /* Кнопка создать новую карту*/
        private void buttonCreateMap_Click(object sender, EventArgs e)
        {
            textBoxMapName.Text = "";
            panelCreateEditMap.Visible = true;
            panelMapSelection.Visible = false;
            MapEdit.installRobot = false;
            MapEdit.installFinish = false;
            standardClearMap();
            imageButtonRobotFinish();
        }

        /* Редактировать карту */
        private void buttonMapEdit_Click(object sender, EventArgs e)
        {
            WayColorClear();
            DataBase.currentTableName = SelectTable.Text;
            textBoxMapName.Text= SelectTable.Text; 
            DataBase.editTable = true;//включаем режим редактирования
            panelCreateEditMap.Visible = true;
            panelMapSelection.Visible = false;
            statusBar.SelectionColor = Color.SlateBlue;
            statusBar.AppendText("● Редактировать карту «" + SelectTable.Text + "» \n");
        }

        /* Кнопка удалить карту */
        private void buttonDeleteMap_Click(object sender, EventArgs e)
        {
            DataBase BD = new DataBase();
            if (MessageBox.Show("Вы действительно хотите удалить карту «" + SelectTable.SelectedItem + "» ?", "Удаление",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                BD.InquiryNOReturnValue("drop table " + Convert.ToString(SelectTable.SelectedItem) + ";");
                string currentTable = Convert.ToString(SelectTable.SelectedItem);
                loadAllMapInSelectTable(true);
                statusBar.SelectionColor = Color.Red;
                statusBar.AppendText("● Карта «" + currentTable + "» была удалена \n");
            }
        }

        /* Кнопка поиска пути */
        private void buttonGetDirections_Click(object sender, EventArgs e)
        {
            WayColorClear();
            AStar A = new AStar();

            int[,] map = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];
            int XStar = 0;
            int YStart = 0;
            int XFinish = 0;
            int YFinish = 0;
            byte RobotPosition = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)//строки
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)//столбцы
                {
                    MapEdit searchStartFinish = new MapEdit();
                    if (searchStartFinish.searchRobotInstall(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), false) == true)
                    {
                        XStar = i;
                        YStart = j;
                        RobotPosition = searchStartFinish.RobotPosition;
                        map[i, j] = 0;
                    }
                    else 
                    if (searchStartFinish.SearchFinishInstall(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), false) == true)
                    {
                        XFinish = i;
                        YFinish = j;
                        map[i, j] = 0;
                    }
                    else                      
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) == "w")
                    {
                        map[i, j] = -5;
                    } else
                    {
                        map[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }

                }//j
            }//i

            int[,] way= A.AstarAlgoritm(map, XStar, YStart, XFinish, YFinish);

            if (way.GetLength(0) > 0)
            {
                GLOBAL_way = new int[way.GetLength(0), 2]; // массив пути X и Y
                GLOBAL_robotPosition = new string[way.GetLength(0)]; // Положение робота
                GLOBAL_way[0, 0] = way[0, 0];
                GLOBAL_way[0, 1] = way[0, 1];

                for (int i = 1; i < way.GetLength(0); i++)
                {
                    dataGridView1.Rows[way[i, 1]].Cells[way[i, 0]].Style.BackColor = Color.SteelBlue;
                    GLOBAL_way[i, 0] = way[i, 0];
                    GLOBAL_way[i, 1] = way[i, 1];
                }


                GLOBAL_robotRoute.Clear();

                int current_X = YStart;
                int current_Y = XStar;
                int currentPosition = RobotPosition;

                for (int i = GLOBAL_way.GetLength(0) - 1; i >= 0; i--)
                {
                    if (currentPosition == 2)
                    {
                        if (current_X + 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 6; current_X++; continue; }
                        if (current_X - 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 4; current_X--; continue; }
                        if (current_Y + 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 8; current_Y++; continue; }
                        if (current_Y - 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(2); current_Y--; continue; }
                    }
                    if (currentPosition == 4)
                    {
                        if (current_X + 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 6; current_X++; continue; }
                        if (current_X - 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(2); current_X--; continue; }
                        if (current_Y + 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 8; current_Y++; continue; }
                        if (current_Y - 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 2; current_Y--; continue; }
                    }
                    if (currentPosition == 6)
                    {
                        if (current_X + 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(2); current_X++; continue; }
                        if (current_X - 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 4; current_X--; continue; }
                        if (current_Y + 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 8; current_Y++; continue; }
                        if (current_Y - 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 2; current_Y--; continue; }
                    }
                    if (currentPosition == 8)
                    {
                        if (current_X + 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 6; current_X++; continue; }
                        if (current_X - 1 == GLOBAL_way[i, 0]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 4; current_X--; continue; }
                        if (current_Y + 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(2); current_Y++; continue; }
                        if (current_Y - 1 == GLOBAL_way[i, 1]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 2; current_Y--; continue; }
                    }
                }//for

                GLOBAL_buf_timerPlus = 0;
                GLOBAL_X_timer = YStart;
                GLOBAL_Y_timer = XStar;
                GLOBAL_X_finish_stop = YFinish;
                GLOBAL_Y_finish_stop = XFinish;
                GLOBAL_initialPositionRobot_timer = RobotPosition;
                try
                {
                    if (SerialPort.IsOpen == true)
                    {
                        buttonSendWayRobot.Image = Properties.Resources.LoadInRobot;
                        buttonSendWayRobot.Enabled = true;
                    }
                    else
                    {
                        statusBar.AppendText("● Отсутствует соединение с каким либо портом \n");
                    }
                }
                catch
                {
                    statusBar.AppendText("● Отсутствует соединение с каким либо портом \n");
                }

            }//Если путь построен

        }//buttonGetDirections

        /* Очищает карту от цвета пути*/
        private void WayColorClear()
        {
            MapEdit CurrentCellColor = new MapEdit();
            for (int i = 0; i < dataGridView1.RowCount; i++)//строки
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)//столбцы
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = CurrentCellColor.CellColor(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value));
                }

            }

        }

        /* Обновляет список доступных COM портов */
        private void ComPortRefresh()
        {
            ComPortNumber.Items.Clear();
            // получаем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            // выводим список портов
            for (int i = 0; i < ports.Length; i++)
            {
                ComPortNumber.Items.Add(ports[i].ToString());
            }
        }

        /* Обновить список COM портов*/
        private void buttonComPortRefresh_Click(object sender, EventArgs e)
        {
            ComPortRefresh();
        }

        /* Установить соединение с COM портом */
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort = new SerialPort(Convert.ToString(ComPortNumber.SelectedItem));
                SerialPort.BaudRate = 115200;
                SerialPort.Parity = Parity.None;
                SerialPort.StopBits = StopBits.One;
                SerialPort.DataBits = 8;
                SerialPort.Handshake = Handshake.None;
                SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                statusBar.AppendText("● Установка соединения с портом " + Convert.ToString(ComPortNumber.SelectedItem) + "..." + "\n");
                SerialPort.Open();
                statusBar.AppendText("● Соединение c " + SerialPort.PortName + " успешно установлено " + "\n");

            }
            catch
            {
                statusBar.AppendText("● Не удалось выполнить соединение c " + Convert.ToString(ComPortNumber.SelectedItem) + "\n");

            }
        }

        /* Чтение данных их COM  порта*/
        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (indata == "R")
            {
     
                statusBar.Invoke((MethodInvoker)delegate
                {
                    statusBar.AppendText("● Робот успешно принял маршрут\n");
                    buttonStartWay.Enabled = true;
                    buttonStartWay.Image = Properties.Resources.startWay;
                });
                      
            }
            else if (indata == "S")
            {
                statusBar.Invoke((MethodInvoker)delegate
                {
                    statusBar.AppendText("‼ Робот обнаружил препятствие на пути. Дальнейшее движение невозможно.\n");
                    buttonStop_Click(sender, e);
                });
            }
        }
        private delegate void LineReceivedEvent(string POT);

        /* Отправить путь роботу */
        private void buttonSendWayRobot_Click(object sender, EventArgs e)
        {
            try
            {
                if (SerialPort.IsOpen == true)
                {
                   
                    statusBar.AppendText("● Маршрут отправлен роботу \n");
                    for (int i=0; i< GLOBAL_robotRoute.Count; i++)
                    {
                        SerialPort.Write(Convert.ToString(GLOBAL_robotRoute[i]));
                    }
                }
                else
                {
                    statusBar.AppendText("● Отсутствует соединение с каким либо портом \n");
                }
            }
            catch
            {
                statusBar.AppendText("● Отсутствует соединение с каким либо портом \n");
            }           
        }

        /* Начать путь */
        private void buttonStartWay_Click(object sender, EventArgs e)
        {
            AStar.robotGo = true;
            SerialPort.Write("G");
            buttonSendWayRobot.Image = Properties.Resources.LoadInRobotLock;
            buttonSendWayRobot.Enabled = false;

            buttonMapSelection2.Image = Properties.Resources.choicesLock;
            buttonMapSelection2.Enabled = false;

            buttonGetDirections.Image = Properties.Resources.destinationLock;
            buttonGetDirections.Enabled = false;

            buttonStop.Image = Properties.Resources.stop;
            buttonStop.Enabled = true;

            buttonStartWay.Enabled = false;
            buttonStartWay.Image = Properties.Resources.startWayLock;

            timer1.Enabled = true;
        }
     
        /* Таймер. Движение робота по карте */
        private void timer1_Tick(object sender, EventArgs e)
        {
            MapEdit M = new MapEdit();
            for (int i = 0; i < 1; i++)
            {

                if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 4)
                {
                    if (GLOBAL_initialPositionRobot_timer == 2)
                    {
                        GLOBAL_initialPositionRobot_timer = 4;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 4)
                    {
                        GLOBAL_initialPositionRobot_timer = 8;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 6)
                    {
                        GLOBAL_initialPositionRobot_timer = 2;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 8)
                    {
                        GLOBAL_initialPositionRobot_timer = 6;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                        break;
                    }
                }

                if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 6)
                {
                    if (GLOBAL_initialPositionRobot_timer == 2)
                    {
                        GLOBAL_initialPositionRobot_timer = 6;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 4)
                    {
                        GLOBAL_initialPositionRobot_timer = 2;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 6)
                    {
                        GLOBAL_initialPositionRobot_timer = 8;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                        break;
                    }
                    if (GLOBAL_initialPositionRobot_timer == 8)
                    {
                        GLOBAL_initialPositionRobot_timer = 4;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                        break;
                    }
                }
                if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 0)
                {
                    if (GLOBAL_initialPositionRobot_timer == 2)
                    {
                        GLOBAL_initialPositionRobot_timer = 8;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 4)
                    {
                        GLOBAL_initialPositionRobot_timer = 6;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 6)
                    {
                        GLOBAL_initialPositionRobot_timer = 4;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 8)
                    {
                        GLOBAL_initialPositionRobot_timer = 2;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                        break;
                    }
                }
            }

            if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 2)
            {
                if (GLOBAL_initialPositionRobot_timer == 2)
                {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_Y_timer--;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                }

                if (GLOBAL_initialPositionRobot_timer == 4)
                {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_X_timer--;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                }

                if (GLOBAL_initialPositionRobot_timer == 6)
                {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_X_timer++;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                }

                if (GLOBAL_initialPositionRobot_timer == 8)
                {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = M.DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_Y_timer++;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                }

                dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.Orange;
            }
            GLOBAL_buf_timerPlus++;
            if (GLOBAL_buf_timerPlus >= GLOBAL_robotRoute.Count)
            {
                timer1.Enabled = false;
                MessageBox.Show("Робот успешно закончил маршрут");
                dataGridView1.Rows[GLOBAL_Y_finish_stop].Cells[GLOBAL_X_finish_stop].Value = M.DeleteFinish(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_finish_stop].Cells[GLOBAL_X_finish_stop].Value));
                MapEdit.installRobot = true;
                MapEdit.installFinish = false;
                imageButtonRobotFinish();
                buttonMapSelection2_Click(sender, e);
                buttonMapEdit_Click(sender, e);



            }

        }//timer1_Tick

        /* Разорвать все активные соединения */
        private void buttonBreakConnection_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort.Close();
                statusBar.AppendText("● Закрыто соединение с " + SerialPort.PortName + " \n");
            }
            catch
            {

                statusBar.AppendText("● Отсутствует соединение с каким либо портом \n");
            }
        }

        /*Кнопка перехода на панель выбора карт с панели panelUploadRobot*/
        private void buttonMapSelection2_Click(object sender, EventArgs e)
        {
            AStar.robotGo = false;
            buttonSendWayRobot.Image = Properties.Resources.LoadInRobotLock;
            buttonSendWayRobot.Enabled = false;

            buttonMapSelection2.Image = Properties.Resources.choices;
            buttonMapSelection2.Enabled = true;

            buttonGetDirections.Image = Properties.Resources.destination;
            buttonGetDirections.Enabled = true;

            buttonStop.Image = Properties.Resources.stopLock;
            buttonStop.Enabled = false;

            buttonStartWay.Image = Properties.Resources.startWayLock;
            buttonStartWay.Enabled = false;
            panelUploadRobot.Visible = false;
            panelMapSelection.Visible = true;

            WayColorClear();
        }

        /* Остановка выполнения маршрута */
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            AStar.robotGo = false;
            buttonSendWayRobot.Image = Properties.Resources.LoadInRobotLock;
            buttonSendWayRobot.Enabled = false;

            buttonMapSelection2.Image = Properties.Resources.choices;
            buttonMapSelection2.Enabled = true;

            buttonGetDirections.Image = Properties.Resources.destination;
            buttonGetDirections.Enabled = true;

            buttonStop.Image = Properties.Resources.stopLock;
            buttonStop.Enabled = false;

            buttonStartWay.Image = Properties.Resources.startWayLock;
            buttonStartWay.Enabled = false;
        }

        /* переход на панелт загрузки карты в робота */
        private void buttonLoadMapIntoRobot_Click(object sender, EventArgs e)
        {
            panelUploadRobot.Visible = true;
            panelMapSelection.Visible = false;
        }

        /* Открыть окно настроек */
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = true;
            trackBarTransparency.Value = Properties.Settings.Default.Transparency;
            labelTransparency.Text = "Прозрачность: " + trackBarTransparency.Value;
        }

        /* Закрыть окно настроек */
        private void buttonSettingsClose_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            Properties.Settings.Default.Reload();
            SetColorButton(this.Controls);
            textBoxConnectingDatabase.Text= Properties.Settings.Default.connectionDatabase;
            DataBase.connectionString = Properties.Settings.Default.connectionDatabase;
        }

        /* Определяет цвет кнопки */
        private void buttonSetColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Properties.Settings.Default.ButtonColor = colorDialog1.Color;
            SetColorButton(this.Controls);
        }

        /* Ползунок прозрачности */
        private void trackBarTransparency_Scroll(object sender, EventArgs e)
        {
            labelTransparency.Text = "Прозрачность: " + trackBarTransparency.Value;
            Properties.Settings.Default.Transparency = trackBarTransparency.Value;
            SetColorButton(this.Controls);
        }

        /* Определяет цвет ВСЕХ кнопок */
        private void SetColorButton(Control.ControlCollection control)
        {
            foreach (Control _control in control)
            {
                if (_control is Button & String.IsNullOrEmpty(_control.Text))
                {
                    ((Button)_control).BackColor = Color.FromArgb(Properties.Settings.Default.Transparency, Properties.Settings.Default.ButtonColor); // цвет кнопки                 
                }
                if (_control.Controls.Count > 0)
                {
                    SetNullInTextBox(_control.Controls);
                }
            }
        }

        /*Сохранить настройки*/
        private void buttonSettingsSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.connectionDatabase= textBoxConnectingDatabase.Text;
            Properties.Settings.Default.Save();
            statusBar.SelectionColor = Color.Green;
            statusBar.AppendText("● Настройки сохранены \n");
        }

        /* Проверка подключения к БД */
        private void buttonCheckConnection_Click(object sender, EventArgs e)
        {

            if (DataBase.checkСonnection(textBoxConnectingDatabase.Text) == true)
            {
                statusBar.SelectionColor = Color.Green;
                statusBar.AppendText("● Подключение к БД корректно \n");
            }
            else
            {
                statusBar.SelectionColor = Color.Red;
                statusBar.AppendText("● Не удалось выполнить подключение к БД \n");

            }
        }
    }//form
}//namespace
