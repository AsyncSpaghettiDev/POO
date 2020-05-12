using System;

class Program{
    static void Main(){
        Console.Write("Captura tu edad: ");
        String edad_capturada= Console.ReadLine();
        short edad=-1;
        bool conexion= true;
        try{
        edad = Int16.Parse(edad_capturada);
        }
        catch(FormatException FormaE){
            Console.WriteLine(FormaE.Message);
        }
        catch(Exception){
            Console.WriteLine("Error al capturar");
        }
        finally{
            conexion=false;
        }

        if(edad!=-1){
            if(edad>40)
                Console.WriteLine("Estás en riesgo");
            else
                Console.WriteLine("Riesgo bajo");
            Console.WriteLine(conexion);
        }
    }
}