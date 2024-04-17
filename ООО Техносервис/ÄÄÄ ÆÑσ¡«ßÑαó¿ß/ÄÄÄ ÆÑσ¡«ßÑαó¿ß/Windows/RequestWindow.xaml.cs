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

namespace ООО_Техносервис.Windows
{
    /// <summary>
    /// Логика взаимодействия для RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        public RequestWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RepairRequestList.ItemsSource = Demoexm1Context._context.Repairrequests.ToList();

            FilrtrComboStatus.Items.Add("Все статусы");
            foreach (var item in Demoexm1Context._context.Statusrepairs.ToList())
                FilrtrComboStatus.Items.Add(item.StatusName);


            FilrtrComboStatus.SelectedIndex = 0;

            FullNameText.Text = $"{GlobalClass.user.NameUser} {GlobalClass.user.SurNameUser}";

            if (GlobalClass.user.RoleId == 3)
            {
                RegistrRequestBtn.Visibility = Visibility.Visible;
                FullNameText.Text = FullNameText.Text + " - Сотрудник";
            }

            if (GlobalClass.user.RoleId == 2)
            {
                FullNameText.Text = FullNameText.Text + " - Исполнитель";
            }

            if (GlobalClass.user.RoleId == 1)
            {
                ContextInf.Visibility = Visibility.Hidden;
                FullNameText.Text = FullNameText.Text + " - Клиент";
            }

            if (GlobalClass.user.RoleId == 4)
            {
                FullNameText.Text = FullNameText.Text + " - Менеджер";
            }


        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            var list = Demoexm1Context._context.Repairrequests.ToList();

            if (!string.IsNullOrEmpty(SearchText.Text))
            {
                list = list.Where(x=>x.FullNameClient.Contains(SearchText.Text)).ToList();
            }

           
            if(FilrtrComboStatus.SelectedIndex!=0)
                list = list.Where(x=>x.StatusRequest == FilrtrComboStatus.SelectedValue.ToString()).ToList();

          
            RepairRequestList.ItemsSource = list;

        }

        private void FilrtrComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        private void ContextInf_Click(object sender, RoutedEventArgs e)
        {
            if (RepairRequestList.SelectedItem != null)
            {
                var item = (Repairrequest)RepairRequestList.SelectedItem;

                EquipmentInformationWindow equipmentInformationWindow = new EquipmentInformationWindow(item.IdRepairRequest);
                equipmentInformationWindow.Show();
                this.Close();
            }
        }

        private void AddRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRequestWindow requestWindow = new AddRequestWindow();
            requestWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void qrcodebutton_Click(object sender, RoutedEventArgs e)
        {
            QRCodeWindow qRCodeWindow = new QRCodeWindow();
            qRCodeWindow.ShowDialog();
        }
    }
}
