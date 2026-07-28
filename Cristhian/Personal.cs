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
                          $" - CI: {CI}\n" +
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
            opcionActualizar = Console.ReadKey(true).Key;

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