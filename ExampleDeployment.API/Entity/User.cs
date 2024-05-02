using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleDeployment.API.Entity
{
    [Table("tbl_User")]
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
