using System;
using System.Collections.Generic;
    /*Creacion de la clase "Correo" */
    class CorreoE{
        /*Se declaran los atributos */
        private string correo;
        /*Se declara el constructor */
        public CorreoE(string correo){
            this.correo=correo;
        }
        /*Se crea un método */
        public string getCorreo()=>correo;
    }
    /*Creacion de la clase usuario */
    class Usuario{
        /*Declaracion de atributos */
        private string nombre;
        /*Se crea una lista pero no se define */
        private List<CorreoE> correos;
        /*Creación del constructor y también se define la lista */
        public Usuario(string nombre){
            this.nombre=nombre;
            correos=new List<CorreoE>();
        }
        /*Método para que retorne el valor */
        public string getNombre()=>nombre;
        /*Método para crear/asignar un correo al usuario */
        public void Add(CorreoE c){
            correos.Add(c);
        }
        /*Método para imprimir el nombre del usuario y la lista de correos del
        mismo */
        public void print(){
            Console.WriteLine("Los correos del usuario {0} son:",nombre);
            foreach (CorreoE c in correos){
                Console.WriteLine(c.getCorreo());
            }
        }
    }
    class Program{
        static void Main(){
            /*Se crea el objeto de tipo usuario y se incializa con el constructor */
            Usuario u1=new Usuario("Juan");
            /*Se imprime el nombre del usuario usando el método de la clase */
            Console.WriteLine(u1.getNombre());

            /*Se le asignan correos al usuario u1(Juan) */
            u1.Add(new CorreoE("juan@a.com"));
            u1.Add(new CorreoE("juan@gmail.com"));
            /*Se llama el método para imprimir todo lo del objeto */
            u1.print();
        }
    }

