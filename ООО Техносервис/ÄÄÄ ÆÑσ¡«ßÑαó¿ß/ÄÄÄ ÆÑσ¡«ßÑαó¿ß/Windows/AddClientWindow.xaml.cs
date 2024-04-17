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
using ООО_Техносервис.neModel;

namespace ООО_Техносервис.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginText.Text) && !string.IsNullOrEmpty(SurNameText.Text)
                && !string.IsNullOrEmpty(NameText.Text)
                && !string.IsNullOrEmpty(PasswordText.Password))
            {
                int id = Demoexm1Context._context.Users.Max(x => x.IdUser) + 1;

                User usr = new User
                {
                    IdUser = id,
                    LoginUser = LoginText.Text,
                    NameUser = NameText.Text,
                    SurNameUser = SurNameText.Text,
                    PasswordUser = PasswordText.Password,
                    RoleId = 1
                };

                Demoexm1Context._context.Users.Add(usr);
                Demoexm1Context._context.SaveChanges();

                MessageBox.Show("Пользователь добавлен");

                AddRequestWindow addRequestWindow = new AddRequestWindow();
                addRequestWindow.Show();
                this.Close();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AddRequestWindow addRequestWindow = new AddRequestWindow();
            addRequestWindow.Show();
            this.Close();
        }
    }
}
