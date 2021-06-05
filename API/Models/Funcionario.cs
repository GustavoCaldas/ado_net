using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Cpf { get; set; }

        public Funcionario(int id, string name, int age, string cpf)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Cpf = cpf;
        }
    }
}