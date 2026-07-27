namespace Proyect_BancoSangre_Consola.Cristhian;

public interface IGestionar
{
    void CargarArchivo();
    void GuardarArchivo();
    
    void Registrar();
    void Listar();
    void Actualizar();
    void Eliminar();
    
    // Metodo sobrecargado para buscar al elemento
    int Buscar(Guid idBuscar);
    int Buscar(string ci); // nose si daria con la unidades de sangre
}