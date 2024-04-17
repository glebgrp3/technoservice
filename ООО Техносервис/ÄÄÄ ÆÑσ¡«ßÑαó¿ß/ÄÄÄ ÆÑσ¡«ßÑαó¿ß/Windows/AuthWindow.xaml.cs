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
using System.Windows.Shapes;
using ООО_Техносервис.Classes;
using ООО_Техносервис.neModel;
using ООО_Техносервис.Windows;

namespace ООО_Техносервис
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginText.Text) && !string.IsNullOrEmpty(passwordText.Password))
            {
                GlobalClass.user = Demoexm1Context._context.Users.FirstOrDefault(x => x.PasswordUser == passwordText.Password
                && x.LoginUser == loginText.Text);
                if (GlobalClass.user == null)
                    MessageBox.Show("Введён неверный пароль или логин");
                else
                {
                    RequestWindow requestWindow = new RequestWindow();
                    requestWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
