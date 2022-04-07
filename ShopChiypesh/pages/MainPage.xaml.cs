﻿using System;
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

namespace ShopChiypesh.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        User usr;
        public MainPage(User Newusr)
        {
            InitializeComponent();
            usr = Newusr;
            prod.ItemsSource = BD_connection.shop.Product.ToList();
            var LvUnit = BD_connection.shop.Unit.ToList();
            LvUnit.Insert(0, new Unit() { Id = -1, Name = "Все" });
            UnitCb.ItemsSource = LvUnit;
            UnitCb.DisplayMemberPath = "Name";
        }

        private void Del_event(object sender, RoutedEventArgs e)
        {
            var isSelProduct = prod.SelectedItem as Product;
            if (isSelProduct != null)
            {
                if (usr.RoleId == 1)
                {
                    var result = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.OK)
                    {
                        BD_connection.shop.Product.Remove(isSelProduct);
                        BD_connection.shop.SaveChanges();
                    }
                }
                else
                    MessageBox.Show("Вы не админ");
            }
            else
                MessageBox.Show("Ничего не выбрано!");
        }

        private void EditBtnt_Click(object sender, RoutedEventArgs e)
        {
            var isSelProduct = prod.SelectedItem as Product;
            if (isSelProduct != null)
                NavigationService.Navigate(new EditingPage(isSelProduct));
            else
                MessageBox.Show("Ничего не выбрано!");
        }

        private void Refresh()
        {
            var FilterProduct = (IEnumerable<Product>)BD_connection.shop.Product.ToList();

            if (!string.IsNullOrWhiteSpace(SearchNameDescTb.Text))
                FilterProduct = FilterProduct.Where(c => c.Name.StartsWith(SearchNameDescTb.Text) || c.Description.StartsWith(SearchNameDescTb.Text));

            if (UnitCb.SelectedIndex > 0)
                FilterProduct = FilterProduct.Where(c => c.UnitId == (UnitCb.SelectedItem as Unit).Id || c.UnitId == -1);

            if (DateMounthBtn.IsPressed)
                prod.ItemsSource = FilterProduct.Where(x => x.AddDate.Month == DateTime.Now.Month).ToList();

            if (DateCb.SelectedIndex == 1)
                FilterProduct = FilterProduct.OrderBy(c => c.AddDate).ToList();
            else if(DateCb.SelectedIndex == 2)
                FilterProduct = FilterProduct.OrderByDescending(c => c.AddDate).ToList();

            if (AlfCb.SelectedIndex == 1)
                FilterProduct = FilterProduct.OrderBy(c => c.Name);
            else
                FilterProduct = FilterProduct.OrderByDescending(c => c.Name);

            prod.ItemsSource = FilterProduct;
        }

        private void UnitCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchNameDescTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void DateMounthBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void DateCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AlfCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Reset_event(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
