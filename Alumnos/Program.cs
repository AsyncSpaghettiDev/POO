using System;
class Alumno{
    /*Asignación de atributos de la clase, se declaran como protected para que se puedan heredar a las
    siguientes clases*/
    protected string nombre;
    protected int matricula;
    /*Creacion del constructor, usando la sobrecarga de parametros*/
    public Alumno(string nombre,int matricula){
        this.nombre=nombre;
        this.matricula=matricula;
    }
    /*Creacion del método imprime, se usa la palabra reservada virtual para declarar que en otras clases
    se puede redefinir.*/
    public virtual void imprime(){
        Console.WriteLine("Mi nombre es {0} y mi matricula es {1}\n",this.nombre,this.matricula);
    }
}
    /*Creacion de clase Licenciatura heredando de Alumno*/
class Licenciatura:Alumno{
    /*Asignacion de atributos de clase como privados, debido a que no se van a heredar*/
    private string carrera;
    private int semestre;
    private string act_esp;
    /*Creacion del constructor de la clase, se usa la palabra reservada "base" para referenciar al
    constructor de la clase base. Si actualmente cursa un semestre mayor al octavo estará haciendo
    residencia y en caso de que estar en un semestre menor hará servicio social.*/
    public Licenciatura(string nombre,int matricula,string carrera,int semestre):base(nombre,matricula){
        this.carrera=carrera;
        this.semestre=semestre;
        if(semestre>8) act_esp="Residencia";
        else act_esp="Servicio Social";
    }
    /*Redefinición del método imprime usando los atributos de la clase*/
    public override void imprime(){
        Console.WriteLine("Mi nombre es {0}, estoy en el semestre {1} de la carrera de {2}.\nMi matricula es {3} y actualmente estoy haciendo mi {4}\n",this.nombre,this.semestre,this.carrera,this.matricula,this.act_esp);
    }
}
    /*Creacion de clase Posgrado heredando de Alumno*/
class Posgrado:Alumno{
    /*Asignacion de atributos de clase como privados, debido a que no se van a heredar*/
    private string especialidad;
    private int cuatrimestre;
    private string tema;
    /*Creacion del constructor de la clase, se usa la palabra reservada "base" para referenciar al
    constructor de la clase base.*/
    public Posgrado(string nombre,int matricula,string especialidad,int cuatrimestre,string tema):base(nombre,matricula){
        this.especialidad=especialidad;
        this.cuatrimestre=cuatrimestre;
        this.tema=tema;
    }
    /*Redefinición del método imprime usando los atributos de la clase*/
    public override void imprime(){
        Console.WriteLine("Mi nombre es {0}, estoy en el cuatrimestre{1} de la especialidad {2}.\nMi matricula es {3} y mi tema de investigación {4}\n",this.nombre,this.cuatrimestre,this.especialidad,this.matricula,this.tema);
    }
}
class Program{
    static void Main(){
        /*Creación de objetos y su respectiva impresión*/
        Alumno Pedro = new Alumno("Pedro",20211450);
        Pedro.imprime();

        Licenciatura Jonathan = new Licenciatura("Jonathan",19211688,"Ingeniería en Sistemas Computacionales.",3);
        Jonathan.imprime();

        Posgrado Mario = new Posgrado("Mario",15211023,"Tecnologias de la Informacion y Comunicación",5,"Inteligencia Artificial.");
        Mario.imprime();
    }
}