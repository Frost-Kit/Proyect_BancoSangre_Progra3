namespace Proyect_BancoSangre_Progra3.Cristhian;

public interface IGestionar
{
    void CargarArchivo();
    void GuardarArchivo();
    
    void Registrar();
    void Listar();
    void Buscar();
    void Actualizar();
    void Eliminar();
    
    // Metodo sobrecargado para buscar al elemento
    int BuscarIndice(Guid idBuscar);
    int BuscarIndice(string ci); // nose si daria con la unidades de sangre
}