using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierda, Derecha;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierda = Derecha = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;

    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo raiz, int valor)
    {
        if (raiz == null)
        {
            return new Nodo(valor);
        }

        if (valor < raiz.Valor)
        {
            raiz.Izquierda = InsertarRec(raiz.Izquierda, valor);
        }
        else if (valor > raiz.Valor)
        {
            raiz.Derecha = InsertarRec(raiz.Derecha, valor);
        }

        return raiz;
    }

    public Nodo Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private Nodo BuscarRec(Nodo raiz, int valor)
    {
        if (raiz == null || raiz.Valor == valor)
        {
            return raiz;
        }

        if (valor < raiz.Valor)
        {
            return BuscarRec(raiz.Izquierda, valor);
        }

        return BuscarRec(raiz.Derecha, valor);
    }

    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo EliminarRec(Nodo raiz, int valor)
    {
        if (raiz == null)
        {
            return raiz;
        }

        if (valor < raiz.Valor)
        {
            raiz.Izquierda = EliminarRec(raiz.Izquierda, valor);
        }
        else if (valor > raiz.Valor)
        {
            raiz.Derecha = EliminarRec(raiz.Derecha, valor);
        }
        else
        {
            if (raiz.Izquierda == null)
            {
                return raiz.Derecha;
            }
            else if (raiz.Derecha == null)
            {
                return raiz.Izquierda;
            }

            raiz.Valor = MinimoValor(raiz.Derecha);

            raiz.Derecha = EliminarRec(raiz.Derecha, raiz.Valor);
        }

        return raiz;
    }

    private int MinimoValor(Nodo raiz)
    {
        int min = raiz.Valor;
        while (raiz.Izquierda != null)
        {
            min = raiz.Izquierda.Valor;
            raiz = raiz.Izquierda;
        }
        return min;
    }

    public void Imprimir()
    {
        ImprimirRec(raiz);
    }

    private void ImprimirRec(Nodo raiz)
    {
        if (raiz != null)
        {
            ImprimirRec(raiz.Izquierda);
            Console.Write(raiz.Valor + " ");
            ImprimirRec(raiz.Derecha);
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();

        int[] valores = { 50, 30, 70, 20, 40, 60, 80 };

        foreach (int valor in valores)
        {
            arbol.Insertar(valor);
        }

        Console.WriteLine("Árbol original:");
        arbol.Imprimir();

        int valorBuscar = 40;
        if (arbol.Buscar(valorBuscar) != null)
        {
            Console.WriteLine($"\n{valorBuscar} encontrado en el árbol.");
        }
        else
        {
            Console.WriteLine($"\n{valorBuscar} no encontrado en el árbol.");
        }

        int valorEliminar = 30;
        arbol.Eliminar(valorEliminar);
        Console.WriteLine($"\nÁrbol después de eliminar {valorEliminar}:");
        arbol.Imprimir();
    }
}
