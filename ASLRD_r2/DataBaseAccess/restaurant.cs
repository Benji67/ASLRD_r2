//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASLRD_r2.DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class restaurant
    {
        public restaurant()
        {
            this.adresse = new HashSet<adresse>();
            this.commentaire = new HashSet<commentaire>();
            this.detailcommande = new HashSet<detailcommande>();
            this.detailcommandetmp = new HashSet<detailcommandetmp>();
            this.menu = new HashSet<menu>();
            this.ouverture = new HashSet<ouverture>();
            this.produit = new HashSet<produit>();
        }
    
        public int restaurantID { get; set; }
        public string email { get; set; }
        public string motdepasse { get; set; }
        public string nom { get; set; }
        public Nullable<int> telephone { get; set; }
        public string status { get; set; }
        public string genre { get; set; }
        public string nsiret { get; set; }
    
        public virtual ICollection<adresse> adresse { get; set; }
        public virtual ICollection<commentaire> commentaire { get; set; }
        public virtual ICollection<detailcommande> detailcommande { get; set; }
        public virtual ICollection<detailcommandetmp> detailcommandetmp { get; set; }
        public virtual ICollection<menu> menu { get; set; }
        public virtual ICollection<ouverture> ouverture { get; set; }
        public virtual ICollection<produit> produit { get; set; }
    }
}
