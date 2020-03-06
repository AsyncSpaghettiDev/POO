using System;

    class Algebra{
        public int n;
        public void cuadrado(int a){
            a=a*a;
            //Se asigna el valor del resultado a la variable n para ver donde se queda
            n=a;
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

            /*Se imprime el valor de n que tiene el objeto para ver que se queda de manera local*/
            Console.WriteLine(operacion.n);

            /*Se imprime 2 porque solo se ejecutó el método no regresó ningun valor*/
            Console.WriteLine(x);

            /*Se ejecuta el método pero ahora como referencia*/
            operacion.cuadrado_ref(ref x);

            /*Al usar el método anterior en modo referencia el valor a imprimir será 4*/
            Console.WriteLine(x);

            /*Declaración de variables que se multiplicaran*/
            x=5;
            int y=2;
            int r;//Se declara la variable pero no se inicializa

            /*Se imprime lo que va a devolver el método multiplica*/
            Console.WriteLine(operacion.multiplica(x,y));

            /*Se ejecuta el método y el valor se guarda en la varible sin asignar llamada r, se imprime para saber que está sin valor
            Al ejecutarse marcaría error 
            Console.WriteLine(r);*/
            operacion.multiplica_out(x,y,out r);

            /*Se imprime la variable r para saber que ahora ya tiene valor*/ 
            Console.WriteLine(r);
        }
    }