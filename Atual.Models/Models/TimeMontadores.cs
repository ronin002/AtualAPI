
using Atual.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{
    public class TimeMontadores
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public string NameTime { get; set; }

        [ForeignKey("Funcionario")]
        public Guid FuncionarioId { get; set; }
        public ELevelMontador LevelMontador { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
