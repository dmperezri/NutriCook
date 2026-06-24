# NutriCook Digital 

¡Bienvenido a **NutriCook Digital**! Una aplicación interactiva de consola desarrollada en **C#** diseñada para optimizar la organización alimenticia diaria mediante la gestión dinámica de recetas mediante dos perfiles adaptados al usuario.

---

## Características Principales

El sistema se divide en dos enfoques de uso diferenciados por sesiones lógicas:

### 1. Perfil Saludable
Diseñado para entusiastas del fitness y la vida sana.
* **Registro Fit:** Almacenamiento rápido de preparaciones saludables.
* **Control y Seguimiento:** Módulo interactivo con un contador acumulativo para llevar el registro de platos saludables consumidos en el día.
* **Cocina Veloz:** Filtro de recetas que se ajustan al tiempo máximo disponible de tu agenda.

### 2. Perfil de Aprendizaje
Especializado en personas que están dando sus primeros pasos en el arte culinario.
* **Recetario Didáctico:** Permite registrar guías paso a paso detalladas utilizando separadores cronológicos (`;`).
* **Módulo de Tips Técnicos:** Espacio interactivo que despliega consejos prácticos del hogar (técnicas de corte, balance de condimentos, etc.).

---

## 🛠️ Tecnologías Utilizadas

* **Lenguaje:** C# (.NET Core / .NET 6.0 o superior)
* **Paradigma:** Estructurado mediante modularización funcional (`void`) y registros con estructuras de datos (`struct`).
* **Persistencia:** Archivos planos de texto (`.txt`) mediante flujos de entrada/salida (`StreamWriter`/`StreamReader`).

---

## Arquitectura de Datos y Persistencia

La información se gestiona localmente en un arreglo estático con límite físico de **50 recetas**. Para evitar la pérdida de información entre ejecuciones, el sistema lee y escribe de manera automatizada en dos archivos locales:

* `recetasSaludables.txt` (Registros separados por `;`)
* `recetasAprendizaje.txt` (Registros separados por `;`)

> **Nota:** Si la aplicación inicia por primera vez y no detecta registros guardados, el sistema cargará automáticamente un catálogo de ejemplos predefinidos (*Ensalada Mediterránea* y *Huevos Revueltos*).

---

## Instalación y Compilación

### Requisitos Previos
* Tener instalado el SDK de .NET (.NET 10.0).

### Pasos para ejecución local:

1. **Clonar e ingresar al repositorio:**
   ```bash
   git clone [https://github.com/TU_USUARIO/GestorRecetasCocina.git](https://github.com/TU_USUARIO/GestorRecetasCocina.git)
   cd GestorRecetasCocina
