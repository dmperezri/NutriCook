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


public struct Receta
{
    public string nombre;
    public string ingredientes;
    public string pasos;
    public int tiempoPreparacion;
    public string categoria;
}