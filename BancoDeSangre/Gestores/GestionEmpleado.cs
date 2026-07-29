using ProyectoBancoSangre.Clases;
using ProyectoBancoSangre.Interfaces;

namespace ProyectoBancoSangre.Gestores;

public class GestionEmpleado : IGestionar
{
    private static List<Empleado> _lista = [];
    public static List<Empleado> Lista 
    {
        get { return _lista; }
        protected set { _lista = value; }
    }

    private string _rutaArchivoEmpleado = @"Empleado.txt";
    
    public GestionEmpleado() {}

    public void CargarArchivo()
    {
        if ( !File.Exists(_rutaArchivoEmpleado) ) return;
        
        using (StreamReader archivoEmpleado = new StreamReader(_rutaArchivoEmpleado))
        {
            string linea;

            while ((linea = archivoEmpleado.ReadLine()) != null)
            {
                string[] datoEmpleado = linea.Split('░');
                
                Lista.Add( new Empleado(
                    Guid.Parse(datoEmpleado[0]),
                    datoEmpleado[1],
                    datoEmpleado[2],
                    datoEmpleado[3],
                    datoEmpleado[4],
                    Convert.ToByte(datoEmpleado[5]),
                    datoEmpleado[6])
                );
            }
        }
        Console.WriteLine("*** Cargado de datos exitoso!!! ***");
    }

    public void GuardarArchivo()
    {
        if (Lista == null) return;

        using (StreamWriter archivoEmpleado = new StreamWriter(_rutaArchivoEmpleado))
        {
            foreach (var chambeador in Lista)
            {
                archivoEmpleado.WriteLine($"{chambeador.IdEmpleado}░" +
                                          $"{chambeador.Nombre}░" +
                                          $"{chambeador.CI}░" +
                                          $"{chambeador.Telefono}░" +
                                          $"{chambeador.CorreoElectronico}░" +
                                          $"{chambeador.Edad}░" +
                                          $"{chambeador.Cargo}");
            }
        }
        Console.WriteLine("*** Guardado de datos exitoso!!! ***"); 
    }

    public void Registrar()
    {
        ConsoleKey opcionContinuarRegistro = ConsoleKey.None;

        do
        {
            Console.Write("--- REGISTRO DE EMPLEADO ---\n" +
                          "Ingrese los datos:\n" +
                          " Nombre");
            string nom = ILeerYValidar.Nombre();
            Console.Write(" C.I.");
            string ci = ILeerYValidar.Ci();
            Console.Write(" Telefono -> ");
            string telefono = ILeerYValidar.Telefono();
            Console.Write(" Correo Electronico");
            string email = ILeerYValidar.Correo();
            Console.Write(" Edad");
            byte edad = ILeerYValidar.ByteeeEdadEmpleado();
            Console.Write(" Cargo -> ");
            string cargo = ILeerYValidar.Nombre();
            
            Lista.Add( new Empleado( Guid.CreateVersion7() ,nom, ci, telefono, email, edad, cargo) );

            Console.Clear();
            Console.Write("Empleado Registrado!!!\n" +
                          "Pulse:\n" +
                          " Espacio (o cualquier tecla) para continuar con el registro.\n" +
                          " ENTER para terminar el registro.");
            opcionContinuarRegistro = Console.ReadKey().Key;
            Console.WriteLine("\n");
            
        } while (opcionContinuarRegistro != ConsoleKey.Enter);
    }

