Receta[] recetas = new Receta[50];

int cantidad = 0;
string perfilActual = "";
int platosPreparados = 0;

string rutaSaludables = "recetasSaludables.txt";
string rutaAprendizaje = "recetasAprendizaje.txt";


/*  *
    DANNIA:                                STEPHANIE
Main()                              BuscarPorIngrediente()
PantallaLogin()                     FiltrarPorTiempo()
MostrarMenuSaludable()
MostrarMenuAprendizaje()                    LUIS
Banner()
MostrarError()                      GuardarDatos()
Pausar()                            CargarDatos()
                                    LeerArchivo()CargarEjemplos()
 PATRICIA                           Cargando()                          
 AgregarReceta()                    ModuloSeguimiento()
                                    MostrarRecetas()*/


void BuscarPorIngrediente()
{
    Banner("BÚSQUEDA POR INGREDIENTES");
    Console.Write("  Ingresa el ingrediente que deseas buscar: ");
    string ing = Console.ReadLine()!.ToLower();

    bool encontrado = false;
    Console.WriteLine("\n  Resultados encontrados:\n");

    for (int i = 0; i < cantidad; i++)
    {
        if (recetas[i].categoria == perfilActual && !string.IsNullOrEmpty(recetas[i].nombre) &&
            recetas[i].ingredientes.ToLower().Contains(ing))
        {
            Console.WriteLine("  - " + recetas[i].nombre + " (" + recetas[i].tiempoPreparacion + " min)");
            Console.WriteLine("    Ingredientes: " + recetas[i].ingredientes + "\n");
            encontrado = true;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("  No se encontraron recetas con ese ingrediente en tu catálogo actual.");
    }
    Pausar();
}

void FiltrarPorTiempo()
{
    Banner("FILTRO DE COCINA RÁPIDA");
    Console.Write("  Ingresa el tiempo máximo del que dispones (minutos): ");

    if (!int.TryParse(Console.ReadLine(), out int maxT) || maxT <= 0)
    {
        MostrarError("Valor no válido.");
        return;
    }

    bool encontrado = false;
    Console.WriteLine($"\n  Platos que puedes preparar en {maxT} minutos o menos:\n");

    for (int i = 0; i < cantidad; i++)
    {
        if (recetas[i].categoria == perfilActual && !string.IsNullOrEmpty(recetas[i].nombre) &&
            recetas[i].tiempoPreparacion <= maxT)
        {
            Console.WriteLine("  - " + recetas[i].nombre + ": " + recetas[i].tiempoPreparacion + " min");
            encontrado = true;
        }
    }

    if (!encontrado)
    {
        Console.WriteLine("  No hay recetas dentro de ese límite de tiempo.");
    }
    Pausar();
}



public struct Receta
{
    public string nombre;
    public string ingredientes;
    public string pasos;
    public int tiempoPreparacion;
    public string categoria;
}