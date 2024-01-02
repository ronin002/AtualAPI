
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{
    public class Ambiente
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [ForeignKey("Montagem")]
        public Guid MontagemId { get; set; }
        public string Descricao { get; set; }
        public int QtdItems { get; set; }
        public string Details { get; set; }
        public DateTime DataInicioPrev { get; set; }
        public DateTime DataInicioReal { get; set; }
        public DateTime DataTerminoPrev { get; set; }
        public DateTime DataTerminoReal { get; set; }

        public DateTime DataVistoria { get; set; }
        public string RelatorioVistoria { get; set; }
        public string URLImgVistoria { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
