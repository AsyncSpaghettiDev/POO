using System;
class Domino{
    /*Asignación de atributos a la clase Dominó*/
    private int Espacio1;
    private int Espacio2;
    /*Creación del constructor con la condición que el domino no puede tener más de 6 puntos
    ni menos de 0 puntos*/
    public Domino(int Espacio1,int Espacio2){
        if((Espacio1>6)|(Espacio1<0))this.Espacio1=0;
        else this.Espacio1=Espacio1;
        
        if((Espacio2>6)|(Espacio2<0))this.Espacio2=0;
        else this.Espacio2=Espacio2;
    }
    /*Creacion de los metodos get*/
    public int getEspacio1()=>Espacio1;
    public int getEspacio2()=>Espacio2;
    /*Metodo para la impresion de los atributos, donde se despliega simulando la ficha de domino*/
    public override string ToString()=>String.Format(" {0}\n|-|\n {1}\n",this.Espacio1,this.Espacio2);
    /*Sobrecarga del operador +, devolviendo un entero*/
    public static int operator +(Domino x,Domino y){
        return y.getEspacio1()+y.getEspacio2()+x.getEspacio1()+x.getEspacio2();
    }
}
class Program{
    static void Main(){
        /*Creacion de los dominos con su respectiva impresión*/
        Domino a=new Domino(5,6);
        Console.WriteLine(a);

        Domino b=new Domino(0,1);
        Console.WriteLine(b);
        /*Se lleva a cabo la suma de todas los puntos en las fichas de dominó*/
        int suma=a+b;

        /*Impresión del resultado de sumar los puntos de las fichas de dominó*/
        Console.Write("La suma de los dominos es: "+suma);
    }
}