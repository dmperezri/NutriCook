Receta[] recetas = new Receta[50];

int cantidad = 0;
string perfilActual = "";
int platosPreparados = 0;

string rutaSaludables = "recetasSaludables.txt";
string rutaAprendizaje = "recetasAprendizaje.txt";


/* 
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

public struct Receta
{
    public string nombre;
    public string ingredientes;
    public string pasos;
    public int tiempoPreparacion;
    public string categoria;
}