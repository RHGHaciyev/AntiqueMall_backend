﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AntiqueMall.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AnticDataEntities : DbContext
    {
        public AnticDataEntities()
            : base("name=AnticDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aboutf> Aboutfs { get; set; }
        public virtual DbSet<Adminsp> Adminsps { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BotText> BotTexts { get; set; }
        public virtual DbSet<box> boxes { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<fsecslide> fsecslides { get; set; }
        public virtual DbSet<information> information { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Most_given_questions> Most_given_questions { get; set; }
        public virtual DbSet<Order_s> Order_s { get; set; }
        public virtual DbSet<Paragraph> Paragraphs { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Product_tags> Product_tags { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<select> selects { get; set; }
        public virtual DbSet<selectclock> selectclocks { get; set; }
        public virtual DbSet<selectShop> selectShops { get; set; }
        public virtual DbSet<selectTableware> selectTablewares { get; set; }
        public virtual DbSet<Send_question> Send_question { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<StartSelling> StartSellings { get; set; }
        public virtual DbSet<Submenu> Submenus { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<vaseselect> vaseselects { get; set; }
    }
}
