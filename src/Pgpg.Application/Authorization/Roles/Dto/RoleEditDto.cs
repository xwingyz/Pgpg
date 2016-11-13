using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Pgpg.Core.Authorization.Roles;

namespace Pgpg.Application.Authorization.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }
        
        public bool IsDefault { get; set; }
    }
}