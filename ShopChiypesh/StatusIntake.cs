//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopChiypesh
{
    using System;
    using System.Collections.Generic;
    
    public partial class StatusIntake
    {
        public StatusIntake()
        {
            this.ProductIntakeProduct = new HashSet<ProductIntakeProduct>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ProductIntakeProduct> ProductIntakeProduct { get; set; }
    }
}
