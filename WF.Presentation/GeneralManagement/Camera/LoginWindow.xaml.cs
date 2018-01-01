using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace GeneralManagement.Camera
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool isOk = false; //for check whether or not login.

        public LoginWindow()
        {
             
            InitializeComponent();
            
        }


        //check login information is ok.
        private void ok_Clicked(object sender, RoutedEventArgs e)
        {
             
            if (ip.Text == "" || ip.Text == null)
            {
                MessageBox.Show("ID_LOGIN_IP_ERROR");
                return;
            }
            else if (port.Text == "" || port.Text == null)
            {
                MessageBox.Show("ID_LOGIN_PORT_ERROR");
                return;
            }
            else if (username.Text == "" || username.Text == null)
            {
                MessageBox.Show("ID_LOGIN_USERNAME_ERROR");
                return;
            }
            else
            {
                isOk = true;
        
                this.Close();
            }
        }

        //just can input number.
        private void port_input(object sender, TextCompositionEventArgs e)
        {             
            try
            {
                Convert.ToUInt32(e.Text);
                e.Handled = false;
            }
            catch (Exception ex)
            {  
                e.Handled = true;
            }
            
        }

    }
}
