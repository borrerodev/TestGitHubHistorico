# TestGitHubHistorico

Proyecto ASP.NET Core Web API en **.NET 8** para demostración de integración con GitHub y gestión de datos.

Este proyecto es una prueba de concepto que expone endpoints REST para consultar datos de países y tipos de documentos, con soporte para integración con Kafka y Azure KeyVault.

---

## 📋 Características

- ✅ API REST en ASP.NET Core .NET 8
- ✅ Dos endpoints principales: `/api/countries` y `/api/documenttypes`
- ✅ Configuración de Kafka para publicación/suscripción
- ✅ Rutas configurables para archivos y logs
- ✅ Integración con Azure KeyVault
- ✅ Logging estructurado

---

## 📁 Estructura del Proyecto

```
TestGitHubHistorico/
├── Controllers/
│   ├── CountriesController.cs      # Controlador de países
│   └── DocumentTypesController.cs  # Controlador de tipos de documentos
├── Properties/
│   └── launchSettings.json         # Configuración de lanzamiento
├── Program.cs                      # Punto de entrada y configuración
├── TestGitHubHistorico.csproj      # Proyecto C#
├── appsettings.json                # Configuración de la aplicación
└── README.md                       # Este archivo
```

---

## 🚀 Endpoints Disponibles

### 1. Obtener Países
```
GET /api/countries
```

**Respuesta:**
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

### 2. Obtener Tipos de Documentos
```
GET /api/documenttypes
```

**Respuesta:**
```json
[
  {
    "id": 1,
    "code": "CC",
    "name": "Cédula de Ciudadanía",
    "country": "Colombia"
  },
  {
    "id": 2,
    "code": "TI",
    "name": "Tarjeta de Identidad",
    "country": "Colombia"
  },
  ...
]
```

---

## ⚙️ Configuración

### Archivo `appsettings.json`

#### Base de Datos MongoDB
```json
"MongoDB": {
  "ConnectionString": "mongodb"
}
```

#### Azure KeyVault
```json
"KeyVault": {
  "VaultUrl": "https://test-github-historico.vault.azure.net/",
  "ClientId": "12345678-1234-1234-1234-123456789012",
  "ClientSecret": "secret_key_abc123def456ghi789jkl012mno345pqr",
  "TenantId": "87654321-4321-4321-4321-210987654321",
  "SecretNames": {
    "DatabasePassword": "test-github-historico-db-password",
    "ApiKey": "test-github-historico-api-key",
    "JwtSecret": "test-github-historico-jwt-secret"
  }
}
```

#### Rutas de Archivos
```json
"FilePaths": {
  "DocumentsFolder": "C:\\Data\\Documents",
  "LogsFolder": "C:\\Logs\\Application",
  "TempFolder": "C:\\Temp\\Processing",
  "BackupFolder": "C:\\Backups\\Database",
  "MaxFileSizeMB": 100
}
```

#### Configuración Kafka
```json
"Kafka": {
  "BootstrapServers": "localhost:9092,localhost:9093,localhost:9094",
  "GroupId": "test-github-historico-consumer-group",
  "Topics": {
    "Countries": "topic-countries",
    "DocumentTypes": "topic-document-types",
    "Logs": "topic-application-logs"
  },
  "ProducerConfig": {
    "Acks": "all",
    "Retries": 3,
    "BatchSize": 16384,
    "LingerMs": 10
  },
  "ConsumerConfig": {
    "MaxPollRecords": 500,
    "SessionTimeoutMs": 30000,
    "HeartbeatIntervalMs": 10000
  },
  "SecurityProtocol": "PLAINTEXT",
  "SaslMechanism": "PLAIN",
  "SaslUsername": "kafka-user",
  "SaslPassword": "kafka-password-dev"
}
```

---

## 🏃 Cómo Ejecutar

### Requisitos
- .NET 8 SDK o superior
- (Opcional) MongoDB local o en la nube
- (Opcional) Kafka instalado para testing

### Comandos

**Restaurar dependencias:**
```bash
dotnet restore
```

**Compilar el proyecto:**
```bash
dotnet build
```

**Ejecutar la aplicación:**
```bash
dotnet run
```

La API estará disponible en:
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`

---

## 📚 Documentación de Kafka

### Topics Configurados

| Topic | Propósito |
|-------|-----------|
| `topic-countries` | Publicar/suscribirse a cambios de países |
| `topic-document-types` | Publicar/suscribirse a cambios de tipos de documentos |
| `topic-application-logs` | Registrar eventos de la aplicación |

### Producción
- **Acks:** `all` — Espera confirmación de todos los replicas
- **Retries:** `3` — Reintentos en caso de fallo
- **Batch Size:** `16384 bytes` — Tamaño de lote
- **Linger:** `10 ms` — Espera antes de enviar

### Consumo
- **Max Poll Records:** `500` — Máximo de registros por poll
- **Session Timeout:** `30000 ms` — Timeout de sesión
- **Heartbeat Interval:** `10000 ms` — Intervalo de latido

---

## 🔒 Seguridad

### Variables de Entorno Recomendadas

Por seguridad, sobrescribe valores sensibles en producción:

```bash
# MongoDB
export MongoDB_ConnectionString="tu-conexion-real"

# KeyVault
export KeyVault_ClientSecret="tu-secreto-real"

# Kafka
export Kafka_SaslPassword="tu-password-real"
```

### Notas
- ⚠️ **En desarrollo:** Las credenciales en `appsettings.json` son ficticias
- ⚠️ **En producción:** Usar Azure KeyVault, AWS Secrets Manager o variables de entorno
- ⚠️ **Nunca commitear** credenciales reales en el repositorio

---

## 📝 Logging

Configurado en `appsettings.json`:

```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore": "Warning"
  }
}
```

Los logs se guardarán en la ruta configurada: `C:\Logs\Application`

---

## 🛠️ Tecnologías Utilizadas

| Tecnología | Versión | Propósito |
|------------|---------|----------|
| .NET | 8.0 | Framework principal |
| ASP.NET Core | 8.0 | Web API |
| MongoDB | (Opcional) | Base de datos NoSQL |
| Kafka | (Opcional) | Message broker |
| Azure KeyVault | (Opcional) | Gestión de secretos |

---

## 📖 Historia del Proyecto

Este proyecto fue creado como una prueba de concepto para demostrar:

1. Creación de una API REST básica en .NET 8
2. Gestión de configuración segura
3. Integración con servicios en la nube (Azure KeyVault)
4. Arquitectura de mensajería con Kafka
5. Prácticas de seguridad en repositorios Git

---

## 🤝 Contribuciones

Para contribuir:

1. Haz fork del repositorio
2. Crea una rama feature (`git checkout -b feature/mi-feature`)
3. Haz commit de tus cambios (`git commit -m "feat: descripción"`)
4. Push a la rama (`git push origin feature/mi-feature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.

---

## ✉️ Contacto

Para preguntas o problemas, contacta al equipo de desarrollo.

---

**Última actualización:** 2026-07-27
