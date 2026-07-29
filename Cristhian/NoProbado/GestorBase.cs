namespace Proyect_BancoSangre_Progra3.Cristhian.NoProbado;

public abstract class GestorBase<T> where T : IMostrable, IActualizable
{
    public List<T> Lista { get; protected set; } = [];
    
    public GestorBase(){ }
    
    public abstract void CargarDatos();
    public abstract void GuardarDatos();
    
    public abstract void Registrar();
    public abstract void Listar();
    
    public abstract int BuscarIndice(Guid idBuscado);
    public abstract int BuscarIndice(string ci);
    
    public void Buscar(string tipo)
    {
        Console.Clear();
        Console.WriteLine($"Buscar {tipo.ToUpper()}\n" +
                          $"Ingrese el identificador (CI/Código) del {tipo.ToLower()} a buscar -> ");
        
        string idObjetivo = Console.ReadLine().Trim();

        int indiceObjetivo = BuscarIndice(idObjetivo);

        if (indiceObjetivo == -1)
        {
            Console.WriteLine($"*** {char.ToUpper(tipo[0]) + tipo.Substring(1)} no encontrado/a ***");
            return;
        }

        Lista[indiceObjetivo].MostrarDatos();
    }

    public void Actualizar(string tipo)
    {
        Console.Clear();
        Console.WriteLine($"Actualizar {tipo.ToUpper()}\n" +
                          $"Ingrese el identificador (CI/Código) del {tipo.ToLower()} objetivo -> ");
        
        string idObjetivo = Console.ReadLine().Trim();

        int indiceObjetivo = BuscarIndice(idObjetivo);

        if (indiceObjetivo == -1)
        {
            Console.WriteLine($"*** {char.ToUpper(tipo[0]) + tipo.Substring(1)} no encontrado/a ***");
            return;
        }
        
        Lista[indiceObjetivo].ActualizarDatos();
    }

    public void Eliminar(string tipo)
    {
        Console.Clear();
        Console.WriteLine($"Eliminar {tipo.ToUpper()}\n" +
                          $"Ingrese el identificador (CI/Código) del {tipo.ToLower()} a eliminar -> ");
        
        string idObjetivo = Console.ReadLine().Trim();

        int indiceObjetivo = BuscarIndice(idObjetivo);

        if (indiceObjetivo == -1)
        {
            Console.WriteLine($"*** {char.ToUpper(tipo[0]) + tipo.Substring(1)} no encontrado/a ***");
            return;
        }

        Lista.RemoveAt(indiceObjetivo);
    }
}