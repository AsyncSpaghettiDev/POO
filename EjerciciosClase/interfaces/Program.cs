using System;
using System.Collections.Generic;
interface IEscribe{
    String Color{get;set;}
    void Escribir(string text);
}
interface IPluma:IEscribe{
    bool Abrir();
    bool Cerrar();
}
class Cello:IPluma{
    private String _Color;
    public String Color{get=> _Color;set=>_Color=value;}
    private bool sePuedeEscribir=false;
    public Cello(string Color){
        this.Color=Color;
    }
    public bool Abrir(){
        sePuedeEscribir=true;
        return sePuedeEscribir;
    }
    public bool Cerrar(){
        sePuedeEscribir=false;
        return sePuedeEscribir;
    }
    public void Escribir(string texto){
        if(sePuedeEscribir)Console.WriteLine("Escribe el texto {0} en color {1}",texto,this._Color);
        else Console.WriteLine("La pluma está cerrada");
    }
}
class Bic:IPluma{
    private String _Color;
    private bool tapon=false;
    public String Color{get =>_Color;set=>_Color=value;}
    public Bic(string Color){
        this.Color=Color;
    }
    public bool Abrir(){
        return tapon=true;
    }
    public bool Cerrar(){
        return tapon=false;
    }
    public void Escribir(string texto){
        if(tapon)Console.WriteLine("Escribe el texto {0} en color {1}",texto,this._Color);
        else Console.WriteLine("Quita el tapón de la pluma");
    }
}
class Gis:IEscribe{
    public String Color{get;set;}
    public Gis(string Color){
        this.Color=Color;
    }
    public void Escribir(string texto){
        Console.WriteLine("Escribe el texto {0} en color {1}",texto,this.Color);
    }
}
class Program{
    static void Main(){
        Cello pluma_cello= new Cello("Rojo");
        var pluma_Bic =new Bic("Azul");
        var gis_morado = new Gis("Morado");

        List<Object> plumas = new List<Object>();
        plumas.Add(pluma_cello);
        plumas.Add(pluma_Bic);
        plumas.Add(gis_morado);

        foreach(var objeto in plumas){
            if(objeto is IPluma){
                Console.WriteLine("El objeto implementa IPluma");
                (objeto as IPluma).Abrir();
                (objeto as IPluma).Escribir("Hola 2");
            }
            else if(objeto is IEscribe){
                var objEscribir = objeto as IEscribe;
                objEscribir.Escribir("Hola");
            }

        }
    }
}
