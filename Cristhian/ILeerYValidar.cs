namespace Proyect_BancoSangre_Consola.Cristhian;

// No se si esto este bien XD
public interface ILeerYValidar
{
    static string Correo()
    {
        string correoValidado;
        string mensaje = " -> ";
        bool esCorrecto = false;
        do
        {
            Console.Write(mensaje);
            correoValidado = Console.ReadLine();

            if (correoValidado.Contains('@') && correoValidado.Length >= 7)
            {
                esCorrecto = true;
                return correoValidado;
            }
            mensaje = "Error: Intente de nuevo -> ";

        } while (!esCorrecto);

        return "Esta MAL";
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
