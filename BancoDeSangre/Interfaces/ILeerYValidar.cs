using ProyectoBancoSangre.Clases;

namespace ProyectoBancoSangre.Interfaces;

// No se si esto este bien XD
public interface ILeerYValidar
{
    static string Nombre()
    {
        string mensaje = " -> ";

        while (true)
        {
            Console.Write(mensaje);
            string nombreValidado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nombreValidado)) return nombreValidado;

            mensaje = "*** Error: el nombre no puede estar vacio ***\n" +
                          " Intente de nuevo -> ";
        }
    }

    static string Ci()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            string ciValidado = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ciValidado)) 
            {
                mensaje = "*** Error: el CI no puede estar vacio ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;

            } else puntosValidos++;

            if (!ciValidado.All(char.IsDigit))
            {
                mensaje = "*** Error: solo numeros en el CI ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;

            } else puntosValidos++;

            if (puntosValidos == 2) return ciValidado;
        }
    }

    static string Telefono()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            string telefonoValidado = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(telefonoValidado))
            {
                mensaje = "*** Error: el Telefono no puede estar vacio ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;

            }
            else puntosValidos++;

            if (!telefonoValidado.All(char.IsDigit))
            {
                mensaje = "*** Error: solo numeros en el telefono ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;

            }
            else puntosValidos++;

            if (telefonoValidado.Length > 8)
            {
                mensaje = "*** Error: solo telefono con 8 digitos ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;

            }
            else puntosValidos++;

            if (puntosValidos == 3) return telefonoValidado;
        }
    }

    static string Correo()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;
        
        while (true)
        {
            Console.Write(mensaje);
            string correoValidado = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(correoValidado))
            {
                mensaje = "*** Error: no contiene @ ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if ( !correoValidado.Contains('@') )
            {
                mensaje = "*** Error: no contiene @ ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (correoValidado.StartsWith('@'))
            {
                mensaje = "*** Error: no puede empezar con @ ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if ( !(correoValidado.Contains(".com") || correoValidado.Contains(".net")) )
            {
                mensaje = "*** Error: no contiene .com ni .net ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if ( !(correoValidado.Length >= 10) )
            {
                mensaje = "*** Error: El correo debe ser de almenos 6 caracteres ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 5) return correoValidado;
            
            puntosValidos = 0;
        }
    }
    
    static byte Byteee()
    {
        byte byteValidado;
        string mensaje = " -> ";
        bool esByte;
        do
        {
            Console.Write(mensaje);
            esByte = byte.TryParse(Console.ReadLine(), out byteValidado);
            mensaje = "Intente de nuevo -> ";
        } while (!esByte);

        return byteValidado;
    }

    static int Enterooo()
    {
        int enteroValidado;
        string mensaje = " -> ";
        bool esEntero;
        do
        {
            Console.Write(mensaje);
            esEntero = int.TryParse(Console.ReadLine(), out enteroValidado);
            mensaje = "Intente de nuevo -> ";
        } while (!esEntero);

        return enteroValidado;
    }

    static byte ByteeeEdadDonante()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if ( !(byte.TryParse(Console.ReadLine(), out byte edadValidada)) )
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (edadValidada < 18)
            {
                mensaje = "*** Error: Debe ser mayor de edad, para donar ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (edadValidada > 60)
            {
                mensaje = "*** Error: Con esa edad ya no puede donar ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 3) return edadValidada;

            puntosValidos = 0;
        }
    }

    static byte ByteeeEdadEmpleado()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(byte.TryParse(Console.ReadLine(), out byte edadValidada)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (edadValidada < 18)
            {
                mensaje = "*** Error: Debe ser mayor de edad ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (edadValidada > 70)
            {
                mensaje = "*** Error: Ya jubilenlo ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 3) return edadValidada;

            puntosValidos = 0;
        }
    }

    static double Doubleee()
    {
        double doubleValidado;
        string mensaje = " -> ";
        bool esDouble;
        do
        {
            Console.Write(mensaje);
            esDouble = double.TryParse(Console.ReadLine(), out doubleValidado);
            mensaje = "Intente de nuevo -> ";
        } while (!esDouble);

        return doubleValidado;
    }

    static double DoubleeePeso()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(double.TryParse(Console.ReadLine(), out double pesoValidado)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (pesoValidado < 30)
            {
                mensaje = "*** Error: No puede donar si tiene bajo peso ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (pesoValidado > 120)
            {
                mensaje = "*** Error: Excedente de peso ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 3) return pesoValidado;

            puntosValidos = 0;
        }
    }
    
    static double DoubleeeAltura()
    {
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(double.TryParse(Console.ReadLine(), out double alturaValidado)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (alturaValidado < 0.6)
            {
                mensaje = "*** Error: Esta enano ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (alturaValidado > 2.8)
            {
                mensaje = "*** Error: Se paso de grande ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 3) return alturaValidado;

            puntosValidos = 0;
        }
    }
    
    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Para la sangre El volumen de Glóbulos Rojos debe estar entre 200 y 350 ml.
    static decimal DecimaaalVolumenExtraiEntera()
    {
        string mensaje = ": ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(decimal.TryParse(Console.ReadLine(), out decimal volumenValidado)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (volumenValidado < 400 || volumenValidado > 500)
            {
                mensaje = "*** Error: El volumen de Sangre Entera debe estar entre 400 y 500 ml. ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 2) return volumenValidado;

            puntosValidos = 0;
        }
    }
    
    static decimal DecimaaalVolumenExtraiGlobuRjos()
    {
        string mensaje = ": ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(decimal.TryParse(Console.ReadLine(), out decimal volumenValidado)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (volumenValidado < 200 || volumenValidado > 350)
            {
                mensaje = "*** Error: El volumen de Glóbulos Rojos debe estar entre 200 y 350 ml. ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 2) return volumenValidado;

            puntosValidos = 0;
        }
    }
    
    static decimal DecimaaalVolumenExtraiPlasma()
    {
        string mensaje = ": ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(decimal.TryParse(Console.ReadLine(), out decimal volumenValidado)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (volumenValidado < 200 || volumenValidado > 300)
            {
                mensaje = "*** Error: El volumen de Plasma debe estar entre 200 y 300 ml. ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 2) return volumenValidado;

            puntosValidos = 0;
        }
    }
    static decimal DecimaaalVolumenExtraiPlaquetas()
    {
        string mensaje = ": ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(decimal.TryParse(Console.ReadLine(), out decimal volumenValidado)))
            {
                mensaje = "*** Error: lo que ingreso no es un numero ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (volumenValidado < 40 || volumenValidado > 70)
            {
                mensaje = "*** Error: El volumen de Plaquetas debe estar entre 40 y 70 ml. ***\n" +
                          " Intente de nuevo -> ";
                puntosValidos = 0;
            }
            else puntosValidos++;

            if (puntosValidos == 2) return volumenValidado;

            puntosValidos = 0;
        }
    }
    
    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Para los enums
    static TipoRH Rhhh()
    {
        TipoRH rhValidado;
        string mensaje = " -> ";
        bool esRHValido;
        do
        {
            Console.Write(mensaje);
            esRHValido = Enum.TryParse<TipoRH>(Console.ReadLine(), true, out rhValidado);
            mensaje = "Intente de nuevo -> ";
        } while (!esRHValido);

        return rhValidado;
    }

    static TipoSangre TipoSangreee()
    {
        TipoSangre tipoSangreValidada;
        string mensaje = " -> ";
        bool esTipoSangreValida;
        do
        {
            Console.Write(mensaje);
            esTipoSangreValida = Enum.TryParse<TipoSangre>(Console.ReadLine(), true, out tipoSangreValidada);
            mensaje = "Intente de nuevo -> ";
        } while (!esTipoSangreValida);

        return tipoSangreValidada;
    }
}
