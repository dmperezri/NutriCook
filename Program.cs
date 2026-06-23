void GuardarDatos()
{
    try
    {
        using (StreamWriter swSaludable = new StreamWriter(rutaSaludables, false))
        using (StreamWriter swAprendizaje = new StreamWriter(rutaAprendizaje, false))
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (string.IsNullOrEmpty(recetas[i].nombre)) continue;

                string linea = recetas[i].nombre + ";" + recetas[i].ingredientes + ";" + recetas[i].pasos + ";" + recetas[i].tiempoPreparacion;

                if (recetas[i].categoria == "Saludable")
                    swSaludable.WriteLine(linea);
                else if (recetas[i].categoria == "Aprendizaje")
                    swAprendizaje.WriteLine(linea);
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  ¡Registros guardados satisfactoriamente en archivos .txt!");
        Console.ResetColor();
    }
 