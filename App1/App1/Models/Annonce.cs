using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
   public class Annonce
    {
        public  string local { get; set; }
        public int id { get; set; }
        public string user_id { get; set; }
        public string titre { get; set; }
	    public int published { get; set; }
        public int publish { get; set; }
        public string titredesc { get; set; }
        public string categorie { get; set; }
        public string acces { get; set; }
        public string payement { get; set; }
        public string adresse { get; set; }
        public string motif { get; set; }
        public string desc { get; set; }
        public string dispo { get; set; }
        public string photos { get; set; }
        public Annonce() { }
        public Annonce(Object ob) {
            dynamic obj =  ob ;
            id =(int) obj.id;
            user_id = obj.user_id;
            titre = obj.titre;
            published = (int)obj.published;
            titredesc = obj.titredesc;
            categorie = obj.categorie;
            acces = obj.acces;
            payement = obj.payement;
            adresse = obj.adresse;
            motif = obj.motif;
            desc = obj.desc;
            dispo = obj.dispo;
            photos = obj.photos;
            local = obj.local;


        }
    }
   
}
