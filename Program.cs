Receta[] recetas = new Receta[50];

int cantidad = 0;
string perfilActual = "";
int platosPreparados = 0;

string rutaSaludables = "recetasSaludables.txt";
string rutaAprendizaje = "recetasAprendizaje.txt";

void Main()
{
    CargarDatos();
    if (cantidad == 0)
    {
        CargarEjemplos();
    }

    Cargando();
    PantallaLogin();
}

Main();

void PantallaLogin()
{
    bool salirLogin = false;
    while (!salirLogin)
    {
        Console.Clear();
        Banner("BIENVENIDO A NUTRICOOK");
        Console.WriteLine("  1. Perfil Saludable");
        Console.WriteLine("  2. Perfil de Aprendizaje");
        Console.WriteLine("  3. Salir\n");
        Console.Write("  Seleccione su perfil: ");

        string opc = Console.ReadLine()!;
        if (opc == "1")
        {
            perfilActual = "Saludable";
            MostrarMenuSaludable();
        }
        else if (opc == "2")
        {
            perfilActual = "Aprendizaje";
            MostrarMenuAprendizaje();
        }
        else if (opc == "3")
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nSaliendo de NutriCook. ¡Hasta pronto y buen provecho!");
            Console.ResetColor();
            salirLogin = true;
        }
        else
        {
            MostrarError("Opción no válida.");
        }
    }
}

void MostrarMenuSaludable()
{
    int op = 0;
    do
    {
        Console.Clear();
        Banner("PERFIL SALUDABLE");
        Console.WriteLine("  1. Registrar nueva receta fit / saludable");
        Console.WriteLine("  2. Ver recetas saludables disponibles");
        Console.WriteLine("  3. Buscar recetas por ingrediente clave");
        Console.WriteLine("  4. Filtrar por tiempo (Cocina Saludable Rápida)");
        Console.WriteLine("  5. Control y Seguimiento de platos preparados");
        Console.WriteLine("  6. Guardar Cambios");
        Console.WriteLine("  7. Cerrar Sesión\n");
        Console.Write("  Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out op)) op = 0;
        Console.Clear();
        switch (op)
        {
            case 1: AgregarReceta("Saludable"); break;
            case 2: MostrarRecetas(); break;
            case 3: BuscarPorIngrediente(); break;
            case 4: FiltrarPorTiempo(); break;
            case 5: ModuloSeguimiento(); break;
            case 6: GuardarDatos(); break;
            case 7:
                Console.WriteLine("\n  Cerrando sesión del Perfil Saludable...");
                System.Threading.Thread.Sleep(1000);
                break;
            default:
                MostrarError("Opción no válida.");
                break;
        }
    } while (op != 7);
}

void MostrarMenuAprendizaje()
{
    int op = 0;
    do
    {
        Console.Clear();
        Banner("PERFIL DE APRENDIZAJE");
        Console.WriteLine("  1. Registrar receta paso a paso (Didáctica)");
        Console.WriteLine("  2. Mostrar catálogo de recetas para principiantes");
        Console.WriteLine("  3. Buscar recetas por ingredientes disponibles");
        Console.WriteLine("  4. Filtrar platos fáciles por tiempo máximo");
        Console.WriteLine("  5. Consejos útiles y técnicas de cocina básicas");
        Console.WriteLine("  6. Guardar Cambios");
        Console.WriteLine("  7. Cerrar Sesión\n");
        Console.Write("  Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out op)) op = 0;

        Console.Clear();
        switch (op)
        {
            case 1: AgregarReceta("Aprendizaje"); break;
            case 2: MostrarRecetas(); break;
            case 3: BuscarPorIngrediente(); break;
            case 4: FiltrarPorTiempo(); break;
            case 5: ModuloDidactico(); break;
            case 6: GuardarDatos(); break;
            case 7:
                Console.WriteLine("\n  Cerrando sesión del Perfil de Aprendizaje...");
                System.Threading.Thread.Sleep(1000);
                break;
            default: MostrarError("Opción no válida."); break;
        }
    } while (op != 7);
}

void AgregarReceta(string tipoPerfil)
{
    Banner(tipoPerfil == "Saludable" ? "NUEVA RECETA FIT" : "NUEVA RECETA PASO A PASO");

    if (cantidad >= 50)
    {
        MostrarError("Se ha alcanzado el límite máximo de recetas (" + 50 + ").");
        return;
    }

    Console.Write("  Nombre de la receta: ");
    string nombre = Console.ReadLine()!;
    if (string.IsNullOrEmpty(nombre))
    {
        MostrarError("El nombre no puede estar vacío.");
        return;
    }

    Console.Write(tipoPerfil == "Saludable" ? "  Ingredientes (Separados por coma): "
                                            : "  Ingredientes (Qué necesitas comprar, separados por coma): ");
    string ingredientes = Console.ReadLine()!;

    Console.Write(tipoPerfil == "Saludable" ? "  Pasos de preparación (Separados por ';'): "
                                            : "  Pasos MUY DETALLADOS (Separados por ';'): ");
    string pasos = Console.ReadLine()!;

    Console.Write("  Tiempo estimado de preparación (en minutos): ");
    if (!int.TryParse(Console.ReadLine(), out int tiempo) || tiempo <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  Valor inválido detectado. Se asignará 1 minuto por defecto.");
        Console.ResetColor();
        tiempo = 1;
    }

    recetas[cantidad].nombre = nombre;
    recetas[cantidad].ingredientes = ingredientes;
    recetas[cantidad].pasos = pasos;
    recetas[cantidad].tiempoPreparacion = tiempo;
    recetas[cantidad].categoria = tipoPerfil;

    cantidad++;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n  ¡Receta agregada localmente con éxito!");
    Console.ResetColor();
    Pausar();
}

void MostrarRecetas()
{
    Banner("CATÁLOGO: " + perfilActual.ToUpper());

    bool hayRecetas = false;
    int contadorVisual = 1;

    for (int i = 0; i < cantidad; i++)
    {
        if (recetas[i].categoria == perfilActual && !string.IsNullOrEmpty(recetas[i].nombre))
        {
            hayRecetas = true;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  +-- #" + contadorVisual + " " + recetas[i].nombre +
                " [" + recetas[i].categoria + "] - " + recetas[i].tiempoPreparacion + " min");
            Console.ResetColor();
            Console.WriteLine("  |  Ingredientes : " + recetas[i].ingredientes);
            Console.WriteLine("  |  Pasos        :");

            string[] pasosArray = recetas[i].pasos.Split(';');
            for (int j = 0; j < pasosArray.Length; j++)
            {
                if (!string.IsNullOrWhiteSpace(pasosArray[j]))
                    Console.WriteLine("  |    " + (j + 1) + ". " + pasosArray[j].Trim());
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  +-------------------------------------------------\n");
            Console.ResetColor();
            contadorVisual++;
        }
    }

    if (!hayRecetas)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("  Aún no hay recetas registradas en este perfil. ¡Agrega una!");
        Console.ResetColor();
    }
    Pausar();
}

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


public struct Receta
{
    public string nombre;
    public string ingredientes;
    public string pasos;
    public int tiempoPreparacion;
    public string categoria;
}