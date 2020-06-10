using System;
using System.Collections.Generic;

namespace Productos {
    /// <summary>
    /// Definicion de un precio con limite de tiempo
    /// </summary>
    abstract class PrecioFecha {
        /// <summary>
        /// Obtiene o establece la fecha de inicio del costo del producto.
        /// </summary>
        public DateTime f_Inicio { get; set; }
        /// <summary>
        /// Obtiene o establece la fecha de fin del costo del producto.
        /// </summary>
        public DateTime f_Fin { get; set; }
        /// <summary>
        /// Obtiene o establece el costo del producto.
        /// </summary>
        public double precio { get; set; } 
        /// <summary>
        /// Intanciación vacia.
        /// </summary>
        public PrecioFecha() { }
        public PrecioFecha(DateTime f_Inicio, double precio) {
            this.f_Inicio = f_Inicio;
            this.precio = precio;
        }
        /// <summary>
        /// Establece la fecha final aumentando en una cierta cantidad de dias la fecha inicial.
        /// </summary>
        /// <param name="dias">Dias que tiene el producto antes de pasar al siguiente estado.</param>
        protected void Aumenta(double dias) => this.f_Fin = f_Inicio.AddDays(dias);
        
    }
    /// <summary>
    /// Definicion de producto, no se puede instanciar.
    /// </summary>
    abstract class Producto{
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
        /// <summary>
        /// Lista interna con todos los precios pertenecientes al producto.
        /// </summary>
        protected List<PrecioFecha> _precios;
        /// <summary>
        /// Lista de precios cambiantes al tiempo
        /// </summary>
        /// <exception cref="ProductoSinVidaException"></exception>
        public PrecioFecha precios {
            set {
                /* 
                 * Al momento de registrar un nuevo precio se limpia la lista interna de precios para evitar 
                 * problemas cuando se quiera actualizar un artículo.
                 */
                this._precios.Clear();
                /*
                 * Se añade el valor dado a la lista interna de precios y dependiendo del tipo de dato que sea 
                 * el ingresado se rellenará la lista con ese tipo dato.
                 * En el caso de producto perecedero se rellena la lista con precios perecederos con 15 dias de duración.
                 * En el caso de ser producto no perecedero se rellenan con precios con vida de 1 año.
                 */
                this._precios.Add(value);
                if (value is PrecioFechaP)
                    for (int i = 1 ; i < 3 ; i++)
                        this._precios.Add(new PrecioFechaP(this._precios[i - 1].f_Fin, this._precios[i - 1].precio * 0.90));
                else if (value is PrecioFechaNP)
                    for (int i = 1 ; i < 3 ; i++)
                        this._precios.Add(new PrecioFechaNP(this._precios[i - 1].f_Fin, this._precios[i - 1].precio));
            }
            get {
                /*
                 * En caso que la fecha actual sea menor a la fecha final de un precio se devuelve ese precios
                 * en caso de no ser así se lanza una excepción en la que se dice que el producto ya caducó.
                 */ 
                  foreach (PrecioFecha costo in this._precios)
                      if (costo.f_Fin > DateTime.Now)
                          return costo;
                  throw new ProductoSinVidaException();
            }
        }
        /// <summary>
        /// Obtiene el primer precioFecha registrado en la lista.
        /// </summary>
        public PrecioFecha precioLanzado  => this._precios[0];
        
        /// <summary>
        /// Creacion de un producto generico
        /// </summary>
        /// <param name="departamento">Departamento al que pertence el producto</param>
        /// <param name="codigo">Codigo del producto</param>
        /// <param name="descripcion">Descripción del producto</param>
        /// <param name="likes">Valoración dada por el público</param>
        public Producto(string departamento, string codigo, string descripcion, double likes) {
            this._precios = new List<PrecioFecha>();
            this.departamento = new Departamento(departamento);
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.likes = likes;
        }
        /// <summary>
        /// Devuelve una cadena con toda la información del producto.
        /// </summary>
        /// <returns>Info general de producto.</returns>
        public override string ToString() => String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", 
            this.departamento,this.codigo, this.descripcion, this.likes,
            this._precios[0].f_Inicio.ToString("dd/MM/yyyy"),this._precios[0].precio,
            this._precios[1].f_Inicio.ToString("dd/MM/yyyy"), this._precios[1].precio,
            this._precios[2].f_Inicio.ToString("dd/MM/yyyy"), this._precios[2].precio,this._precios[2].f_Fin.ToString("dd/MM/yyyy"));
        /// <summary>
        /// Obtiene todos los headers que corresponden a la información del producto.
        /// </summary>
        public static string txt_Header => 
            String.Format("CodigoDepartamento|Departamento|Codigo|Descripcion|Likes|FechaLanzamiento|PrecioLanzamiento|FechaMadurez|PrecioMadurez|FechaMerma|PrecioMerma|FechaMuerte");
    }
}