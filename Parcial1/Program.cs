

class Program
{
    static void Main(string[] args)
    {
        // Define los períodos de tiempo
        Periodo[] periodos = {
            new Periodo("C", new DateTime(2024, 5, 1, 10, 0, 0), new DateTime(2024, 5, 1, 14, 0, 0)),// 10:00 - 14:00
            new Periodo("B", new DateTime(2024, 5, 1, 17, 0, 0), new DateTime(2024, 5, 1, 19, 0, 0)),// 17:00 - 19:00
            new Periodo("D", new DateTime(2024, 5, 1, 13, 0, 0), new DateTime(2024, 5, 1, 16, 0, 0)),// 13:00 - 16:00
            new Periodo("A", new DateTime(2024, 5, 1, 8, 0, 0), new DateTime(2024, 5, 1, 12, 0, 0)),// 8:00 - 12:00
        };

        
        foreach (var periodo in periodos)
        {
           
            Console.WriteLine($"[{periodo.Nombre}] Inicio: {periodo.Inicio}, Fin: {periodo.Fin}");
         
        }
        // Realiza la unión de los períodos
        List<Periodo> periodosUnidos = UnionPeriodos(periodos);

        // Muestra los períodos resultantes
        Console.WriteLine("Períodos resultantes:");
        foreach (var periodo in periodosUnidos)
        {
            Console.WriteLine($"[{periodo.Nombre}] Inicio: {periodo.Inicio}, Fin: {periodo.Fin}");
        }

        
    }

    // Método para unir los períodos
    static List<Periodo> UnionPeriodos(Periodo[] periodos)
    {
        // Ordena los períodos por fecha de inicio
        Array.Sort(periodos, (x, y) => x.Inicio.CompareTo(y.Inicio));
        
        foreach (var periodo in periodos)
        {
            periodo.mostrarPeriodo();
        }
      
        List<Periodo> periodosUnidos = new List<Periodo>();
        Periodo periodoActual = null;

        foreach (var periodo in periodos)
        {
            if (periodoActual == null || periodo.Inicio > periodoActual.Fin)
            {
                // Si no hay solapamiento o es el primer periodo, lo añadimos a la lista
                periodosUnidos.Add(periodo);
                periodoActual = periodo;

            }
            else if (periodo.Fin > periodoActual.Fin)
            {
                // Si hay solapamiento, extiendo el periodo actual
                periodoActual.Fin = periodo.Fin;
            }
        }
        //8:00 - 12:00
        //10:00 - 14:00
        //13:00 - 16:00
        //17:00 - 19:00
        return periodosUnidos;
    }
}

// Clase para representar un período de tiempo
class Periodo
{
    
    public string Nombre { get; }
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }

    public Periodo(string nombre, DateTime inicio, DateTime fin)
    {
        Nombre = nombre;
        Inicio = inicio;
        Fin = fin;
    }
    public void mostrarPeriodo()
    {
        Console.WriteLine($"[{Nombre}] Inicio: {Inicio}, Fin: {Fin}");
    }
}
