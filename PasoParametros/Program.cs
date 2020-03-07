using System;

    class Algebra{
        public int ejemref;
        public int ejemin;

        public void cuadrado(int a){
            a=a*a;
            //Se asigna el valor del resultado a la variable ejemref para ver donde se queda
            ejemref=a;
        }
        public void cuadrado_ref(ref int a){
            a=a*a;
        }
        public int multiplica(int n1,int n2)=>(n1*n2);
        public void multiplica_out(int n1,int n2, out int resultado){
            resultado=n1*n2;
        }
        public int suma(in int x){
            //Al ser un método tipo int esta línea daria error porque no se puede asigar valor a una variable
            //x=x+2;//Error
            ejemin=x+4;
            return x;
        }
    }
    class Program{
        static void Main(){
            /*Creacion del objeto tipo Algebra*/
            Algebra operacion=new Algebra();

            /*Inicializacion manual de la variable x*/
            int re=2;

            /*Se ejecuta la operacion de elevar al cuadrado*/
            operacion.cuadrado(re);

            /*Se imprime 2 porque solo se ejecutó el método no regresó ningun valor*/
            Console.WriteLine("Resultado de la variable local re: "+re);

            /*Se imprime el valor de n que tiene el objeto para ver que se queda de manera local*/
            Console.WriteLine("Resultado del atributo del objeto: "+operacion.ejemref);

            /*Se ejecuta el método pero ahora como referencia*/
            operacion.cuadrado_ref(ref re);

            /*Al usar el método anterior en modo referencia el valor a imprimir será 4*/
            Console.WriteLine("Resultado del cuadrado de re usando refencia: "+re);

            /*Declaración de variables que se multiplicaran*/
            int x=5;
            int y=2;
            int r;//Se declara la variable pero no se inicializa

            /*Se imprime lo que va a devolver el método multiplica*/
            Console.WriteLine("Resultado de multiplicar {0}x{1}={2}",x,y,operacion.multiplica(x,y));

            /*Se ejecuta el método y el valor se guarda en la varible sin asignar llamada r, se imprime para saber que está sin valor
            Al ejecutarse marcaría error 
            Console.WriteLine(r);*/
            operacion.multiplica_out(x,y,out r);

            /*Se imprime la variable r para saber que ahora ya tiene valor*/ 
            Console.WriteLine("Resultado de multiplicar usando out {0}x{1}={2}",x,y,r);

            int z=9;

            /*Se ejecuta el método in para ver cual sería el valor de retorno*/
            Console.WriteLine("Valor de la variable z porque el método no la puede modificar: "+operacion.suma(z));

            /*Imprimos el atributo donde guardamos el valor leido*/
            Console.WriteLine("Valor del atributo de la clase asignado en el método anterior(z+4): "+operacion.ejemin);
        }
    }