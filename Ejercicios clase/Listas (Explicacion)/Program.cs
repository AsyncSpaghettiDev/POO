using System;
/*Se usa la siguiente libreria para poder crear lista tipo objeto */
using System.Collections.Generic;

    class Alumno{
        public string nombre;
        public Alumno(string nombre){
            this.nombre=nombre;
        }
        public void imprime(){
            Console.WriteLine(nombre);
        }
    }
    class Program{
        static void Main(){
            /*Creacion del objeto ana y se da la orden de que se imprima */
            Alumno ana = new Alumno("Ana");
            ana.imprime();

            /*Crear una lista de tipo Alumno, esta hereda todo de la
            la Clase Alumno, como si fuera un constructor */
            List<Alumno> alumnos = new List<Alumno>();
            /*Agregar a la lista el objetivo ana creado con anterioridad */
            alumnos.Add(ana);
            /*Se crean más objetos de tipo Alumno y automaticamente se
            almacenan en la lista */
            alumnos.Add(new Alumno("Pam"));
            alumnos.Add(new Alumno("Carlos"));
            alumnos.Add(new Alumno("Maria"));
            alumnos.Add(new Alumno("Juan"));
            alumnos.Add(new Alumno("Karen"));
            alumnos.Add(new Alumno("Jose"));
            alumnos.Add(new Alumno("Ricardo"));
            alumnos.Add(new Alumno("Alma"));
            alumnos.Add(new Alumno("Jorge"));
            alumnos.Add(new Alumno("Arturo"));
            alumnos.Add(new Alumno("David"));

            /*La lista "tipo objeto" se comporta igual que una lista normal
            por lo que se debe especificar el campo que se quiere imprimir y
            como es "tipo objeto" se pueden usar los metodos de la clase Alumno*/
            alumnos[0].imprime();

            Console.WriteLine();
            /*Imprimir la lista por medio de índice,usando un ciclo for */
            for(int i=0;i<alumnos.Count;i++){
                alumnos[i].imprime();
            }
            Console.WriteLine();
            /* Tipo de datos "clase", in, nombre de la lista*/
            foreach(Alumno a in alumnos){
                a.imprime();
            }
        }
    }