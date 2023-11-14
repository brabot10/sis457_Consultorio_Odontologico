using CadConsultorioOdontologico;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnConsultorioOdontologico
{
    public class UsuarioCln
    {
            public static Usuario validar(string usuario, string clave)
            {
                using (var context = new LabConsultorioOdontologicoEntities())
                {
                    return context.Usuario
                        .Where(x => x.usuario1 == usuario && x.clave == clave)
                        .FirstOrDefault();
                }
            }
        }
}
