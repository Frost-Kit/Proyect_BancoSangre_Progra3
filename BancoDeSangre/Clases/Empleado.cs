using ProyectoBancoSangre.Interfaces;

namespace ProyectoBancoSangre.Clases;

public class Empleado : Persona
{
    private Guid _idEmpleado;
    private string _cargo;
    public Guid IdEmpleado
    {
        get { return _idEmpleado; }
        protected set { _idEmpleado = value; }
    }
    public string Cargo
    {
        get { return _cargo; }
        protected set { _cargo = value; }
    }

    public Empleado()
    {
        IdEmpleado = Guid.Empty;
        Cargo = "PorAsignar";
    }

    public Empleado(Guid idEmpleado,string nombre, string ci, string telefono, string email, byte edad, string cargo)
        :base(nombre, ci, telefono, email, edad)
    {
        IdEmpleado = idEmpleado;
        Cargo = cargo;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"===========================================\n" +
                          $"\tDatos Empleado\n" +
                          $" - ID: {IdEmpleado}\n" +
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
            
            Console.Write($"\n Actualizar Datos del Chambeador (ID: {IdEmpleado})\n" +
                          $"╔════════════════════════════════════════════════╗\n" +
                          $"║  Pulse:                                        ║\n" +
                          $"║       ├ 1 para Cambiar el Nombre               ║\n" +
                          $"║       ├ 2 para Cambiar el C.I.                 ║\n" +
                          $"║       ├ 3 para Cambiar el Telefono             ║\n" +
                          $"║       ├ 4 para Cambiar el Correo electronico   ║\n" +
                          $"║       ├ 5 para Cambiar la Edad                 ║\n" +
                          $"║       └ 6 para Cambiar el Cargo                ║\n" +
                          $"║  0 para VOLVER al menu anterior.               ║\n" +
                          $"╚════════════════════════════════════════════════╝\n");
            opcionActualizar = Console.ReadKey(true).Key;

            switch (opcionActualizar)
            {
                case  ConsoleKey.D1:
                    Console.Write($" - Nombre ACTUAL => {Nombre} -\n" +
                                  $"Ingrese el nuevo nombre");
                    Nombre = ILeerYValidar.Nombre();
                    break;
                case ConsoleKey.D2:
                    Console.Write($" - C.I. ACTUAL => {CI} -\n" +
                                  $"Ingrese el nuevo CI");
                    CI = ILeerYValidar.Ci();
                    break;
                case ConsoleKey.D3:
                    Console.Write($" - Telefono ACTUAL => {Telefono} -\n" +
                                  $"Ingrese el nuevo telefono");
                    Telefono = ILeerYValidar.Telefono();
                    break;
                case ConsoleKey.D4:
                    Console.Write($" - Correo Electronico ACTUAL => {CorreoElectronico} -\n" +
                                  $"Ingrese el nuevo Correo Electronico");
                    CorreoElectronico = ILeerYValidar.Correo();
                    break;
                case ConsoleKey.D5:
                    Console.Write($" - Edad ACTUAL => {Edad} -\n" +
                                  $"Ingrese la nueva edad");
                    Edad = ILeerYValidar.ByteeeEdadEmpleado();
                    break;
                case ConsoleKey.D6:
                    Console.Write($" - Cargo ACTUAL => {Cargo} -\n" +
                                  $"Ingrese el nuevo cargo");
                    Cargo = ILeerYValidar.Nombre();
                    break;
                case ConsoleKey.D0:
                    Console.Write("Volviendo...");
                    break;
                default: Console.WriteLine("*** Error: Opcion Invalida. ***"); break;
            }
        } while (opcionActualizar != ConsoleKey.D0);
    }
}