using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Productos {
    class InventarioDB {
        public static List<Departamento> departamentos = new List<Departamento>();
        public static List<Producto> inventario = new List<Producto>();
        public static void Listas(int lista,bool CG) {
            string path=null;
            switch (lista) {
                case 0:
                    if(!File.Exists("./Departamentos.txt") )
                        File.WriteAllText("./Departamentos.txt", Properties.Resources.Departamentos);
                    path = "./Departamentos.txt";
                    break;
                case 1:
                    path = "./Inventario.txt";
                    break;
            }
            if(CG)
                cargar_Listas(path, lista);
            else
                guardar_Listas(path, lista);
        }
        static void guardar_Listas(string path,int lista) {
            StreamWriter textOut=null;
            try {
                textOut = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
                textOut.WriteLine(new ProductoPerecedero().txt_Header());
                foreach (Producto cat in inventario)
                    textOut.WriteLine(cat.ToString());
            }
            catch (FileNotFoundException) {
                deployFD(lista);
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            finally {
                if (textOut != null)
                    textOut.Close();
            }
        }
        static void cargar_Listas(string path, int lista) {
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
                deployFD(lista);
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
                if (dep.serie == code)
                    return true;
            throw new InvalidDepartamentException();
        }
        public static Producto Contain (string code,string depa) {
            foreach (Producto prod in inventario) {
                if (prod.codigo.Contains(code) && prod.departamento.serie.Contains(depa))
                    return prod;
                }
            return null;
        }
        static void deployFD(int lista) {
            OpenFileDialog ventanaSelect = new OpenFileDialog();

            ventanaSelect.InitialDirectory = @"%userprofile%\Desktop";
            ventanaSelect.Filter = "Database files (*.txt)|*.txt";
            ventanaSelect.FilterIndex = 0;

            if (ventanaSelect.ShowDialog() == DialogResult.OK)
                cargar_Listas(ventanaSelect.FileName, lista);
        }
    }
}
