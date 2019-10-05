using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuvekSoft.Models
{
    public class InsertStoreModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        

        //public int id { get; set; }

       // public int InsMat { get; set; }

        //public int FacType { get; set; }

        //public decimal Size1 { get; set; }

        public virtual FacetingType FacetingType { get; set; }

        public virtual InsertMaterial InsertMaterial { get; set; }


        public IEnumerable<InsertStore> InsertStores { get; set; }
        public SelectList id { get; set; }
        public SelectList InsMat { get; set; }
        public SelectList FacType { get; set; }
        public SelectList Size1 { get; set; }

        //public InsertStore()
        //{
        //    Products = new HashSet<Product>();
        //}

        //[Column(TypeName = "image")]
        //public byte[] Photo { get; set; }



        //public decimal? Size2 { get; set; }

        //public decimal? Size3 { get; set; }

        //public int SizeUnits { get; set; }

        //public int Quantity { get; set; }

        //public int QuantityUnits { get; set; }

        //[Column(TypeName = "money")]
        //public decimal Cost { get; set; }

        //public int CostUnits { get; set; }

        //[StringLength(50)]
        //public string OtherInfo { get; set; }

        //public bool InUse { get; set; }



        //public virtual Unit Unit { get; set; }

        //public virtual Unit Unit1 { get; set; }

        //public virtual Unit Unit2 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Product> Products { get; set; }
    }
}