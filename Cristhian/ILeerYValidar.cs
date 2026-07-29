namespace Proyect_BancoSangre_Progra3.Cristhian;

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

            if (ciValidado.All(char.IsDigit))
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

            if (telefonoValidado.All(char.IsDigit))
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

            if (!correoValidado.StartsWith('@'))
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
        byte edadValidada;
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if ( !(byte.TryParse(Console.ReadLine(), out edadValidada)) )
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
        byte edadValidada;
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(byte.TryParse(Console.ReadLine(), out edadValidada)))
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

            if (edadValidada > 65)
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
        byte pesoValidado;
        string mensaje = " -> ";
        byte puntosValidos = 0;

        while (true)
        {
            Console.Write(mensaje);
            if (!(byte.TryParse(Console.ReadLine(), out pesoValidado)))
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
