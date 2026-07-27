namespace Proyect_BancoSangre_Consola.Cristhian;

public abstract class Persona : INotificar
{
    // Atributos privados
    private string _nombre;
    private string _ci;
    private string _telefono;
    private string _correoElectronico;
    private byte _edad;
    public string Nombre
    {
        get { return _nombre; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío.");

            _nombre = value.Trim();
        }
    }

    public string CI
    {
        get { return _ci; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El CI no puede estar vacío.");

            _ci = value.Trim();
        }
    }

    public string Telefono
    {
        get { return _telefono; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El teléfono no puede estar vacío.");

            _telefono = value.Trim();
        }
    }

    public string CorreoElectronico
    {
        get { return _correoElectronico; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El correo electrónico no puede estar vacío.");

            if (!value.Contains("@"))
                throw new ArgumentException("Correo electrónico inválido.");

            _correoElectronico = value.Trim();
        }
    }

    public byte Edad
    {
        get { return _edad; }
        protected set
        {
            if (!byte.TryParse(value.ToString(), out byte numValidado))
            {
                throw new ArgumentException("*** Debe ingresar solo numeros. ***");
            }
            
            if (numValidado < 18)
                throw new ArgumentException("*** La edad debe ser mayor o igual a 18 años. ***");
            
            _edad = numValidado;
        }
    }
    
    // Constructores    
    public Persona()
    {
        Nombre = "";
        CI = "";
        Telefono = "";
        CorreoElectronico = "";
        Edad = 0;
    }
    protected Persona(string nombre,
                       string ci,
                       string telefono,
                       string correoElectronico,
                       byte edad)
    {
        try
        {
            Nombre = nombre;
            CI = ci;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            Edad = edad;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // Metodos Abstractos usados
    public abstract void MostrarDatos();
    
    // Metodo de la interfaz
    public void Notificar(string mensaje, string medio)
    {
        switch (medio)
        {
            case "SMS_WhatsApp":
                Console.WriteLine($"Mensaje: {mensaje} | Enviar por {medio.Substring(0,3)} o {medio.Substring(4)} al numero {Telefono}");
                return;
            
            case "email":
                Console.WriteLine($"Mensaje: {mensaje} | Enviar por {medio} a la direccion {CorreoElectronico}");
                return;
            
            default: Console.WriteLine("*** Error: Medio invalido ***"); return;
        }
    }

    public bool DatosCorrectos()
    {
        if ( !CI.All(char.IsDigit) ) return false;
        
        if (CI.Length != 7 || CI.Length != 8) return false;
        
        if (Telefono.Length != 8) return false;
        
        return true;
    }
}