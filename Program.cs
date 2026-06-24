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
public struct Receta
{
    public string nombre;
    public string ingredientes;
    public string pasos;
    public int tiempoPreparacion;
    public string categoria;
}