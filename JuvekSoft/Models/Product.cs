namespace JuvekSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            InsertStores = new List<InsertStore>();
            //InsertStores = new HashSet<InsertStore>();
            MetalStores = new HashSet<MetalStore>();
            Operations = new HashSet<Operation>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Название изделия")]
        public string Name { get; set; }

        [Column(TypeName = "image")]
        [DisplayName("Фото")]
        public byte[] Photo { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Цена")]
        public decimal? Cost { get; set; }

        [StringLength(50)]
        [DisplayName("Дополнительная информация")]
        public string OtherInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName("Вставка")]
        //public virtual ICollection<InsertStore> InsertStores { get; set; }
        public virtual List<InsertStore> InsertStores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName("Металл")]
        public virtual ICollection<MetalStore> MetalStores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName("Операции")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
