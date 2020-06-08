using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Productos {
    class InventarioDB {
        public static List<Departamento> departamentos = new List<Departamento>();
        public static List<Producto> inventario = new List<Producto>();
        public static void Guardar_Listas(string path) {
            StreamWriter textOut=null;
            try {
                textOut = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
                textOut.WriteLine(new ProductoPerecedero().txt_Header());
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
        public static void Cargar_Listas(string path, int lista) {
            StreamReader textIn=null;
            try {
                string [] campos;
                textIn = new StreamReader(new FileStream(
                    path,
                    FileMode.Open, FileAccess.Read));
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
        public static bool Contains (string code) {
            foreach (Departamento dep in departamentos)
                    return dep.serie == code;
            throw new InvalidDepartamentException();
        }
        public static Producto Contain (string code,string depa) {
            foreach (Producto prod in inventario) {
                if (prod.codigo.Contains(code) && prod.departamento.serie.Contains(depa))
                    return prod;
                }
            return null;
        }
        public static void DeployFD(int lista) {
            OpenFileDialog ventanaSelect = new OpenFileDialog();
            string path;
            ventanaSelect.Title = "Carga archivo con Inventario";
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
        public static void Consulta(DateTime B_Fec, out List<Producto> respu) {
            respu = new List<Producto>();

            foreach (Producto prod in inventario) 
                if (B_Fec == prod.precioLanzado.f_Inicio)
                    respu.Add(prod);
            
            if (respu.Count < 1)
                throw new ResultadoNuloException();
        }
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
