using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebAPI_TransportesVeloso.Models
{
    [Table("TD_Perfil_Usuario")]
    public class PerfilUsuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerfilUsuario { get; set; }
        public string Descricao { get; set; }

        #region[Relacionamento 1:N]
        /*Indica ao Entity Framework que existe um relacionamento de 
         1: N entre a entidade Filial e as demais classes abaixo*/
        [JsonIgnore]
        public virtual List<Usuario> Usuario { get; set; }
        #endregion

    }
}