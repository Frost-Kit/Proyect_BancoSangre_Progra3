namespace Proyect_BancoSangre_Consola.Cristhian;

public class Personal : Persona
{
    private Guid _idPersonal;
    private string _cargo;
    public Guid IdPersonal
    {
        get { return _idPersonal; }
        protected set { _idPersonal = value; }
    }
    public string Cargo
    {
        get { return _cargo; }
        protected set { _cargo = value; }
    }

    public Personal()
    {
        IdPersonal = Guid.Empty;
        Cargo = "PorAsignar";
    }

    public Personal(Guid idPersonal,string nombre, string ci, string telefono, string email, byte edad, string cargo)
        :base(nombre, ci, telefono, email, edad)
    {
        IdPersonal = idPersonal;
        Cargo = cargo;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"===========================================\n" +
                          $"\tDatos Personal\n" +
                          $" - ID: {IdPersonal}\n" +
                          $" - Nombre: {Nombre}\n" +
                          $" - Ci: {CI}\n" +
                          $" - Telefono: {Telefono}\n" +
                          $" - Email: {CorreoElectronico}\n" +
                          $" - Edad: {Edad}\n" +
                          $" - Cargo: {Cargo}\n" +
                          $"===========================================\n");
    }

    public override void ActualizarDatos()
    {
        ConsoleKey opcionActualizar = ConsoleKey.None;
        do
        {
            Console.Clear();
            
            Console.Write($" Actualizar Datos del Chambeador(ID: {IdPersonal})\n" +
                          $"\tIngrese:\n" +
                          $"\t     ├ 1 para Cambiar el nombre\n" +
                          $"\t     ├ 2 para Cambiar el C.I.\n" +
                          $"\t     ├ 3 para Cambiar el telefono\n" +
                          $"\t     ├ 4 para Cambiar el Correo electronico\n" +
                          $"\t     ├ 5 para Cambiar la Edad\n" +
                          $"\t     └ 6 para Cambiar el Cargo\n" +
                          $"\t0 para VOLVER al menu anterior.\n");
            opcionActualizar = Console.ReadKey().Key;

            switch (opcionActualizar)
            {
                case  ConsoleKey.D1:
                    Console.Write($" - Nombre ACTUAL => {Nombre} -\n" +
                                  $"Ingrese el nuevo nombre -> ");
                    Nombre = Console.ReadLine().Trim();
                    break;
                case ConsoleKey.D2:
                    Console.Write($" - C.I. ACTUAL => {CI} -\n" +
                                  $"Ingrese el nuevo CI -> ");
                    CI = Console.ReadLine().Trim();
                    break;
                case ConsoleKey.D3:
                    Console.Write($" - Telefono ACTUAL => {Telefono} -\n" +
                                  $"Ingrese el nuevo telefono -> ");
                    Telefono = Console.ReadLine().Trim();
                    break;
                case ConsoleKey.D4:
                    Console.Write($" - Correo Electronico ACTUAL => {CorreoElectronico} -\n" +
                                  $"Ingrese el nuevo Correo Electronico");
                    CorreoElectronico = ILeerYValidar.Correo();
                    break;
                case ConsoleKey.D5:
                    Console.Write($" - Edad ACTUAL => {Edad} -\n" +
                                  $"Ingrese la nueva edad");
                    Edad = ILeerYValidar.Byteee();
                    break;
                case ConsoleKey.D6:
                    Console.Write($" - Cargo ACTUAL => {Cargo} -\n" +
                                  $"Ingrese el nuevo cargo -> ");
                    Cargo = Console.ReadLine().Trim();
                    break;
                case ConsoleKey.D0:
                    Console.Write("Volviendo...");
                    break;
                default: Console.WriteLine("*** Error: Opcion Invalida. ***"); break;
            }
        } while (opcionActualizar != ConsoleKey.D0);
    }
}

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

    // Esto retorna el indice del personal buscado
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
        
        Lista.RemoveAt(indiceObjetivo);
        Console.WriteLine(" Personal Eliminado!!!");
    }
}