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
        var nums = new Stack<int>();
        Random rdm=new Random();
        for(int i=0;i<8;i++)
            nums.Push(rdm.Next(20));
        for(int i=0;i<8;i++)
            Console.Write(nums.Pop()+"\t");

        Console.WriteLine();

        var vocal= new Char[]{'a','e','i','o','u'};
        var text = new Stack<char>();
        for(int i=0;i<8;i++)
            text.Push(vocal[rdm.Next(vocal.Length)]);
        for(int i=0;i<8;i++)
            Console.Write(text.Pop()+"\t");
    }
}