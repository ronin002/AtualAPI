
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{

    public class Address
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }


        [ForeignKey("Element")]
        public Guid ElementId { get; set; }


        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

    }
}
