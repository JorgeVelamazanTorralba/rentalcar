PRUEBA TÉCNICA .NET
Implementar un microservicio que permita gestionar la siguiente funcionalidad:
Una Empresa de renting. El microservicio debería de permitir realizar las siguientes
acciones (a través de llamadas REST):
- Debería de gestionar la creación de nuevos vehículos para la flota.
- Poder listar los vehículos disponibles de la flota.
- Poder alquilar un vehículo.
- Devolución del vehículo.
Restricciones:
- Una misma persona no debería de poder reservar más de 1 vehículo al mismo tiempo.
- La flota no debe de contener vehículos cuya fecha de fabricación sea superior a 5 años.
___________________________________________________________________________
Haciendo uso de la template de arquitectura que se proporciona y de algunos de los
patrones indicados en la misma, implementar dicho microservicio.
Hay que tener en cuenta que la implementación debería de facilitar el desarrollo de
pruebas automáticas (unitarias, funcionales y de infrastructura).
No es necesaria la implementación de dichas pruebas para todo el código pero sí un
ejemplo de cada una:
- Infrastructura: Probar uno de los métodos REST que salgan de la implementación. Solo a
nivel de host (recepción de la llamada y validación del modelo), no completa.
- Unitaria: Validar de forma unitaria (sin sus dependencias) uno de los métodos que se
implementen.
- Funcional: Realizar una prueba de integración (excluyendo el host).
El microservicio debería de poder ejecutarlo en local cualquier persona sin necesidad de
instalar ninguna dependencia externa (se admite el uso de docker y/o docker-compose).
