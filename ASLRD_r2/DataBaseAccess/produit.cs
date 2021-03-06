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
    
    public partial class produit
    {
        public produit()
        {
            this.commentaire = new HashSet<commentaire>();
            this.detailcommande = new HashSet<detailcommande>();
            this.detailcommandetmp = new HashSet<detailcommandetmp>();
            this.ingredient = new HashSet<ingredient>();
            this.menu = new HashSet<menu>();
        }
    
        public int produitID { get; set; }
        public string nom { get; set; }
        public decimal prixproduit { get; set; }
        public string description { get; set; }
        public Nullable<System.TimeSpan> delais { get; set; }
        public Nullable<double> reduction { get; set; }
        public int restaurantID { get; set; }
    
        public virtual restaurant restaurant { get; set; }
        public virtual ICollection<commentaire> commentaire { get; set; }
        public virtual ICollection<detailcommande> detailcommande { get; set; }
        public virtual ICollection<detailcommandetmp> detailcommandetmp { get; set; }
        public virtual ICollection<ingredient> ingredient { get; set; }
        public virtual ICollection<menu> menu { get; set; }
    }
}
