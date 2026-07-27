// namespace Proyect_BancoSangre_Consola.Cristhian.IntentosRiesgosos;
//
// public class GestorDonante : GestorBase<Donante>
// {
//     private string _rutaArchivoDonante = @"Donante.txt";
//     
//     public GestorDonante() {}
//
//     public override void CargarDatos()
//     {
//         if (!File.Exists(_rutaArchivoDonante)) return;
//
//         using (StreamReader archivoDonante = new StreamReader(_rutaArchivoDonante))
//         {
//             string linea;
//
//             while ((linea = archivoDonante.ReadLine()) != null)
//             {
//                 var datosDonante = linea.Split('░');
//
//                 List<DateTimeOffset> histoTemp = [];
//                 
//                 foreach (var fechaaaa in datosDonante[9].Split('▒'))
//                 {
//                     histoTemp.Add(DateTimeOffset.Parse(fechaaaa));
//                 }
//                 //histoTemp.AddRange(datosDonante[9].Split('▒').Select(fechaaaa => DateTimeOffset.Parse(fechaaaa)));
//
//                 Lista.Add( new Donante(
//                     Guid.Parse(datosDonante[0]),
//                     datosDonante[1],
//                     datosDonante[2],
//                     datosDonante[3],
//                     datosDonante[4],
//                     Convert.ToByte(datosDonante[5]),
//                     Enum.Parse<TipoSangre>(datosDonante[6]),
//                     Convert.ToDouble(datosDonante[7]),
//                     Convert.ToDouble(datosDonante[8]),
//                     histoTemp
//                     )
//                 );
//             }
//         }
//         Console.WriteLine("*** Cargado de datos exitoso!!! ***");
//     }
//
//     public override void GuardarDatos()
//     {
//         if (Lista == null) return;
//
//         using (StreamWriter archivoDonante = new StreamWriter(_rutaArchivoDonante))
//         {
//             foreach (var personal in Lista)
//             {
//                 archivoDonante.WriteLine($"{personal.IdDonante}░" +
//                                           $"{personal.Nombre}░" +
//                                           $"{personal.CI}░" +
//                                           $"{personal.Telefono}░" +
//                                           $"{personal.CorreoElectronico}░" +
//                                           $"{personal.Edad}░" +
//                                           $"{personal.TipoSangre}░" +
//                                           $"{personal.Peso}░" +
//                                           $"{personal.Altura}░" +
//                                           $"{string.Join('▒',personal.HistorialDonaciones)}");
//             }
//         }
//         Console.WriteLine("*** Guardado de datos exitoso!!! ***"); 
//     }
//
//     public override void Registrar()
//     {
//         ConsoleKey opcionContinuarRegistro = ConsoleKey.None;
//
//         do
//         {
//             Console.Write(" * REGISTRO DE DONANTE *\n" +
//                           "Ingrese:\n" +
//                           " Nombre -> ");
//             string nombre = Console.ReadLine();
//             Console.Write(" C.I. -> ");
//             string ci = Console.ReadLine();
//             Console.Write(" Telefono -> ");
//             string telefono = Console.ReadLine();
//             Console.Write(" Correo Electronico -> ");
//             string email = Console.ReadLine();
//             Console.Write(" Edad");
//             byte edad = ILeerYValidar.Byteee();
//             Console.Write(" Tipo de sangre -> ");
//             TipoSangre tipSangre = Enum.TryParse(Console.ReadLine().Trim(),true, out TipoSangre tipoSangreValidada) ? 
//                 tipoSangreValidada : TipoSangre.O;
//             Console.Write(" Peso");
//             double peso = ILeerYValidar.Doubleee();
//             Console.Write(" Altura");
//             double altura = ILeerYValidar.Doubleee();
//             
//             Lista.Add( new Donante( Guid.CreateVersion7(), nombre, ci, telefono, email, edad, tipSangre, peso, altura) );
//             
//             Console.Write("Donante Registrado!!!\n" +
//                           "Pulse:\n" +
//                           " Espacio (o cualquier tecla) para continuar con el registro.\n" +
//                           " ENTER para terminar el registro.");
//             opcionContinuarRegistro = Console.ReadKey().Key;
//             Console.WriteLine("\n");
//             
//         } while (opcionContinuarRegistro != ConsoleKey.Enter);
//         
//         Console.WriteLine("Volviendo al menu anterior...");
//     }
//
//     public override void Listar()
//     {
//         Console.WriteLine($"\tLISTA de DONANTES\n" +
//                           $"┌{new string('─',32)}┬{new string('─',10)}┬{new string('─',10)}┬{new string('─',27)}┬{new string('─',9)}┬{new string('─',16)}┬{new string('─',9)}┬{new string('─',9)}┬{new string('─',38)}┐\n" +
//                           $"│ {"NOMBRE COMPLETO",-30} │ {"C.I.",-8} | TELEFONO | {"CORREO ELECTRONICO",-25} | {"EDAD",-7} | TIPO DE SANGRE | {"PESO",-7} | {"ALTURA",-7} | {"ID DONANTE", -36} |\n" +
//                           $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',16)}┼{new string('─',9)}┼{new string('─',9)}┼{new string('─',38)}┤");
//
//         foreach (var sujetPrueba in  Lista)
//         {
//             if ( Lista.IndexOf(sujetPrueba) != Lista.Count - 1 )
//             {
//                 Console.WriteLine($"│ {sujetPrueba.Nombre,-30} │ {sujetPrueba.CI,-8} | {sujetPrueba.Telefono, -8} | {sujetPrueba.CorreoElectronico,-25} | {sujetPrueba.Edad,-7} | {sujetPrueba.TipoSangre, -14} | {sujetPrueba.Peso, -7} | {sujetPrueba.Altura, -7} | {sujetPrueba.IdDonante} |\n" +
//                                   $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',16)}┼{new string('─',9)}┼{new string('─',9)}┼{new string('─',38)}┤");
//             }
//             else
//             {
//                 Console.WriteLine($"│ {sujetPrueba.Nombre,-30} │ {sujetPrueba.CI,-8} | {sujetPrueba.Telefono, -8} | {sujetPrueba.CorreoElectronico,-25} | {sujetPrueba.Edad,-7} | {sujetPrueba.TipoSangre, -14} | {sujetPrueba.Peso, -7} | {sujetPrueba.Altura, -7} | {sujetPrueba.IdDonante} |\n" +
//                                   $"└{new string('─',32)}┴{new string('─',10)}┴{new string('─',10)}┴{new string('─',27)}┴{new string('─',9)}┴{new string('─',16)}┴{new string('─',9)}┴{new string('─',9)}┴{new string('─',38)}┘");
//             }
//         }
//         Console.Write("Pulse cualquier tecla para continuar...");
//         Console.ReadKey();
//     }
//     
//     // Esto devuelve el indice, asi consultan en la lista con el indice que les de
//     // Ejemplo: GestionPersonal.Lista[indiceObjetivo].MostrarDatos();
//     public override int BuscarIndice(Guid idBuscado)
//     {
//         foreach (var donante in Lista)
//         {
//             if (donante.IdDonante == idBuscado) return Lista.IndexOf(donante);
//         }
//         
//         return -1;
//     }
//
//     public override int BuscarIndice(string ci)
//     {
//         foreach (var personal in Lista)
//         {
//             if (personal.CI == ci) return Lista.IndexOf(personal);
//         }
//         
//         return -1;
//     }
// }asdad