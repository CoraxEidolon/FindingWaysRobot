﻿namespace FindingWaysRobot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelCreateEditMap = new System.Windows.Forms.Panel();
            this.labelPatencyWall = new System.Windows.Forms.Label();
            this.labelPatencyBad = new System.Windows.Forms.Label();
            this.labelPatency = new System.Windows.Forms.Label();
            this.labelWall = new System.Windows.Forms.Label();
            this.labelPatency3 = new System.Windows.Forms.Label();
            this.labelPatencyMedium = new System.Windows.Forms.Label();
            this.labelMapName = new System.Windows.Forms.Label();
            this.labelPatencyGood = new System.Windows.Forms.Label();
            this.labelPatency2 = new System.Windows.Forms.Label();
            this.labelRobotPosition = new System.Windows.Forms.Label();
            this.labelPatency1 = new System.Windows.Forms.Label();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.RobotPosition = new System.Windows.Forms.ComboBox();
            this.buttonSetRemoveFinish = new System.Windows.Forms.Button();
            this.buttonInstallOrRemoveRobot = new System.Windows.Forms.Button();
            this.buttonMapSelection = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.LabelLines = new System.Windows.Forms.Label();
            this.LabelСolumns = new System.Windows.Forms.Label();
            this.numberOfLines = new System.Windows.Forms.NumericUpDown();
            this.numberOfСolumns = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonGetDirections = new System.Windows.Forms.Button();
            this.buttonLoadMapIntoRobot = new System.Windows.Forms.Button();
            this.buttonDeleteMap = new System.Windows.Forms.Button();
            this.buttonMapEdit = new System.Windows.Forms.Button();
            this.buttonCreateMap = new System.Windows.Forms.Button();
            this.buttonComPortRefresh = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSendWayRobot = new System.Windows.Forms.Button();
            this.buttonStartWay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonMapSelection2 = new System.Windows.Forms.Button();
            this.panelMapSelection = new System.Windows.Forms.Panel();
            this.labelMapSelect = new System.Windows.Forms.Label();
            this.SelectTable = new System.Windows.Forms.ComboBox();
            this.statusBar = new System.Windows.Forms.RichTextBox();
            this.panelUploadRobot = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ComPortNumber = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCreateEditMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfСolumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMapSelection.SuspendLayout();
            this.panelUploadRobot.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCreateEditMap
            // 
            this.panelCreateEditMap.Controls.Add(this.labelPatencyWall);
            this.panelCreateEditMap.Controls.Add(this.labelPatencyBad);
            this.panelCreateEditMap.Controls.Add(this.labelPatency);
            this.panelCreateEditMap.Controls.Add(this.labelWall);
            this.panelCreateEditMap.Controls.Add(this.labelPatency3);
            this.panelCreateEditMap.Controls.Add(this.labelPatencyMedium);
            this.panelCreateEditMap.Controls.Add(this.labelMapName);
            this.panelCreateEditMap.Controls.Add(this.labelPatencyGood);
            this.panelCreateEditMap.Controls.Add(this.labelPatency2);
            this.panelCreateEditMap.Controls.Add(this.labelRobotPosition);
            this.panelCreateEditMap.Controls.Add(this.labelPatency1);
            this.panelCreateEditMap.Controls.Add(this.textBoxMapName);
            this.panelCreateEditMap.Controls.Add(this.RobotPosition);
            this.panelCreateEditMap.Controls.Add(this.buttonSetRemoveFinish);
            this.panelCreateEditMap.Controls.Add(this.buttonInstallOrRemoveRobot);
            this.panelCreateEditMap.Controls.Add(this.buttonMapSelection);
            this.panelCreateEditMap.Controls.Add(this.buttonSave);
            this.panelCreateEditMap.Controls.Add(this.LabelLines);
            this.panelCreateEditMap.Controls.Add(this.LabelСolumns);
            this.panelCreateEditMap.Controls.Add(this.numberOfLines);
            this.panelCreateEditMap.Controls.Add(this.numberOfСolumns);
            this.panelCreateEditMap.Location = new System.Drawing.Point(10, 10);
            this.panelCreateEditMap.Name = "panelCreateEditMap";
            this.panelCreateEditMap.Size = new System.Drawing.Size(941, 88);
            this.panelCreateEditMap.TabIndex = 0;
            this.panelCreateEditMap.Visible = false;
            // 
            // labelPatencyWall
            // 
            this.labelPatencyWall.AutoSize = true;
            this.labelPatencyWall.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.labelPatencyWall.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPatencyWall.Location = new System.Drawing.Point(852, 71);
            this.labelPatencyWall.Name = "labelPatencyWall";
            this.labelPatencyWall.Size = new System.Drawing.Size(39, 15);
            this.labelPatencyWall.TabIndex = 3;
            this.labelPatencyWall.Text = "Стена";
            // 
            // labelPatencyBad
            // 
            this.labelPatencyBad.AutoSize = true;
            this.labelPatencyBad.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatencyBad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPatencyBad.Location = new System.Drawing.Point(852, 52);
            this.labelPatencyBad.Name = "labelPatencyBad";
            this.labelPatencyBad.Size = new System.Drawing.Size(46, 15);
            this.labelPatencyBad.TabIndex = 5;
            this.labelPatencyBad.Text = "Плохая";
            // 
            // labelPatency
            // 
            this.labelPatency.AutoSize = true;
            this.labelPatency.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatency.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPatency.Location = new System.Drawing.Point(819, -3);
            this.labelPatency.Margin = new System.Windows.Forms.Padding(0);
            this.labelPatency.Name = "labelPatency";
            this.labelPatency.Size = new System.Drawing.Size(91, 15);
            this.labelPatency.TabIndex = 2;
            this.labelPatency.Text = "Проходимость:";
            // 
            // labelWall
            // 
            this.labelWall.AutoSize = true;
            this.labelWall.BackColor = System.Drawing.Color.Black;
            this.labelWall.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWall.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWall.Location = new System.Drawing.Point(838, 71);
            this.labelWall.Name = "labelWall";
            this.labelWall.Size = new System.Drawing.Size(16, 15);
            this.labelWall.TabIndex = 2;
            this.labelWall.Text = "w";
            // 
            // labelPatency3
            // 
            this.labelPatency3.AutoSize = true;
            this.labelPatency3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelPatency3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatency3.Location = new System.Drawing.Point(838, 52);
            this.labelPatency3.Name = "labelPatency3";
            this.labelPatency3.Size = new System.Drawing.Size(13, 15);
            this.labelPatency3.TabIndex = 6;
            this.labelPatency3.Text = "3";
            // 
            // labelPatencyMedium
            // 
            this.labelPatencyMedium.AutoSize = true;
            this.labelPatencyMedium.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatencyMedium.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPatencyMedium.Location = new System.Drawing.Point(852, 32);
            this.labelPatencyMedium.Name = "labelPatencyMedium";
            this.labelPatencyMedium.Size = new System.Drawing.Size(53, 15);
            this.labelPatencyMedium.TabIndex = 4;
            this.labelPatencyMedium.Text = "Средняя";
            // 
            // labelMapName
            // 
            this.labelMapName.AutoSize = true;
            this.labelMapName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMapName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMapName.Location = new System.Drawing.Point(192, 50);
            this.labelMapName.Name = "labelMapName";
            this.labelMapName.Size = new System.Drawing.Size(112, 17);
            this.labelMapName.TabIndex = 11;
            this.labelMapName.Text = "Название карты:";
            // 
            // labelPatencyGood
            // 
            this.labelPatencyGood.AutoSize = true;
            this.labelPatencyGood.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatencyGood.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPatencyGood.Location = new System.Drawing.Point(852, 13);
            this.labelPatencyGood.Name = "labelPatencyGood";
            this.labelPatencyGood.Size = new System.Drawing.Size(58, 15);
            this.labelPatencyGood.TabIndex = 3;
            this.labelPatencyGood.Text = "Хорошая";
            // 
            // labelPatency2
            // 
            this.labelPatency2.AutoSize = true;
            this.labelPatency2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))));
            this.labelPatency2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatency2.Location = new System.Drawing.Point(838, 32);
            this.labelPatency2.Name = "labelPatency2";
            this.labelPatency2.Size = new System.Drawing.Size(13, 15);
            this.labelPatency2.TabIndex = 5;
            this.labelPatency2.Text = "2";
            // 
            // labelRobotPosition
            // 
            this.labelRobotPosition.AutoSize = true;
            this.labelRobotPosition.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRobotPosition.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelRobotPosition.Location = new System.Drawing.Point(176, 22);
            this.labelRobotPosition.Name = "labelRobotPosition";
            this.labelRobotPosition.Size = new System.Drawing.Size(128, 17);
            this.labelRobotPosition.TabIndex = 10;
            this.labelRobotPosition.Text = "Положение робота:";
            // 
            // labelPatency1
            // 
            this.labelPatency1.AutoSize = true;
            this.labelPatency1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelPatency1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatency1.Location = new System.Drawing.Point(838, 13);
            this.labelPatency1.Name = "labelPatency1";
            this.labelPatency1.Size = new System.Drawing.Size(13, 15);
            this.labelPatency1.TabIndex = 4;
            this.labelPatency1.Text = "1";
            // 
            // textBoxMapName
            // 
            this.textBoxMapName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMapName.Location = new System.Drawing.Point(310, 46);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(167, 22);
            this.textBoxMapName.TabIndex = 9;
            this.textBoxMapName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMapName_KeyPress);
            // 
            // RobotPosition
            // 
            this.RobotPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RobotPosition.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RobotPosition.FormattingEnabled = true;
            this.RobotPosition.Items.AddRange(new object[] {
            "▲",
            "►",
            "▼",
            "◄"});
            this.RobotPosition.Location = new System.Drawing.Point(310, 18);
            this.RobotPosition.MaxLength = 1;
            this.RobotPosition.Name = "RobotPosition";
            this.RobotPosition.Size = new System.Drawing.Size(42, 22);
            this.RobotPosition.TabIndex = 8;
            // 
            // buttonSetRemoveFinish
            // 
            this.buttonSetRemoveFinish.Image = global::FindingWaysRobot.Properties.Resources.finish;
            this.buttonSetRemoveFinish.Location = new System.Drawing.Point(498, 9);
            this.buttonSetRemoveFinish.Name = "buttonSetRemoveFinish";
            this.buttonSetRemoveFinish.Size = new System.Drawing.Size(65, 70);
            this.buttonSetRemoveFinish.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonSetRemoveFinish, "Установить/убрать финишную точку");
            this.buttonSetRemoveFinish.UseVisualStyleBackColor = true;
            this.buttonSetRemoveFinish.Click += new System.EventHandler(this.buttonSetRemoveFinish_Click);
            // 
            // buttonInstallOrRemoveRobot
            // 
            this.buttonInstallOrRemoveRobot.Image = global::FindingWaysRobot.Properties.Resources.robot;
            this.buttonInstallOrRemoveRobot.Location = new System.Drawing.Point(569, 9);
            this.buttonInstallOrRemoveRobot.Name = "buttonInstallOrRemoveRobot";
            this.buttonInstallOrRemoveRobot.Size = new System.Drawing.Size(65, 70);
            this.buttonInstallOrRemoveRobot.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonInstallOrRemoveRobot, "Установить/убрать робота с карты");
            this.buttonInstallOrRemoveRobot.UseVisualStyleBackColor = true;
            this.buttonInstallOrRemoveRobot.Click += new System.EventHandler(this.buttonInstallOrRemoveRobot_Click);
            // 
            // buttonMapSelection
            // 
            this.buttonMapSelection.Image = ((System.Drawing.Image)(resources.GetObject("buttonMapSelection.Image")));
            this.buttonMapSelection.Location = new System.Drawing.Point(711, 9);
            this.buttonMapSelection.Name = "buttonMapSelection";
            this.buttonMapSelection.Size = new System.Drawing.Size(65, 70);
            this.buttonMapSelection.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonMapSelection, "Перейти на панель выбора карт");
            this.buttonMapSelection.UseVisualStyleBackColor = true;
            this.buttonMapSelection.Click += new System.EventHandler(this.buttonMapSelection_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Location = new System.Drawing.Point(640, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(65, 70);
            this.buttonSave.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonSave, "Сохранить карту");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // LabelLines
            // 
            this.LabelLines.AutoSize = true;
            this.LabelLines.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelLines.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelLines.Location = new System.Drawing.Point(16, 22);
            this.LabelLines.Name = "LabelLines";
            this.LabelLines.Size = new System.Drawing.Size(49, 17);
            this.LabelLines.TabIndex = 3;
            this.LabelLines.Text = "Строк:";
            // 
            // LabelСolumns
            // 
            this.LabelСolumns.AutoSize = true;
            this.LabelСolumns.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelСolumns.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelСolumns.Location = new System.Drawing.Point(7, 46);
            this.LabelСolumns.Name = "LabelСolumns";
            this.LabelСolumns.Size = new System.Drawing.Size(71, 17);
            this.LabelСolumns.TabIndex = 2;
            this.LabelСolumns.Text = "Столбцов:";
            // 
            // numberOfLines
            // 
            this.numberOfLines.Location = new System.Drawing.Point(84, 18);
            this.numberOfLines.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfLines.Name = "numberOfLines";
            this.numberOfLines.ReadOnly = true;
            this.numberOfLines.Size = new System.Drawing.Size(72, 20);
            this.numberOfLines.TabIndex = 1;
            this.numberOfLines.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfLines.ValueChanged += new System.EventHandler(this.numberOfLines_ValueChanged);
            // 
            // numberOfСolumns
            // 
            this.numberOfСolumns.Location = new System.Drawing.Point(84, 46);
            this.numberOfСolumns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfСolumns.Name = "numberOfСolumns";
            this.numberOfСolumns.ReadOnly = true;
            this.numberOfСolumns.Size = new System.Drawing.Size(72, 20);
            this.numberOfСolumns.TabIndex = 0;
            this.numberOfСolumns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfСolumns.ValueChanged += new System.EventHandler(this.numberOfСolumns_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(256, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 5;
            this.dataGridView1.Size = new System.Drawing.Size(52, 53);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // buttonGetDirections
            // 
            this.buttonGetDirections.Image = global::FindingWaysRobot.Properties.Resources.destination;
            this.buttonGetDirections.Location = new System.Drawing.Point(210, 15);
            this.buttonGetDirections.Name = "buttonGetDirections";
            this.buttonGetDirections.Size = new System.Drawing.Size(65, 70);
            this.buttonGetDirections.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonGetDirections, "Проложить маршрут");
            this.buttonGetDirections.UseVisualStyleBackColor = true;
            this.buttonGetDirections.Click += new System.EventHandler(this.buttonGetDirections_Click);
            // 
            // buttonLoadMapIntoRobot
            // 
            this.buttonLoadMapIntoRobot.Image = global::FindingWaysRobot.Properties.Resources.robotConnect;
            this.buttonLoadMapIntoRobot.Location = new System.Drawing.Point(408, 9);
            this.buttonLoadMapIntoRobot.Name = "buttonLoadMapIntoRobot";
            this.buttonLoadMapIntoRobot.Size = new System.Drawing.Size(65, 70);
            this.buttonLoadMapIntoRobot.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonLoadMapIntoRobot, "Перейти к загрузке карты в робота");
            this.buttonLoadMapIntoRobot.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMap
            // 
            this.buttonDeleteMap.Image = global::FindingWaysRobot.Properties.Resources.delete;
            this.buttonDeleteMap.Location = new System.Drawing.Point(337, 9);
            this.buttonDeleteMap.Name = "buttonDeleteMap";
            this.buttonDeleteMap.Size = new System.Drawing.Size(65, 70);
            this.buttonDeleteMap.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonDeleteMap, "Удалить карту");
            this.buttonDeleteMap.UseVisualStyleBackColor = true;
            this.buttonDeleteMap.Click += new System.EventHandler(this.buttonDeleteMap_Click);
            // 
            // buttonMapEdit
            // 
            this.buttonMapEdit.Image = global::FindingWaysRobot.Properties.Resources.edit;
            this.buttonMapEdit.Location = new System.Drawing.Point(195, 9);
            this.buttonMapEdit.Name = "buttonMapEdit";
            this.buttonMapEdit.Size = new System.Drawing.Size(65, 70);
            this.buttonMapEdit.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonMapEdit, "Редактировать карту");
            this.buttonMapEdit.UseVisualStyleBackColor = true;
            this.buttonMapEdit.Click += new System.EventHandler(this.buttonMapEdit_Click);
            // 
            // buttonCreateMap
            // 
            this.buttonCreateMap.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreateMap.Image")));
            this.buttonCreateMap.Location = new System.Drawing.Point(266, 9);
            this.buttonCreateMap.Name = "buttonCreateMap";
            this.buttonCreateMap.Size = new System.Drawing.Size(65, 70);
            this.buttonCreateMap.TabIndex = 3;
            this.toolTip1.SetToolTip(this.buttonCreateMap, "Создать новую карту");
            this.buttonCreateMap.UseVisualStyleBackColor = true;
            this.buttonCreateMap.Click += new System.EventHandler(this.buttonCreateMap_Click);
            // 
            // buttonComPortRefresh
            // 
            this.buttonComPortRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonComPortRefresh.Image")));
            this.buttonComPortRefresh.Location = new System.Drawing.Point(103, 38);
            this.buttonComPortRefresh.Name = "buttonComPortRefresh";
            this.buttonComPortRefresh.Size = new System.Drawing.Size(30, 30);
            this.buttonComPortRefresh.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonComPortRefresh, "Обновить");
            this.buttonComPortRefresh.UseVisualStyleBackColor = true;
            this.buttonComPortRefresh.Click += new System.EventHandler(this.buttonComPortRefresh_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonConnect.Image")));
            this.buttonConnect.Location = new System.Drawing.Point(139, 15);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(65, 70);
            this.buttonConnect.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonConnect, "Установить соединение");
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSendWayRobot
            // 
            this.buttonSendWayRobot.Image = ((System.Drawing.Image)(resources.GetObject("buttonSendWayRobot.Image")));
            this.buttonSendWayRobot.Location = new System.Drawing.Point(281, 15);
            this.buttonSendWayRobot.Name = "buttonSendWayRobot";
            this.buttonSendWayRobot.Size = new System.Drawing.Size(65, 70);
            this.buttonSendWayRobot.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonSendWayRobot, "Отправить маршрут роботу");
            this.buttonSendWayRobot.UseVisualStyleBackColor = true;
            this.buttonSendWayRobot.Click += new System.EventHandler(this.buttonSendWayRobot_Click);
            // 
            // buttonStartWay
            // 
            this.buttonStartWay.Image = ((System.Drawing.Image)(resources.GetObject("buttonStartWay.Image")));
            this.buttonStartWay.Location = new System.Drawing.Point(352, 15);
            this.buttonStartWay.Name = "buttonStartWay";
            this.buttonStartWay.Size = new System.Drawing.Size(65, 70);
            this.buttonStartWay.TabIndex = 10;
            this.toolTip1.SetToolTip(this.buttonStartWay, "Начать выполнение маршрута");
            this.buttonStartWay.UseVisualStyleBackColor = true;
            this.buttonStartWay.Click += new System.EventHandler(this.buttonStartWay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(423, 15);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(65, 70);
            this.buttonStop.TabIndex = 11;
            this.toolTip1.SetToolTip(this.buttonStop, "Остановить выполнение маршрута");
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonMapSelection2
            // 
            this.buttonMapSelection2.Image = ((System.Drawing.Image)(resources.GetObject("buttonMapSelection2.Image")));
            this.buttonMapSelection2.Location = new System.Drawing.Point(494, 15);
            this.buttonMapSelection2.Name = "buttonMapSelection2";
            this.buttonMapSelection2.Size = new System.Drawing.Size(65, 70);
            this.buttonMapSelection2.TabIndex = 12;
            this.toolTip1.SetToolTip(this.buttonMapSelection2, "Перейти на панель выбора карт");
            this.buttonMapSelection2.UseVisualStyleBackColor = true;
            // 
            // panelMapSelection
            // 
            this.panelMapSelection.Controls.Add(this.buttonLoadMapIntoRobot);
            this.panelMapSelection.Controls.Add(this.labelMapSelect);
            this.panelMapSelection.Controls.Add(this.SelectTable);
            this.panelMapSelection.Controls.Add(this.buttonDeleteMap);
            this.panelMapSelection.Controls.Add(this.buttonMapEdit);
            this.panelMapSelection.Controls.Add(this.buttonCreateMap);
            this.panelMapSelection.Location = new System.Drawing.Point(10, 10);
            this.panelMapSelection.Name = "panelMapSelection";
            this.panelMapSelection.Size = new System.Drawing.Size(492, 88);
            this.panelMapSelection.TabIndex = 2;
            // 
            // labelMapSelect
            // 
            this.labelMapSelect.AutoSize = true;
            this.labelMapSelect.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.labelMapSelect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMapSelect.Location = new System.Drawing.Point(7, 22);
            this.labelMapSelect.Name = "labelMapSelect";
            this.labelMapSelect.Size = new System.Drawing.Size(113, 17);
            this.labelMapSelect.TabIndex = 1;
            this.labelMapSelect.Text = "Выберете карту:";
            // 
            // SelectTable
            // 
            this.SelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectTable.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTable.FormattingEnabled = true;
            this.SelectTable.Location = new System.Drawing.Point(10, 42);
            this.SelectTable.Name = "SelectTable";
            this.SelectTable.Size = new System.Drawing.Size(167, 23);
            this.SelectTable.TabIndex = 0;
            this.SelectTable.SelectedIndexChanged += new System.EventHandler(this.SelectTable_SelectedIndexChanged);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusBar.Location = new System.Drawing.Point(12, 107);
            this.statusBar.Name = "statusBar";
            this.statusBar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.statusBar.Size = new System.Drawing.Size(238, 304);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "";
            // 
            // panelUploadRobot
            // 
            this.panelUploadRobot.Controls.Add(this.buttonMapSelection2);
            this.panelUploadRobot.Controls.Add(this.buttonStop);
            this.panelUploadRobot.Controls.Add(this.buttonStartWay);
            this.panelUploadRobot.Controls.Add(this.buttonSendWayRobot);
            this.panelUploadRobot.Controls.Add(this.buttonConnect);
            this.panelUploadRobot.Controls.Add(this.label1);
            this.panelUploadRobot.Controls.Add(this.buttonGetDirections);
            this.panelUploadRobot.Controls.Add(this.buttonComPortRefresh);
            this.panelUploadRobot.Controls.Add(this.ComPortNumber);
            this.panelUploadRobot.Location = new System.Drawing.Point(256, 389);
            this.panelUploadRobot.Name = "panelUploadRobot";
            this.panelUploadRobot.Size = new System.Drawing.Size(610, 88);
            this.panelUploadRobot.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Номер Com порта:";
            // 
            // ComPortNumber
            // 
            this.ComPortNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPortNumber.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ComPortNumber.FormattingEnabled = true;
            this.ComPortNumber.Location = new System.Drawing.Point(16, 42);
            this.ComPortNumber.Name = "ComPortNumber";
            this.ComPortNumber.Size = new System.Drawing.Size(87, 23);
            this.ComPortNumber.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1167, 506);
            this.Controls.Add(this.panelUploadRobot);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.panelMapSelection);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelCreateEditMap);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCreateEditMap.ResumeLayout(false);
            this.panelCreateEditMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfСolumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMapSelection.ResumeLayout(false);
            this.panelMapSelection.PerformLayout();
            this.panelUploadRobot.ResumeLayout(false);
            this.panelUploadRobot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCreateEditMap;
        private System.Windows.Forms.Label LabelLines;
        private System.Windows.Forms.Label LabelСolumns;
        private System.Windows.Forms.NumericUpDown numberOfСolumns;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonMapSelection;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSetRemoveFinish;
        private System.Windows.Forms.Button buttonInstallOrRemoveRobot;
        private System.Windows.Forms.ComboBox RobotPosition;
        private System.Windows.Forms.Label labelMapName;
        private System.Windows.Forms.Label labelRobotPosition;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.NumericUpDown numberOfLines;
        private System.Windows.Forms.Label labelPatency3;
        private System.Windows.Forms.Label labelPatency2;
        private System.Windows.Forms.Label labelPatency1;
        private System.Windows.Forms.Label labelPatency;
        private System.Windows.Forms.Label labelPatencyGood;
        private System.Windows.Forms.Label labelPatencyMedium;
        private System.Windows.Forms.Label labelPatencyBad;
        private System.Windows.Forms.Label labelPatencyWall;
        private System.Windows.Forms.Label labelWall;
        private System.Windows.Forms.Panel panelMapSelection;
        private System.Windows.Forms.ComboBox SelectTable;
        private System.Windows.Forms.Button buttonDeleteMap;
        private System.Windows.Forms.Button buttonCreateMap;
        private System.Windows.Forms.Button buttonMapEdit;
        private System.Windows.Forms.Label labelMapSelect;
        private System.Windows.Forms.Button buttonLoadMapIntoRobot;
        private System.Windows.Forms.Button buttonGetDirections;
        private System.Windows.Forms.RichTextBox statusBar;
        private System.Windows.Forms.Panel panelUploadRobot;
        private System.Windows.Forms.ComboBox ComPortNumber;
        private System.Windows.Forms.Button buttonComPortRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMapSelection2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStartWay;
        private System.Windows.Forms.Button buttonSendWayRobot;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Timer timer1;
    }
}
