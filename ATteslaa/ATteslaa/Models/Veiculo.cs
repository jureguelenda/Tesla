//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATteslaa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Veiculo
    {
        public Veiculo()
        {
            this.Modelo = new HashSet<Modelo>();
        }
    
        public int CODIGO { get; set; }
        public string DESCRICAO { get; set; }
        public int VALOR { get; set; }
        public int CODIGMODELO { get; set; }
    
        public virtual ICollection<Modelo> Modelo { get; set; }
    }
}
