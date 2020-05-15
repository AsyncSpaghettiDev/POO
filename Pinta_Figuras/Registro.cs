using System;
using System.IO;
using System.Windows.Forms;
/// <summary>
/// Clase encargada de crear un registro con las figuras creadas
/// </summary>
class Registro {
    /// <summary>
    /// Escritura en el registro 
    /// </summary>
    /// <param name="fig">Figura que se dibujo</param>
    /// <param name="col">Color de la figura dibujada</param>
    public static void registrar(String fig,String col) {
        StreamWriter textOut=null;
        try {
            textOut = new StreamWriter(new FileStream("./log.txt", FileMode.Append,FileAccess.Write));
            File.SetAttributes("./log.txt", FileAttributes.Hidden);
            textOut.WriteLine("[{0}] Se dibuja un {1} de {2}", DateTime.Now.ToString("yyyy-mm-dd:hh:mm:ss"), fig, col);
        }
        catch (UnauthorizedAccessException) {
            MessageBox.Show("Excepcion de no acceso");
        }
        catch(Exception ex) {
            MessageBox.Show(ex.Message);
        }
        finally {
            if(textOut!=null)
                textOut.Close();
        }
    }
}