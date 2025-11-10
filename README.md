-----------SISTEMA DE RESERVAS DE TURNOS MEDORAPP------------- 
Pasos para la ejecucion del programa: 
1) Descargar y ejecutar los .sql (Primero el MedoraDB.sql y luego el lote de datos)
2) Entrar a la carpeta de la aplicacion, MedoraApp -> bin -> debug
3) Click derecho en MedoraApp.exe.config -> editar con blog de notas -> en la linea
   <connectionStrings>
		<add name="MedoraDB"
			 connectionString="Server=SEBAADMIN\SQLEXPRESS;Database=MedoraDB;Trusted_Connection=True;"
			 providerName="System.Data.SqlClient" />  cambiar el SEBAADMIN\SQLEXPRESS por el nombre de
   su servidor SQL
4) Guardar cambios y ejecutar el MedoraApp.exe, entrar con cualquiera de los siguientes usuarios:

----CREDENCIALES      Usuario        Contraseña
---- Administrador -> adm@mail.com   hash123
---- Medico        -> med@mail.com   hash123
---- Recepcionista -> recep@mail.com hash123

PARA GENERAR EL RESPALDO DE LA DB -> Guardar en el disco C/: (por temas de permisos no permite 
guardar en el escritorio o en Documentos)
