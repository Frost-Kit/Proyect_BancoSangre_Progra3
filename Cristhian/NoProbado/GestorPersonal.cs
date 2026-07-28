// namespace Proyect_BancoSangre_Consola.Cristhian.NoProbado;
//
// public class GestorPersonal : GestorBase<Personal>
// {
//     private string _rutaArchivoPersonal = @"Personal.txt";
//     public GestorPersonal() {}
//
//     public override void CargarDatos()
//     {
//         if ( !File.Exists(_rutaArchivoPersonal) ) return;
//
//         Lista = new List<Personal>();
//
//         using (StreamReader archivoPersonal = new StreamReader(_rutaArchivoPersonal))
//         {
//             string linea;
//
//             while ((linea = archivoPersonal.ReadLine()) != null)
//             {
//                 string[] datosPersonal = linea.Split('░');
//                 
//                 Lista.Add( new Personal(
//                     Guid.Parse(datosPersonal[0]),
//                     datosPersonal[1],
//                     datosPersonal[2],
//                     datosPersonal[3],
//                     datosPersonal[4],
//                     Convert.ToByte(datosPersonal[5]),
//                     datosPersonal[6])
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
//         using (StreamWriter archivoPersonal = new StreamWriter(_rutaArchivoPersonal))
//         {
//             foreach (var personal in Lista)
//             {
//                 archivoPersonal.WriteLine($"{personal.IdPersonal}░" +
//                                           $"{personal.Nombre}░" +
//                                           $"{personal.CI}░" +
//                                           $"{personal.Telefono}░" +
//                                           $"{personal.CorreoElectronico}░" +
//                                           $"{personal.Edad}░" +
//                                           $"{personal.Cargo}");
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
//             Console.Write(" * REGISTRO DE PERSONAL *\n" +
//                           "Ingrese:\n" +
//                           " Nombre -> ");
//             string nom = Console.ReadLine().Trim();
//             Console.Write(" C.I. -> ");
//             string ci = Console.ReadLine().Trim();
//             Console.Write(" Telefono -> ");
//             string telefono = Console.ReadLine().Trim();
//             Console.Write(" Correo Electronico -> ");
//             string email = Console.ReadLine().Trim();
//             Console.Write(" Edad");
//             byte edad = ILeerYValidar.Byteee();
//             Console.Write(" Cargo -> ");
//             string cargo = Console.ReadLine().Trim();
//             
//             Lista.Add( new Personal( Guid.CreateVersion7() ,nom, ci, telefono, email, edad, cargo) );
//             
//             Console.Write("Personal Registrado!!!\n" +
//                           "Pulse:\n" +
//                           " Espacio (o cualquier tecla) para continuar con el registro.\n" +
//                           " ENTER para terminar el registro.");
//             opcionContinuarRegistro = Console.ReadKey().Key;
//             Console.WriteLine("\n");
//             
//         } while (opcionContinuarRegistro != ConsoleKey.Enter);
//     }
//
//     public override void Listar()
//     {
//         Console.WriteLine($"\tLISTA del PERSONAL\n" +
//                           $"┌{new string('─',32)}┬{new string('─',10)}┬{new string('─',10)}┬{new string('─',27)}┬{new string('─',9)}┬{new string('─',22)}┬{new string('─',38)}┐\n" +
//                           $"│ {"NOMBRE COMPLETO",-30} │ {"C.I.",-8} | TELEFONO | {"CORREO ELECTRONICO",-25} | {"EDAD",-7} | {"CARGO",-20} | {"ID PERSONAL", -36} |\n" +
//                           $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',22)}┼{new string('─',38)}┤");
//
//         foreach (var chambeador in  Lista)
//         {
//             if ( Lista.IndexOf(chambeador) != Lista.Count - 1 )
//             {
//                 Console.WriteLine($"│ {chambeador.Nombre,-30} │ {chambeador.CI,-8} | {chambeador.Telefono} | {chambeador.CorreoElectronico,-25} | {chambeador.Edad,-7} | {chambeador.Cargo,-20} | {chambeador.IdPersonal} |\n" +
//                                   $"├{new string('─',32)}┼{new string('─',10)}┼{new string('─',10)}┼{new string('─',27)}┼{new string('─',9)}┼{new string('─',22)}┼{new string('─',38)}┤");
//             }
//             else
//             {
//                 Console.WriteLine($"│ {chambeador.Nombre,-30} │ {chambeador.CI,-8} | {chambeador.Telefono} | {chambeador.CorreoElectronico,-25} | {chambeador.Edad,-7} | {chambeador.Cargo,-20} | {chambeador.IdPersonal} |\n" +
//                                   $"└{new string('─',32)}┴{new string('─',10)}┴{new string('─',10)}┴{new string('─',27)}┴{new string('─',9)}┴{new string('─',22)}┴{new string('─',38)}┘");
//             }
//         }
//         Console.Write("Pulse cualquier tecla para continuar...");
//         Console.ReadKey();
//     }
//
//     public override int BuscarIndice(Guid idBuscado)
//     {
//         foreach (var personal in Lista)
//         {
//             if (personal.IdPersonal == idBuscado) return Lista.IndexOf(personal);
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
//     
//     // Ya los metodos Buscar, Actualizar , Eliminar.
//     // Estan aqui por la herencia
// }