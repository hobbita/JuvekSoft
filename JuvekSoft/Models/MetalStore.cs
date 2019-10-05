namespace JuvekSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MetalStore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MetalStore()
        {
            Products = new HashSet<Product>();
        }

        public int id { get; set; }

        [Column(TypeName = "image")]
        [DisplayName("Фото")]
        public byte[] Photo { get; set; }
        [DisplayName("Тип проката")]
        public int MetType { get; set; }
        [DisplayName("Тип металла")]
        public int MetName { get; set; }
        [DisplayName("Размер1")]
        public decimal Size1 { get; set; }
        [DisplayName("Размер2")]
        public decimal? Size2 { get; set; }
        [DisplayName("Размер3")]
        public decimal? Size3 { get; set; }
        [DisplayName("Единицы размеров")]
        public int SizeUnits { get; set; }
        [DisplayName("Количество")]
        public decimal Quantity { get; set; }
        [DisplayName("Единицы измерения кол-ва")]
        public int QuantityUnits { get; set; }
        [DisplayName("Цена")]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        [DisplayName("Валюта")]
        public int CostUnits { get; set; }

        [StringLength(50)]
        [DisplayName("Дополнительная информация")]
        public string OtherInfo { get; set; }

        public bool InUse { get; set; }
        [DisplayName("Тип металла")]
        public virtual MetalName MetalName { get; set; }
        [DisplayName("Тип проката")]
        public virtual MetalType MetalType { get; set; }
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
