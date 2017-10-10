using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DatabaseInfo;
using SierFormsControlLibrary;
using System.IO;
using System.Text.RegularExpressions;
using CommonHelper;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq.Expressions;
namespace AutoCodeTool
{
    public partial class FrmMain : SForm
    {
        public FrmMain()
        {
            InitializeComponent();
            this.cbxDataVersion.SelectedIndex = 3;

            txtassembly.Text = _confg.assemly;
            txtUsername.Text = _confg.username;
            txtPwd.Text = _confg.pwd;
            txtServerAddress.Text = _confg.Address;
            txtschema.Text = _confg.schema;
            txtnamespace.Text = _confg.@namespace;
            txtpath.Text = _confg.path;

            tbxServerAddress_TextChanged(null, null);

            this.cbxDatas.SelectedIndexChanged += cbxDatas_SelectedIndexChanged;
            this.cbxTables.SelectedIndexChanged += cbxTables_SelectedIndexChanged;
        }
        static Config _confg = (Config)(XmlSerializer.LoadFromXml(AppPath + "config.xml", typeof(Config)));
        public static readonly string AppPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        const string _connection = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";
        const string _testconn = "Data Source={0};Persist Security Info=True;User ID={1};Password={2}";
        static string connection = "";
        string Catalog = "";

        void cbxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxServerAddress_TextChanged(null, null);
            if (cbxTables.SelectedValue.GetType() != typeof(string))
            { return; }
            try
            {
                string tablename = cbxTables.SelectedValue.ToString();
                List<DbColumn> list = DbHelper.GetDbColumns(connection, Catalog, tablename, _confg.schema);

                string classname = tablename + "Entity";
                string _namespace = txtnamespace.Text.Trim() + "." + tablename;

                dataGridView1.DataSource = list;
                //var map = mappingcontrol.CreatehibernatemappingXML(list, tablename, _confg.schema, _namespace, _confg.assemly);
                //CommonHelper.XmlSerializer.SaveToXml("D:\\" + classname + ".xml", map, typeof(hibernatemapping), "hibernate-mapping");

                mappingentity mapent = CreateMap();
                //string entity = mappingcontrol.CreateEntity(list, tablename, _confg.schema, _namespace, _confg.assemly, mapent);
            }
            catch (Exception ex)
            {
            }

        }

