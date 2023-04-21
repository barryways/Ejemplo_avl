using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Principalmente creamos la clase Nodo, esta clase es la que va a contener 
//La informacion que podemos meter en un AVL es variada, pero aqui es donde entran los genericos
//Podemos establecer una clase Persona y meterla como el valor

namespace Arbol_AVL
{
    public class Nodo
    {

        public int Valor; //Este es el valor del Nodo, este se asigna cuando invocamos al Nodo
        public int Altura;//Esta es la altura del arbol, como saben es importante tener una altura 
        public Nodo Izquierdo; //Este es el hijo izquierdo, es un dato de tipo Nodo (o sea de la misma Clase) porque el hijo va
                               //... va a contener la informacion igual en todos los Nodos y necesitamos que sea asi para todos los Nodos
        public Nodo Derecho;//Igual con el hijo derecho

        //Sin mas, creamos el constructor, este sirve para que cuando llamemos la Clase Nodo desde otro archivo le podemos establecer un valor
        public Nodo(int valor)//a este le vamos a llamar parametro_Valor
        {
            this.Valor = valor; //Establecemos que el Valor que declaramos al principio va a ser el valor del parametro (parametro_Valor) que le mandamos ahorita
            this.Altura = 1;//La altura se va a establecer en 1 porque cuando ya estamos metiendo un Nodo en el Arbol ya hay 1 nodo o sea el root 
        }
    }
}
