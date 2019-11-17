using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.Office.Core;
using System.IO;
using Microsoft.Office.Interop;
using System.Runtime.InteropServices;



namespace TableManager
{
    public partial class Win_Main : Form
    {
        public string table;//记录用户所选报表
        public string logtimeName;//报表中的时间名称
        public string equipName;

        public string Get_Config()
        {
            StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory()+"/config.txt");
            string line;
            line = sr.ReadLine();
            //构建数据库连接字符串
            string source = "server=(local);" +
                     "integrated security=SSPI;" +
                     "database="+line;
            sr.Close();
            return source;
        }

        public Win_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
       {
           CB_ChooseTab.Text = CB_ChooseTab.Items[0].ToString();
        }

        private void Choose_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] items=new string[6];//combobox选项
            string[] tablesName = new string[6];//对应选项报表在数据库中的名称
            string[] tablesTimeName = new string[6];//对应选项报表时间列名称
            items[0] = "模式接收记录";
            items[1] = "模式运行记录";
            items[2] = "报警记录";
            items[3] = "模拟量历史记录";
            items[4] = "用户操作记录";
            items[5] = "设备动作记录";
            //items[5] = "参数设置记录";

            tablesName[0] = "modereceive";
            tablesName[1] = "moderun";
            tablesName[2] = "ALARMS";
            tablesName[3] = "HJCS";
            tablesName[4] = "OPERLOG";
            tablesName[5] = "equipmentrun";
            //tablesName[5] = "parasetclass";

            tablesTimeName[0] = "LOGTIME";
            tablesTimeName[1] = "LOGTIME";
            tablesTimeName[2] = "itime";
            tablesTimeName[3] = "TIMESTAMP";
            tablesTimeName[4] = "TMSTAMP";
            tablesTimeName[5] = "LOGTIME";
            //tablesTimeName[5] = "";
 
            Dictionary<string, string> tablePro = new Dictionary<string, string>();
            tablePro.Add(tablesName[0], tablesTimeName[0]);
            tablePro.Add(tablesName[1], tablesTimeName[1]);
            tablePro.Add(tablesName[2], tablesTimeName[2]);
            tablePro.Add(tablesName[3], tablesTimeName[3]);
            tablePro.Add(tablesName[4], tablesTimeName[4]);
            tablePro.Add(tablesName[5], tablesTimeName[5]);


            
            //用户选择不同报表
            //模式接收记录modereceive
            if (CB_ChooseTab.Text == items[0])
            {
                table = tablesName[0];
                logtimeName = tablePro[tablesName[0]];
                TB_equipName.Enabled = false;
            }
            //模式运行记录moderun
            if (CB_ChooseTab.Text == items[1])
            {
                table = tablesName[1];
                logtimeName = tablePro[tablesName[1]];
                TB_equipName.Enabled = false;
            }
            //报警记录ALARMS
            if (CB_ChooseTab.Text == items[2])
            {
                table = tablesName[2];
                logtimeName = tablePro[tablesName[2]];
                TB_equipName.Enabled = false;
                //equipName = "name";
            }
            //模拟量历史记录HJCS
            if (CB_ChooseTab.Text == items[3])
            {
                table = tablesName[3];
                logtimeName = tablePro[tablesName[3]];
                TB_equipName.Enabled = true;
                //equipName = "devicename";
                //DTP_beginTime.Enabled = false;
                //DTP_endTime.Enabled = false;

            }
            //用户操作记录OPERLOG
            if (CB_ChooseTab.Text == items[4])
            {
                table = tablesName[4];
                logtimeName = tablePro[tablesName[4]];
                TB_equipName.Enabled = false;
            }
            //设备运行记录equipmentrun
            if (CB_ChooseTab.Text == items[5])
            {
                table = tablesName[5];
                logtimeName = tablePro[tablesName[5]];
                TB_equipName.Enabled = true;
            }
 
        }

        public void printAll(DataTable dt)
        {
            if (dt != null)
            {
                try
                {
                    //保存文件
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
                    saveFileDialog.FilterIndex = 0;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.CreatePrompt = false;
                    saveFileDialog.Title = "导出文件保存路径";
                    saveFileDialog.ShowDialog();
                    string strName = saveFileDialog.FileName;
                    if (strName.Length != 0)
                    {
                        System.Reflection.Missing miss = System.Reflection.Missing.Value;
                        //实例化一个excel对象
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Application.Workbooks.Add(true);
                        excel.Visible = false;
                        if (excel == null)
                        {
                            MessageBox.Show("Excel无法启动!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                        Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                        Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                        sheet.Name = "sheet1";
                        //int m = 0, n = 0;

                        //生成表头
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                        }
                        //写入数据
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    string str = dt.Rows[i][j].ToString();
                                    excel.Cells[i + 2, j + 1] = str;
                                }
                            }

                        }
                        sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                        book.Close(false, miss, miss);
                        books.Close();
                        excel.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                        GC.Collect();
                        MessageBox.Show("数据已成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(strName);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示");
                }

            }
            
        }

        private DataTable GetDataTableFromSqlServer()
        {
            DateTime beginTime;// 开始时间
            DateTime endTime;//结束时间
            string select;

            beginTime = DTP_beginTime.Value;
            endTime = DTP_endTime.Value;
            equipName = TB_equipName.Text;
            //构建sql筛选语句
            if (CB_ChooseTab.Text == "设备动作记录")
            {
                if (TB_equipName.Text == "")
                {
                    select = "SELECT * FROM " +
                table +
                " WHERE " +
                logtimeName + " BETWEEN" +
                "'" + beginTime.ToString() + "'" +
                "AND" +
                "'" + endTime.ToString() + "'";
                }
                else
                {
                    select = "SELECT * FROM " +
                table +
                " WHERE TAGNAME LIKE " +
                "'%" + equipName + "%'" +
                " AND " +
                logtimeName + " BETWEEN" +
                "'" + beginTime.ToString() + "'" +
                "AND" +
                "'" + endTime.ToString() + "'";
                }

     
            }
            if (CB_ChooseTab.Text == "模拟量历史记录")
            {
                if (TB_equipName.Text == "")
                {
                    select = "SELECT * FROM " +
                table +
                " WHERE " +
                logtimeName + " BETWEEN" +
                "'" + beginTime.ToString() + "'" +
                "AND" +
                "'" + endTime.ToString() + "'";
                }
                else
                {
                    
                    string select1 = "SELECT NAME FROM syscolumns where id=object_id('HJCS')";//获取全部列名
                    //创建一个列名为内容的DataTable
                    SqlConnection newConn = new SqlConnection(Get_Config());
                    newConn.Open();
                    SqlCommand getColumnCmd = new SqlCommand(select1, newConn);
                    SqlDataAdapter getColumnDa = new SqlDataAdapter(getColumnCmd);
                    DataTable columnsDt = new DataTable();
                    getColumnDa.Fill(columnsDt);
                    newConn.Close();



                    
                    DataRow[] drs = columnsDt.Select("name like " + "'" + equipName + "%'");//筛选

                    //将筛选出来的内容转化为string
                    string[] sendto = new string[drs.Length];
                    string columnName = "";
                    int drRow=0;
                    foreach (DataRow dra in drs)
                    {
                        sendto[drRow] = dra["name"].ToString();
                        drRow++;
                    }
                    
                    for (int i = 0; i < sendto.Length; i++)
                    {
                        columnName =columnName+ "," + sendto[i] ;
                    }

                    //构造用于操作数据库的命令字符串
                    select = "SELECT " + "FLTIME,TIMESTAMP" + columnName + " FROM HJCS"
                             +
                             " WHERE " +
                             logtimeName + " BETWEEN" +
                             "'" + beginTime.ToString() + "'" +
                             "AND" +
                             "'" + endTime.ToString() + "'";
 
                }

                

                
                

            }
            else
            {
                select = "SELECT * FROM " +
                table +
                " WHERE " +
                logtimeName + " BETWEEN" +
                "'" + beginTime.ToString() + "'" +
                "AND" +
                "'" + endTime.ToString() + "'";
            }
            
            try
            {
                SqlConnection conn = new SqlConnection(Get_Config());
                conn.Open();
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
                return null; 
            }
        }




        private void B_Confirm_Click(object sender, EventArgs e)
        {
            if (DTP_beginTime.Value > DTP_endTime.Value)
            {
                MessageBox.Show("起始日期大于结束日期!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printAll(GetDataTableFromSqlServer());
            }
            //printAll(GetDataTableFromSqlServer());

        }
                    

        private void B_Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void B_ViewData_Click(object sender, EventArgs e)
        {
            if (DTP_beginTime.Value > DTP_endTime.Value)
            {
                MessageBox.Show("起始日期大于结束日期!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = GetDataTableFromSqlServer();
            }
            //dataGridView1.DataSource = GetDataTableFromSqlServer();

        }

        private void B_DeletSql_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定收缩所选报表吗?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string delete = "DELETE FROM " +
                                    table +
                                    " WHERE " + logtimeName + " <" +
                                    "'" + DateTime.Now.AddDays(-180).ToString() + "'";
                    SqlConnection conn = new SqlConnection(Get_Config());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(delete, conn); 
                    int i=cmd.ExecuteNonQuery();
                    MessageBox.Show("成功删除" + i + "行数据", "提示", MessageBoxButtons.OK);
                    conn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示");
                }
            }
            

        }

     

    }
}
