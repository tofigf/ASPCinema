//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaAddMultiple.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FillmGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int FilmId { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Film Film { get; set; }
    }
}
