using System;
using System.IO;
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
                    path=".././Departamentos.txt";
                    break;
                case 1:
                   path="../../Inventario.txt";
                    break;
            }
            cargar_Listas(path, lista);
        }
        private static void cargar_Listas(string path,int lista) {
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
                            departamentos.Add (new Departamento(campos[0], campos[1]) );
                            break;
                    }
                }
            }
            catch (FileNotFoundException) {
                OpenFileDialog ventanaSelect = new OpenFileDialog();

                ventanaSelect.InitialDirectory = @"%userprofile%\Desktop";
                ventanaSelect.Filter = "Database files (*.txt)|*.txt";
                ventanaSelect.FilterIndex = 0;

                if (ventanaSelect.ShowDialog() == DialogResult.OK || ventanaSelect.ShowDialog() == DialogResult.Yes)
                    cargar_Listas(ventanaSelect.FileName, lista);
                else if(ventanaSelect.ShowDialog()==DialogResult.No|| ventanaSelect.ShowDialog() == DialogResult.Cancel || ventanaSelect.ShowDialog() == DialogResult.Abort || ventanaSelect.ShowDialog() == DialogResult.Ignore)
                    Application.Exit();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
            finally {
                if (textIn != null)
                    textIn.Close();
            }
        }
    }
}
