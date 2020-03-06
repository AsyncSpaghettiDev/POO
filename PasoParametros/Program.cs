using System;

    class Algebra{
        public void cuadrado(int a){
            a=a*a;
        }
        public void cuadrado_ref(ref int a){
            a=a*a;
        }
        public int multiplica(int n1,int n2)=>(n1*n2);
        public void multiplica_out(int n1,int n2, out int resultado){
            resultado=n1*n2;
        }
    }
    class Program{
        static void Main(){
            /*Creacion del objeto tipo Algebra*/
            Algebra operacion=new Algebra();

            /*Inicializacion manual de la variable a*/
            int x=2;

            /*Se ejecuta la operacion de elevar al cuadrado*/
            operacion.cuadrado(x);

            /*Se imprime 2 porque solo se ejecutó el método no regresó ningun valor*/
            Console.WriteLine(x);

            /*Se ejecuta el método pero ahora como referencia*/
            operacion.cuadrado_ref(ref x);

            /*Al usar el método anterior en modo referencia el valor a imprimir será 4*/
            Console.Write(x);

            
        }
    }