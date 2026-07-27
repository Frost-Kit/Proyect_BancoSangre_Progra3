namespace Proyect_BancoSangre_Consola.Cristhian;

// No se si esto este bien XD
public interface ILeerYValidar
{
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
}
