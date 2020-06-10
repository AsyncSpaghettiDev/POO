using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
class Program{
    static void Main(){
        List<Producto> prods= new List<Producto>();
        /*prods.Add( new Producto(015,"Cereal_chocolatado",28.50));
        prods.Add( new Producto(125,"Galletas_varias",35.0));
        prods.Add( new Producto(325,"Bombones",21.0));
        File.WriteAllText("./ejemplo.json",JsonSerializer.Serialize(prods));*/
        prods = JsonSerializer.Deserialize<List<Producto>>(File.ReadAllText("./ejemplo.json"));
        foreach(Producto item in prods)
            Console.WriteLine(item);
    }
}