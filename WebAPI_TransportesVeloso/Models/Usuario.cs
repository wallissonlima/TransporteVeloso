﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }
    }
}