    public void Listar()
    {   
        Console.WriteLine($"\tLISTA de EMPLEADO\n" +
                          $"┌{new string('─',32)}┬{new string('─',10)}┬{new string('─',10)}┬{new string('─',27)}┬{new string('─',9)}┬{new string('─',22)}┬{new string('─',38)}┐\n" +
                          $"│ {"NOMBRE COMPLETO",-30} │ {"C.I.",-8} | TELEFONO | {"CORREO ELECTRONICO",-25} | {"EDAD",-7} | {"CARGO",-20} | {"ID EMPLEADO", -36} |\n" +
                          $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',22)}┼{new string('─',38)}┤");

        foreach (var chambeador in  Lista)
        {
            if ( Lista.IndexOf(chambeador) != Lista.Count - 1 )
            {
                Console.WriteLine($"│ {chambeador.Nombre,-30} │ {chambeador.CI,-8} | {chambeador.Telefono} | {chambeador.CorreoElectronico,-25} | {chambeador.Edad,-7} | {chambeador.Cargo,-20} | {chambeador.IdEmpleado} |\n" +
                              $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',22)}┼{new string('─',38)}┤");
            }
            else
            {
                Console.WriteLine($"│ {chambeador.Nombre,-30} │ {chambeador.CI,-8} | {chambeador.Telefono} | {chambeador.CorreoElectronico,-25} | {chambeador.Edad,-7} | {chambeador.Cargo,-20} | {chambeador.IdEmpleado} |\n" +
                                  $"└{new string('─',32)}┴{new string('─',10)}┴{new string('─',10)}┴{new string('─',27)}┴{new string('─',9)}┴{new string('─',22)}┴{new string('─',38)}┘");
            }
        }
        Console.Write("Pulse cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodos que devuelven al chambeador Buscado, ya sea por IdEmpleado o CI
    public Empleado? ObtenerPersonal(Guid idBuscado)
    {
        foreach (var personal in Lista)
        {
            if (personal.IdEmpleado == idBuscado) return personal;
        }

        return null;
    }

    public Empleado? ObtenerPersonal(string ciBuscado)
    {
        foreach (var personal in Lista)
        {
            if (personal.CI == ciBuscado) return personal;
        }

        return null;
    }

    // Esto devuelve el indice, asi consultan en la lista con el indice que les de
    // Ejemplo: GestionEmpleado.Lista[indiceObjetivo].MostrarDatos();
    public int BuscarIndice(Guid idBuscado)
    {
        foreach (var personal in Lista)
        {
            if (personal.IdEmpleado == idBuscado) return Lista.IndexOf(personal);
        }
        
        return -1;
    }

    public int BuscarIndice(string ci)
    {
        foreach (var personal in Lista)
        {
            if (personal.CI == ci) return Lista.IndexOf(personal);
        }
        
        return -1;
    }

    public void Buscar()
    {
        Console.Clear();
        Console.WriteLine("Buscar Empleado\n" +
                          "Ingrese el CI del chambeador a buscar -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo); // aqui puede que hacerlo por GUID sea mas complejo para el usuario
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Empleado no encontrado ***");
            return;
        }
        
        Lista[indiceObjetivo].MostrarDatos();
        
    }

    public void Actualizar()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Empleado\n" +
                          "Ingrese el CI del chambeador objetivo -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo); // aqui puede que hacerlo por GUID sea mas complejo para el usuario
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Empleado no encontrado ***");
            return;
        }
        
        Lista[indiceObjetivo].ActualizarDatos();
        Console.WriteLine(" Empleado Actualizado!!!");
    }

    public void Eliminar()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Empleado\n" +
                          "Ingrese el CI del chambeador objetivo -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo);
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Empleado no encontrado ***");
            return;
        }

        Console.Write($"Empleado por Eliminar\n" +
                      $"\tNombre: {Lista[indiceObjetivo].Nombre} | CI: {Lista[indiceObjetivo].Nombre}\n" +
                      $"¡SE NECESITA CONFIRMACION!\n" +
                      $"¿Esta Seguro de Eliminar a este empleado? (Responda Si o No)\n" +
                      $" -> ");
        string opcionConfirmar = Console.ReadLine();

        if (opcionConfirmar.ToLower() == "si")
        {
            Lista.RemoveAt(indiceObjetivo);
            Console.WriteLine(" Empleado Eliminado!!!");
            return;
        }
        
        Console.WriteLine("*** OPCION INVALIDA ***\n" +
                          "Se Cancela la eliminacion, Volviendo...");
    }
}