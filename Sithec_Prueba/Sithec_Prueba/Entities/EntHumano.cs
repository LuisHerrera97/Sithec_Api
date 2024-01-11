using System.ComponentModel.DataAnnotations.Schema;

namespace Sithec_Prueba.Entities
{
    [Table("Humano")]
    public class EntHumano
    {
        public Guid? Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}
