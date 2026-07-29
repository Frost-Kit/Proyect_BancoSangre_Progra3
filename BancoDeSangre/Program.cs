using ProyectoBancoSangre.Clases;
using ProyectoBancoSangre.Gestores;
using ProyectoBancoSangre.Interfaces;

namespace ProyectoBancoSangre;

class Program
{
    // Se crean y/o instancian los objetos necesarios para el programa
    static GestionDonante gestorDonantes = new GestionDonante();
    static GestionEmpleado gestorEmpleados = new GestionEmpleado();
    static List<SangreEntera> listaSangreEntera = new List<SangreEntera>();
    static List<GlobulosRojos> listaGlobulosRojos = new List<GlobulosRojos>();
    static List<Plasma> listaplasma = new List<Plasma>();
    static List<Plaquetas> listaplaquetas = new List<Plaquetas>();

    public static void Main(string[] args)
    {
        // Inicio del programa
        CargarTodosLosDatos();
        gestorDonantes.CargarArchivo();
        gestorEmpleados.CargarArchivo();
        
        bool work = true;
        while (work)
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════════════╗");
            Console.WriteLine("║       MENU PRINCIPAL        ║");
            Console.WriteLine("╠═════════════════════════════╣");
            Console.WriteLine("║    1. Sistema Donadores     ║");
            Console.WriteLine("║    2. Sistema Empleados     ║");
            Console.WriteLine("║    3. Sistema Donaciones    ║");
            Console.WriteLine("║    4. Salir                 ║");
            Console.WriteLine("╚═════════════════════════════╝");
            string a = Console.ReadLine();
            
            switch (a)
            {
                case "1":
                    SistemaDonadores();
                    break;
                case "2":
                    SistemaEmpleados();
                    break;
                case "3":
                    SistemaDonaciones();
                    break;
                case "4":
                    work = false;
                    break;
            }
        }
    }

    public static void SistemaDonaciones()
    {
        bool work = true;
        while (work)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║               MENU Donaciones                 ║");
            Console.WriteLine("╠═══════════════════════════════════════════════╣");
            Console.WriteLine("║    1. Registrar unidad entera de sangre       ║");
            Console.WriteLine("║    2. Registrar unidad de plasma              ║");
            Console.WriteLine("║    3. Registrar unidad de plaquetas           ║");
            Console.WriteLine("║    4. Registrar unidad de globulos rojos      ║");
            Console.WriteLine("║    5. Mostrar inventario de Sangre Entera     ║");
            Console.WriteLine("║    6. Mostrar inventario de Plasma            ║");
            Console.WriteLine("║    7. Mostrar inventario de Plaquetas         ║");
            Console.WriteLine("║    8. Mostrar inventario de Globulos rojos    ║");
            Console.WriteLine("║    9. Mostrar el inventario completo          ║");
            Console.WriteLine("║    10. Volver al menú principal               ║");
            Console.WriteLine("║    11. Guardar todos los datos                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            string a = Console.ReadLine();
            
            switch (a)
            {
                case "1":
                {
                    Console.Clear();
                    Console.WriteLine("\n--- EXTRACCIÓN DE SANGRE ENTERA ---");
                    Console.Write("Ingrese el C.I. del donante: ");
                    string ciDonante = Console.ReadLine();
                    int indice = gestorDonantes.BuscarIndice(ciDonante);

                    if (indice == -1)
                    {
                        Console.WriteLine("Donante no encontrado. Regístrelo primero.");
                    }
                    else
                    {
                        Donante donanteReal = GestionDonante.Lista[indice];
                        Console.Write("Ingrese el volumen extraído (ml): ");
                        decimal volumen = ILeerYValidar.DecimaaalVolumenExtraiEntera();
                        Console.Write("Ingrese el lugar de extracción: ");
                        string lugar = Console.ReadLine();
                        DateTime fechaActual = DateTime.Now;
                        
                        listaSangreEntera.Add(new SangreEntera(donanteReal.IdDonante, donanteReal.TipoSangre, donanteReal.RH, fechaActual, lugar, volumen));

                        Console.WriteLine("\n ¡Bolsa de Sangre Entera instanciada y guardada en la lista!");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                break;

                case "2":
                {
                    Console.Clear();
                    Console.WriteLine("\n--- EXTRACCIÓN DE PLASMA ---");
                    Console.Write("Ingrese el C.I. del donante: ");
                    string ciDonante = Console.ReadLine();
                    int indice = gestorDonantes.BuscarIndice(ciDonante);

                    if (indice == -1)
                    {
                        Console.WriteLine("Donante no encontrado. Regístrelo primero.");
                    }
                    else
                    {
                        Donante donanteReal = GestionDonante.Lista[indice];
                        Console.Write("Ingrese el volumen extraído (ml): ");
                        decimal volumen = ILeerYValidar.DecimaaalVolumenExtraiPlasma();
                        Console.Write("Ingrese el lugar de extracción: ");
                        string lugar = Console.ReadLine();
                        DateTime fechaActual = DateTime.Now;
                        
                        listaplasma.Add(new Plasma(donanteReal.IdDonante, donanteReal.TipoSangre, donanteReal.RH, fechaActual, lugar, volumen));

                        Console.WriteLine("\n¡Bolsa de Plasma instanciada y guardada en la lista!");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                break;

                case "3":
                {
                    Console.Clear();
                    Console.WriteLine("\n--- EXTRACCIÓN DE PLAQUETAS ---");
                    Console.Write("Ingrese el C.I. del donante: ");
                    string ciDonante = Console.ReadLine();
                    int indice = gestorDonantes.BuscarIndice(ciDonante);

                    if (indice == -1)
                    {
                        Console.WriteLine("Donante no encontrado. Regístrelo primero.");
                    }
                    else
                    {
                        Donante donanteReal = GestionDonante.Lista[indice];
                        Console.Write("Ingrese el volumen extraído (ml): ");
                        decimal volumen = ILeerYValidar.DecimaaalVolumenExtraiPlaquetas();
                        Console.Write("Ingrese el lugar de extracción: ");
                        string lugar = Console.ReadLine();
                        DateTime fechaActual = DateTime.Now;
                        
                        listaplaquetas.Add(new Plaquetas(donanteReal.IdDonante, donanteReal.TipoSangre, donanteReal.RH, fechaActual, lugar, volumen));

                        Console.WriteLine("\n¡Bolsa de Plaquetas instanciada y guardada en la lista!");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                break;

                case "4":
                {
                    Console.Clear();
                    Console.WriteLine("\n--- EXTRACCIÓN DE GLÓBULOS ROJOS ---");
                    Console.Write("Ingrese el C.I. del donante: ");
                    string ciDonante = Console.ReadLine();
                    int indice = gestorDonantes.BuscarIndice(ciDonante);

                    if (indice == -1)
                    {
                        Console.WriteLine("Donante no encontrado. Regístrelo primero.");
                    }
                    else
                    {
                        Donante donanteReal = GestionDonante.Lista[indice];
                        Console.Write("Ingrese el volumen extraído (ml): ");
                        decimal volumen = ILeerYValidar.DecimaaalVolumenExtraiGlobuRjos();
                        Console.Write("Ingrese el lugar de extracción: ");
                        string lugar = Console.ReadLine();
                        DateTime fechaActual = DateTime.Now;
                        
                        listaGlobulosRojos.Add(new GlobulosRojos(donanteReal.IdDonante, donanteReal.TipoSangre, donanteReal.RH, fechaActual, lugar, volumen));

                        Console.WriteLine("\n¡Bolsa de Glóbulos Rojos instanciada y guardada en la lista!");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("--- INVENTARIO: SANGRE ENTERA ---");
                    if (listaSangreEntera.Count == 0) Console.WriteLine("No hay bolsas registradas.");
                    foreach (SangreEntera u in listaSangreEntera)
                    {
                        Console.WriteLine(u.GenerarEtiqueta());
                        Console.WriteLine("--------------------------------------------------");
                    }
                    
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("--- INVENTARIO: PLASMA ---");
                    if (listaplasma.Count == 0) Console.WriteLine("No hay bolsas registradas.");
                    foreach(Plasma p in listaplasma)
                    {
                        Console.WriteLine(p.GenerarEtiqueta());
                        Console.WriteLine("--------------------------------------------------");
                    }
                    
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("--- INVENTARIO: PLAQUETAS ---");
                    if (listaplaquetas.Count == 0) Console.WriteLine("No hay bolsas registradas.");
                    foreach(Plaquetas pl in listaplaquetas)
                    {
                        Console.WriteLine(pl.GenerarEtiqueta());
                        Console.WriteLine("--------------------------------------------------");
                    }
                    
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "8":
                    Console.Clear();
                    Console.WriteLine("--- INVENTARIO: GLÓBULOS ROJOS ---");
                    if (listaGlobulosRojos.Count == 0) Console.WriteLine("No hay bolsas registradas.");
                    foreach (GlobulosRojos gr in listaGlobulosRojos)
                    {
                        Console.WriteLine(gr.GenerarEtiqueta());
                        Console.WriteLine("--------------------------------------------------");
                    }
                    
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                // ==========================================
                // INVENTARIO COMPLETO (Opción 9)
                // ==========================================
                case "9":
                    Console.Clear();
                    Console.WriteLine("--- INVENTARIO COMPLETO DEL BANCO DE SANGRE ---");
                    
                    int totalBolsas = listaSangreEntera.Count + listaplasma.Count + listaplaquetas.Count + listaGlobulosRojos.Count;
                    
                    Console.WriteLine($"Total de unidades almacenadas: {totalBolsas}\n");
                    
                    Console.WriteLine($"[1] Sangre Entera  : {listaSangreEntera.Count} bolsas");
                    Console.WriteLine($"[2] Plasma         : {listaplasma.Count} bolsas");
                    Console.WriteLine($"[3] Plaquetas      : {listaplaquetas.Count} bolsas");
                    Console.WriteLine($"[4] Glóbulos Rojos : {listaGlobulosRojos.Count} bolsas");

                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                // ==========================================
                // SALIR (Opción 10)
                // ==========================================
                case "10":
                    work = false; 
                    break;
                    
                default:
                    Console.Clear();
                    Console.WriteLine("\nOpción no válida.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.Clear();
                    Console.ReadKey();
                    break;
                case "11":
                    GuardarTodosLosDatos();
                    break;
            }
        }
    }
    public static void SistemaDonadores()
    {
        bool work = true;
        while (work)
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║            MENU DONADORES               ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.WriteLine("║    1. Registrar nuevo donante           ║");
            Console.WriteLine("║    2. Listar todos los donantes         ║");
            Console.WriteLine("║    3. Buscar donante                    ║");
            Console.WriteLine("║    4. Actualizar datos de un donante    ║");
            Console.WriteLine("║    5. Eliminar donante                  ║");
            Console.WriteLine("║    6. Guardar datos de los donantes     ║");
            Console.WriteLine("║    7. Volver al menú principal          ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");
            
            Console.Write("Seleccione una opción: ");
            string a = Console.ReadLine();
            
            switch (a)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--- REGISTRO DE DONANTE ---");
                    gestorDonantes.Registrar(); 
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE DONANTES ---");
                    gestorDonantes.Listar();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("--- BÚSQUEDA DE DONANTE ---");
                    gestorDonantes.Buscar();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("--- ACTUALIZAR DONANTE ---");
                    gestorDonantes.Actualizar();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("--- ELIMINAR DONANTE ---");
                    gestorDonantes.Eliminar();
                    break;

                case "6":
                    gestorDonantes.GuardarArchivo();
                    break;
                
                case "7":
                    work = false; // Pa romper el ciclo y volver al Menú Principal
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\n Opción no válida.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.Clear();
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    public static void SistemaEmpleados()
    {
        bool work = true;
        while (work)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           MENU EMPLEADOS                 ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║    1. Registrar nuevo empleado           ║");
            Console.WriteLine("║    2. Listar todos los empleados         ║");
            Console.WriteLine("║    3. Buscar empleado                    ║");
            Console.WriteLine("║    4. Actualizar datos de un empleado    ║");
            Console.WriteLine("║    5. Eliminar empleado                  ║");
            Console.WriteLine("║    6. Guardar datos de los empleados     ║");
            Console.WriteLine("║    7. Volver al menú principal           ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            
            Console.Write("Seleccione una opción: ");
            string a = Console.ReadLine();
            
            switch (a)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--- REGISTRO DE EMPLEADO ---");
                    gestorEmpleados.Registrar(); 
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE EMPLEADOS ---");
                    gestorEmpleados.Listar();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("--- BÚSQUEDA DE EMPLEADO ---");
                    gestorEmpleados.Buscar();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("--- ACTUALIZAR EMPLEADO ---");
                    gestorEmpleados.Actualizar();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("--- ELIMINAR EMPLEADO ---");
                    gestorEmpleados.Eliminar();
                    break;

                case "6":
                    gestorEmpleados.GuardarArchivo();
                    break;
                
                case "7":
                    work = false; // Pa romper el ciclo y volver al Menú Principal
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\n Opción no válida.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.Clear();
                    Console.ReadKey();
                    break;
            }
        }
    }
    public static void GuardarTodosLosDatos()
    {
        try
        {
            // 1. Guardar Sangre Entera
            using (StreamWriter escritor = new StreamWriter("GuardarSangreEntera.txt"))
            {
                foreach (SangreEntera se in listaSangreEntera)
                    escritor.WriteLine(se.GenerarGuardado());
            }

            // 2. Guardar Plasma
            using (StreamWriter escritor = new StreamWriter("GuardarPlasma.txt"))
            {
                foreach (Plasma p in listaplasma)
                    escritor.WriteLine(p.GenerarGuardado());
            }

            // 3. Guardar Plaquetas
            using (StreamWriter escritor = new StreamWriter("GuardarPlaquetas.txt"))
            {
                foreach (Plaquetas pl in listaplaquetas)
                    escritor.WriteLine(pl.GenerarGuardado());
            }

            // 4. Guardar Glóbulos Rojos
            using (StreamWriter escritor = new StreamWriter("GuardarGlobulosRojos.txt"))
            {
                foreach (GlobulosRojos gr in listaGlobulosRojos)
                    escritor.WriteLine(gr.GenerarGuardado());
            }

            Console.WriteLine("\n¡Todos los inventarios se guardaron correctamente en el disco!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al guardar en disco: {ex.Message}");
        }
    }
    public static void CargarTodosLosDatos()
    {
        // --- 1. CARGAR SANGRE ENTERA ---
        if (File.Exists("GuardarSangreEntera.txt"))
        {
            listaSangreEntera.Clear();
            using (StreamReader lector = new StreamReader("GuardarSangreEntera.txt"))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    // SEGURO 1: Si la línea está vacía (salto de línea al final del txt), la saltamos
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] partes = linea.Split('|');
                    
                    // SEGURO 2: Verificamos que tenga al menos las 9 partes antes de leer
                    if (partes.Length < 9) continue; 
                    
                    listaSangreEntera.Add(new SangreEntera(
                        idUnidad: Guid.Parse(partes[0]),
                        idDonante: Guid.Parse(partes[1]),
                        lugarExtraccion: partes[2],
                        grupo: Enum.Parse<TipoSangre>(partes[3]),
                        rh: Enum.Parse<TipoRH>(partes[4]),         
                        volumen: decimal.Parse(partes[5]),
                        estadounidad: Enum.Parse<EstadoUnidad>(partes[6]),
                        fechaExtraccion: DateTime.ParseExact(partes[7], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        fechacaduc: DateTime.ParseExact(partes[8], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                    ));
                }
            }
        }

        // --- 2. CARGAR PLASMA ---
        if (File.Exists("GuardarPlasma.txt"))
        {
            listaplasma.Clear();
            using (StreamReader lector = new StreamReader("GuardarPlasma.txt"))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] partes = linea.Split('|');

                    // Plasma necesita 10 datos (el índice 9 es el EstadoTermico)
                    if (partes.Length < 10) continue;

                    listaplasma.Add(new Plasma(
                        idUnidad: Guid.Parse(partes[0]),
                        idDonante: Guid.Parse(partes[1]),
                        lugarExtraccion: partes[2],
                        grupo: Enum.Parse<TipoSangre>(partes[3]),
                        rh: Enum.Parse<TipoRH>(partes[4]),         
                        volumen: decimal.Parse(partes[5]),
                        estadounidad: Enum.Parse<EstadoUnidad>(partes[6]),
                        fechaExtraccion: DateTime.ParseExact(partes[7], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        fechacaduc: DateTime.ParseExact(partes[8], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture),
                        estadoFisicoGuardado: Enum.Parse<Plasma.EstadoTermico>(partes[9])
                    ));
                }
            }
        }

        // --- 3. CARGAR PLAQUETAS ---
        if (File.Exists("GuardarPlaquetas.txt"))
        {
            listaplaquetas.Clear();
            using (StreamReader lector = new StreamReader("GuardarPlaquetas.txt"))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] partes = linea.Split('|');
                    if (partes.Length < 9) continue;

                    listaplaquetas.Add(new Plaquetas(
                        idUnidad: Guid.Parse(partes[0]),
                        idDonante: Guid.Parse(partes[1]),
                        lugarExtraccion: partes[2],
                        grupo: Enum.Parse<TipoSangre>(partes[3]),
                        rh: Enum.Parse<TipoRH>(partes[4]),         
                        volumen: decimal.Parse(partes[5]),
                        estadounidad: Enum.Parse<EstadoUnidad>(partes[6]),
                        fechaExtraccion: DateTime.ParseExact(partes[7], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        fechacaduc: DateTime.ParseExact(partes[8], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                    ));
                }
            }
        }

        // --- 4. CARGAR GLÓBULOS ROJOS ---
        if (File.Exists("GuardarGlobulosRojos.txt"))
        {
            listaGlobulosRojos.Clear();
            using (StreamReader lector = new StreamReader("GuardarGlobulosRojos.txt"))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] partes = linea.Split('|');
                    if (partes.Length < 9) continue;

                    listaGlobulosRojos.Add(new GlobulosRojos(
                        idUnidad: Guid.Parse(partes[0]),
                        idDonante: Guid.Parse(partes[1]),
                        lugarExtraccion: partes[2],
                        grupo: Enum.Parse<TipoSangre>(partes[3]),
                        rh: Enum.Parse<TipoRH>(partes[4]),         
                        volumen: decimal.Parse(partes[5]),
                        estadounidad: Enum.Parse<EstadoUnidad>(partes[6]),
                        fechaExtraccion: DateTime.ParseExact(partes[7], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        fechacaduc: DateTime.ParseExact(partes[8], "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                    ));
                }
            }
        }

        Console.WriteLine("✅ Archivos de inventario cargados desde el disco.");
    }
}