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
        this.horas=0;
        this.segundos=0;
        if(min>59){
            for(int i=1;i<=24;i++){
                if(min/60>=1){
                    this.horas=i;
                    min=min-60;
                }
            else{
                this.minutos=min;
                break;
                } 
            }
        }
    }
    public override string ToString()=>string.Format("{0}:{1}:{2}",this.horas,this.minutos,this.segundos);
}
class Program{
    static void Main(){
        Duracion a=new Duracion(7,35,45);
        Duracion b=new Duracion(350);
        Console.WriteLine(b);
    }
}