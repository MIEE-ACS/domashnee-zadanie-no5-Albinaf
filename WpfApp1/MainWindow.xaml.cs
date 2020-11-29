using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace WpfApp1
{
    class Tovar
    {
        public enum Name
        {
            Паста,
            Помада,
            Крем,
            Пудра,
            Any
        }

        public Name name;
        public int vendorCode;
        public decimal price;
        public DateTime date;
        public int expirationMonths;

        public Tovar(DateTime m_productionDate, int m_expirationMonths)
        {
            date = m_productionDate;
            expirationMonths = m_expirationMonths;
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
        }

        public bool isExpired
        {
            get
            {
                return ((DateTime.Now - date).TotalDays / 30) >= expirationMonths;
            }
        }

        public int VendorCode
        {
            set
            {
                if (value > 0)
                    vendorCode = value;
            }

            get
            {
                return vendorCode;
            }
        }

        public int ExpirationMonths
        {
            set
            {
                if (value > 0)
                    expirationMonths = value;
            }

            get
            {
                return expirationMonths;
            }
        }

        public decimal Price
        {
            set
            {
                if (value > 0)
                    price = value;
            }
            get
            {
                return price;
            }
        }

        public override string ToString()
        {
            string name_name;

            switch (name)
            {
                case Name.Паста:
                    name_name = "Зубная паста";
                    break;
                case Name.Крем:
                    name_name = "Крем";
                    break;
                case Name.Помада:
                    name_name = "Помада";
                    break;
                case Name.Пудра:
                    name_name = "Пудра";
                    break;
                default:
                    name_name = "";
                    break;
            }
            return $"{name_name}, {vendorCode}, {price}, {date}, {expirationMonths}";
        }
    }

    public partial class MainWindow : Window
    {
        List<Tovar> tovars = new List<Tovar>
        {
            new Tovar (new DateTime(2020,12,23), 6) { name = Tovar.Name.Крем, vendorCode = 182, price = 254},
            new Tovar (new DateTime(2020,11,20), 3) { name = Tovar.Name.Пудра, vendorCode = 456, price = 145},
            new Tovar (new DateTime(2020,9,14), 2) { name = Tovar.Name.Паста, vendorCode = 123, price = 123},
            new Tovar (new DateTime(2020,2,21), 9) { name = Tovar.Name.Помада, vendorCode = 442, price = 200},
        };

        public void updateTovarList()
        {
            lbTovar.Items.Clear();

            
           
            foreach (var tovar in tovars)
            {
               
                    lbTovar.Items.Add(tovar);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            updateTovarList();
        }

        private void cbTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateTovarList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                foreach (var tvr in tovars)
                {
                    if (tvr.vendorCode == int.Parse(tbVC.Text))
                    {
                        MessageBox.Show("Артикулы не могут быть одинаковыми!", "Проверьте введенные значения", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                        return;
                    }

                }
                   
                    Tovar tovar = new Tovar(new DateTime(int.Parse(tbY.Text), int.Parse(tbM.Text), int.Parse(tbD.Text)), int.Parse(tbSL.Text))
                    {
                        vendorCode = int.Parse(tbVC.Text),
                        name = (Tovar.Name)cbName.SelectedIndex,
                        price = int.Parse(tbP.Text)
                    };

                    tovars.Add(tovar);

                    updateTovarList();
                
                    
                
            }
            catch (FormatException)
            {             
                MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Обратитесь к разработчику: " + ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void btnCh_Click(object sender, RoutedEventArgs e)
        {
            Tovar tovarr = lbTovar.SelectedItem as Tovar;

            MessageBox.Show($"Дата изготовления:{tovarr.Date}, истёк ли срок (f - не истёк, t - истёк): {tovarr.isExpired}", "Проверка на срок годности", MessageBoxButton.OK);
        }





        private void lbTovar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        try
        {
        Tovar tovarr = lbTovar.SelectedItem as Tovar;
                tbVC.Text = tovarr.vendorCode.ToString();
                tbP.Text = tovarr.price.ToString();
                tbSL.Text = tovarr.expirationMonths.ToString();
                tbY.Text = tovarr.Date.Year.ToString();
                tbD.Text = tovarr.Date.Day.ToString();
                tbM.Text = tovarr.Date.Month.ToString();
            }
        catch (Exception ex)
        {
        MessageBox.Show("Обратитесь к разработчику: " + ex.Message, "Неизвестная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        }
    }




















}


    