//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadConsultorioOdontologico
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cita
    {
        public int id { get; set; }
        public int idPaciente { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string tratamiento { get; set; }
        public decimal pago { get; set; }
        public string usuarioRegistro { get; set; }
        public System.DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    
        public virtual Paciente Paciente { get; set; }
    }
}