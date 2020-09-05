using System;
using System.Collections.Generic;
using System.Text;

namespace ESO.Scraper.Models
{
    public class Item : BaseClass
    {
        public Item(int _id) : base()
        {
            ID = _id;
        }
        public Item(int _id, string _name) : base()
        {
            ID = _id;
            Name = _name;
        }

        private string name;
        private int id;

        public int ID
        {
            get { return id; }
            private set { id = value; NotifyPropertyChanged(); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(); }
        }


    }
}
