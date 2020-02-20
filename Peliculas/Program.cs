using System;
    class Pelicula{
        private string titulo;
        private Int16 año;
        private string pais;
        private string director;
        public void SetTitulo(string titulo){
            this.titulo=titulo;
        }
        public string GetTitulo()=> titulo;
        public void SetAño(Int16 año){
            this.año=año;
        }
        public Int16 GetAño()=> año;
    }
    class Program{
        static void Main(){
            Pelicula p1=new Pelicula();
            p1.SetTitulo("La forma del agua");
            p1.SetAño(2017);

            Console.WriteLine("La película {0} se estrenó el año {1}.",p1.GetTitulo(),p1.GetAño());

            Pelicula p3=new Pelicula();
            p3.SetTitulo("El discurso del Rey");
            p3.SetAño(2010);

            Console.WriteLine("La película {0} se estrenó el año {1}.",p3.GetTitulo(),p3.GetAño());
        }
    }