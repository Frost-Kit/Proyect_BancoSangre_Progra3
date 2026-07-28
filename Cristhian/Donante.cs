namespace Proyect_BancoSangre_Consola.Cristhian;

public enum TipoSangre
{
    A,
    B,
    AB,
    O
}

public enum TipoRH
{
    Positivo,
    Negativo
}

public class Donante : Persona
{
    private Guid _idDonante;
    private TipoSangre _tipoSangre;
    private TipoRH _rh;
    private double _peso;
    private double _altura;
    private List<Guid> _historialDonaciones;

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

    public TipoRH RH
    {
        get { return _rh; }
        protected set { _rh = value; }
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

    public List<Guid> HistorialDonaciones
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
        HistorialDonaciones = new List<Guid>();
    }

    public Donante(Guid idDonante, string nombre, string ci, string telefono, string email, byte edad,
         TipoSangre tipoSangre, TipoRH tipoRH, double peso, double altura, List<Guid> historialDonaciones = null)
        : base(nombre, ci, telefono, email, edad)
    {
        IdDonante = idDonante;
        TipoSangre = tipoSangre;
        RH = tipoRH;
        Peso = peso;
        Altura = altura;
        if (historialDonaciones == null) HistorialDonaciones = [];
        else HistorialDonaciones = historialDonaciones;
    }

    string FormatearHistorial()
    {
        string histoFormateado = string.Empty;

        foreach (var donacion in HistorialDonaciones)
        {
            // POR HACER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Necesito el 
            // int indiceDonacion = GestionDonaciones.Lista[donacion].Fecha;
            // histoFormateado += $"  * {donacion.ToString("yyyy/MM/dd hh:mm tt")}\n";
            histoFormateado += $"  * {donacion.ToString("yyyy/MM/dd hh:mm tt")}\n";
        }

        return histoFormateado;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"===========================================\n" +
                          $"\tDATOS del DONANTE\n" +
                          $" - ID: {IdDonante}\n" +
                          $" - Nombre: {Nombre}\n" +
                          $" - CI: {CI}\n" +
                          $" - Telefono: {Telefono}\n" +
                          $" - Email: {CorreoElectronico}\n" +
                          $" - Edad: {Edad}\n" +
                          $" - Tipo de Sangre: {TipoSangre}{ (RH == TipoRH.Positivo? '+' : '-') }\n" +
                          $" - Tipo de RH: {RH}\n" +
                          $" - Peso: {Peso}\n" +
                          $" - Altura: {Altura}\n" +
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
            Console.Write($" Actualizar Datos del DONANTE (ID: {IdDonante})\n" +
                          $"\tPulse:\n" +
                          $"\t     ├ 1 para Cambiar el nombre\n" +
                          $"\t     ├ 2 para Cambiar el C.I.\n" +
                          $"\t     ├ 3 para Cambiar el telefono\n" +
                          $"\t     ├ 4 para Cambiar el Correo electronico\n" +
                          $"\t     ├ 5 para Cambiar la Edad\n" +
                          $"\t     ├ 6 para Cambiar el Tipo de sangre\n" +
                          $"\t     ├ 7 para Cambiar el Tipo de RH\n" +
                          $"\t     ├ 8 para Cambiar el Peso\n" +
                          $"\t     └ 9 para Cambiar la Altura\n" +
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
                                  $"Ingrese el nuevo Correo Electronico");
                    CorreoElectronico = ILeerYValidar.Correo();
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
                                  $"Ingrese el nuevo tipo de sangre\n" +
                                  $"\tOpciones Validas: A - B - AB - O\n" +
                                  $" Aqui -> ");
                    TipoSangre = Enum.TryParse(Console.ReadLine().Trim(), true, out TipoSangre tipoSangreValidada) ?
                        tipoSangreValidada : TipoSangre.O;
                    Console.Clear();
                    break;

                case ConsoleKey.D7:
                    Console.Write($" - Tipo RH ACTUAL => {RH} -\n" +
                                  $"Ingrese el nuevo tipo RH\n" +
                                  $"\tOpciones Validas: Positivo - Negativo\n" +
                                  $" Aqui");
                    RH = ILeerYValidar.Rhhh();
                    Console.Clear();
                    break;

                case ConsoleKey.D8:
                    Console.Write($" - Peso ACTUAL => {Peso} -\n" +
                                  $"Ingrese el nuevo peso");
                    Peso = ILeerYValidar.Doubleee();
                    Console.Clear();
                    break;

                case ConsoleKey.D9:
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

    public void RegistrarDonancion(Guid IdDonacion) => HistorialDonaciones.Add(IdDonacion);

    public Guid DarUltimafechaDonacion() => HistorialDonaciones[^1];
}

