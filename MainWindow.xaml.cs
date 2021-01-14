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

namespace Anamaria_Han_App_Examen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int mDessertMuffin = 0;
        private int mDessertCookies = 0;
        private int mDessertIceCream = 0;
        private int mDrinkJuice = 0;
        private int mDrinkTea = 0;
        private int mDrinkCoffee = 0;
        private double Total = 0;
        private FoodType selectedFood;

        private void muffinMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDessertMuffin++;
            txtMuffinDessert.Text = mDessertMuffin.ToString();
        }

        private void cookiesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDessertCookies++;
            txtCookiesDessert.Text = mDessertCookies.ToString();
        }

        private void icecreamMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDessertIceCream++;
            txtIceCreamDessert.Text = mDessertIceCream.ToString();
        }

        private void juiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDrinkJuice++;
            txtJuiceDrink.Text = mDrinkJuice.ToString();
        }

        private void teaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDrinkTea++;
            txtTeaDrink.Text = mDrinkTea.ToString();
        }

        private void coffeeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDrinkCoffee++;
            txtCoffeeDrink.Text = mDrinkCoffee.ToString();
        }

        private void FoodItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " vegan is ready!";
            this.Title = mesaj;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        KeyValuePair<FoodType, double>[] PriceList = {
            new KeyValuePair<FoodType, double>(FoodType.Muffin,3),
            new KeyValuePair<FoodType, double>(FoodType.Cookies,2.5),
            new KeyValuePair<FoodType, double>(FoodType.IceCream,4.5),
            new KeyValuePair<FoodType, double>(FoodType.Juice,6),
            new KeyValuePair<FoodType, double>(FoodType.Tea,5),
            new KeyValuePair<FoodType, double>(FoodType.Coffee,5.5)
                 };

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<FoodType, double> selectedEntry =
           (KeyValuePair<FoodType, double>)cmbType.SelectedItem;
            selectedFood = selectedEntry.Key;
        }

        private int ValidateQuantity(FoodType selectedFood)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedFood)
            {
                case FoodType.Muffin:
                    if (q > mDessertMuffin)
                        r = 0;
                    break;
                case FoodType.Cookies:
                    if (q > mDessertCookies)
                        r = 0;
                    break;
                case FoodType.IceCream:
                    if (q > mDessertIceCream)
                        r = 0;
                    break;
                case FoodType.Juice:
                    if (q > mDrinkJuice)
                        r = 0;
                    break;
                case FoodType.Tea:
                    if (q > mDrinkTea)
                        r = 0;
                    break;
                case FoodType.Coffee:
                    if (q > mDrinkCoffee)
                        r = 0;
                    break;
            }
            return r;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedFood) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedFood.ToString() +
               ":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Muffin":
                        mDessertMuffin = mDessertMuffin - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtMuffinDessert.Text = mDessertMuffin.ToString();
                        break;
                    case "Cookies":
                        mDessertCookies = mDessertCookies - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtCookiesDessert.Text = mDessertCookies.ToString();
                        break;
                    case "IceCream":
                        mDessertIceCream = mDessertIceCream - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtIceCreamDessert.Text = mDessertIceCream.ToString();
                        break;
                    case "Juice":
                        mDrinkJuice = mDrinkJuice - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtJuiceDrink.Text = mDrinkJuice.ToString();
                        break;
                    case "Tea":
                        mDrinkTea = mDrinkTea - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtTeaDrink.Text = mDrinkTea.ToString();
                        break;
                }
            }
            lstSale.Items.Clear();
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

    }
}

