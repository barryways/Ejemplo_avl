//------------LEEME ANTES DE COPIAR EL CODIGO-------------
//Buenos dias Compadre, este va a ser un ejemplo de un Arbol AVL
//Lastimosamente no te lo puedo hacer completo porque solo hago las cosas por $$
//Sin embargo te voy a dejar la estructura comentada para que lo volvas generico
//Este repositorio es muy probable que no solo lo comparta contigo, asi que es mejor
//que sepas que tenes que moldear el arbol a tu forma de programar
//Sin nada mas que comentar, empezamos
using Arbol_AVL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Creamos la funcion principal, esto realmente solo lo hago porque es consola y .NET 6.0 que no incluye el main
namespace Arbol_AVL
{
    class ClasePrincipal
{
    static void Main(string[] args)
    {
        //Primero creas la clase Nodo y la clase ArbolAVL metete a ver los archivos
        ArbolAVL arbol_AVL = new ArbolAVL();
            //hasta te deje los valores para que lo debuguees
            arbol_AVL.Insertar(5);
            arbol_AVL.Insertar(6);
            arbol_AVL.Insertar(9);
            arbol_AVL.Insertar(15);
            arbol_AVL.Insertar(20);
            arbol_AVL.Insertar(92);
            arbol_AVL.Insertar(42);
            arbol_AVL.Insertar(105);
            arbol_AVL.Insertar(87);
            //Asi que eso :D hacete el favor y debuguealo
            //NO SEAS IMBECIL :)
    }
}
}


