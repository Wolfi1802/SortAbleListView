using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testListViewSorting
{
    public class MainWindowViewModel
    {

        public MainWindowViewModel(Model model)
        {
            _price = model.Price;
            _ez = model.EZ;
        }
        //Binding

        private double _price;
        private DateTime _ez;
        public string PriceString
        {

            get
            {
                return $"{this._price} €";
            }
        }
        public string EZString
        {

            get
            {
                return $"{this._ez}";
            }
        }

        //Sorting
        public double PriceForSort
        {
            get { return this._price; }
        }

        public DateTime EZForSort
        {
            get { return this._ez; }
        }
    }
}
