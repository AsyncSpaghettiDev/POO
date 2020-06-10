using System;

namespace Productos {
    /// <summary>
    /// Departamento de una tienda.
    /// </summary>
    class Departamento {
        /// <summary>
        /// Código de departamento.
        /// </summary>
        private string _serie;
        /// <summary>
        /// Obtiene o establece el código númerico departamento
        /// </summary>
        public string serie {
            get => this._serie;
            set {
                foreach (Departamento serial in InventarioDB.departamentos)
                    if (serial.serie==value) {
                        this._serie = value;
                        this.tipo = serial.tipo;
                    }
            }
        }
        /// <summary>
        /// Nombre del departamento.
        /// </summary>
        private string _tipo;
        /// <summary>
        /// Obtiene o establece el nombre del departamento.
        /// </summary>
        /// <exception cref="InvalidDepartamentException"></exception>
        public string tipo {
            set => this._tipo = value;
            get {
                if (this._tipo != null)
                    return this._tipo;
                else
                    throw new InvalidDepartamentException();
            }
        }
        /// <summary>
        /// Creación de un departamento nuevo.
        /// </summary>
        /// <param name="serie">Código del departamento.</param>
        /// <param name="tipo">Nombre del departamento.</param>
        public Departamento(string serie,string tipo) {
            this._serie = serie;
            this.tipo = tipo;
        }
        /// <summary>
        /// Asignación de un departamento a un producto.
        /// </summary>
        /// <param name="serie">Código del departamento a asignar.</param>
        public Departamento(string serie) {
            this.serie = serie;
        }
        public override string ToString() => String.Format("{0}|{1}", this.serie, this.tipo);
    }
}
