namespace ProyectoBancoSangre.Clases;

public class SangreEntera : UnidadExtraida
{
    public SangreEntera(Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion,
        string lugarExtraccion, decimal volumen)
        : base(idDonante, grupo, rh, fechaExtraccion, lugarExtraccion)
    {
        if (volumen < 400 || volumen > 500)
            throw new ArgumentOutOfRangeException("El volumen de Sangre Entera debe estar entre 400 y 500 ml.");

        Volumen = volumen;
        FechaCaducidad = fechaExtraccion.AddDays(42);
    }
    //NUEVO CONSTRUCTOR
    public SangreEntera(Guid idUnidad, Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, DateTime fechacaduc, string lugarExtraccion, EstadoUnidad estadounidad, decimal volumen) 
        : base(idUnidad, idDonante, grupo, rh, fechaExtraccion, lugarExtraccion, estadounidad, volumen, fechacaduc)
    {
    }
    

}

public class GlobulosRojos : UnidadExtraida
{
    public GlobulosRojos(Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion,
        string lugarExtraccion, decimal volumen)
        : base(idDonante, grupo, rh, fechaExtraccion, lugarExtraccion)
    {
        if (volumen < 200 || volumen > 350)
            throw new ArgumentOutOfRangeException("El volumen de Glóbulos Rojos debe estar entre 200 y 350 ml.");

        Volumen = volumen;
        FechaCaducidad = fechaExtraccion.AddDays(42);
    }
    //NUEVO CONSTRUCTOR
    public GlobulosRojos(Guid idUnidad, Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, DateTime fechacaduc, string lugarExtraccion, EstadoUnidad estadounidad, decimal volumen) 
        : base(idUnidad, idDonante, grupo, rh, fechaExtraccion, lugarExtraccion, estadounidad, volumen, fechacaduc)
    {
    }
}

public class Plaquetas : UnidadExtraida
{
    public Plaquetas(Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, string lugarExtraccion,
        decimal volumen)
        : base(idDonante, grupo, rh, fechaExtraccion, lugarExtraccion)
    {
        if (volumen < 40 || volumen > 70)
            throw new ArgumentOutOfRangeException("El volumen de Plaquetas debe estar entre 40 y 70 ml.");

        Volumen = volumen;
        FechaCaducidad = fechaExtraccion.AddDays(5);
    }
    //NUEVO CONSTRUCTOR
    public Plaquetas(Guid idUnidad, Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, DateTime fechacaduc, string lugarExtraccion, EstadoUnidad estadounidad, decimal volumen) 
        : base(idUnidad, idDonante, grupo, rh, fechaExtraccion, lugarExtraccion, estadounidad, volumen, fechacaduc)
    {
    }
}

public class Plasma : UnidadExtraida
{
    public enum EstadoTermico
    {
        Congelado,
        Descongelado
    }

    public EstadoTermico EstadoFisico { get; private set; }

    public Plasma(Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, string lugarExtraccion,
        decimal volumen)
        : base(idDonante, grupo, rh, fechaExtraccion, lugarExtraccion)
    {
        if (volumen < 200 || volumen > 300)
            throw new ArgumentOutOfRangeException("El volumen de Plasma debe estar entre 200 y 300 ml.");

        Volumen = volumen;
        FechaCaducidad = fechaExtraccion.AddDays(365);
        EstadoFisico = EstadoTermico.Congelado;
    }
    //NUEVO CONSTRUCTOR
    public Plasma(Guid idUnidad, Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, DateTime fechacaduc, string lugarExtraccion, EstadoUnidad estadounidad, decimal volumen, EstadoTermico estadoFisicoGuardado) 
        : base(idUnidad, idDonante, grupo, rh, fechaExtraccion, lugarExtraccion, estadounidad, volumen, fechacaduc)
    {
        EstadoFisico = estadoFisicoGuardado;
    }
    public void RestaurarFisicoDesdeArchivo(EstadoTermico estadoGuardado)
    {
        EstadoFisico = estadoGuardado;
    }

    public void Descongelar()
    {
        if (Estado == EstadoUnidad.Descartada)
            throw new InvalidOperationException("Peligro: No se puede descongelar una unidad descartada.");
        if (EstadoFisico == EstadoTermico.Descongelado)
            throw new InvalidOperationException("El plasma ya se encuentra descongelado.");

        EstadoFisico = EstadoTermico.Descongelado;
        FechaCaducidad = DateTime.Now.AddHours(24);
    }

    public void Congelar()
    {
        if (EstadoFisico == EstadoTermico.Descongelado)
            throw new InvalidOperationException(
                "VIOLACIÓN DE BIOSEGURIDAD: Médicamente prohibido recongelar plasma.");

        throw new InvalidOperationException("El plasma ya se encuentra congelado.");
    }

    public override string GenerarEtiqueta()
    {
        return base.GenerarEtiqueta() +
               $"\n Temp.    : {EstadoFisico.ToString().ToUpper()}\n========================================";
    }
    //Override de generar guardado para añadir el estado fisico
    public override string GenerarGuardado()
    {
        return base.GenerarGuardado() + $"|{EstadoFisico}";
    }
}