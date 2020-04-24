using System;
interface IPluma{
    String Color{get;set;}
    bool Abrir();
    bool Cerrar();
    void Escribir(string a);
}
class Cello:IPluma{
    private String _Color;
    public String Color{
        get {
            return _Color;
        }
        set {
            if(value.GetType()==Type.GetType("System.String"))
            _Color=value;
            else _Color="negro";
        }
    }
    private bool puede_imprimir=false;
    public Cello(string Color){
        this.Color=Color;
    }
    public bool Abrir(){
        return puede_imprimir=true;
    }
    public bool Cerrar(){
        return puede_imprimir=false;
    }
    void IPluma.Escribir(string texto){
        if(puede_imprimir)Console.WriteLine("Escribe el texto {0} en el color {1}",texto,this._Color);
        else Console.WriteLine("La pluma está cerrada");
    }
}
class Program{
    static void Main(){
        Cello pluma1= new Cello("rojo");
        (pluma1 as IPluma).Escribir("Hola Mundo");
        pluma1.Abrir();
        (pluma1 as IPluma).Escribir("Hola Mundo");
    }
}
