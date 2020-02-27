using System;
    class Pelicula{
        private string titulo;
        private Int16 año;
        private string pais;
        private string director;
        public Pelicula(){
        }
        public Pelicula(){}
        public Pelicula(string titulo,Int16 año){
            this.titulo=titulo;
            this.año=año;
        }
        public void imprime(){
            Console.WriteLine("La película {0} se estrenó el año {1}.",titulo,año);
        }
    }
    class Program{
        static void Main(){
            Pelicula p1=new Pelicula("La forma del Agua",2017);

            p1.imprime();

            Pelicula p3=new Pelicula("El discurso del Rey",2010);

            p3.imprime();
        }
    }