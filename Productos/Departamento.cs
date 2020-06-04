using System;

namespace Productos {
    class Departamento {
        private string _serie;
        public string serie {
            get => this._serie;
            set {
                foreach (Departamento serial in InventarioDB.departamentos) {
                    if (serial.serie==value) {
                        this._serie = value;
                        this.tipo = serial.tipo;
                    }
                }
            }
        }
        private string _tipo;
        public string tipo {
            set => this._tipo = value;
            get {
                if (this._tipo != null)
                    return this._tipo;
                else
                    throw new InvalidDepartamentException();
            }
        }
        public Departamento() { }
        public Departamento(string serie,string tipo) {
            this._serie = serie;
            this.tipo = tipo;
        }
        public Departamento(string serie) {
            this.serie = serie;
        }
        public override string ToString() => String.Format("{0}|{1}",this.serie,this.tipo);
    }
}
