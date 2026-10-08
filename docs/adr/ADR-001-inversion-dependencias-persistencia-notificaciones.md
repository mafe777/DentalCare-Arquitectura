# ADR-001: Inversión de Dependencias para Persistencia y Notificaciones

* **Estatus:** Aceptado
* **Fecha:** 10-07-2026
* **Estándar:** ISO/IEC/IEEE 42010:2022

## Contexto y Problema
En la arquitectura inicial del módulo legado (`DentalCare.Legacy`), la clase monolítica `GestorCitasOdontologicas` creaba y gestionaba sus dependencias de infraestructura de forma directa mediante la palabra clave `new` (por ejemplo, instanciando `SqlServerEjecutor` y servicios de notificación hardcodeados). Esto violaba explícitamente el Principio de Inversión de Dependencias (DIP) y el Principio de Responsabilidad Única (SRP), generando un acoplamiento rígido con la base de datos y los canales de comunicación externos, lo que imposibilitaba la realización de pruebas unitarias aisladas.

## Decisión
Se decide desacoplar por completo el núcleo de la lógica de negocio de los detalles de infraestructura mediante la implementación de Inyección de Dependencias (DI) basada en contratos/interfaces:
1. Se crearon las interfaces abstractas `IRepositorioCitas` y `IServicioNotificacion`.
2. Se reestructuró la clase `GestorCitasRefactorizado` para que reciba estas abstracciones a través de su constructor, delegando la responsabilidad de persistencia y avisos a componentes externos.

## Consecuencias y Trade-offs
### Positivas:
* **Desacoplamiento total:** El negocio ya no depende de tecnologías específicas de bases de datos o proveedores de mensajería.
* **Testabilidad:** Permite el uso de objetos simulados (*mocks* y *stubs*) para realizar pruebas unitarias rápidas y confiables sin afectar bases de datos reales.
* **Mantenibilidad:** Facilita cambiar el motor de persistencia o el proveedor de notificaciones modificando únicamente las clases adaptadoras sin alterar la lógica central.

### Negativas / Costes:
* **Complejidad inicial:** Se incrementa la cantidad de archivos y contratos en el proyecto.
* **Curva de configuración:** Requiere gestionar un contenedor o una composición explícita de dependencias en el punto de entrada de la aplicación (`Program.cs`).