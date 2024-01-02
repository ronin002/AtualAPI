
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{
    public class ReportIncidente
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [ForeignKey("Montagem")]
        public Guid MontagemId { get; set; }

        [ForeignKey("Ambiente")]
        public Guid AmbienteId { get; set; }
        public string Descricao { get; set; }

        public DateTime DataOcorrencia { get; set; }
        public string RelatorioOcorrenciaSolucao { get; set; }
        public string URLImgOcorrencia { get; set; }

        public DateTime DataSolucao { get; set; }
        public string RelatorioSolucao { get; set; }
        public string URLImgSolucao { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
