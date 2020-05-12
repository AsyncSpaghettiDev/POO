using System;
class Stack<T>{
    private readonly int capacity;
    private int apuntador=0;
    T[] miembros;
    public Stack():this(8){}
    public Stack(int capacity){
        this.capacity=capacity;
        miembros= new T[this.capacity];
    }
    public void Push(T miembro){
        if(this.apuntador>=this.capacity)
            throw new Exception("Stack Lleno");
        else{
            this.miembros[this.apuntador]=miembro;
            this.apuntador++;
        }
    }
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
        var pila = new Stack<int>();
        pila.Push(15);
        Console.WriteLine(pila.Pop());
    }
}