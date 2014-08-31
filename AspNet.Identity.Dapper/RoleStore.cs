using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AspNet.Identity.Dapper
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity role store iterfaces
    /// </summary>
    public class RoleStore<TRole> : IQueryableRoleStore<TRole,int>
        where TRole : IdentityRole
    {
        private RoleTable roleTable;
        public DbManager Database { get; private set; }
        public IQueryable<TRole> Roles
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Default constructor that initializes a new database
        /// instance using the Default Connection string
        /// </summary>
        public RoleStore()
        {
            new RoleStore<TRole>(new DbManager(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
        }

        /// <summary>
        /// Constructor that takes a dbmanager as argument 
        /// </summary>
        /// <param name="database"></param>
        public RoleStore(DbManager database)
        {
            Database = database;
            roleTable = new RoleTable(database);
        }

        public Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            roleTable.Insert(role);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            roleTable.Delete(role.Id);

            return Task.FromResult<Object>(null);
        }

        public Task<TRole> FindByIdAsync(int roleId)
        {
            TRole result = roleTable.GetRoleById(roleId) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task<TRole> FindByNameAsync(string roleName)
        {
            TRole result = roleTable.GetRoleByName(roleName) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            roleTable.Update(role);

            return Task.FromResult<Object>(null);
        }

        public void Dispose()
        {
            if (Database != null)
            {
                Database.Dispose();
                Database = null;
            }
        }

    }
}
