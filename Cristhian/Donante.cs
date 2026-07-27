namespace Proyect_BancoSangre_Consola.Cristhian;

public enum TipoSangre
{
    A,
    B,
    AB,
    O
}

public class Donante : Persona
{
    private Guid _idDonante;
    private TipoSangre _tipoSangre;
    private double _peso;
    private double _altura;
    private List<DateTimeOffset> _historialDonaciones;

    public Guid IdDonante
    {
        get { return _idDonante; }
        protected set { _idDonante = value; }
    }

    public TipoSangre TipoSangre
    {
        get { return _tipoSangre; }
        protected set { _tipoSangre = value; }
    }

    public double Peso
    {
        get { return _peso; }
        protected set { _peso = value; }
    }

    public double Altura
    {
        get { return _altura; }
        protected set { _altura = value; }
    }

    public List<DateTimeOffset> HistorialDonaciones
    {
        get { return _historialDonaciones; }
        protected set { _historialDonaciones = value; }
    }

    public Donante()
    {
        IdDonante = Guid.Empty;
        TipoSangre = TipoSangre.O;
        Peso = 0.0;
        Altura = 0.0;
        HistorialDonaciones = new List<DateTimeOffset>();
    }

    public Donante(Guid idDonante, string nombre, string ci, string telefono, string email, byte edad,
         TipoSangre tipoSangre, double peso, double altura, List<DateTimeOffset> historialDonaciones = null)
        : base(nombre, ci, telefono, email, edad)
    {
        IdDonante = idDonante;
        TipoSangre = tipoSangre;
        Peso = peso;
        Altura = altura;
        if (historialDonaciones == null) HistorialDonaciones = [];
        else HistorialDonaciones = historialDonaciones;
    }

    string FormatearHistorial()
    {
        string histoFormateado = string.Empty;

        foreach (var histo in HistorialDonaciones)
        {
            histoFormateado += $"  * {histo.ToString("dd/MM/yyyy hh:mm tt")}\n";
        }

        return histoFormateado;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"===========================================\n" +
                          $"\tDATOS del DONANTE\n" +
                          $" - ID: {IdDonante}\n" +
                          $" - Nombre: {Nombre}\n" +
                          $" - Ci: {CI}\n" +
                          $" - Telefono: {Telefono}\n" +
                          $" - Email: {CorreoElectronico}\n" +
                          $" - Edad: {Edad}\n" +
                          $" - Tipo de Sangre: {TipoSangre}\n" +
                          $" - Peso: {Peso}\n" +
                          $" - Altura: {Altura}\n" +
                          $"--------------------------------------------\n" +
                          $"\tHISTORIAL DE DONACIONES:\n" +
                          $"  * {FormatearHistorial()}" +
                          $"===========================================\n");
    }

    public void VerHistorial()
    {
        Console.WriteLine($"===========================================\n" +
                          $" Donante: {Nombre} CI: {CI}\n" +
                          $"\tHISTORIAL de DONACIONES\n" +
                          $"{FormatearHistorial}" +
                          $"===========================================\n");
    }

    public override void ActualizarDatos()
    {
        ConsoleKey opcionActualizar;
        do
        {
            Console.Write($" Actualizar Datos del DONANTE (ID : {IdDonante})\n" +
                          $"\tPulse:\n" +
                          $"\t     ├ 1 para Cambiar el nombre\n" +
                          $"\t     ├ 2 para Cambiar el C.I.\n" +
                          $"\t     ├ 3 para Cambiar el telefono\n" +
                          $"\t     ├ 4 para Cambiar el Correo electronico\n" +
                          $"\t     ├ 5 para Cambiar la Edad\n" +
                          $"\t     ├ 6 para Cambiar el Tipo de sangre\n" +
                          $"\t     ├ 7 para Cambiar el Peso\n" +
                          $"\t     └ 8 para Cambiar la Altura\n" +
                          $"\t0 para VOLVER al menu anterior.\n");
            opcionActualizar = Console.ReadKey().Key;

            switch (opcionActualizar)
            {
                case ConsoleKey.D1:
                    Console.Write($" - Nombre ACTUAL => {Nombre} -\n" +
                                  $"Ingrese el nuevo nombre -> ");
                    Nombre = Console.ReadLine().Trim();
                    Console.Clear();
                    break;

                case ConsoleKey.D2:
                    Console.Write($" - C.I. ACTUAL => {CI} -\n" +
                                  $"Ingrese el nuevo CI -> ");
                    CI = Console.ReadLine().Trim();
                    Console.Clear();
                    break;

                case ConsoleKey.D3:
                    Console.Write($" - Telefono ACTUAL => {Telefono} -\n" +
                                  $"Ingrese el nuevo telefono -> ");
                    Telefono = Console.ReadLine().Trim();
                    Console.Clear();
                    break;

                case ConsoleKey.D4:
                    Console.Write($" - Correo Electronico ACTUAL => {CorreoElectronico} -\n" +
                                  $"Ingrese el nuevo Correo Electronico -> ");
                    CorreoElectronico = Console.ReadLine().Trim();
                    Console.Clear();
                    break;

                case ConsoleKey.D5:
                    Console.Write($" - Edad ACTUAL => {Edad} -\n" +
                                  $"Ingrese la nueva edad");
                    Edad = ILeerYValidar.Byteee();
                    Console.Clear();
                    break;

                case ConsoleKey.D6:
                    Console.Write($" - Tipo de Sangre ACTUAL => {TipoSangre} -\n" +
                                  $"Ingrese el nuevo tipo de sangre -> ");
                    TipoSangre = Enum.TryParse(Console.ReadLine().Trim(), true, out TipoSangre tipoSangreValidada) ?
                        tipoSangreValidada : TipoSangre.O;
                    Console.Clear();
                    break;

                case ConsoleKey.D7:
                    Console.Write($" - Peso ACTUAL => {Peso} -\n" +
                                  $"Ingrese el nuevo peso");
                    Peso = ILeerYValidar.Doubleee();
                    Console.Clear();
                    break;

                case ConsoleKey.D8:
                    Console.Write($" - Altura ACTUAL => {Altura} -\n" +
                                  $"Ingrese la nueva altura");
                    Altura = ILeerYValidar.Doubleee();
                    Console.Clear();
                    break;

                case ConsoleKey.D0: Console.WriteLine("Volviendo..."); break;

                default: 
                    Console.Clear();
                    Console.WriteLine("*** Error: Opcion Invalida. ***"); 
                    break;
            }
        } while (opcionActualizar != ConsoleKey.D0);
    }

    public void RegistrarDonancion(DateTimeOffset fecha) => HistorialDonaciones.Add(fecha);

    public DateTimeOffset DarUltimafechaDonacion() => HistorialDonaciones[^1];
}

