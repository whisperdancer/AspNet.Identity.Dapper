using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.Dapper
{
    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IRole interface 
    /// </summary>
    public class IdentityRole : IRole<int>
    {
        /// <summary>
        /// Default constructor for Role 
        /// </summary>
        public IdentityRole()
        {
          //  Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Constructor that takes names as argument 
        /// </summary>
        /// <param name="name"></param>
        public IdentityRole(string name) : this()
        {
            Name = name;
        }

        public IdentityRole(string name, int id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Role ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; }
    }
}
