# TestGitHubHistorico

Proyecto ASP.NET Core Web API en **.NET 8** creado como prueba de integración con GitHub.  
Expone un único endpoint REST que retorna un listado de países.

---

## Estructura del proyecto

```
TestGitHubHistorico/
├── Controllers/
│   └── CountriesController.cs   # Controlador con el endpoint GET /api/countries
├── Properties/
│   └── launchSettings.json
├── Program.cs                   # Configuración y arranque de la aplicación
├── TestGitHubHistorico.csproj
└── appsettings.json             # Configuración (cadena de conexión MongoDB)
```

---

## Endpoint disponible

| Método | Ruta             | Descripción                        |
|--------|------------------|------------------------------------|
| GET    | /api/countries   | Retorna un listado de países       |

### Ejemplo de respuesta

```json
[
  "Colombia",
  "Mexico",
  "Argentina",
  "Chile",
  "Peru",
  "Ecuador",
  "Spain",
  "Canada"
]
```

---

## Cómo ejecutar

```bash
dotnet restore
dotnet run
```

La API estará disponible en `http://localhost:5000` por defecto.

---

## Configuración

El archivo `appsettings.json` contiene la cadena de conexión a MongoDB:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://admin:password123@localhost:27017/TestGitHubHistoricoDB?authSource=admin"
  }
}
```

> **Nota de seguridad:** En producción, nunca exponer credenciales reales en este archivo. Usar variables de entorno o un gestor de secretos.

---

## git filter-repo

### ¿Qué es?

`git filter-repo` es la herramienta oficial recomendada por Git para **reescribir el historial** de un repositorio. Reemplaza al antiguo `git filter-branch` siendo mucho más rápida y segura.

Documentación oficial: https://github.com/newren/git-filter-repo

### Instalación

```bash
# Con pip (Python 3)
pip install git-filter-repo

# Con Homebrew (macOS/Linux)
brew install git-filter-repo
```

### Casos de uso comunes

#### 1. Eliminar un archivo sensible de todo el historial

Si accidentalmente subiste un archivo con credenciales (por ejemplo `appsettings.json`):

```bash
git filter-repo --path appsettings.json --invert-paths
```

Esto **elimina el archivo de todos los commits** del historial.

#### 2. Eliminar una carpeta completa del historial

```bash
git filter-repo --path bin/ --invert-paths
git filter-repo --path obj/ --invert-paths
```

#### 3. Reescribir mensajes de commits

```bash
git filter-repo --message-callback '
    return message.replace(b"texto viejo", b"texto nuevo")
'
```

#### 4. Extraer solo una subcarpeta como nuevo repo

```bash
git filter-repo --subdirectory-filter src/
```

#### 5. Cambiar autor en todo el historial

```bash
git filter-repo --mailmap archivo_mailmap.txt
```

Donde `archivo_mailmap.txt` tiene el formato:
```
Nombre Nuevo <nuevo@email.com> <viejo@email.com>
```

### Flujo típico después de usar filter-repo

```bash
# 1. Ejecutar el filtrado
git filter-repo --path archivo-secreto.txt --invert-paths

# 2. Forzar push para actualizar el historial remoto
git remote add origin https://github.com/usuario/repo.git
git push origin --force --all
git push origin --force --tags
```

> **Advertencia:** Forzar push reescribe el historial remoto. Coordina con el equipo antes de hacerlo en ramas compartidas.

---

## Tecnologías

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- MongoDB (cadena de conexión configurada)
- Git / git filter-repo
