using System;
class Duracion{
    private int horas;
    private int minutos;
    private int segundos;
    public Duracion(int horas,int minutos,int segundos){
        this.horas=horas;
        this.minutos=minutos;
        this.segundos=segundos;
    }
    public Duracion(int min){
        if(min>59){
            for(int i=min;i>59;i-=60){
                int horas=minutos/i;
                this.horas=horas;
                this.minutos=i;
            }
        }
        this.segundos=0;
    }
    public override string ToString()=>string.Format("{0}:{1}:{2}");
}
class Program{
    static void Main(){
        Duracion a=new Duracion(60);
        Console.WriteLine(a);
    }
}