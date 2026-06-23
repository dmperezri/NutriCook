void Banner(string titulo)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('=', titulo.Length + 4));
    Console.WriteLine($"  {titulo}");
    Console.WriteLine(new string('=', titulo.Length + 4) + "\n");
    Console.ResetColor();
}

void MostrarError(string msj)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n  [ERROR]: {msj}");
    Console.ResetColor();
    Pausar();
}

void Pausar()
{
    Console.WriteLine("\n  Presiona una tecla para continuar...");
    Console.ReadKey();
}