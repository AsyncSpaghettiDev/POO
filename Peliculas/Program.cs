using System;
    class Pelicula{
        public string titulo;
        public Int16 año;
        public string pais;
        public string director;
    }
    class Program{
        static void Main(){
            Pelicula p1 = new Pelicula();
            p1.titulo="Interestelar";
            p1.año=2014;
            p1.pais="Estados Unidos";
            p1.director="Christopher Nolan";
        }
    }