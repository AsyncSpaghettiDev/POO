using System;
using System.IO;
using System.Windows.Forms;

namespace Productos {
    partial class Pantalla_Inicial:Form {
        public Pantalla_Inicial() {
            Funciones.Diseno(this, 600, 400, "Control de Inventarios 2.2.0", "FLogo");
            iniciaComponentes();
            cargaList();
        }
        void cargaList() {
            if (!File.Exists("./Departamentos.txt"))
                File.WriteAllText("./Departamentos.txt", Properties.Resources.Departamentos);

            InventarioDB.departamentos.Clear();
            InventarioDB.Cargar_Listas(this.p_Dep.Text, 0);

            if (!File.Exists("./Inventario.txt"))
                File.Create("./Inventario.txt").Close();

            InventarioDB.inventario.Clear();
            InventarioDB.Cargar_Listas(this.p_Inv.Text, 1);
        }
    }
}
