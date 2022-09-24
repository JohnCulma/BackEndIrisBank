using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisBanck.DataAccess.Models
{
    public partial class InformationCompanies
    {
        public int totalContactoClientes { get; set; }
        public int motivoReclamo { get; set; }
        public int motivoGarantia { get; set; }
        public int motivoDuda { get; set; }
        public int motivoCompra { get; set; }
        public int motivoFelicitaciones { get; set; }
        public int motivoCambio { get; set; }
        public int hash { get; set; }

    }
}
