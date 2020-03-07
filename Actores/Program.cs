using System;
using System.Collections.Generic;
    class Actor{
        private string nombre;
        private int fechaNac;
        /*Creación del constructor vacio*/
        public Actor(){}
        /*Creación del constructor con parametros*/
        public Actor(string nombre,int fechaNac){
            this.nombre=nombre;
            this.fechaNac=fechaNac;
        }
        /*Creación de método para regresar el nombre del Actor*/
        public string getNombre()=>nombre;

    }
    class Pelicula{
        private string titulo;
        private int año;
        private List<Actor> actores;
        /*Creación de constructor vacio*/
        public Pelicula(){}
        /*Creación de constructor con parámetros*/
        public Pelicula(string titulo,int año){
            this.titulo=titulo;
            this.año=año;
            actores=new List<Actor>();
        }
        /*Método para imprimir titulo de Película*/
        public void imprime(){
            Console.WriteLine(titulo);
        }
        /*Método para agrear actores a la lista de películas*/
        public void addActor(Actor n){
            actores.Add(n);
        }
        /*Método para imprimir la lista de actores de la película*/
        public void getActores(){
            Console.WriteLine("Los actores de la película {0} son: ",titulo);
            foreach (Actor n in actores){
                Console.WriteLine(n.getNombre());
            }
        }
    }
    class Program{
        static void Main(){
            /*Creación del objeto p1*/
            Pelicula p1=new Pelicula("La La Land", 2016);
            /*Agregar lista de actores a la pelicula anterior*/
            p1.addActor(new Actor("Ryan Gosling", 1980));
            p1.addActor(new Actor("Emma Stone", 1988));

            /*Impresión de los actores de la película*/
            p1.getActores();
        }
    }