public class GestionDonante : IGestionar
{
    private static List<Donante> _lista = [];
    public static List<Donante> Lista 
    {
        get { return _lista; }
        protected set { _lista = value; }
    }

    private string _rutaArchivoDonante = @"Donante.txt";
    
    public GestionDonante() {}

    public void CargarArchivo()
    {
        if (!File.Exists(_rutaArchivoDonante)) return;

        using (StreamReader archivoDonante = new StreamReader(_rutaArchivoDonante))
        {
            string linea;

            while ((linea = archivoDonante.ReadLine()) != null)
            {
                var datosDonante = linea.Split('░');

                List<DateTimeOffset> histoTemp = [];
                
                foreach (var fechaaaa in datosDonante[9].Split('▒'))
                {
                    histoTemp.Add(DateTimeOffset.Parse(fechaaaa));
                }
                //histoTemp.AddRange(datosDonante[9].Split('▒').Select(fechaaaa => DateTimeOffset.Parse(fechaaaa)));

                Lista.Add( new Donante(
                    Guid.Parse(datosDonante[0]),
                    datosDonante[1],
                    datosDonante[2],
                    datosDonante[3],
                    datosDonante[4],
                    Convert.ToByte(datosDonante[5]),
                    Enum.Parse<TipoSangre>(datosDonante[6]),
                    Convert.ToDouble(datosDonante[7]),
                    Convert.ToDouble(datosDonante[8]),
                    histoTemp
                    )
                );
            }
        }
        Console.WriteLine("*** Cargado de datos exitoso!!! ***");
    }

    public void GuardarArchivo()
    {
        if (Lista == null) return;

        using (StreamWriter archivoDonante = new StreamWriter(_rutaArchivoDonante))
        {
            foreach (var personal in Lista)
            {
                archivoDonante.WriteLine($"{personal.IdDonante}░" +
                                          $"{personal.Nombre}░" +
                                          $"{personal.CI}░" +
                                          $"{personal.Telefono}░" +
                                          $"{personal.CorreoElectronico}░" +
                                          $"{personal.Edad}░" +
                                          $"{personal.TipoSangre}░" +
                                          $"{personal.Peso}░" +
                                          $"{personal.Altura}░" +
                                          $"{string.Join('▒',personal.HistorialDonaciones)}");
            }
        }
        Console.WriteLine("*** Guardado de datos exitoso!!! ***"); 
    }

