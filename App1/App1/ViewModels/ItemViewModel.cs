using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    class ItemViewModel: INotifyPropertyChanged
    {
        private List<Item> _items_list;
        public List<Item> items_list { get { return _items_list; } set { _items_list = value; OnPropertyChanged(); } }
        public ItemViewModel()
        {

            getListAsync();
        }


        public async Task getListAsync()
        {
            var service = new ItemService();
            items_list = await service.ItemsList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
