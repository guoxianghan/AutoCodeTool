using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoCodeTool
{
    public class mappingcontrol
    {
        public static hibernatemapping CreatehibernatemappingXML(List<DbColumn> list, string tablename, string schema, string _namespace, string assembly)
        {
            hibernatemapping map = new hibernatemapping();

            tablename = schema + "." + list[0].TableName;
            string classname = tablename + "Entity";
            try
            {
                #region 创建MAPXML
                map._namespace = _namespace;
                map.assembly = assembly;
                map.schema = schema;

                var _class = new hibernatemappingClass()
                {
                    table = tablename,
                    schema = schema,
                    name = classname,
                    property = new List<hibernatemappingClassProperty>()
                };

                foreach (var item in list)
                {
                    if (item.ColumnName.ToLower() == "id")
                        continue;
                    var column = new hibernatemappingClassProperty();

                    column.name = item.ColumnName;
                    column.column = item.ColumnName;
                    _class.property.Add(column);
                }
                var id = new hibernatemappingClassID() { };
                id.column = new hibernatemappingClassIDColumn();
                id.column.name = "ID";
                id.column.notnull = true;
                var generator = new hibernatemappingClassIDGenerator();
                generator.@class = "identity";
                id.generator = generator;
                id.name = "Id";
                _class.id = id;
                map.@class = _class;

                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show(tablename, e.Message);
            }
            return map;
        }

        public static string CreateEntity(List<DbColumn> list, string tablename, string schema, string _namespace, string assembly, mappingentity map, string path)
        {
            StringBuilder sb = new StringBuilder(File.ReadAllText(path));


            foreach (var item in map.map)
            {
                #region MyRegion
                switch (item.operate)
                {
                    case "REPLACE":
                        //switch (item.source)
                        //{
                        //    case "":
                        //        break;

                        //    default:
                        //        break;
                        //}
                        sb.Replace("<#" + "NAMESPACE" + "#>", _namespace + "." + tablename);
                        sb.Replace("<#" + "ENTITYNAME" + "#>", tablename + "Entity");
                        break;
                    default:
                        break;
                }
                #endregion
            }
            Regex reg = new Regex(@"(?<=<#FOREACH#>)[\s\S]*?(?=<#/FOREACH#>)");
            MatchCollection mats = reg.Matches(sb.ToString());
            StringBuilder t = sb.Replace(@"<#FOREACH#>" + mats[0].Value + @"<#/FOREACH#>", "");
            StringBuilder colsb = new StringBuilder();
            foreach (var item in map.FOREACH)
            {
                #region MyRegion
                switch (item.source)
                {
                    case "COLUMN":
                        foreach (var col in list)
                        {
                            if ("Created,Updated,Deleted,IsDeleted,ID".ToLower().Contains(col.ColumnName.ToLower()))
                            {
                                continue;
                            }
                            StringBuilder property = new StringBuilder(mats[0].Value);
                            #region MyRegion
                            foreach (var i in item.map)
                            {
                                switch (i.source)
                                {
                                    case "DESCRIPTION":
                                        property.Replace("<#DESCRIPTION#>", string.IsNullOrEmpty(col.Remark) ? col.ColumnName : col.Remark);
                                        break;
                                    case "COLUMNNAME":
                                        property.Replace("<#COLUMNNAME#>", col.ColumnName);
                                        break;
                                    case "TYPE":
                                        property.Replace("<#TYPE#>", col.CSharpType);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            #endregion
                            colsb.Append(property);
                        }
                        break;
                    default:
                        break;
                }
                #endregion
            }
            t.Insert(mats[0].Index - "<#FOREACH#>".Length, colsb.ToString());
            return sb.ToString();
        }
        public static string CreateMapXML(List<string> tables, string assembly, string templatepath)
        {
            StringBuilder sb = new StringBuilder(File.ReadAllText(templatepath));
            Regex reg = new Regex(@"(?<=<#FOREACH#>)[\s\S]*?(?=<#/FOREACH#>)");
            MatchCollection mats = reg.Matches(sb.ToString());
            StringBuilder t = sb.Replace(@"<#FOREACH#>" + mats[0].Value + @"<#/FOREACH#>", "");
            StringBuilder colsb = new StringBuilder();
            foreach (var item in tables)
            {
                string v = mats[0].Value;
                string tmp = v.Replace("<#ASSEMBLY#>", assembly).Replace("<#TABLENAME#>", item);
                colsb.Append(tmp);
            }
            return colsb.ToString();
        }
        public static string CreateBroker(List<string> tables, string templatepath)
        {
            string sb = (File.ReadAllText(templatepath));
            StringBuilder colsb = new StringBuilder();
            foreach (var item in tables)
            {
                var tmp = sb.Replace("<#TABLENAME#>", ToFirstCharUpper(item)).Replace("<#tABLENAME#>", ToFirstCharLower(item)) + Environment.NewLine;
                colsb.Append(tmp);
            }
            return colsb.ToString();
        }

        public static string CreateBroke(string tablename, string templatepath)
        {
            string sb = (File.ReadAllText(templatepath));
            StringBuilder colsb = new StringBuilder();

            {
                var tmp = sb.Replace("<#TABLENAME#>", ToFirstCharUpper(tablename)).Replace("<#tABLENAME#>", ToFirstCharLower(tablename)) + Environment.NewLine;
                colsb.Append(tmp);
            }
            return colsb.ToString();
        }
        public static string CreateBrokeInterface(string tablename, string templatepath)
        {
            string sb = (File.ReadAllText(templatepath));
            StringBuilder colsb = new StringBuilder();
            {
                var tmp = sb.Replace("<#TABLENAME#>", ToFirstCharUpper(tablename)).Replace("<#tABLENAME#>", ToFirstCharLower(tablename)) + Environment.NewLine;
                colsb.Append(tmp);
            }
            return colsb.ToString();
        }
        public static string CreateBrokerNode(List<string> tables, string templatepath)
        {
            StringBuilder sb = new StringBuilder(File.ReadAllText(templatepath));
            Regex reg = new Regex(@"(?<=<#FOREACH#>)[\s\S]*?(?=<#/FOREACH#>)");
            MatchCollection mats = reg.Matches(sb.ToString());
            StringBuilder t = sb.Replace(@"<#FOREACH#>" + mats[0].Value + @"<#/FOREACH#>", "");
            StringBuilder colsb = new StringBuilder();
            foreach (var item in tables)
            {
                string v = mats[0].Value;
                string tmp = v.Replace("<#TABLENAME#>", item);
                colsb.Append(tmp);
            }
            return colsb.ToString();
        }
        public static string CreateBrokerConfig(List<string> tables)
        {
            StringBuilder sb = new StringBuilder(Environment.NewLine);
            foreach (var item in tables)
            {
                sb.Append(item + "ProviderId=\"" + item + "Provider\"" + Environment.NewLine);
            }
            return sb.ToString();
        }
        static string ToFirstCharUpper(string str)
        {
            char c = str.ToArray()[0];
            string i = c.ToString().ToUpper() + str.Substring(1);
            return i;
        }
        static string ToFirstCharLower(string str)
        {
            char c = str.ToArray()[0];
            string i = c.ToString().ToLower() + str.Substring(1);
            return i;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public class Config
{

    private string addressField;

    private string usernameField;

    private string pwdField;

    private string pathField;

    private string namespaceField;

    private string schemaField;

    private string assemlyField;

    /// <remarks/>
    public string Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }

    /// <remarks/>
    public string username
    {
        get
        {
            return this.usernameField;
        }
        set
        {
            this.usernameField = value;
        }
    }

    /// <remarks/>
    public string pwd
    {
        get
        {
            return this.pwdField;
        }
        set
        {
            this.pwdField = value;
        }
    }

    /// <remarks/>
    public string path
    {
        get
        {
            return this.pathField;
        }
        set
        {
            this.pathField = value;
        }
    }

    /// <remarks/>
    public string @namespace
    {
        get
        {
            return this.namespaceField;
        }
        set
        {
            this.namespaceField = value;
        }
    }

    /// <remarks/>
    public string schema
    {
        get
        {
            return this.schemaField;
        }
        set
        {
            this.schemaField = value;
        }
    }

    /// <remarks/>
    public string assemly
    {
        get
        {
            return this.assemlyField;
        }
        set
        {
            this.assemlyField = value;
        }
    }
}