    public void Registrar()
    {
        ConsoleKey opcionContinuarRegistro = ConsoleKey.None;

        do
        {
            Console.Write(" * REGISTRO DE DONANTE *\n" +
                          "Ingrese:\n" +
                          " Nombre -> ");
            string nombre = Console.ReadLine();
            Console.Write(" C.I. -> ");
            string ci = Console.ReadLine();
            Console.Write(" Telefono -> ");
            string telefono = Console.ReadLine();
            Console.Write(" Correo Electronico -> ");
            string email = Console.ReadLine();
            Console.Write(" Edad");
            byte edad = ILeerYValidar.Byteee();
            Console.Write(" Tipo de sangre -> ");
            TipoSangre tipSangre = Enum.TryParse(Console.ReadLine().Trim(),true, out TipoSangre tipoSangreValidada) ? 
                tipoSangreValidada : TipoSangre.O;
            Console.Write(" Peso");
            double peso = ILeerYValidar.Doubleee();
            Console.Write(" Altura");
            double altura = ILeerYValidar.Doubleee();
            
            Lista.Add( new Donante( Guid.CreateVersion7(), nombre, ci, telefono, email, edad, tipSangre, peso, altura) );
            
            Console.Write("Donante Registrado!!!\n" +
                          "Pulse:\n" +
                          " Espacio (o cualquier tecla) para continuar con el registro.\n" +
                          " ENTER para terminar el registro.");
            opcionContinuarRegistro = Console.ReadKey().Key;
            Console.WriteLine("\n");
            
        } while (opcionContinuarRegistro != ConsoleKey.Enter);
        
        Console.WriteLine("Volviendo al menu anterior...");
    }

    public void Listar()
    {
        Console.WriteLine($"\tLISTA de DONANTES\n" +
                          $"┌{new string('─',32)}┬{new string('─',10)}┬{new string('─',10)}┬{new string('─',27)}┬{new string('─',9)}┬{new string('─',16)}┬{new string('─',9)}┬{new string('─',9)}┬{new string('─',38)}┐\n" +
                          $"│ {"NOMBRE COMPLETO",-30} │ {"C.I.",-8} | TELEFONO | {"CORREO ELECTRONICO",-25} | {"EDAD",-7} | TIPO DE SANGRE | {"PESO",-7} | {"ALTURA",-7} | {"ID DONANTE", -36} |\n" +
                          $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',16)}┼{new string('─',9)}┼{new string('─',9)}┼{new string('─',38)}┤");

        foreach (var sujetPrueba in  Lista)
        {
            if ( Lista.IndexOf(sujetPrueba) != Lista.Count - 1 )
            {
                Console.WriteLine($"│ {sujetPrueba.Nombre,-30} │ {sujetPrueba.CI,-8} | {sujetPrueba.Telefono, -8} | {sujetPrueba.CorreoElectronico,-25} | {sujetPrueba.Edad,-7} | {sujetPrueba.TipoSangre, -14} | {sujetPrueba.Peso, -7} | {sujetPrueba.Altura, -7} | {sujetPrueba.IdDonante} |\n" +
                                  $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',16)}┼{new string('─',9)}┼{new string('─',9)}┼{new string('─',38)}┤");
            }
            else
            {
                Console.WriteLine($"│ {sujetPrueba.Nombre,-30} │ {sujetPrueba.CI,-8} | {sujetPrueba.Telefono, -8} | {sujetPrueba.CorreoElectronico,-25} | {sujetPrueba.Edad,-7} | {sujetPrueba.TipoSangre, -14} | {sujetPrueba.Peso, -7} | {sujetPrueba.Altura, -7} | {sujetPrueba.IdDonante} |\n" +
                                  $"└{new string('─',32)}┴{new string('─',10)}┴{new string('─',10)}┴{new string('─',27)}┴{new string('─',9)}┴{new string('─',16)}┴{new string('─',9)}┴{new string('─',9)}┴{new string('─',38)}┘");
            }
        }
        Console.Write("Pulse cualquier tecla para continuar...");
        Console.ReadKey();
    }
    
    // Esto devuelve el indice, asi consultan en la lista con el indice que les de
    // Ejemplo: GestionPersonal.Lista[indiceObjetivo].MostrarDatos();
    public int BuscarIndice(Guid idBuscado)
    {
        foreach (var donante in Lista)
        {
            if (donante.IdDonante == idBuscado) return Lista.IndexOf(donante);
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
        Console.WriteLine("Buscar Donante\n" +
                          "Ingrese el CI del donante a buscar -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo); // aqui puede que hacerlo por GUID sea mas complejo para el usuario

        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Donante no encontrado ***");
            return;
        }
        
        Lista[indiceObjetivo].MostrarDatos();
    }

    public void Actualizar()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Donante\n" +
                          "Ingrese el CI del donante objetivo -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo); // aqui puede que hacerlo por GUID sea mas complejo para el usuario

        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Donante no encontrado ***");
            return;
        }
        
        Lista[indiceObjetivo].ActualizarDatos();
    }

    public void Eliminar()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Donante\n" +
                          "Ingrese el CI del donante objetivo -> ");
        string ciObjetivo = Console.ReadLine().Trim();
        
        int indiceObjetivo = BuscarIndice(ciObjetivo);
        
        if (indiceObjetivo == -1)
        {
            Console.WriteLine("*** Donante no encontrado ***");
            return;
        }
        
        Lista.RemoveAt(indiceObjetivo);
        Console.WriteLine(" Donante Eliminado!!!");
    }
}