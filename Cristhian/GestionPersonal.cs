namespace Proyect_BancoSangre_Consola.Cristhian;

public class GestionPersonal : IGestionar
{
    private static List<Personal> _lista = [];
    public static List<Personal> Lista 
    {
        get { return _lista; }
        protected set { _lista = value; }
    }

    private string _rutaArchivoPersonal = @"Personal.txt";
    
    public GestionPersonal() {}

    public void CargarArchivo()
    {
        if ( !File.Exists(_rutaArchivoPersonal) ) return;

        Lista = new List<Personal>();

        using (StreamReader archivoPersonal = new StreamReader(_rutaArchivoPersonal))
        {
            string linea;

            while ((linea = archivoPersonal.ReadLine()) != null)
            {
                string[] datosPersonal = linea.Split('░');
                
                Lista.Add( new Personal(
                    Guid.Parse(datosPersonal[0]),
                    datosPersonal[1],
                    datosPersonal[2],
                    datosPersonal[3],
                    datosPersonal[4],
                    Convert.ToByte(datosPersonal[5]),
                    datosPersonal[6])
                );
            }
        }
        Console.WriteLine("*** Cargado de datos exitoso!!! ***");
    }

    public void GuardarArchivo()
    {
        if (Lista == null) return;

        using (StreamWriter archivoPersonal = new StreamWriter(_rutaArchivoPersonal))
        {
            foreach (var personal in Lista)
            {
                archivoPersonal.WriteLine($"{personal.IdPersonal}░" +
                                          $"{personal.Nombre}░" +
                                          $"{personal.CI}░" +
                                          $"{personal.Telefono}░" +
                                          $"{personal.CorreoElectronico}░" +
                                          $"{personal.Edad}░" +
                                          $"{personal.Cargo}");
            }
        }
        Console.WriteLine("*** Guardado de datos exitoso!!! ***"); 
    }

    public void Registrar()
    {
        ConsoleKey opcionContinuarRegistro = ConsoleKey.None;

        do
        {
            Console.Write(" * REGISTRO DE PERSONAL *\n" +
                          "Ingrese:\n" +
                          " Nombre -> ");
            string nom = Console.ReadLine().Trim();
            Console.Write(" C.I. -> ");
            string ci = Console.ReadLine().Trim();
            Console.Write(" Telefono -> ");
            string telefono = Console.ReadLine().Trim();
            Console.Write(" Correo Electronico");
            string email = ILeerYValidar.Correo();
            Console.Write(" Edad");
            byte edad = ILeerYValidar.Byteee();
            Console.Write(" Cargo -> ");
            string cargo = Console.ReadLine().Trim();
            
            Lista.Add( new Personal( Guid.CreateVersion7() ,nom, ci, telefono, email, edad, cargo) );
            
            Console.Write("Personal Registrado!!!\n" +
                          "Pulse:\n" +
                          " Espacio (o cualquier tecla) para continuar con el registro.\n" +
                          " ENTER para terminar el registro.");
            opcionContinuarRegistro = Console.ReadKey().Key;
            Console.WriteLine("\n");
            
        } while (opcionContinuarRegistro != ConsoleKey.Enter);
    }

    public void Listar()
    {   
        Console.WriteLine($"\tLISTA del PERSONAL\n" +
                          $"┌{new string('─',32)}┬{new string('─',10)}┬{new string('─',10)}┬{new string('─',27)}┬{new string('─',9)}┬{new string('─',22)}┬{new string('─',38)}┐\n" +
                          $"│ {"NOMBRE COMPLETO",-30} │ {"C.I.",-8} | TELEFONO | {"CORREO ELECTRONICO",-25} | {"EDAD",-7} | {"CARGO",-20} | {"ID PERSONAL", -36} |\n" +
                          $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',22)}┼{new string('─',38)}┤");

        foreach (var chambeador in  Lista)
        {
            if ( Lista.IndexOf(chambeador) != Lista.Count - 1 )
            {
                Console.WriteLine($"│ {chambeador.Nombre,-30} │ {chambeador.CI,-8} | {chambeador.Telefono} | {chambeador.CorreoElectronico,-25} | {chambeador.Edad,-7} | {chambeador.Cargo,-20} | {chambeador.IdPersonal} |\n" +
                              $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',22)}┼{new string('─',38)}┤");
            }
            else
            {
                Console.WriteLine($"│ {chambeador.Nombre,-30} │ {chambeador.CI,-8} | {chambeador.Telefono} | {chambeador.CorreoElectronico,-25} | {chambeador.Edad,-7} | {chambeador.Cargo,-20} | {chambeador.IdPersonal} |\n" +
                                  $"└{new string('─',32)}┴{new string('─',10)}┴{new string('─',10)}┴{new string('─',27)}┴{new string('─',9)}┴{new string('─',22)}┴{new string('─',38)}┘");
            }
        }
        Console.Write("Pulse cualquier tecla para continuar...");
        Console.ReadKey();
    }
    
    // Esto devuelve el indice, asi consultan en la lista con el indice que les de
    // Ejemplo: GestionPersonal.Lista[indiceObjetivo].MostrarDatos();
    public int BuscarIndice(Guid idBuscado)
    {
        foreach (var personal in Lista)
        {
            if (personal.IdPersonal == idBuscado) return Lista.IndexOf(personal);
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
        Console.WriteLine("Buscar Personal\n" +
                          "Ingrese el CI del personal a buscar -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo); // aqui puede que hacerlo por GUID sea mas complejo para el usuario
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Personal no encontrado ***");
            return;
        }
        
        Lista[indiceObjetivo].MostrarDatos();
        
    }

    public void Actualizar()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Personal\n" +
                          "Ingrese el CI del personal objetivo -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo); // aqui puede que hacerlo por GUID sea mas complejo para el usuario
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Personal no encontrado ***");
            return;
        }
        
        Lista[indiceObjetivo].ActualizarDatos();
        Console.WriteLine(" Personal Actualizado!!!");
    }

    public void Eliminar()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Personal\n" +
                          "Ingrese el CI del personal objetivo -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo);
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Personal no encontrado ***");
            return;
        }

        Console.Write($"Personal por Eliminar\n" +
                      $"\tNombre: {Lista[indiceObjetivo].Nombre} | CI: {Lista[indiceObjetivo].Nombre}\n" +
                      $"¡SE NECESITA CONFIRMACION!\n" +
                      $"¿Esta Seguro de Eliminar a este empleado? (Responda Si o No)\n" +
                      $" -> ");
        string opcionConfirmar = Console.ReadLine();

        if (opcionConfirmar.ToLower() == "si")
        {
            Lista.RemoveAt(indiceObjetivo);
            Console.WriteLine(" Personal Eliminado!!!");
            return;
        }
        
        Console.WriteLine("*** OPCION INVALIDA ***\n" +
                          "Se Cancela la eliminacion, Volviendo...");
    }
}