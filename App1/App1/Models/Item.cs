using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class Item
    {
        public int id { get; set; }
        public int annonce_id { get; set; }
        public string titre { get; set; }
        public string titredesc { get; set; }
        public string categorie { get; set; }
        public string description { get; set; }
        public string photos { get; set; }
        public string prix { get; set; }
        public int published { get; set; }

        public Item(Object ob)
        {
            dynamic obj = ob;
            id = (int)obj.id;
            annonce_id = (int)obj.annonce_id;
            titre = obj.titre;
            published = (int)obj.published;
            titredesc = obj.titredesc;
            categorie = obj.categorie;
           
            description = obj.description;
            prix = obj.prix;
            photos = obj.photos;
            


        }
    }
}
