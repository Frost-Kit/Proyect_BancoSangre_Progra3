# 🩸 Proyecto Banco de Sangre (Progra 3)

Este repositorio contiene un proyecto de consola en C# que usa Programación Orientada a Objetos (POO) y una separación por capas (muy generales): `Clases`, `Gestores` e `Interfaces`.

El objetivo de este `README` es que puedan copiar/pegar y ejecutar el proyecto en cualquier sistema operativo, incluso si no usan Git ni conocen IDEs avanzados. Y tengan un vistaso rapido de lo que hace el codigo

---

## Recomendado (prerrequisitos)

- Tener instalado el SDK de .NET (6 o 7). Comprobar con:

```bash
dotnet --version
```

- Opcional: Visual Studio (Windows), Rider o VS Code (cualquier SO). No es obligatorio, el proyecto puede correr desde la terminal con `dotnet`.

---

## Cómo ejecutar (forma más sencilla, multiplataforma)

1) Abre una terminal y ve a la carpeta del proyecto que contiene `BancoDeSangre/` y este `README.md`.

2) Crea un nuevo proyecto de consola con el nombre `ProyectoBancoSangre` (para evitar problemas de namespaces) y copia los archivos fuente dentro.

Linux / macOS / WSL / Git Bash:

```bash
cd BancoDeSangre
dotnet new console -n ProyectoBancoSangre -o ProyectoBancoSangre
cp -r Clases Gestores Interfaces Program.cs ProyectoBancoSangre/
cd ProyectoBancoSangre
dotnet run
```

Windows (PowerShell):

```powershell
cd BancoDeSangre
dotnet new console -n ProyectoBancoSangre -o ProyectoBancoSangre
Copy-Item -Recurse Clases,Gestores,Interfaces,Program.cs ProyectoBancoSangre\
cd ProyectoBancoSangre
dotnet run
```

Notas:
- Estos comandos crean una carpeta `ProyectoBancoSangre` con un proyecto .NET y copian allí las clases del repositorio.
- Usar exactamente el nombre `ProyectoBancoSangre` evita conflictos de `namespace` al compilar.
- Si `dotnet run` falla por namespaces o referencias, puedo generar un `ProyectoBancoSangre.csproj` preconfigurado dentro del repo.

---

## Ejecutar desde un IDE (GUI)

- Visual Studio / Rider: Abrir la carpeta `BancoDeSangreApp` creada (o crear un nuevo `Console Project` y arrastrar las carpetas `Clases`, `Gestores`, `Interfaces` y `Program.cs`). Luego ejecutar con F5.
- VS Code: Abrir la carpeta `BancoDeSangreApp`, instalar la extensión C# si se solicita y ejecutar `dotnet run` desde el terminal integrado.

---


## Explicación detallada de archivos y responsabilidades (para defender en presentación)

- `BancoDeSangre/Program.cs` — `Program` : Punto de entrada. Explicar el flujo del menú principal, cómo se inicializan los gestores y cómo se orquesta la interacción entre módulos. Mencionar manejo de listas en memoria y llamadas a métodos de persistencia al finalizar (guardar/cargar).

- `BancoDeSangre/Interfaces/IGestionar.cs` — `IGestionar` : Interfaz que define el contrato CRUD para gestores. Al defenderla, explicar por qué usar una interfaz mejora la modularidad y facilita pruebas o cambios futuros sin tocar el menú.

- `BancoDeSangre/Interfaces/INotificar.cs` — `INotificar` : Interfaz para notificaciones. Señalar que las clases que implementan esta interfaz (por ejemplo `Persona`) pueden notificar vía distintos medios (simulado en consola), separando la lógica de negocio de la presentación.

- `BancoDeSangre/Interfaces/ILeerYValidar.cs` — `ILeerYValidar` : Contiene helpers de entrada/validación reutilizables (lectura de nombres, CI, email, números, enums). Al presentarlo, resaltar la validación centralizada y cómo evita duplicar código en gestores.

- `BancoDeSangre/Gestores/GestionDonante.cs` — `GestionDonante` : Responsable de la lista de `Donante`, validaciones de negocio (por ejemplo evitar duplicados por CI), persistencia en `Donante.txt`, y funciones de búsqueda/filtrado. Para defenderlo: mostrar el flujo de una operación CRUD (registro → validación → guardar en lista → persistir en archivo).

- `BancoDeSangre/Gestores/GestionEmpleado.cs` — `GestionEmpleado` : Similar a `GestionDonante` pero para empleados; explicar diferencias en campos (cargo, id) y por qué se separó la lógica en otro gestor (SRP — Single Responsibility Principle).

- `BancoDeSangre/Gestores/GestionUnidades.cs` — (placeholder) : Espacio reservado para lógica que gestione `UnidadExtraida` (inventario, caducidad, estados). Si lo presentan, decir que la responsabilidad sería manejar stock y reglas de caducidad.

- `BancoDeSangre/Clases/Persona.cs` — `Persona` (abstracta) : Contiene propiedades comunes (Nombre, CI, Teléfono, Email, Edad) y validaciones. Explicar que herencia evita repetir campos y comportamientos entre `Donante` y `Empleado`.

- `BancoDeSangre/Clases/Donante.cs` — `Donante` : Modelo con `IdDonante`, `TipoSangre`, `RH`, `Peso`, `Altura`, `HistorialDonaciones`. En la defensa, mostrar cómo se registra una donación, qué datos se almacenan y cómo se vincula con `UnidadExtraida`.

- `BancoDeSangre/Clases/Empleado.cs` — `Empleado` : Modelo con `IdEmpleado` y `Cargo`. Explicar pequeñas diferencias de comportamiento con `Donante`, y cómo implementa métodos heredados de `Persona`.

- `BancoDeSangre/Clases/UnidadExtraida.cs` — `UnidadExtraida` (abstracta) : Define las propiedades y comportamientos comunes de una unidad de sangre (volumen, fecha de extracción, caducidad, estado). Buen punto para defender validaciones y modelos de datos usados en inventario.

- `BancoDeSangre/Clases/ComponentesSanguineos.cs` — `SangreEntera`, `GlobulosRojos`, `Plaquetas`, `Plasma` : Clases concretas con reglas específicas (volúmenes, caducidad, manejo de estado térmico en `Plasma`). Explique por qué se usó herencia y polimorfismo para modelar variantes.

- `BancoDeSangre/Clases/Enumerdadores.cs` — `TipoSangre`, `TipoRH`, `EstadoUnidad` : Enumeradores para representar grupos, factores RH y estados; explíquen cómo ayudan a evitar errores por strings y facilitan validación.

Consejos para la defensa técnica:

- Muestren la arquitectura en capas: `Program` → `Gestores` → `Clases` → `Interfaces`.
- Destaquen principios de POO aplicados: encapsulación (validaciones en `Persona`/`UnidadExtraida`), herencia (Personas y Componentes), polimorfismo (unidades concretas) y separación de responsabilidades (gestores vs modelos).
- Expliquen la persistencia simple basada en archivos de texto (qué se guarda y por qué), y propongan mejoras (por ejemplo usar una base de datos si se pide escala).


---

