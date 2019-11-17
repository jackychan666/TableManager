namespace TableManager
{
    partial class Win_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CB_ChooseTab = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_beginTime = new System.Windows.Forms.DateTimePicker();
            this.DTP_endTime = new System.Windows.Forms.DateTimePicker();
            this.L_timeBegin = new System.Windows.Forms.Label();
            this.L_timeEnd = new System.Windows.Forms.Label();
            this.B_Confirm = new System.Windows.Forms.Button();
            this.B_Exit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.B_ViewData = new System.Windows.Forms.Button();
            this.B_DeletSql = new System.Windows.Forms.Button();
            this.TB_equipName = new System.Windows.Forms.TextBox();
            this.L_equipName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_ChooseTab
            // 
            this.CB_ChooseTab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ChooseTab.FormattingEnabled = true;
            this.CB_ChooseTab.Items.AddRange(new object[] {
            "模式接收记录",
            "模式运行记录",
            "报警记录",
            "模拟量历史记录",
            "用户操作记录",
            "设备动作记录"});
            this.CB_ChooseTab.Location = new System.Drawing.Point(165, 14);
            this.CB_ChooseTab.Name = "CB_ChooseTab";
            this.CB_ChooseTab.Size = new System.Drawing.Size(121, 20);
            this.CB_ChooseTab.TabIndex = 0;
            this.CB_ChooseTab.SelectedIndexChanged += new System.EventHandler(this.Choose_mod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择维修记录表";
            // 
            // DTP_beginTime
            // 
            this.DTP_beginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DTP_beginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_beginTime.Location = new System.Drawing.Point(165, 86);
            this.DTP_beginTime.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.DTP_beginTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DTP_beginTime.Name = "DTP_beginTime";
            this.DTP_beginTime.Size = new System.Drawing.Size(200, 21);
            this.DTP_beginTime.TabIndex = 2;
            // 
            // DTP_endTime
            // 
            this.DTP_endTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DTP_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_endTime.Location = new System.Drawing.Point(165, 123);
            this.DTP_endTime.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.DTP_endTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DTP_endTime.Name = "DTP_endTime";
            this.DTP_endTime.Size = new System.Drawing.Size(200, 21);
            this.DTP_endTime.TabIndex = 3;
            // 
            // L_timeBegin
            // 
            this.L_timeBegin.AutoSize = true;
            this.L_timeBegin.Location = new System.Drawing.Point(67, 94);
            this.L_timeBegin.Name = "L_timeBegin";
            this.L_timeBegin.Size = new System.Drawing.Size(89, 12);
            this.L_timeBegin.TabIndex = 4;
            this.L_timeBegin.Text = "记录表开始时间";
            // 
            // L_timeEnd
            // 
            this.L_timeEnd.AutoSize = true;
            this.L_timeEnd.Location = new System.Drawing.Point(67, 127);
            this.L_timeEnd.Name = "L_timeEnd";
            this.L_timeEnd.Size = new System.Drawing.Size(89, 12);
            this.L_timeEnd.TabIndex = 5;
            this.L_timeEnd.Text = "记录表结束时间";
            // 
            // B_Confirm
            // 
            this.B_Confirm.Location = new System.Drawing.Point(174, 457);
            this.B_Confirm.Name = "B_Confirm";
            this.B_Confirm.Size = new System.Drawing.Size(75, 23);
            this.B_Confirm.TabIndex = 6;
            this.B_Confirm.Text = "导出";
            this.B_Confirm.UseVisualStyleBackColor = true;
            this.B_Confirm.Click += new System.EventHandler(this.B_Confirm_Click);
            // 
            // B_Exit
            // 
            this.B_Exit.Location = new System.Drawing.Point(290, 457);
            this.B_Exit.Name = "B_Exit";
            this.B_Exit.Size = new System.Drawing.Size(75, 23);
            this.B_Exit.TabIndex = 7;
            this.B_Exit.Text = "退出";
            this.B_Exit.UseVisualStyleBackColor = true;
            this.B_Exit.Click += new System.EventHandler(this.B_Exit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(396, 222);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.TabStop = false;
            // 
            // B_ViewData
            // 
            this.B_ViewData.Location = new System.Drawing.Point(53, 165);
            this.B_ViewData.Name = "B_ViewData";
            this.B_ViewData.Size = new System.Drawing.Size(327, 23);
            this.B_ViewData.TabIndex = 9;
            this.B_ViewData.Text = "预览数据";
            this.B_ViewData.UseVisualStyleBackColor = true;
            this.B_ViewData.Click += new System.EventHandler(this.B_ViewData_Click);
            // 
            // B_DeletSql
            // 
            this.B_DeletSql.Location = new System.Drawing.Point(53, 457);
            this.B_DeletSql.Name = "B_DeletSql";
            this.B_DeletSql.Size = new System.Drawing.Size(75, 23);
            this.B_DeletSql.TabIndex = 10;
            this.B_DeletSql.Text = "收缩";
            this.B_DeletSql.UseVisualStyleBackColor = true;
            this.B_DeletSql.Click += new System.EventHandler(this.B_DeletSql_Click);
            // 
            // TB_equipName
            // 
            this.TB_equipName.Location = new System.Drawing.Point(165, 53);
            this.TB_equipName.Name = "TB_equipName";
            this.TB_equipName.Size = new System.Drawing.Size(100, 21);
            this.TB_equipName.TabIndex = 11;
            // 
            // L_equipName
            // 
            this.L_equipName.AutoSize = true;
            this.L_equipName.Location = new System.Drawing.Point(101, 62);
            this.L_equipName.Name = "L_equipName";
            this.L_equipName.Size = new System.Drawing.Size(53, 12);
            this.L_equipName.TabIndex = 12;
            this.L_equipName.Text = "设备名称";
            // 
            // Win_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 509);
            this.Controls.Add(this.L_equipName);
            this.Controls.Add(this.TB_equipName);
            this.Controls.Add(this.B_DeletSql);
            this.Controls.Add(this.B_ViewData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.B_Exit);
            this.Controls.Add(this.B_Confirm);
            this.Controls.Add(this.L_timeEnd);
            this.Controls.Add(this.L_timeBegin);
            this.Controls.Add(this.DTP_endTime);
            this.Controls.Add(this.DTP_beginTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_ChooseTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Win_Main";
            this.Text = "报表管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_ChooseTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTP_beginTime;
        private System.Windows.Forms.DateTimePicker DTP_endTime;
        private System.Windows.Forms.Label L_timeBegin;
        private System.Windows.Forms.Label L_timeEnd;
        private System.Windows.Forms.Button B_Confirm;
        private System.Windows.Forms.Button B_Exit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button B_ViewData;
        private System.Windows.Forms.Button B_DeletSql;
        private System.Windows.Forms.TextBox TB_equipName;
        private System.Windows.Forms.Label L_equipName;
    }
}

