using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Productos {
    class InventarioDB {
        /// <summary>
        /// Lista interna que contiene todos los departamentos de la DB departamentos.
        /// </summary>
        public static List<Departamento> departamentos = new List<Departamento>();
        /// <summary>
        /// Lista interna que contiene todos los productos de la DB inventario.
        /// </summary>
        public static List<Producto> inventario = new List<Producto>();
        /// <summary>
        /// Se guarda la lista interna inventario en la DB inventario
        /// </summary>
        /// <param name="path">Ubicación de la DB inventario</param>
        public static void Guardar_Listas(string path) {
            StreamWriter textOut=null;
            try {
                textOut = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
                textOut.WriteLine(Producto.txt_Header);
                foreach (Producto cat in inventario)
                    textOut.WriteLine(cat.ToString());
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            finally {
                if (textOut != null)
                    textOut.Close();
            }
        }
        /// <summary>
        /// Carga los elementos de un DB a la lista interna correspondiente.
        /// </summary>
        /// <param name="path">Ubicación de la lista a cargar</param>
        /// <param name="lista">Identificador de la lista interna donde se cargará.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void Cargar_Listas(string path, int lista) {
            StreamReader textIn=null;
            try {
                string [] campos;
                textIn = new StreamReader(new FileStream(
                    path,
                    FileMode.Open, FileAccess.Read));
                // Se lee la primer linea y no se almacena porque en esta línea están los headers de la DB
                textIn.ReadLine();
                while (textIn.Peek() != -1) {
                    campos = textIn.ReadLine().Split('|');
                    switch (lista) {
                        case 0:
                            departamentos.Add(new Departamento(campos[0], campos[1]));
                            break;
                        case 1:
                            int [] fecha=Array.ConvertAll(campos[5].Split('/'),int.Parse);
                            if (campos[0].Contains("P"))
                                inventario.Add(new ProductoPerecedero(campos[0], campos[2], campos[3], Convert.ToDouble(campos[4]), Convert.ToDouble(campos[6]), new DateTime(fecha[2], fecha[1], fecha[0])));
                            else
                                inventario.Add(new ProductoNoPerecedero(campos[0], campos[2], campos[3], Convert.ToDouble(campos[4]), Convert.ToDouble(campos[6]), new DateTime(fecha[2], fecha[1], fecha[0])));
                            break;
                    }
                }
            }
            catch (FileNotFoundException) {
                DeployFD(lista);
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            finally {
                if (textIn != null)
                    textIn.Close();
            }
        }
        /// <summary>
        /// Determina si un departamento está en la lista interna departamentos.
        /// </summary>
        /// <param name="code">Codigo del departamento a evaluar.</param>
        /// <returns>En caso de no existir se lanza una excepción.</returns>
        /// <exception cref="InvalidDepartamentException"></exception>
        public static bool Contains (string code) {
            foreach (Departamento dep in departamentos)
                    return dep.serie == code;
            throw new InvalidDepartamentException();
        }
        /// <summary>
        /// Determina si un producto existe en la lista interna inventario.
        /// </summary>
        /// <param name="code">Codigo del producto a evaluar.</param>
        /// <param name="depa">Codigo del departamento del producto a evaluar</param>
        /// <returns>Un producto de la lista interna.</returns>
        public static Producto Contain (string code,string depa) {
            foreach (Producto prod in inventario) {
                if (prod.codigo.Contains(code) && prod.departamento.serie.Contains(depa))
                    return prod;
                }
            return null;
        }
        /// <summary>
        /// Despliega una ventana para cargar una DB.
        /// </summary>
        /// <param name="lista">Identificador de lista interna a cargar</param>
        public static void DeployFD(int lista) {
            OpenFileDialog ventanaSelect = new OpenFileDialog();
            string path;
            ventanaSelect.Title = "Carga archivo de Base de Datos";
            ventanaSelect.InitialDirectory = @"%userprofile%\Desktop";
            ventanaSelect.Filter = "Database files (*.txt)|*.txt";
            ventanaSelect.FilterIndex = 0;

            if (lista == 0)
                path = "./Departamentos.txt";
            else
                path = "./Inventario.txt";

            if (ventanaSelect.ShowDialog() == DialogResult.OK)
                File.WriteAllText(path, File.ReadAllText(ventanaSelect.FileName));

            Cargar_Listas(path, lista);
        }
        /// <summary>
        /// Consulta a la DB Inventarios evaluando la fecha.
        /// </summary>
        /// <param name="B_Fec">Fecha que se comparará</param>
        /// <param name="respu">Lista que contendrá los resultados.</param>
        /// <exception cref="ResultadoNuloException"></exception>
        public static void Consulta(DateTime B_Fec, out List<Producto> respu) {
            respu = new List<Producto>();

            foreach (Producto prod in inventario) 
                if (B_Fec == prod.precioLanzado.f_Inicio)
                    respu.Add(prod);
            
            if (respu.Count < 1)
                throw new ResultadoNuloException();
        }
        /// <summary>
        /// Consulta a la DB inventario evaluando el código del Departamento o el código del producto.
        /// </summary>
        /// <param name="Busqueda">Código del Departamento o Código del producto a evaluar.</param>
        /// <param name="respu">Lista de resultados.</param>
        /// <exception cref="ResultadoNuloException"></exception>
        public static void Consulta(String Busqueda, out List<Producto> respu) {
            respu = new List<Producto>();

            foreach (Producto prod in inventario) 
                if (Busqueda == prod.departamento.serie || Busqueda == prod.codigo)
                    respu.Add(prod);
            
            if (respu.Count < 1)
                throw new ResultadoNuloException();
        }

    }
}
