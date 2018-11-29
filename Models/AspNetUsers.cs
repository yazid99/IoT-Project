using System;
using System.Collections.Generic;

namespace sirmoto
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Employees = new HashSet<Employees>();
            SirmotoDevices = new HashSet<SirmotoDevices>();
            Transactions = new HashSet<Transactions>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual  Companies Companies { get; set; }
        public virtual  ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual  ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual  ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual  ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual  ICollection<Employees> Employees { get; set; }
        public virtual  ICollection<SirmotoDevices> SirmotoDevices { get; set; }
        public virtual  ICollection<Transactions> Transactions { get; set; }
    }
}
