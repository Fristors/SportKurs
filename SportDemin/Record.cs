//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportDemin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public int id { get; set; }
        public int idNameSport { get; set; }
        public int idUnitSport { get; set; }
        public double WorldRecord { get; set; }
        public System.DateTime Date { get; set; }
        public string FullName { get; set; }
    
        public virtual NameSport NameSport { get; set; }
        public virtual UnitSport UnitSport { get; set; }
    }
}