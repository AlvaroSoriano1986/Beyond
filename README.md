
# Ejecuci�n de la prueba

La prueba se ha realizado siguiendo las especificaciones del documento, por lo que se ha hecho especial hincapi� en el desarrollo de las entidades de dominio y su l�gica, una peque�a aplicaci�n de consola para su gesti�n y un proyecto de tests unitarios que cubren los diferentes paths para los m�todos AddItem y RemoveItem.

Como arquitectura m�nima de la soluci�n se propone una capa de dominio con lo anteriormente comentado, un repositorio encargado del acceso a datos y una capa de aplicaci�n encargada de la orquestaci�n de la l�gica.

## Extra 1: WebApi

Como soluci�n al primer extra propuesto, se implementa un API con las operaciones propuestas. Como factores de mejora, ser�a necesaria una mejor gesti�n de las excepciones de la l�gica de negocio, con lo que las peticiones que realicen, proporcionar�an mayor informaci�n en caso de fallo. En este caso, no se ha hecho por falta de tiempo.

Por otro lado, y al hilo del objetivo final de la prueba, tambi�n convendr�a haber utilizado alg�n sistema de persistencia de datos para guardar la informaci�n. Por simplificar, he optado por un patr�n Singleton con el que trabajaremos en memoria con un objeto TodoList. En este caso, cada vez que reiniciemos la aplicaci�n o el servicio, perderemos los datos.

## Extra 2: UI

Se ha creado un proyecto Angular para proporcionar una m�nima interfaz de usuario (Beyond.Portal.UI). Por falta de tiempo, pero con el objetivo de mostrar la aplicaci�n de ciertos principios en el frontend, s�lo se simula la obtenci�n de datos y su visualizaci�n por pantalla, de igual manera que los requisitos de la aplicaci�n de consola.

En este caso, se puede ver el uso de llamadas as�ncronas, la utilizaci�n de librer�as (angular-material) para representar las barras de progreso y una m�nima l�gica para la visualizaci�n de los datos.

Para simular el resto de operaciones de escritura, podemos levantar el API creado en el "Extra 1" y, mediante postman, realizar algunos POSTs para crear algunos items y asignarles algunos progresos. Una vez los tengamos, podemos pulsar el bot�n de la interfaz para ver que las operaciones son correctas.

