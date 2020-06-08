using System;
using System.Collections.Generic;

namespace Productos {
    /// <summary>
    /// Devuelve un string con los headers de los atributos del producto.
    /// </summary>
    interface IHeader {
        /// <summary>
        /// Metodo que regresa los headers correspondientes al objeto.
        /// </summary>
        /// <returns>Headers en String</returns>
        string txt_Header();
    }
    /// <summary>
    /// Definicion de un precio con limite de tiempo
    /// </summary>
    abstract class PrecioFecha:IHeader {
        /// <summary>
        /// Obtiene o establece la fecha de inicio del costo del producto.
        /// </summary>
        public DateTime f_Inicio { get; set; }
        protected DateTime _f_Fin;
        /// <summary>
        /// Obtiene o establece la fecha de fin del costo del producto.
        /// </summary>
        public DateTime f_Fin {
            get => this._f_Fin;
        }
        /// <summary>
        /// Obtiene o establece el costo del producto.
        /// </summary>
        public double precio { get; set; } 
        public PrecioFecha() { }
        public PrecioFecha(DateTime f_Inicio, double precio) {
            this.f_Inicio = f_Inicio;
            this.precio = precio;
        }
        /// <summary>
        /// Establece la fecha final aumentando en una cierta cantidad de dias la fecha inicial.
        /// </summary>
        /// <param name="dias">Dias que tiene el producto antes de pasar al siguiente estado.</param>
        protected void Aumenta(double dias) => this._f_Fin = f_Inicio.AddDays(dias);
        string IHeader.txt_Header() => String.Format("Fecha_Inicio|Fecha_Fin|Precio");
        
    }
    /// <summary>
    /// Definicion de producto, no se puede instanciar.
    /// </summary>
    abstract class Producto :IHeader{
        /// <summary>
        /// Obtiene o establece al departamento que pertenece el producto
        /// </summary>
        public Departamento departamento { get; set; }
        /// <summary>
        /// Obtiene o establece el codigo el producto registrado
        /// </summary>
        public string codigo { get; set; }
        /// <summary>
        /// Obtiene o establece la descripcion del producto a registrado
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Obtiene o establece la puntuacion dada del publico al producto
        /// </summary>
        public double likes { get; set; }
        protected List<PrecioFecha> _precios;
        /// <summary>
        /// Lista de precios cambiantes al tiempo
        /// </summary>
        public PrecioFecha precios {
            set {
                this._precios.Clear();
                this._precios.Add(value);
                if (value is PrecioFechaP)
                    for (int i = 1 ; i < 3 ; i++)
                        this._precios.Add(new PrecioFechaNP(this._precios[i - 1].f_Fin, this._precios[i - 1].precio * 0.90, i * 15));
                else if (value is PrecioFechaNP)
                    for (int i = 1 ; i < 3 ; i++)
                        this._precios.Add(new PrecioFechaP(this._precios[i - 1].f_Fin, this._precios[i - 1].precio , i *365 ));
            }
            get {
                if( this._precios.Equals(new PrecioFechaNP() ) ) {
                    foreach (PrecioFecha costo in this._precios)
                        if (costo.f_Fin > DateTime.Now)
                            return costo;
                    throw new ProductoSinVidaException();
                }
                else {
                    throw new ProductoNoPerecederoException();
                }
            }
        }
        public PrecioFecha precioLanzado {
            get => this._precios[0];
        }
        /*Sobrecarga de constructor*/
        public Producto() { }
        /// <summary>
        /// Creacion de un producto generico
        /// </summary>
        /// <param name="departamento">Departamento al que pertence el producto</param>
        /// <param name="codigo">Codigo del producto</param>
        /// <param name="descripcion"></param>
        /// <param name="likes"></param>
        /// <param name="precioBase"></param>
        public Producto(string departamento, string codigo, string descripcion, double likes) {
            this._precios = new List<PrecioFecha>();
            this.departamento = new Departamento(departamento);
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.likes = likes;
        }
        public override string ToString() => String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", 
            this.departamento,this.codigo, this.descripcion, this.likes,
            this._precios[0].f_Inicio.ToString("dd/MM/yyyy"),this._precios[0].precio,
            this._precios[1].f_Inicio.ToString("dd/MM/yyyy"), this._precios[1].precio,
            this._precios[2].f_Inicio.ToString("dd/MM/yyyy"), this._precios[2].precio,this._precios[2].f_Fin.ToString("dd/MM/yyyy"));
        public string txt_Header() => String.Format("CodigoDepartamento|Departamento|Codigo|Descripcion|Likes|FechaLanzamiento|PrecioLanzamiento|FechaMadurez|PrecioMadurez|FechaMerma|PrecioMerma|FechaMuerte");
    }
}