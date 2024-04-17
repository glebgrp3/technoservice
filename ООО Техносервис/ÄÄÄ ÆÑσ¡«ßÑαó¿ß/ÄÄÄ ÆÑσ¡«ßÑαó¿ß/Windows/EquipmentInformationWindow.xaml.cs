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
    /// Логика взаимодействия для EquipmentInformationWindow.xaml
    /// </summary>
    public partial class EquipmentInformationWindow : Window
    {
        public int Id;
        public int? IdEq;
        public EquipmentInformationWindow(int Id)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EquipmentList.ItemsSource = Demoexm1Context._context.Repairequipments.Where(x => x.IdRepair == Id).ToList();

            ExecutorCombo.ItemsSource = Demoexm1Context._context.Users.Where(x => x.RoleId == 2).Select(x => x.NameUser + " " + x.SurNameUser).ToList();
            StatusCombo.ItemsSource = Demoexm1Context._context.Statusrepairs.Select(x => x.StatusName).ToList();
        }

        private void EquipmentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EquipmentList.SelectedIndex > 0)
            {
                var item = (Repairequipment)EquipmentList.SelectedItem;
                CauseEquipmentText.Text = item.IdEquipmentNavigation.CauseEquipment;
                ExecutorCombo.SelectedValue = $"{item.ExecutorNavigation.NameUser} {item.ExecutorNavigation.SurNameUser}";
                StatusCombo.SelectedIndex = Convert.ToInt32(item.Status - 1);

                IdEq = item.IdEquipment;
                redactStack.Visibility= Visibility.Visible;   
            }
            else
            {
                var item = (Repairequipment)EquipmentList.Items[0];
                CauseEquipmentText.Text = item.IdEquipmentNavigation.CauseEquipment;
                ExecutorCombo.SelectedValue = $"{item.ExecutorNavigation.NameUser} {item.ExecutorNavigation.SurNameUser}";
                StatusCombo.SelectedIndex = Convert.ToInt32(item.Status - 1);

                IdEq = item.IdEquipment;
                redactStack.Visibility = Visibility.Visible;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CauseEquipmentText.Text) && IdEq != null)
            {
                var Eq = Demoexm1Context._context.Equipments.FirstOrDefault(x => x.IdEquipment == IdEq);
                if (Eq != null)
                {
                    Eq.CauseEquipment = CauseEquipmentText.Text;
                    Demoexm1Context._context.SaveChanges();
                }

                var repEq = Demoexm1Context._context.Repairequipments.FirstOrDefault(x => x.IdRepairEquipment == Id);
                if (repEq != null)
                {
                    repEq.Status = StatusCombo.SelectedIndex+1;
                    var ex = Demoexm1Context._context.Users.FirstOrDefault(x => (x.NameUser + " " + x.SurNameUser) == ExecutorCombo.SelectedValue.ToString());
                    repEq.Executor = ex.IdUser;
                    Demoexm1Context._context.SaveChanges();
                }
                MessageBox.Show("Изменения успешно сохранены");
                RequestWindow requestWindow = new RequestWindow();
                requestWindow.Show();
                this.Close();
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
        }
    }
}
