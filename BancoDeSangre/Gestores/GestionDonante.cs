using ProyectoBancoSangre.Clases;
using ProyectoBancoSangre.Interfaces;

namespace ProyectoBancoSangre.Gestores;

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

                List<Guid> histoTemp = [];

                if (datosDonante.Length == 11)
                {
                    foreach (var idDonan in datosDonante[10].Split('▒'))
                    {
                        histoTemp.Add(Guid.Parse(idDonan));
                    }
                }
                
                //histoTemp.AddRange(datosDonante[10].Split('▒').Select(fechaaaa => DateTime.Parse(fechaaaa)));

                Lista.Add( new Donante(
                    Guid.Parse(datosDonante[0]),
                    datosDonante[1],
                    datosDonante[2],
                    datosDonante[3],
                    datosDonante[4],
                    Convert.ToByte(datosDonante[5]),
                    Enum.Parse<TipoSangre>(datosDonante[6]),
                    Enum.Parse<TipoRH>(datosDonante[7]),
                    Convert.ToDouble(datosDonante[8]),
                    Convert.ToDouble(datosDonante[9]),
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
                if (personal.HistorialDonaciones.Count == 0)
                {
                    archivoDonante.WriteLine($"{personal.IdDonante}░" +
                                             $"{personal.Nombre}░" +
                                             $"{personal.CI}░" +
                                             $"{personal.Telefono}░" +
                                             $"{personal.CorreoElectronico}░" +
                                             $"{personal.Edad}░" +
                                             $"{personal.TipoSangre}░" +
                                             $"{personal.RH}░" +
                                             $"{personal.Peso}░" +
                                             $"{personal.Altura}");
                }
                else
                {
                    archivoDonante.WriteLine($"{personal.IdDonante}░" +
                                             $"{personal.Nombre}░" +
                                             $"{personal.CI}░" +
                                             $"{personal.Telefono}░" +
                                             $"{personal.CorreoElectronico}░" +
                                             $"{personal.Edad}░" +
                                             $"{personal.TipoSangre}░" +
                                             $"{personal.RH}░" +
                                             $"{personal.Peso}░" +
                                             $"{personal.Altura}░" +
                                             $"{string.Join('▒',personal.HistorialDonaciones)}");
                }
                
            }
        }
        Console.WriteLine("*** Guardado de datos exitoso!!! ***"); 
    }

    public void Registrar()
    {
        ConsoleKey opcionContinuarRegistro = ConsoleKey.None;

        do
        {
            Console.Write("--- REGISTRO DE DONANTE ---\n" +
                          "Ingrese los datos:\n" +
                          " Nombre -> ");
            string nombre = ILeerYValidar.Nombre();
            Console.Write(" C.I. -> ");
            string ci = ILeerYValidar.Ci();
            Console.Write(" Telefono -> ");
            string telefono = ILeerYValidar.Telefono();
            Console.Write(" Correo Electronico");
            string email = ILeerYValidar.Correo();
            Console.Write(" Edad");
            byte edad = ILeerYValidar.ByteeeEdadDonante();
            Console.Write(" Tipo de sangre (A / B / AB / O) -> ");
            TipoSangre tipSangre = Enum.TryParse(Console.ReadLine().Trim(),true, out TipoSangre tipoSangreValidada) ? 
                tipoSangreValidada : TipoSangre.O;
            Console.Write(" Tipo de RH (Positivo / Negativo)");
            TipoRH tipRh = ILeerYValidar.Rhhh();
            Console.Write(" Peso");
            double peso = ILeerYValidar.DoubleeePeso();
            Console.Write(" Altura");
            double altura = ILeerYValidar.Doubleee();
            
            Lista.Add( new Donante( Guid.CreateVersion7(), nombre, ci, telefono, email, edad, tipSangre, tipRh, peso, altura) );

            Console.Clear();
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
                Console.WriteLine($"│ {sujetPrueba.Nombre,-30} │ {sujetPrueba.CI,-8} | {sujetPrueba.Telefono, -8} | {sujetPrueba.CorreoElectronico,-25} | {sujetPrueba.Edad,-7} | {sujetPrueba.TipoSangre.ToString() + (sujetPrueba.RH == TipoRH.Positivo ? '+' : '-'), -14} | {sujetPrueba.Peso, -7} | {sujetPrueba.Altura, -7} | {sujetPrueba.IdDonante} |\n" +
                                  $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',16)}┼{new string('─',9)}┼{new string('─',9)}┼{new string('─',38)}┤");
            }
            else
            {
                Console.WriteLine($"│ {sujetPrueba.Nombre,-30} │ {sujetPrueba.CI,-8} | {sujetPrueba.Telefono, -8} | {sujetPrueba.CorreoElectronico,-25} | {sujetPrueba.Edad,-7} | {sujetPrueba.TipoSangre.ToString() + (sujetPrueba.RH == TipoRH.Positivo ? '+' : '-'), -14} | {sujetPrueba.Peso, -7} | {sujetPrueba.Altura, -7} | {sujetPrueba.IdDonante} |\n" +
                                  $"└{new string('─',32)}┴{new string('─',10)}┴{new string('─',10)}┴{new string('─',27)}┴{new string('─',9)}┴{new string('─',16)}┴{new string('─',9)}┴{new string('─',9)}┴{new string('─',38)}┘");
            }
        }
        Console.Write("Pulse cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Metodos que devuelven al donante Buscado, ya sea por IdDonante o CI
    public Donante? ObtenerDonante(Guid idBuscado)
    {
        foreach (var donante in Lista)
        {
            if (donante.IdDonante == idBuscado) return donante;
        }

        return null;
    }

    public Donante? ObtenerDonante(string ciBuscado)
    {
        foreach (var donante in Lista)
        {
            if (donante.CI == ciBuscado) return donante;
        }

        return null;
    }

    // Esto devuelve el indice, asi consultan en la lista con el indice que les de
    // Ejemplo: GestionEmpleado.Lista[indiceObjetivo].MostrarDatos();
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

        Console.Write($"Donante por Eliminar\n" +
                      $"\tNombre: {Lista[indiceObjetivo].Nombre} | CI: {Lista[indiceObjetivo].Nombre}\n" +
                      $"¡SE NECESITA CONFIRMACION!\n" +
                      $"¿Esta Seguro de Eliminar a este Donante? (Responda Si o No)\n" +
                      $" -> ");
        string opcionConfirmar = Console.ReadLine();

        if (opcionConfirmar.ToLower() == "si")
        {
            Lista.RemoveAt(indiceObjetivo);
            Console.WriteLine(" Donante Eliminado!!!");
            return;
        }
        
        Console.WriteLine("*** OPCION INVALIDA ***\n" +
                          "Se Cancela la eliminacion, Volviendo...");
    }
}