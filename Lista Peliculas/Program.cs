using System;
using System.Collections.Generic;

    class Pelicula{
        private string titulo;
        public Pelicula(string titulo){
            this.titulo=titulo;
        }
        public void imprime(){
            Console.WriteLine(titulo);
        }
    }
    class Program{
        static void Main(){
            List<Pelicula> peliculas= new List<Pelicula>();
            peliculas.Add(new Pelicula("El Rey Leon"));
            peliculas.Add(new Pelicula("Jurasic Park"));
            peliculas.Add(new Pelicula("Titanic"));
            peliculas.Add(new Pelicula("Interstellar"));
            peliculas.Add(new Pelicula("The Revenant"));

            foreach (Pelicula a in peliculas){
                a.imprime();
            }
        }
    }

