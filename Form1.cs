using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sampletest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Assembly assemble = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(assemble.Location);
            string StrFilename = System.IO.File.ReadAllText(path + "\\NETTest00.txt");
            string StrFile = StrFilename.Replace("\r\n", ",");
            string[] Filewords = StrFile.Split(',');
            if (Filewords != null)
            {
                var sortedWords = Filewords.OrderBy(word => word.Length).ToList().Take(1);
                List<string> list2 = new List<string>(Filewords);
                List<string> Finallist = new List<string>();
                char[] smallstrchar = String.Join("", list2.Where(x => x.Length <= sortedWords.FirstOrDefault().Length + 1)).ToCharArray();
                char[] bigstrchar = String.Join("", list2.Where(x => x.Length > sortedWords.FirstOrDefault().Length + 1)).ToCharArray();
                char[] modchar = bigstrchar.Except(smallstrchar).ToArray();

                foreach (string bigstr in list2)
                {
                    if (!(bigstr.IndexOfAny(modchar) != -1))
                    {
                        Finallist.Add(bigstr);
                    }
                }
                Finallist = Finallist.OrderByDescending(x => x.Length).Take(2).ToList();
                MessageBox.Show("The (1) longest one : " + Finallist[0].ToString());
                MessageBox.Show("The (2) longest one : " + Finallist[1].ToString());
            }




        }
    }
       

}
