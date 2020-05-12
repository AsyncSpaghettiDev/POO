using System;
/*Creacion de clase generica tupo cola FirstInput FirstOutput*/
class Cola<T>{
    private readonly int capacidad;
    private int apuntador=0;
    private T[] miembros;
    /*Sobrecarga de constructor*/
    public Cola():this(8){}
    /*Se declara el tamaño de la estructura y se inicializa*/
    public Cola(int capacidad){
        this.capacidad=capacidad;
        this.miembros= new T[this.capacidad];
    }
    /*Se añade un nuevo miembro a la estructura antes validando que el apuntador no exceda la capacidad de
    *la estructura, de ser asi se lanza una excepcion
    */
    public void Push(T miembro){
        if(this.apuntador>=this.capacidad)
            throw new Exception("No se pueden agregar más elementos porque la fila esta llena");
        else{
            miembros[this.apuntador]= miembro;
            this.apuntador++;
        }
            
    }
    /*Se guarda el valor de la primer posicion en una variable temporal y se recorre todo la
    *estructura -1 para dejar el ultimo espacio vacio, disponible para ser ocupado.
    */
    public T Pop(){
        this.apuntador--;
        if(this.apuntador>=0 && this.apuntador<=this.capacidad){
            var temp= miembros[0];
            for(int i=0;i<this.apuntador;i++)
                miembros[i]=miembros[i+1];
            return temp;
        }
        else
            throw new Exception("No se pueden sacar elementos porque la fila esta vacia");
    }
}
class Program{
    static void Main(){
        var nums = new Cola<int>();
        Random rdm=new Random();
        for(int i=0;i<8;i++)
            nums.Push(i+1);
        for(int i=0;i<8;i++)
            Console.Write(nums.Pop()+"\t");

        Console.WriteLine();

        var vocal= new Char[]{'a','e','i','o','u'};
        var text = new Cola<char>(vocal.Length);
        for(int i=0;i<vocal.Length;i++)
            text.Push(vocal[i]);
        for(int i=0;i<vocal.Length;i++)
            Console.Write(text.Pop()+"\t");
    }
}