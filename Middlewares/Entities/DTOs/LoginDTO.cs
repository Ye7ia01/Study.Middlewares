using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Middlewares.Entities.DTOs
{
    public class LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        [MinLength(3)]
        [NotNull]
        public string email{ get; set; }
        [MinLength(3)]
        [NotNull]
        public string password { get; set; }
    }
}
