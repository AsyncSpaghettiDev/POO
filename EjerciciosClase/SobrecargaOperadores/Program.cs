using System;
class Racional{
    private int numerador;
    private int denominador;
    public Racional(int numerador,int denominador){
        this.numerador=numerador;
        this.denominador=denominador;
    }
    public int getNumerador()=>numerador;
    public int getDenominador()=>denominador;
    public override string ToString()=> String.Format("{0}/{1}",numerador,denominador);
    public static Racional operator +(Racional x, Racional y){
        int numerador=(x.getNumerador()*y.getDenominador())+(y.getNumerador()*x.getDenominador());
        int denominador=x.getDenominador()*y.getDenominador();
        return new Racional(numerador,denominador);
    }
}
class Program{
    static void Main(){
        Racional a=new Racional(2,3);
        Racional b=new Racional(3,4);
        Racional c=a+b;

        Console.WriteLine("{0}\n{1}\n{2}",a,b,c);
    }
}