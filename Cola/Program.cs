using System;
class Cola<T>{
    private readonly int capacidad;
    private int apuntador=0;
    private T[] miembros;
    public Cola():this(8){}
    public Cola(int capacidad){
        this.capacidad=capacidad;
        this.miembros= new T[this.capacidad];
    }
    public void Push(T miembro){
        if(this.apuntador>=0 && this.apuntador<this.capacidad){
            miembros[this.apuntador]= miembro;
            apuntador++;
        }
        else
            throw new Exception("No se pueden agregar más elementos porque la fila esta llena");
    }
    public T Pop(){
        this.apuntador--;
        if(this.apuntador>=0 && this.apuntador<=this.capacidad){
            T temp= miembros[0];
            for(int i=0;i<this.apuntador;i++)
                miembros[i]=miembros[i+1];
            return temp;
        }
        throw new Exception("No se pueden sacar más elementos porque la fila esta vacia");
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