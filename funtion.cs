using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace SideBar
{

    class funtion
    {


        private string list_path(bool all)
        {
            company cp = new company();
            string data_path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            cp.AssemblyCompany(),
            cp.AssemblyProduct());

            if (all)
            {
                return Path.Combine(data_path,
              "list.xml");
            }
            else
            {
                return data_path;
            }



        }
        public void Create_list()
        {
            if (!File.Exists(list_path(true)))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream sm = asm.GetManifestResourceStream("SideBar.list.xml");
                Directory.CreateDirectory(list_path(false));


                using (FileStream fs = new FileStream(list_path(true), FileMode.Create, FileAccess.Write))
                {
                    sm.CopyTo(fs);
                    sm.Close();
                    fs.Close();
                }

            }
        }
        private XmlDocument load_xml()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(list_path(true));
            return doc;
        }
        public string Validate_Shortcut_Path(string final_string)
        {
            string sys_str = "SysWOW64";
            string pro_str = "Program Files (x86)";

            string final_string_lower = final_string.ToLower();
            int sys_value = final_string_lower.IndexOf(sys_str.ToLower());
            int pro_value = final_string_lower.IndexOf(pro_str.ToLower());
            if (sys_value > -1)
            {

                string new_string = final_string.Substring(0, sys_value) + "System32" + final_string.Substring(sys_value + sys_str.Length);
                if (System.IO.File.Exists(new_string) == true && System.IO.File.Exists(final_string) == false)
                {
                    final_string = new_string;
                }
            }
            else if (pro_value > -1)
            {
                string new_string = final_string.Substring(0, pro_value) + "Program Files" + final_string.Substring(pro_value + pro_str.Length);
                if (System.IO.File.Exists(new_string) == true && System.IO.File.Exists(final_string) == false)
                {
                    final_string = new_string;
                }

            }
            return final_string;
        }
        public string[,] Shortcut_List(string side)
        {
            XmlDocument doc = load_xml();
            XmlNodeList nodes = doc.SelectSingleNode(@"menu/" + side).ChildNodes;
            if (nodes == null)
            {
                return null;
            }
            else if (nodes.Count != 0)
            {
                int coun = nodes.Count;
                string[,] value = new string[3, coun];
                for (int i = 0; i < coun; i++)
                {
                    value[0, i] = nodes.Item(i).InnerText;
                    value[1, i] = nodes.Item(i).NamespaceURI;
                    value[2, i] = nodes.Item(i).Attributes["ID"].Value;
                }
                return value;
            }
            else
            {
                return null;
            }

        }
        public void save_Shortcut(string side, string name, string link, string id)
        {
            XmlDocument doc = load_xml();
            XmlElement root = (XmlElement)doc.SelectSingleNode(@"menu/" + side);
            XmlNode newNode = doc.CreateNode("element", "value", link);
            newNode.InnerText = name;
            XmlAttribute attr = null;
            attr = doc.CreateAttribute("ID");
            attr.Value = id;
            newNode.Attributes.SetNamedItem(attr);
            root.AppendChild(newNode);
            doc.Save(list_path(true));
        }

        public void del_Shortcut(string side, string id)
        {
            XmlDocument doc = load_xml();
            XmlNodeList nodes = doc.SelectSingleNode(@"menu/" + side).ChildNodes;
            foreach (XmlNode theNode in nodes)
            {
                XmlElement theEl = (XmlElement)theNode;
                if (theEl.GetAttribute("ID") == id)
                {
                    theEl.ParentNode.RemoveChild(theEl);

                }
            }
            doc.Save(list_path(true));


        }


        public bool SetAutoRun(string keyName, string filePath, bool AddOrCancel)
        {
            try
            {
                RegistryKey Local = Registry.CurrentUser;
                RegistryKey runKey = Local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\");
                if (AddOrCancel)
                {
                    runKey.SetValue(keyName, filePath);
                    Local.Close();
                }
                else
                {
                    if (runKey != null)
                    {
                        runKey.DeleteValue(keyName, false);
                        Local.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        //    SetAutoRun("ServiceControl.exe", Application.StartupPath + @"\ServiceControl.exe", false);

    }
    class company

    {
        public string AssemblyProduct()
        {

            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyProductAttribute)attributes[0]).Product;

        }
        public string AssemblyCompany()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCompanyAttribute)attributes[0]).Company;

        }

    }
}

