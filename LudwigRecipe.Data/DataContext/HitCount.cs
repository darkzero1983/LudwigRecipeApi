//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LudwigRecipe.Data.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class HitCount
    {
        public int Id { get; set; }
        public System.DateTime HitDate { get; set; }
        public string Ip { get; set; }
        public Nullable<int> RecipeId { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
