using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testListViewSorting
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string NAME_PROPETY_EZ = "EZ";
        private const string NAME_PROPETY_PRICE = "Preis pro Stück";
        private ObservableCollection<MainWindowViewModel> TestItemsSource = new ObservableCollection<MainWindowViewModel>();
        public MainWindow()
        {
            InitializeComponent();
            FillItemsSourceByTestDatas();
            this.SetListView(this.TestItemsSource);
        }

        private ListSortDirection lastDirection;

        private void FillItemsSourceByTestDatas()
        {
            try
            {
                var item = new Model();
                item.Price = 1;
                item.EZ = DateTime.ParseExact("01-20", "MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                this.TestItemsSource.Add(new MainWindowViewModel( item));

                var item1 = new Model();
                item1.Price = 2;
                item1.EZ = DateTime.ParseExact("05-19", "MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                this.TestItemsSource.Add(new MainWindowViewModel(item1));

                var item2 = new Model();
                item2.Price = 3;
                item2.EZ = DateTime.ParseExact("12-21", "MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                this.TestItemsSource.Add(new MainWindowViewModel(item2));

                var item3 = new Model();
                item3.Price = 4;
                item3.EZ = DateTime.ParseExact("06-01", "MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                this.TestItemsSource.Add(new MainWindowViewModel(item3));

                var item4 = new Model();
                item4.Price = 5;
                item4.EZ = DateTime.ParseExact("11-05", "MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                this.TestItemsSource.Add(new MainWindowViewModel(item4));
            }
            catch(Exception ex)
            {

            }
        }

        private void SetListView(IEnumerable<MainWindowViewModel> bikes)
        {
            this.ListView.ItemsSource = bikes;
            this.ListView.DataContext = bikes;
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            string header = headerClicked.Column.Header as string;

            if (header != null)
            {
                string propertyName = this.GetPropertyNameBy(header);

                if (lastDirection == ListSortDirection.Ascending)
                {
                    lastDirection = ListSortDirection.Descending;
                }
                else
                {
                    lastDirection = ListSortDirection.Ascending; ;
                }

                this.SortMotorbikeListViewBy(propertyName, lastDirection);
            }
        }

        private void SortMotorbikeListViewBy(string column, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(column, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private string GetPropertyNameBy(string columnHeaderText)
        {
            string propertyName;

            switch (columnHeaderText)
            {
                case NAME_PROPETY_EZ:
                    propertyName = "EZForSort";
                    break;
                case NAME_PROPETY_PRICE:
                    propertyName = "PriceForSort";
                    break;
                default:
                    propertyName = null;
                    break;
            }

            return propertyName;
        }
    }
}
