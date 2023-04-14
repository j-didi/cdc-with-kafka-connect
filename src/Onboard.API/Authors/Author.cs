using System.ComponentModel.DataAnnotations;

namespace Onboard.API.Authors;

public class Author
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Cpf { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}