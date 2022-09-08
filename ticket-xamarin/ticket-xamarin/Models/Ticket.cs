using SQLite;
using System;

namespace ticket_xamarin.Models
{
    public class Ticket
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Cedula { get; set; }

        [MaxLength(50)]
        public string NameCompleto { get; set; }

        [MaxLength(50)]
        public string Origen { get; set; }

        [MaxLength(50)]
        public string Destino { get; set; }

        [MaxLength(50)]
        public string Precio { get; set; }

        [MaxLength(6)]
        public string Cantidad { get; set; }

        [MaxLength(6)]
        public string Iva { get; set; }
        
        [MaxLength(6)]
        public string TotPagar { get; set; }
    }
}