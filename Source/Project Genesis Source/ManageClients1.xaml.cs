using Project_Genesis_Source.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Genesis_Source
{
    /// <summary>
    /// Interaction logic for ManageClients1.xaml
    /// </summary>
    public partial class ManageClients1 : Page
    {
        public ManageClients1()
        {
            InitializeComponent();

            DatabaseConnection dataConnect = new DatabaseConnection();

            string[] fnames = dataConnect.retrieveFNames();

            //populate customerOutputBox with Customer names

            if (fnames.Length == 0)
            {
                MessageBox.Show("No first names to populate with");
            }
            else
            {
                for (int i = 0; i < fnames.Length; i++)
                {
                    nameOutputBox.Items.Add(fnames[i] + "\n");
                }
            }
          
        }



    }
}
