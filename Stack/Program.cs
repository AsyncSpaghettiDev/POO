using System;
/*Creacion de la clase generica tipo Stack*/
class Stack<T>{
    private readonly int capacity;
    private int apuntador=0;
    T[] miembros;
    /*Sobrecarga del constructor*/
    public Stack():this(8){}
    /*Se establece el tamaño que tendrá la estructura*/
    public Stack(int capacity){
        this.capacity=capacity;
        miembros= new T[this.capacity];
    }
    /*
    *Se añade un nuevo miembro a la estructura y se aumenta el apuntador
    *en caso que este ultimo sea mayor o igual (igual porque la estructura 
    *empieza en 0) a la capacidad de la estructura se lanza una excepcion 
    *que indica que la estructura está llena
    */
    public void Push(T miembro){
        if(this.apuntador>=this.capacity)
            throw new Exception("Stack Lleno");
        else{
            this.miembros[this.apuntador]=miembro;
            this.apuntador++;
        }
    }
    /*
    *Se expulsa el ultimo miembro agregado a la estructura, en caso de que
    *el apuntador llegue a ser menor que 0 se lanzará una nueva excepcion que
    *indique que la estructura está vacia
    */
    public T Pop(){
        this.apuntador--;
        if(this.apuntador>=0)
            return this.miembros[this.apuntador];
        else
            throw new IndexOutOfRangeException("Stack vacio");
    }
}
class Program{
    static void Main(){
        var nums = new Stack<int>();
        Random rdm=new Random();
        for(int i=0;i<8;i++)
            nums.Push(i+1);
        for(int i=0;i<8;i++)
            Console.Write(nums.Pop()+"\t");

        Console.WriteLine();

        var vocal= new Char[]{'a','e','i','o','u'};
        var text = new Stack<char>(vocal.Length);
        for(int i=0;i<vocal.Length;i++)
            text.Push(vocal[i]);
        for(int i=0;i<vocal.Length;i++)
            Console.Write(text.Pop()+"\t");
    }
}