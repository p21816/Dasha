//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransfersHistory
    {
        public int id { get; set; }
        public Nullable<int> fromId { get; set; }
        public int toId { get; set; }
        public int playerId { get; set; }
        public System.DateTime transferDate { get; set; }
        public decimal price { get; set; }
    
        public virtual FootballClub FootballClub { get; set; }
        public virtual FootballClub FootballClub1 { get; set; }
        public virtual Player Player { get; set; }
    }
}