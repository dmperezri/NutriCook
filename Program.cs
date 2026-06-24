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


public struct Receta
{
    public string nombre;
    public string ingredientes;
    public string pasos;
    public int tiempoPreparacion;
    public string categoria;
}