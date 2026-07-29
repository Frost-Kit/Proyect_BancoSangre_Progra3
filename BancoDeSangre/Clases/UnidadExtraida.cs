namespace ProyectoBancoSangre.Clases;

public abstract class UnidadExtraida
{
    private string _lugarExtraccion;
    private DateTime _fechaExtraccion;

    public Guid IdUnidad { get; private set; }
    public Guid IdDonante { get; private set; }
    public TipoSangre GrupoSanguineo { get; private set; }
    public TipoRH FactorRh { get; private set; }
    public decimal Volumen { get; protected set; }
    public DateTime FechaCaducidad { get; protected set; }
    public EstadoUnidad Estado { get; protected set; }

    public DateTime FechaExtraccion
    {
        get { return _fechaExtraccion; }
        private set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("La fecha de extracción no puede ser del futuro.");
            _fechaExtraccion = value;
        }
    }

    public string LugarExtraccion
    {
        get { return _lugarExtraccion; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El lugar de extracción no puede estar vacío.");
            _lugarExtraccion = value.Trim();
        }
    }

    public string SignoRh
    {
        get
        {
            if (FactorRh == TipoRH.Positivo) return "+";
            if (FactorRh == TipoRH.Negativo) return "-";
            throw new ArgumentOutOfRangeException("El tipo RH no es válido.");
        }
    }

    protected UnidadExtraida(Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, string lugarExtraccion)
    {
        if (idDonante == Guid.Empty) throw new ArgumentException("El ID del donante no puede estar vacío.");

        IdUnidad = Guid.NewGuid();
        IdDonante = idDonante;
        GrupoSanguineo = grupo;
        FactorRh = rh;
        FechaExtraccion = fechaExtraccion;
        LugarExtraccion = lugarExtraccion;
        Estado = EstadoUnidad.Cuarentena;
    }
    //NUEVO CONSTRUCTOR PARA TRABAJAR
    protected UnidadExtraida(Guid idUnidad,Guid idDonante, TipoSangre grupo, TipoRH rh, DateTime fechaExtraccion, string lugarExtraccion, EstadoUnidad estadounidad, decimal volumen,DateTime fechacaduc)
    {
        
        IdUnidad = idUnidad;
        IdDonante = idDonante;
        GrupoSanguineo = grupo;
        FactorRh = rh;
        FechaExtraccion = fechaExtraccion;
        LugarExtraccion = lugarExtraccion;
        Estado = estadounidad;
        Volumen = volumen;
        FechaCaducidad = fechacaduc;
    }
    //#######################################################
    public virtual void CambiarEstado(EstadoUnidad nuevoEstado)
    {
        if (Estado == EstadoUnidad.Descartada)
            throw new InvalidOperationException("Peligro de bioseguridad: No se puede revivir una unidad descartada.");
        if (Estado == nuevoEstado)
            throw new InvalidOperationException($"La unidad ya se encuentra en estado {nuevoEstado}.");

        Estado = nuevoEstado;
    }

    public void RegistrarResultadoTamizaje(bool reactivoInfeccion)
    {
        if (Estado != EstadoUnidad.Cuarentena)
            throw new InvalidOperationException("Solo es posible registrar tamizaje de una unidad en Cuarentena.");

        if (reactivoInfeccion) CambiarEstado(EstadoUnidad.Descartada);
        else CambiarEstado(EstadoUnidad.Disponible);
    }
    //Persistencia
    public void RestaurarDatosDesdeArchivo(Guid idOriginal, EstadoUnidad estadoGuardado, DateTime caducidadGuardada)
    {
        IdUnidad = idOriginal;
        Estado = estadoGuardado;
        FechaCaducidad = caducidadGuardada;
    }

    public virtual string GenerarEtiqueta()
    {
        return $@"
========================================
 ID Unidad : {IdUnidad}
 ID Donante: {IdDonante}
 Grupo     : {GrupoSanguineo}{SignoRh}
 Volumen   : {Volumen} ml
 Estado    : {Estado.ToString().ToUpper()}
 Extraído  : {FechaExtraccion:yyyy-MM-dd}
 Caducidad : {FechaCaducidad:yyyy-MM-dd HH:mm}";
    }
    //Metodo para guardar
    public virtual string GenerarGuardado()
    {
        return $"{IdUnidad}|{IdDonante}|{LugarExtraccion}|{GrupoSanguineo}|{FactorRh}|{Volumen}|{Estado}|{FechaExtraccion:yyyy-MM-dd}|{FechaCaducidad:yyyy-MM-dd HH:mm}";
    }
}