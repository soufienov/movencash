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
    class AnnonceViewModel: INotifyPropertyChanged
    { private List<Annonce> _annonces_list;
        public List<Annonce> annonces_list { get { return _annonces_list; }set { _annonces_list = value;OnPropertyChanged(); } }
        public AnnonceViewModel() {

            getListAsync();
        }

       
        public async Task getListAsync()
        { var service = new AnnonceService();
            annonces_list = await service.AnnoncesList(); }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
