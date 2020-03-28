using System;
class Domino{
    private int Espacio1;
    private int Espacio2;
    public Domino(int Espacio1,int Espacio2){
        if((Espacio1>6)|(Espacio1<0))this.Espacio1=0;
        else this.Espacio1=Espacio1;
        if((Espacio2>6)|(Espacio2<0))this.Espacio2=0;
        else this.Espacio2=Espacio2;
    }
    public int getEspacio1()=>Espacio1;
    public int getEspacio2()=>Espacio2;
    public override string ToString()=>String.Format(" {0}\n|-|\n {1}\n",this.Espacio1,this.Espacio2);
    public static int operator +(Domino x,Domino y){
        int suma=y.getEspacio1()+x.getEspacio2();
        return suma;
    }
}
class Program{
    static void Main(){
        Domino a=new Domino(6,2);
        Console.WriteLine(a);
        Domino b=new Domino(5,3);
        Console.WriteLine(b);
        int suma=a+b;

        Console.Write("La suma de la parte de arriba del domino 2 más la parte de abajo del domino l es:"+suma);
    }
}