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

namespace WpfApp1
{
    class Tovar
    {
        public enum Name
        {
            Паста,
            Помада,
            Крем,
            Пудра
        }

        private Name m_name;
        private int m_vendorCode;
        private decimal m_price;
        public DateTime m_date;
        private int m_expirationMonths;

        public DateTime Date
        {
            get
            {
                return m_date;
            }
        }

        public bool isExpired
        {
            get
            {
                return ((DateTime.Now - m_date).TotalDays / 30) >= m_expirationMonths;
            }
        }

        public int VendorCode
        {
            set
            {
                if (value > 0)
                    m_vendorCode = value;
            }

            get
            {
                return m_vendorCode;
            }
        }

        public int ExpirationMonths
        {
            set
            {
                if (value > 0)
                    m_expirationMonths = value;
            }

            get
            {
                return m_expirationMonths;
            }
        }

        public decimal Price
        {
            set
            {
                if (value > 0)
                    m_price = value;
            }
            get
            {
                return m_price;
            }
        }

        public Tovar(Name name, int vendorCode, decimal price, DateTime productionDate, int expirationMonths)
        {
            m_name = name;
            m_vendorCode = vendorCode;
            m_price = price;
            m_date = productionDate;
            m_expirationMonths = expirationMonths;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int vendorCode = int.Parse(tbVC.Text);
                decimal price = decimal.Parse(tbP.Text);
                int day = int.Parse(tbD.Text);
                int month = int.Parse(tbM.Text);
                int year = int.Parse(tbY.Text);
                int expirationMonths = int.Parse(tbSL.Text);
                int nTovar = cbName.SelectedIndex;
                DateTime date1 = new DateTime(year, month, day);

                switch (nTovar)
                {
                    case 0:
                        Tovar tovars = new Tovar(Tovar.Name.Паста, vendorCode, price, date1, expirationMonths);
      
                        int compare = DateTime.Compare(date1.AddMonths(expirationMonths), DateTime.Now);

                        if (compare < 0)
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Паста}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        else
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Паста}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        break;
                    case 1:
                        tovars = new Tovar(Tovar.Name.Помада, vendorCode, price, date1, expirationMonths);

                        compare = DateTime.Compare(date1.AddMonths(expirationMonths), DateTime.Now);

                        if (compare < 0)
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Помада}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        else
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Помада}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        break;
                    case 2:
                        tovars = new Tovar(Tovar.Name.Крем, vendorCode, price, date1, expirationMonths);

                        compare = DateTime.Compare(date1.AddMonths(expirationMonths), DateTime.Now);

                        if (compare < 0)
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Крем}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        else
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Крем}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        break;
                    case 3:
                        tovars = new Tovar(Tovar.Name.Пудра, vendorCode, price, date1, expirationMonths);

                        compare = DateTime.Compare(date1.AddMonths(expirationMonths), DateTime.Now);

                        if (compare < 0)
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Пудра}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        else
                        {
                            lbTovar.Items.Add($"{Tovar.Name.Пудра}, Артикул: {vendorCode}, Цена: {price}, Дата выпуска: {date1}, Срок годности(мес.): {expirationMonths}, На сегоднящний день товар годен.");
                        }
                        break;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }




















}


    