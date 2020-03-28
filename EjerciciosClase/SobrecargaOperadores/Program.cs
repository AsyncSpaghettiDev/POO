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
    public void simplificar(){
        for(int i=1;i<9;i++){
            int num=numerador%i;
            int den=denominador%i;
            if((num==0)&(den==0)){
                this.numerador=numerador/i;
                this.denominador=denominador/i;
            }
        }
    }
    public override string ToString(){
        if(denominador==1)return String.Format("{0}",numerador);
        else return String.Format("{0}/{1}",numerador,denominador);
    }
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
        Racional d=new Racional(30,8);
        d.simplificar();

        Console.WriteLine("{0}\n{1}\n{2}\nSimplificado:{3} ",a,b,c,d);
    }
}