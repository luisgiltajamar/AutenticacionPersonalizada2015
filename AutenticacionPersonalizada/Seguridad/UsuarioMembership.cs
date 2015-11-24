﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using AutenticacionPersonalizada.Models;
using AutenticacionPersonalizada.Utilidades;

namespace AutenticacionPersonalizada.Seguridad
{
  public class UsuarioMembership:MembershipUser
    {
        public int id { get; set; }
        public string login { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string imagen { get; set; }
        public String Rol { get; set; }
         public override String Email { get; set; }
      public UsuarioMembership(Usuario us)
      {
          var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
          id = us.id;
          nombre = us.nombre;
          apellidos = us.apellidos;
          imagen = us.imagen;
          Rol = us.Rol.nombre;
          Email =SeguridadUtilidades.
                DesCifrar(Convert.FromBase64String(us.email),clave);
          login = us.login;
      }

    }
}
