using System;
class Duracion{
    /*Asignación de atributos a la clase Duración*/
    private int horas;
    private int minutos;
    private int segundos;
    /*Creación del constructor con el método para convertir de
    segundos a minutos y de minutos a segundos para evitar errores
    de formato, más adelante se muestra el método.*/
    public Duracion(int horas,int minutos,int segundos){
        convertir(ref segundos,ref minutos);
        this.segundos=segundos;

        convertir(ref minutos,ref horas);
        this.minutos=minutos;
        this.horas=horas;
    }
    /*Sobrecarga del constructor con tambien el método de conversión
    de segundos a minutos y minutos a horas. En este caso como no era
    para validar el formato se requirió inicializar minutos y horas,
    esto porque las referencias deben estar en 0*/
    public Duracion(int segundos){
        int minutos=0;
        int horas=0;

        convertir(ref segundos,ref minutos);
        this.segundos=segundos;

        convertir(ref minutos,ref horas);
        this.minutos=minutos;
        this.horas=horas;
    }
    public int getHoras()=>this.horas;
    public int getMinutos()=>this.minutos;
    public int getSegundos()=>this.segundos;
    /*Creación del metodo convertir, su finalidad es convertir segundos a minutos y minutos a horas.
    Es perfecto porque para hacer ambas conversiones se usa un sistema de 60.
    Para poder afectar los valores sin necesidad de regresar un objeto se usa el paso de parametros
    tipo referencia.
    Pasa el valor segundos/minutos y si su división es igual o mayor que 1,significando esto que hay 
    más de 1 minuto/hora representado en segundos/minutos, se agrega 1 minuto/hora y se disminuyen 60 
    segundos/minutos, así hasta que el resultado de la división sea menor a 1, significando que hay más
    de 1 minuto/hora representada en segundos/minutos, entonces se rompe el ciclo y el valor de segundos/minutos
    no se modifica más.*/
    private void convertir(ref int x,ref int y){
        for(int i=0;i<=3600;i++){
            if(x/60>=1){
                y++;
                x-=60;
            }
            else{
                break;
            } 
        }
    }
    /*Método para asignar el formato de HH:MM:SS, para poder lograr esto se usa el .ToString y entre los 
    parentesis la letra D seguida de la longitud deseada, para este caso 2.
    Tambien se puede lograr este resultado si seguido de la posición se ponen 2 puntos, la letra D seguidas
    del tamaño deseado.*/
    public override string ToString()=>string.Format("{0:D2}:{1}:{2}",this.horas,this.minutos.ToString("D2"),this.segundos.ToString("D2"));
    /*Sobrecarga del operador + y se suman directamente las horas, minutos y segundos de ambas duraciones,
    no es necesario hacer validaciones porque esta se lleva a cabo en el momento que devolvemos un nuevo
    objeto de tipo Duracion*/
    public static Duracion operator +(Duracion x, Duracion y){
        return new Duracion(x.getHoras()+y.getHoras(),x.getMinutos()+y.getMinutos(),x.getSegundos()+y.getSegundos());
    }

}
class Program{
    static void Main(){
        /*Creación de 2 duraciones, una con los atributos escritos de forma correcta, y otra donde será
        necesaria la conversión de segundos a minutos y horas*/
        Duracion a=new Duracion(7,18,55);
        Console.WriteLine("Duración #1 {0}",a);

        Duracion b=new Duracion(22565);
        Console.WriteLine("Duración #2 {0}",b);

        /*Suma e impresión de la sobrecarga del operador + con las duraciones A y B*/
        Duracion c=a+b;
        Console.WriteLine("Duración #1 + Duración #2 {0}",c);
    }
}