        void Create(string connectionString, string database, List<string> tables)
        {
            foreach (var item in tables)
            {
                DataTable dt = DbHelper.GetDataTable(connection, "SELECT * FROM "+ _confg.schema + "."+ item);
                string d = GetDataTableColumns(dt);
                if (!Directory.Exists(_confg.path + "\\DataGridViewColumns" ))
                {
                    Directory.CreateDirectory(_confg.path + "\\DataGridViewColumns");
                }
                var fs = File.Create(_confg.path + "\\DataGridViewColumns\\" + item + ".txt");
                fs.Write(Encoding.UTF8.GetBytes(d), 0, Encoding.UTF8.GetBytes(d).Length);
                fs.Close();
            }
            mappingentity mapent;
            try
            {
                mapent = CreateMap();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #region 创建Broker
            if (checkcreateBroker.Checked)
            {
                string p = AppPath + @"BROKER.TEMPLATE";
                var broker = mappingcontrol.CreateBroker(tables, p);
                var b = File.Create(_confg.path + "\\" + "brokerLogic.cs");
                b.Write(Encoding.UTF8.GetBytes(broker), 0, Encoding.UTF8.GetBytes(broker).Length);
                b.Close();
                string brokernode = mappingcontrol.CreateBrokerNode(tables, AppPath + @"BROKERNODE.TEMPLATE");
                b = File.Create(_confg.path + "\\" + "brokerLogic.xml");
                b.Write(Encoding.UTF8.GetBytes(brokernode), 0, Encoding.UTF8.GetBytes(brokernode).Length);
                b.Close();
                string conf = mappingcontrol.CreateBrokerConfig(tables);
                b = File.Create(_confg.path + "\\" + "brokerconfig.xml");
                b.Write(Encoding.UTF8.GetBytes(conf), 0, Encoding.UTF8.GetBytes(conf).Length);
                b.Close();
            }
            #endregion 
            #region 创建xml配置文件
            string tpath = AppPath + @"MAPPING_XML_CONFIG.Template";
            var mapxml = mappingcontrol.CreateMapXML(tables, _confg.assemly, tpath);

            var tfs = File.Create(_confg.path + "\\" + "mapconfig.xml");
            tfs.Write(Encoding.UTF8.GetBytes(mapxml), 0, Encoding.UTF8.GetBytes(mapxml).Length);
            tfs.Close();
            #endregion
            foreach (var item in tables)
            {
                try
                {
                    #region MyRegion
                    List<DbColumn> list = DbHelper.GetDbColumns(connection, database, item, _confg.schema);
                    if (list == null || list.Count == 0)
                    {
                        MessageBox.Show("表格不包含任何列", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    #region 创建XML映射文件
                    if (checkMapXML.Checked)
                    {
                        var map = mappingcontrol.CreatehibernatemappingXML(list, item, _confg.schema, _confg.@namespace, _confg.assemly);
                        CommonHelper.XmlSerializer.SaveToXml(_confg.path + "\\" + item + ".hbm.xml", map, typeof(hibernatemapping), "hibernate-mapping");
                    }
                    #endregion

                    #region  创建实体
                    if (checkEntity.Checked)
                    {
                        string path = AppPath + @"SNTON_TEMPLATE.template";
                        string entity = mappingcontrol.CreateEntity(list, item, _confg.schema, _confg.@namespace, _confg.assemly, mapent, path);
                        if (!Directory.Exists(_confg.path + "\\" + item))
                        {
                            Directory.CreateDirectory(_confg.path + "\\" + item);
                        }
                        var fs = File.Create(_confg.path + "\\" + item + "Entity.cs");
                        fs.Write(Encoding.UTF8.GetBytes(entity), 0, Encoding.UTF8.GetBytes(entity).Length);
                        fs.Close();
                    }
                    #endregion

                    if (checkcreateBroker.Checked)
                    {
                        string broke = mappingcontrol.CreateBroke(item, AppPath + @"BROKE.TEMPLATE");
                        var fs   = File.Create(_confg.path + "\\" + item + ".cs");
                        fs.Write(Encoding.UTF8.GetBytes(broke), 0, Encoding.UTF8.GetBytes(broke).Length);
                        fs.Close();
                        string @interface = mappingcontrol.CreateBrokeInterface(item, AppPath + @"BROKERINTERFACE.TEMPLATE");
                        fs = File.Create(_confg.path + "\\I" + item + ".cs");
                        fs.Write(Encoding.UTF8.GetBytes(@interface), 0, Encoding.UTF8.GetBytes(@interface).Length);
                        fs.Close();
                    }

                    #endregion
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void cbxDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxServerAddress_TextChanged(null, null);
            string errinfo = "";
            string strsql = @"select * from [sysobjects] where [type] = 'u' order by [name]";
            database.ConnectionString = connection;
            DataTable dt = database.Query(strsql, out errinfo);
            this.cbxTables.DataSource = dt;
            //checkBoxComboBox1.DataSource = dt;
            this.cbxTables.ValueMember = "name";
            this.cbxTables.DisplayMember = "name";
            this.checkBoxComboBox1.Items.Clear();
            foreach (DataRow item in dt.Rows)
            {
                this.checkBoxComboBox1.Items.Add(item[0].ToString());
            }
            //this.checkBoxComboBox1.Items.Add("Tao");
            //this.checkBoxComboBox1.Items.Add("Json");
            //this.checkBoxComboBox1.Items.Add("Tom");
        }


        Database database;


        private void btnTestLogin_Click(object sender, EventArgs e)
        {
            string errinfo = "";
            string conn = string.Format(_testconn, txtServerAddress.Text.Trim(), txtUsername.Text.Trim(), txtPwd.Text.Trim());
            database = new DatabaseInfo.Database(conn, DatabaseInfo.DatabaseTypeID.SqlServer, DatabaseInfo.ConnectionTypeID.ShortConnection);

            DataTable dt = database.Query("select [name] from [sysdatabases] where name not in ('master','model','msdb','tempdb')  order by [name]", out errinfo);

            this.cbxDatas.DataSource = dt;
            this.cbxDatas.DisplayMember = "name";
            if (!string.IsNullOrEmpty(errinfo))
            {
                MessageBox.Show("登录失败", "提示");
            }

        }




        /// <summary>
        /// 初始化DataGridView
        /// </summary>
        /// <returns></returns>
        private string GetDataTableColumns(DataTable dt)
        {
            //List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            StringBuilder sb = new StringBuilder();
            StringBuilder sbcoms = new StringBuilder("            return new System.Windows.Forms.DataGridViewColumn[] {");
            sb.Append("       private DataGridViewColumn[] CreateColumns()\r\n        {");
            foreach (DataColumn c in dt.Columns)
            {
                string columnname = c.ColumnName;
                string s = Environment.NewLine + @"            DataGridViewColumn # = new System.Windows.Forms.DataGridViewTextBoxColumn();" + Environment.NewLine
                + "            #.DataPropertyName = \"" + "#" + "\";" + Environment.NewLine
                + "            #.HeaderText = \"" + "#" + "\";" + Environment.NewLine
                + "            #.MinimumWidth = 30;" + Environment.NewLine
                + "            #.Name = \"" + "#" + "\";" + Environment.NewLine
                + "            #.ReadOnly = true;" + Environment.NewLine
                + "            #.ToolTipText =  \"" + "#" + "\";" + Environment.NewLine
                + "            #.Visible = true;" + Environment.NewLine
                + "            #.Width = 80;" + Environment.NewLine;
                sb.Append(s.Replace("#", columnname));
                sbcoms.Append(columnname + ",");
            }
            return sb.Append(Environment.NewLine + sbcoms.ToString().TrimEnd(',') + " };" + Environment.NewLine + "        }").ToString();

        }



        private DataGridViewColumn[] CreateColumns()
        {
            DataGridViewColumn Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Key.DataPropertyName = "Key";
            Key.HeaderText = "Key";
            Key.MinimumWidth = 30;
            Key.Name = "Key";
            Key.ReadOnly = true;
            Key.ToolTipText = "Key";
            Key.Visible = false;
            Key.Width = 80;

            DataGridViewColumn Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Value.DataPropertyName = "Value";
            Value.HeaderText = "Value";
            Value.MinimumWidth = 30;
            Value.Name = "Value";
            Value.ReadOnly = true;
            Value.ToolTipText = "Value";
            Value.Visible = false;
            Value.Width = 80;

            DataGridViewColumn Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Name";
            Name.MinimumWidth = 30;
            Name.Name = "Name";
            Name.ReadOnly = true;
            Name.ToolTipText = "Name";
            Name.Visible = false;
            Name.Width = 80;

            return new System.Windows.Forms.DataGridViewColumn[] { Key, Value, Name };
        }

        private void tbxServerAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Catalog = ((System.Data.DataRowView)cbxDatas.SelectedValue).Row.ItemArray[0].ToString();
            }
            catch (Exception)
            {

            }
            _confg.username = txtUsername.Text.Trim();
            _confg.pwd = txtPwd.Text.Trim();
            _confg.Address = txtServerAddress.Text.Trim();
            _confg.schema = txtschema.Text.Trim();
            _confg.@namespace = txtnamespace.Text.Trim();
            _confg.assemly = txtassembly.Text.Trim();

            XmlSerializer.SaveToXml(AppPath + "config.xml", _confg, typeof(Config), "Config");
            connection = string.Format(_connection, _confg.Address, Catalog, _confg.username, _confg.pwd);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //DataTable dt = DbHelper.GetDataTable(connection, "SELECT * FROM SNTON.AGVConfig");
            //string d = GetDataTableColumns(dt);
            Create(connection, Catalog, checkBoxComboBox1.Text.Replace(" ", "").Split(',').ToList());
            MessageBox.Show("生成结束");
            System.Diagnostics.Process.Start("Explorer.exe", _confg.path);
        }

        mappingentity CreateMap()
        {
            mappingentity map = null;
            object obj = XmlSerializer.LoadFromXml(AppPath + @"mapping.xml", typeof(mappingentity));
            map = obj as mappingentity;
            return map;
        }

        private void txtpath_Click(object sender, EventArgs e)
        {
            var r = folderBrowserDialog1.ShowDialog();
            if (r == DialogResult.Cancel)
                return;
            _confg.path = folderBrowserDialog1.SelectedPath;
            txtpath.Text = _confg.path;
            XmlSerializer.SaveToXml(AppPath + "config.xml", _confg, typeof(Config), "Config");
        }
    }
}
