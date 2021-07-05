using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaMicroservice.CRUD.Models
{
    public partial class CargaBipRetail
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Entidad { get; set; }
        public string NombreFantasia { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string HorarioReferencial { get; set; }
        public int Este { get; set; }
        public int Norte { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
    }
}
