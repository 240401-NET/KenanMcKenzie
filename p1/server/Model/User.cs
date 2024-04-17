using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace server.Model;

public partial class User : IdentityUser
{
    [MaxLength(50)]
    public string Name { get; set; }
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
