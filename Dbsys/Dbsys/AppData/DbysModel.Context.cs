﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dbsys.AppData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class DBSYSEntities : DbContext
    {
        public DBSYSEntities()
            : base("name=DBSYSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Role> Role { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<vw_all_user_role> vw_all_user_role { get; set; }
    
        public virtual int SP_NewUser(string username, string password, Nullable<int> creator)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var creatorParameter = creator.HasValue ?
                new ObjectParameter("creator", creator) :
                new ObjectParameter("creator", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_NewUser", usernameParameter, passwordParameter, creatorParameter);
        }
    
        public virtual int SP_NewUser1(string username, string password, Nullable<int> creator, Nullable<int> roleId)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var creatorParameter = creator.HasValue ?
                new ObjectParameter("creator", creator) :
                new ObjectParameter("creator", typeof(int));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("roleId", roleId) :
                new ObjectParameter("roleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_NewUser1", usernameParameter, passwordParameter, creatorParameter, roleIdParameter);
        }
    }
}
