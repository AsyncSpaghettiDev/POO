using System;
    class Pelicula{
        public string titulo;
        public Int16 año;
        public string pais;
        public string director;
    }
    class Program{
        static void Main(){
            Pelicula p1=new Pelicula();
            p1.titulo="La forma del agua";
            p1.año=2017;
            p1.pais="Estados Unidos";
            p1.director="Guillermo del Toro";

            Console.WriteLine("La película {0} se estrenó el año {1}.",p1.titulo,p1.año);

            Pelicula p3=new Pelicula();
            p3.titulo="El discurso del Rey";
            p3.año=2010;
            p3.pais="Reino Unido";
            p3.director="Tom Hooper";

            Console.WriteLine("La película {0} se estrenó el año {1}.",p3.titulo,p3.año);
        }
    }