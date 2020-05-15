using System;
using System.IO;
/*Excepcion que indica que el archivo ya existe*/
class ArchivoExistenteException:Exception{
    public ArchivoExistenteException():base("El archivo ya existe"){
    }
}
/*Clase que se encargará de crear,leer y modificar los txt*/
class Registro{
    /*Comprobacion de que el archivo existe, de ser asi se lanza una excepcion que
    indica que el archivo ya existe, se cierra la conexion con el archivo despues*/
    public static void crea(String name){
        FileStream fs=null;
        if(File.Exists("./"+name+".txt"))
            throw new ArchivoExistenteException();
            else fs= File.Create("./"+name+".txt");
        if(fs!=null)
            fs.Close();
    }
    /*Se imprime en consola todo el contenido del archivo txt seleccionado, en caso de excepcion se
    muestra en consola cual es, finalmente si se abrió la conexion con el archivo se cierra*/
    public static void leer(string name){
        StreamReader textIn=null;
        try{
            textIn= new StreamReader(new FileStream("./"+name+".txt",FileMode.Open,FileAccess.Read));
            while(textIn.Peek()!=-1){
                Console.WriteLine(textIn.ReadLine());
            }
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            if(textIn!=null)
            textIn.Close();
        }
    }
    /*Se crea una conexion y se lee de consola la linea que se quiere añadir al archivo
    si la conexion fue exitosa se cierra*/
    public static void escribe(String name){
        StreamWriter textOut=null;
        try{
            textOut= new StreamWriter(new FileStream("./"+name+".txt",FileMode.Append));
            textOut.WriteLine(Console.ReadLine());
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            if (textOut!=null)
                textOut.Close();
        }
    }
}
class Program{
    static void Main(){
        int i=0;
        do{
            Console.WriteLine("MENU Archivo de Text con Flujos de Bytes\na)Crear archivo\nb)Leer archivo\nc)Cierra el programa");
            switch (Console.ReadLine().ToLower()){
                case "a":
                    Console.Write("Ingresa el nombre del archivo: ");
                    string temp_name=Console.ReadLine();
                    try{
                        Registro.crea(temp_name);
                        Console.WriteLine("¿Deseas editarlo? (Si=Presiona Y, No= presiona otra letra para regresar al menu)");
                        if(Console.ReadLine().ToLower().Equals("y")){
                            Registro.escribe(temp_name);
                            break;
                        }
                            else break;
                    }
                    catch( ArchivoExistenteException){
                        Console.WriteLine("El archivo ya existe, elige otro nombre");
                        goto case "a";
                    }
                    
                case "b":
                    Console.Write("Escribe el nombre del archivo a leer: ");
                    temp_name= Console.ReadLine();
                    Console.WriteLine("----------------------------");
                    Registro.leer(temp_name);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("¿Deseas editarlo? (Si=Presiona Y, No= presiona otra letra para regresar al menu)");
                        if(Console.ReadLine().ToLower().Equals("y")){
                            Registro.escribe(temp_name);
                            break;
                        }
                            else break;

                case "c":
                    i=-1;
                break;

                default:
                Console.WriteLine("Tecla incorrecta");
                break;
            }
        }
        while(i!=-1);
    }
}
