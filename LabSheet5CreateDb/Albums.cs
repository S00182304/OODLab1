//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabSheet5CreateDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Albums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Released { get; set; }
        public string Sales { get; set; }
        public string AlbumImage { get; set; }
        public int BandsId { get; set; }
    
        public virtual Bands Band { get; set; }
    }
}
