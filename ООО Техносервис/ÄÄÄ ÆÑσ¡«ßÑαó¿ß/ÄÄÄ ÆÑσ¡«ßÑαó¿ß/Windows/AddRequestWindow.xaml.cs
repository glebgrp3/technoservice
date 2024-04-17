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
    /// Логика взаимодействия для AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {
        public AddRequestWindow()
        {
            InitializeComponent();
        }

        private void AddEqButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CauseText.Text)
                && !string.IsNullOrEmpty(NameEquirementText.Text)
                && !string.IsNullOrEmpty(SeriaText.Text)
                && ComboType.SelectedItem != null)
            {
                try
                {
                    int id = Demoexm1Context._context.Equipments.Max(x => x.IdEquipment) + 1;
                    Equipment eq = new Equipment
                    {
                        IdEquipment = id,
                        NameEquipment = NameEquirementText.Text,
                        Description = DescriptionText.Text,
                        SeriaEquipment = SeriaText.Text,
                        CauseEquipment = CauseText.Text,
                        TypeEquipment = ComboType.SelectedIndex + 1
                    };

                    Demoexm1Context._context.Equipments.Add(eq);
                    Demoexm1Context._context.SaveChanges();
                    MessageBox.Show("Оборудование добавлено");

                   


                }
                catch
                {
                    MessageBox.Show("Данная серия оборудования занята");
                }


            }
        }

        

        private string[] prioruty = { "Низкий", "Средний", "Высокий" };
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            ComboType.ItemsSource = Demoexm1Context._context.Equipmenttypes.ToList().Select(x => x.TypeName);
            ClientCombo.ItemsSource = Demoexm1Context._context.Users.Where(x => 
            x.RoleId == 1).ToList().Select(x => x.NameUser + " " + x.SurNameUser);
            PriorityCombo.ItemsSource = prioruty;

            var equipmentWithoutRepair = Demoexm1Context._context.Equipments
            .Where(e => !Demoexm1Context._context.Repairequipments.Any(re => re.IdEquipment == e.IdEquipment))
            .ToList().Select(x => x.SeriaEquipment);

            //if (equipmentWithoutRepair!=null)
            //{
            //    RequestStackPanel.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    RequestStackPanel.Visibility = Visibility.Hidden;
            //}
        }

        private void ComboEq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RepairRequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCombo.SelectedItem != null && PriorityCombo.SelectedItem != null)
            {
                int id = Demoexm1Context._context.Repairrequests.Max(x => x.IdRepairRequest) + 1;
                int idClient = Demoexm1Context._context.Users.FirstOrDefault(x => 
                (x.NameUser + " " + x.SurNameUser) == ClientCombo.SelectedValue.ToString()).IdUser;

                Repairrequest repReq = new Repairrequest
                {
                    IdRepairRequest = id,
                    DateRequest = DateOnly.FromDateTime(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))),
                    Priority = PriorityCombo.SelectedValue.ToString(),
                    IdClient = idClient
                };

                Demoexm1Context._context.Repairrequests.Add(repReq);
                Demoexm1Context._context.SaveChanges();

                MessageBox.Show("Заявка оставлена");

                RepairEquirementWindow repair = new RepairEquirementWindow();
                repair.Show();
                this.Close();
            }
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
        }
    }
}
