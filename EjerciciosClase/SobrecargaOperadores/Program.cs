using System;
class Racional{
    /*Asignación de atributos a la clase Racional*/
    private int numerador;
    private int denominador;
    /*Creación del constructor de la clase*/
    public Racional(int numerador,int denominador){
        this.numerador=numerador;
        this.denominador=denominador;
    }
    /*Creación de los métodos para acceder a los atributos*/
    public int getNumerador()=>numerador;
    public int getDenominador()=>denominador;
    /*Método para reducir los atributos del racional a su mínima expresión*/
    public void simplificar(){
        for(int i=1;i<9;i++){
            /*Se calcula el residuo de dividir el denominador y numerador entre el
            mismo factor(0-9), en caso de que ambos sean 0 se divide ambos entre
            ese factor logrando asi reducirlo*/
            int num=numerador%i;
            int den=denominador%i;
            if((num==0)&(den==0)){
                this.numerador=numerador/i;
                this.denominador=denominador/i;
            }
        }
    }
    /*Metodo para imprimir el numero racional, en caso que el denominador sea igual 
    a 1 solo se escribirá el numerador*/
    public override string ToString(){
        if(denominador==1)return String.Format("{0}",numerador);
        else return String.Format("{0}/{1}",numerador,denominador);
    }
    /*Sobrecarga del operador +, para sumar 2 fracciones es necesario:
    1-Multiplicar cruzado (numerador por denominador) y sumar el resultado para
    calcular así el nuevo numerador.
    2-Multiplicar ambos denominadores para obtener el nuevo denominador
    Ambos resultados se guardan en un nuevo numero racional que será el que se
    regresará*/
    public static Racional operator +(Racional x, Racional y){
        int numerador=(x.getNumerador()*y.getDenominador())+(y.getNumerador()*x.getDenominador());
        int denominador=x.getDenominador()*y.getDenominador();
        return new Racional(numerador,denominador);
    }
}
class Program{
    static void Main(){
        /*Creación de los numeros racionales*/
        Racional a=new Racional(2,3);
        Racional b=new Racional(3,4);
        /*Suma de los números racionales a y b*/
        Racional c=a+b;
        /*Creacion de un numero racional que posteriomente fue simplificado usando
        el método simplificar*/
        Racional d=new Racional(30,8);
        d.simplificar();

        /*Impresión de los resultados de todas las operaciones realizadas
        (suma de 2 numeros racionales y la simplifacion de un tercero.)*/
        Console.WriteLine("{0}\n{1}\n{2}\nSimplificado:{3} ",a,b,c,d);
    }
}