using Microsoft.AspNetCore.Identity;

namespace TodoApp.Core.Domain
{
    public class User : IdentityUser
    {
        public new Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
