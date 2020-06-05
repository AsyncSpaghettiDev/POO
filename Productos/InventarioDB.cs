using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Productos {
    class InventarioDB {
        public static List<Departamento> departamentos = new List<Departamento>();
        public static List<Producto> inventario = new List<Producto>();
        public static void Cargar_Listas(int lista) {
            string path=null;
            switch (lista) {
                case 0:
                    path = "../../Departamentos.txt";
                    break;
                case 1:
                    path = "../../Inventario.txt";
                    break;
            }
            cargar_Listas(path, lista);
        }
        private static void cargar_Listas(string path, int lista) {
            StreamReader textIn=null;
            try {
                string [] campos;

                textIn = new StreamReader(new FileStream(
                    path,
                    FileMode.Open, FileAccess.Read));

                while (textIn.Peek() != -1) {
                    campos = textIn.ReadLine().Split('|');
                    switch (lista) {
                        case 0:
                            departamentos.Add(new Departamento(campos[0], campos[1]));
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
        public static Producto Contain (string code) {
            foreach (Producto prod in inventario)
                if (prod.codigo == code)
                    return prod;
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
