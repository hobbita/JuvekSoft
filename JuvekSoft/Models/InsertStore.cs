namespace JuvekSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InsertStore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InsertStore()
        {
            Products = new HashSet<Product>();
        }

        public int id { get; set; }

        [Column(TypeName = "image")]
        [DisplayName("Фото")]
        public byte[] Photo { get; set; }
        [DisplayName("Материал вставки")]
        public int InsMat { get; set; }
        [DisplayName("Форма огранки")]
        public int FacType { get; set; }
        [DisplayName("Размер")]
        public decimal Size1 { get; set; }
        [DisplayName("Размер")]
        public decimal? Size2 { get; set; }
        [DisplayName("Размер")]
        public decimal? Size3 { get; set; }
        [DisplayName("Единицы")]
        public int SizeUnits { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }
        [DisplayName("Единицы")]
        public int QuantityUnits { get; set; }
        [DisplayName("Цена")]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        [DisplayName("Единицы")]
        public int CostUnits { get; set; }
        [DisplayName("Допольнительная информация")]
        [StringLength(50)]
        public string OtherInfo { get; set; }

        public bool InUse { get; set; }
        [DisplayName("Форма огранки")]
        public virtual FacetingType FacetingType { get; set; }
        [DisplayName("Материал вставки")]
        public virtual InsertMaterial InsertMaterial { get; set; }
        [DisplayName("Единицы")]
        public virtual Unit Unit { get; set; }
        [DisplayName("Единицы")]
        public virtual Unit Unit1 { get; set; }
        [DisplayName("Единицы")]
        public virtual Unit Unit2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
