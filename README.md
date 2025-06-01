
# Ejecución de la prueba

La prueba se ha realizado siguiendo las especificaciones del documento, por lo que se ha hecho especial hincapié en el desarrollo de las entidades de dominio y su lógica, una pequeña aplicación de consola para su gestión y un proyecto de tests unitarios que cubren los diferentes paths para los métodos AddItem y RemoveItem.

Como arquitectura mínima de la solución se propone una capa de dominio con lo anteriormente comentado, un repositorio encargado del acceso a datos y una capa de aplicación encargada de la orquestación de la lógica.

## Extra 1: WebApi

Como solución al primer extra propuesto, se implementa un API con las operaciones propuestas. Como factores de mejora, sería necesaria una mejor gestión de las excepciones de la lógica de negocio, con lo que las peticiones que realicen, proporcionarían mayor información en caso de fallo. En este caso, no se ha hecho por falta de tiempo.

Por otro lado, y al hilo del objetivo final de la prueba, también convendría haber utilizado algún sistema de persistencia de datos para guardar la información. Por simplificar, he optado por un patrón Singleton con el que trabajaremos en memoria con un objeto TodoList. En este caso, cada vez que reiniciemos la aplicación o el servicio, perderemos los datos.

## Extra 2: UI

Se ha creado un proyecto Angular para proporcionar una mínima interfaz de usuario (Beyond.Portal.UI). Por falta de tiempo, pero con el objetivo de mostrar la aplicación de ciertos principios en el frontend, sólo se simula la obtención de datos y su visualización por pantalla, de igual manera que los requisitos de la aplicación de consola.

En este caso, se puede ver el uso de llamadas asíncronas, la utilización de librerías (angular-material) para representar las barras de progreso y una mínima lógica para la visualización de los datos.

Para simular el resto de operaciones de escritura, podemos levantar el API creado en el "Extra 1" y, mediante postman, realizar algunos POSTs para crear algunos items y asignarles algunos progresos. Una vez los tengamos, podemos pulsar el botón de la interfaz para ver que las operaciones son correctas.

