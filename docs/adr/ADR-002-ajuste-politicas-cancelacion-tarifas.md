# ADR-002: Ajuste de Políticas de Cancelación y Cálculo de Tarifas

* **Estatus:** Aceptado
* **Fecha:** 2026-10-07
* **Estándar:** ISO/IEC/IEEE 42010:2022

## Contexto y Problema
El cálculo de tarifas, copagos y la aplicación de multas por cancelación en el sistema legado dependían de estructuras de control condicional masivas (`switch` y múltiples `if-else`) encadenadas dentro de la misma *God Class*. Esto infringía el Principio Abierto/Cerrado (OCP), ya que cualquier adición de una nueva especialidad médica, un nuevo convenio o un cambio en las multas obligaba a modificar directamente el código fuente existente, aumentando el riesgo de introducir errores en producción.

## Decisión
Se decide aislar la lógica de cálculo y negocio extrayéndola hacia componentes especializados y cohesivos:
1. Se diseñó la clase independiente `CalculadorTarifas` para encapsular las reglas paramétricas de cobro de copagos según especialidades y convenios.
2. Se estructuró el flujo de cancelación y agendamiento para que el gestor principal delegue las reglas de negocio en clases auxiliares dedicadas.

## Consecuencias y Trade-offs
### Positivas:
* **Cumplimiento de OCP:** Es posible extender el sistema (añadiendo nuevas tarifas, convenios o reglas de cancelación) mediante nuevas clases o parámetros sin modificar la lógica principal de gestión de citas.
* **Alta Cohesión (LCOM96b optimizado):** Cada clase atiende una única preocupación del negocio, reduciendo drásticamente la complejidad ciclomática de los métodos.
* **Legibilidad:** El código del flujo de citas se vuelve limpio y comprensible.

### Negativas / Costes:
* **Mayor fragmentación:** El código se distribuye en varias clases de soporte más pequeñas, requiriendo un mejor entendimiento estructural por parte de nuevos desarrolladores.