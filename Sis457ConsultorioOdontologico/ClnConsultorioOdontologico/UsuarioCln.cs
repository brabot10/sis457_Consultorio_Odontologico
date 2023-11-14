﻿using CadConsultorioOdontologico;
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
        public static int insertar(Usuario usuario)
        {
            using (var context = new LabConsultorioOdontologicoEntities())
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return usuario.id;
            }
        }

        public static int actualizar(Usuario usuario)
        {
            using (var context = new LabConsultorioOdontologicoEntities())
            {
                var existente = context.Usuario.Find(usuario.id);
                existente.usuario1 = usuario.usuario1;
                existente.clave = usuario.clave;
                existente.usuarioRegistro = usuario.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabConsultorioOdontologicoEntities())
            {
                var existente = context.Usuario.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Usuario get(int id)
        {
            using (var context = new LabConsultorioOdontologicoEntities())
            {
                return context.Usuario.Find(id);
            }
        }

        public static List<Usuario> listar()
        {
            using (var context = new LabConsultorioOdontologicoEntities())
            {
                return context.Usuario.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paUsuarioListar_Result> listarPa(string parametro)
        {
            using (var context = new LabConsultorioOdontologicoEntities())
            {
                return context.paUsuarioListar(parametro).ToList();
            }
        }
    }
}
