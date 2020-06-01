using System;

namespace Productos {
    class PrecioFechaP:PrecioFecha {
        public PrecioFechaP(DateTime f_Inicio, double precio) : base(f_Inicio,precio) {
            Aumenta(15);
        }
    }
    class PrecioFechaNP : PrecioFecha {
        public PrecioFechaNP(DateTime f_Inicio, double precio) : base(f_Inicio, precio) {
            Aumenta(25);
        }
    }
}
