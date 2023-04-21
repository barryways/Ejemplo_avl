using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_AVL
{
    public class ArbolAVL
    {
        private Nodo Raiz;//empezamos declarando un Nodo de tipo Nodo que va a ser nuestra raiz

        // 
        public void Insertar(int valor)
        {
            Raiz = Insertar(Raiz, valor);// Aqui hacemos este metodo que va a llamar al metodo del mismo nombre pero privado para que de parametros podamos meter el nodo
            //que ya teniamos como variable y el valor.
        }

        private Nodo Insertar(Nodo nodo, int valor)// este es el verdadero metodo que inserta
        {
            if (nodo == null)//aqui verificamos que el Nodo que queremos meter no sea nulo, si es nulo significa que el arbol esta vacio
            {
                return new Nodo(valor);//retornamos la insercion de un nuevo nodo que no esta ligado con nada, esta sera nuestra raiz
            }

            if (valor < nodo.Valor)//Aqui empieza lo complicado y es que vamos a hacer un metodo recursivo para en el que vamos a pasarle el nodo Izquierdo o derecho dependiendo si es mayor o menor
            {
                nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);//Como el valor del item que queremos meter es menor que el item que tenemos actualmente lo mandamos a la izquierda
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = Insertar(nodo.Derecho, valor);//ahora como el item es mayor lo mandamos a la derecha
            }
            else
            {
                // En el extraño caso de que seas imbecil y querras meter un  valor que ya existe en el árbol esto valida que no se permite duplicados
                return nodo;
            }
            //Bueno eso fue para meterlo, ahora toca balancearlo, se balancea en cada insercion

            //Aqui vamos a calcular la altura sabiendo que tenemos que devolver la altura de cada nodo, no se si me explico pero aqui tambien
            //se basa un poco que el valor de la altura en el nodo sea 1, o sea se van sumando cada vez y eso devuelve la altura de abajo
            nodo.Altura = 1 + Math.Max(Altura(nodo.Izquierdo), Altura(nodo.Derecho));//es una funcion que le suma 1 a lo que ya tenemos

            int balance = Balance(nodo);//Aqui mandamos a llamar el metodo balance el cual va a calcular el balance que ya tiene el arbol en base al nodo que manda

            // Aqui como te dije en el metodo Balance si es mayor a 1 esta desbalanceado
            if (balance > 1)
            {
                if (valor < nodo.Izquierdo.Valor)
                {
                    return RotacionDerecha(nodo);//Como ves aqui llamamos a la rotacion de la derecha si el nodo es menor al nodo de la izquierda
                }
                else
                {
                    //Aqui lo que hacemos es que rotamos de primero el de la izquierda, para ver que todo este cuadrado bien de ese lado
                    nodo.Izquierdo = RotacionIzquierda(nodo.Izquierdo);
                    return RotacionDerecha(nodo);//despues lo mandamos a la derecha ya para que se rote a la derecha como se supone
                }
            }

            //Aunque tambien existe la probabilidad de que nos duvuelva un valor negativo que significa que esta desbalanceado para el otro lado
            if (balance < -1)
            {
                //en este caso revertimos el proceso hecho anteriormente, 
                if (valor > nodo.Derecho.Valor)
                {
                    //En el que revertimos a la izquierda, si te das cuenta en el metodo anterior era la rotacion a la derecha cuando era menor ahora lo hacemos cuando es mayor
                    return RotacionIzquierda(nodo);
                }
                else
                {
                    //Y hacemos lo mismo para el otro lado
                    nodo.Derecho = RotacionDerecha(nodo.Derecho);
                    return RotacionIzquierda(nodo);
                }
            }
            //ahora solo retornamos el nodo :D

            return nodo;
        }

        // Rotación a la derecha
        private Nodo RotacionDerecha(Nodo y)//Pasamos el nodo, le vamos a poner y, para tener de referencia las variables x y y
        {
            Nodo x = y.Izquierdo;//aqui vamos a crear un nuevo Nodo que va a representar el valo que acabamos de mandar
            Nodo subarbol = x.Derecho;//y este va a ser nuestro nodo de un subarbol que esta bien

            //aqui vamos a invertir los valores de las varables de arriba
            x.Derecho = y;
            y.Izquierdo = subarbol;

            //y facil, otra vez usamos el modulo de calculo de altura, tal vez seria mas facil con una inyeccion de dependencias, pero lo dejo a tu criterio
            y.Altura = 1 + Math.Max(Altura(y.Izquierdo), Altura(y.Derecho));
            x.Altura = 1 + Math.Max(Altura(x.Izquierdo), Altura(x.Derecho));

            return x;
        }

        // Rotación a la izquierda
        private Nodo RotacionIzquierda(Nodo x)
        {
            //me da mucha hueva explicar esto ya que esta explicado arriba pero si lo lees bien te das cuenta que es el mismo metodo solo que 
            //lo usamos al reves
            Nodo y = x.Derecho;
            Nodo subarbol = y.Izquierdo;

            y.Izquierdo = x;
            x.Derecho = subarbol;

            x.Altura = 1 + Math.Max(Altura(x.Izquierdo), Altura(x.Derecho));
            y.Altura = 1 + Math.Max(Altura(y.Izquierdo), Altura(y.Derecho));

            return y;
        }
        
        private int Altura(Nodo nodo)//si queremos tener la altura del nodo necesitamos este metodo
        {
            if (nodo == null)//verificamos que el nodo no sea nulo, lo explico mejor en el metodo balance
            {
                return 0;
            }
            return nodo.Altura;//regresamos el atributo altura de cada nodo :D
        }
        private int Balance(Nodo nodo)// es algo trabado y confuso pero aqui llega el balance
        {
            if (nodo == null)
            {
                return 0;//verificamos que nodo que mandamos tenga algo, porque si no el arbol esta vacio y asi no podemos calcular nada
            }
            return Altura(nodo.Izquierdo) - Altura(nodo.Derecho);// y aqui lo que hacemos es mandar la altura que tiene cada nodo y la restamos, como vimos en la clase si tiene mas de 1 esta desbalanceado
        }
    }
}
