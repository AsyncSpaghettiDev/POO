using System;
class Alumno{
    protected string nombre;
    protected int matricula;
    public Alumno(string nombre,int matricula){
        this.nombre=nombre;
        this.matricula=matricula;
    }
    public virtual void imprime(){
        Console.WriteLine("Mi nombre es {0} y mi matricula es {1}\n",this.nombre,this.matricula);
    }
}
class Licenciatura:Alumno{
    private string carrera;
    private int semestre;
    private string act_esp;

    public Licenciatura(string nombre,int matricula,string carrera,int semestre): base(nombre,matricula){
        this.carrera=carrera;
        this.semestre=semestre;
        if(semestre>8) act_esp="Residencia";
        else act_esp="Servicio Social";
    }
    public override void imprime(){
        Console.WriteLine("Mi nombre es {0}, estoy en el semestre {1} de la carrera de {2}.\nMi matricula es {3} y actualmente estoy haciendo mi {4}\n",this.nombre,this.semestre,this.carrera,this.matricula,this.act_esp);
    }
}
class Posgrado:Alumno{
    private string especialidad;
    private int cuatrimestre;
    private string tema;
    public Posgrado(string nombre,int matricula,string especialidad,int cuatrimestre,string tema):base(nombre,matricula){
        this.especialidad=especialidad;
        this.cuatrimestre=cuatrimestre;
        this.tema=tema;
    }
    public override void imprime(){
        Console.WriteLine("Mi nombre es {0}, estoy en el cuatrimestre{1} de la especialidad {2}.\nMi matricula es {3} y mi tema de investigación {4}\n",this.nombre,this.cuatrimestre,this.especialidad,this.matricula,this.tema);
    }
}
class Program{
    static void Main(){
        Alumno Pedro = new Alumno("Pedro",20211450);
        Pedro.imprime();

        Licenciatura Jonathan = new Licenciatura("Jonathan",19211688,"Ingeniería en Sistemas Computacionales.",3);
        Jonathan.imprime();

        Posgrado Mario = new Posgrado("Mario",15211023,"Tecnologias de la Informacion y Comunicación",5,"Inteligencia Artificial.");
        Mario.imprime();
    }
}