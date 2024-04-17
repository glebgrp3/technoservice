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
    /// Логика взаимодействия для RepairEquirementWindow.xaml
    /// </summary>
    public partial class RepairEquirementWindow : Window
    {
        public RepairEquirementWindow()
        {
            InitializeComponent();
        }

        private void SourceComboEq()
        {
            var equipmentWithoutRepair = Demoexm1Context._context.Equipments
           .Where(e => !Demoexm1Context._context.Repairequipments.Any(re => re.IdEquipment == e.IdEquipment))
           .ToList().Select(x => x.SeriaEquipment);

            ComboEq.ItemsSource = equipmentWithoutRepair;

            ComboNumberRequest.ItemsSource = Demoexm1Context._context.Repairrequests.Select(x => x.IdRepairRequest).ToList();
            ComboExecutor.ItemsSource = Demoexm1Context._context.Users.Where(x => x.RoleId == 2).Select(x => x.NameUser + " " + x.SurNameUser).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SourceComboEq();
        }

        private void AddEqButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(CostText.Text) && ComboEq.SelectedItem!=null
                && ComboExecutor.SelectedItem!=null && ComboNumberRequest.SelectedItem!=null)
            {
                int id = Demoexm1Context._context.Repairequipments.Max(x => x.IdRepairEquipment) + 1;
                int idr = Demoexm1Context._context.Repairrequests.Max(x => x.IdRepairRequest);
                var ex = Demoexm1Context._context.Users.FirstOrDefault(x => (x.NameUser + " " + x.SurNameUser) == ComboExecutor.SelectedValue.ToString());
                var eq = Demoexm1Context._context.Equipments.FirstOrDefault(x => x.SeriaEquipment == ComboEq.SelectedValue.ToString());
                Repairequipment repair = new Repairequipment
                {
                    IdRepairEquipment = id,
                    IdRepair = idr,
                    Executor = ex.IdUser,
                    IdEquipment = eq.IdEquipment,
                    Cost = Convert.ToInt32(CostText.Text),
                    Comment = CommentText.Text,
                    Status = 1
                };

                Demoexm1Context._context.Repairequipments.Add(repair);
                Demoexm1Context._context.SaveChanges();

                MessageBox.Show("Оборудование добавлено к заявке");

                RequestWindow requestWindow = new RequestWindow();
                requestWindow.Show();
                this.Close();


            }
        }
    }
}
