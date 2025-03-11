# SalesDatePrediction
Patrón de arquitectura de la aplicación: Arquitectura de Cliente-Servidor o Arquitectura de Aplicación Web de 2 Capas.

# SalesDatePredictionAPI
Datos a considerar:
1.	Versión de Visual Studio: 2022
2.	Framework: .Net Core 8
3.	Aplicación: WebApi
4.	Arquitectura: DDD

En el archivo appsettings.json ajustar el nombre de la base de datos, el usuario y el password según como haya construido el escenario anterior o en el que funcione su SSMS.

Ejecutar la API
Para ejecutar la aplicación:
1.	Abrir una ventana de símbolo de sistema.
2.	Ir hasta la ruta donde este SalesDatePredictionAPI.
3.	Ignorar los certificados de seguridad en desarrollo ejecutando la siguiente línea: set DOTNET_SYSTEM_NET_HTTP_SOCKS5_PROXY=true
4.	Ejecutar el siguiente comando: dotnet run.
5.	El puerto de ejecución es 5207

# sales-date-predictionIU y grafic-d3

La interfaz de aplicación esta construida con angular en la versión 18 con Bootstrap y material.

1.	Versión angular cli: 18.2.3
2.	Versión Node: 22.8.0

En caso de no contar con Node.js y npm, puede dirigirse a la pagina oficial e instalarlo: https://nodejs.org/es, una vez instalado, verificar la versión:
1.	Abrir un cmd
2.	Ejecutar: node -v
3.	Ejecutar: npm -v

# Versión angular cli

Verificar la versión de angular cli:

1.	Abrir un cmd
2.	Ejecutar: ng versión
Instalar angular cli
En caso de no tener instalado angular cli:
1.	Ejecutar: npm install -g @angular/cli.

# Actualizar angular cli

En caso de no tener instalado la versión correcta:
1.	Abrir un cmd.
2.	Ejecutar: npm uninstall -g @angular/cli
3.	Limpiar el cahe: npm cache verify
4.	Instalar la última versión de angular cli: npm install -g @angular/cli
5.	Verificar la versión: ng versión

# Instalar node_modules
Antes de poner en funcionamiento la aplicación, instalaremos los modulos del node:

1.	Abre Visual Studio Code.
2.	En la barra de menú superior, selecciona Terminal y luego New Terminal. Alternativamente, puedes usar el atajo de teclado:
3.	Windows/Linux: Ctrl + `` (la tecla justo debajo de Esc`).
4.	Mac: `Cmd + ``.
5.	Esto abrirá un terminal integrado dentro de Visual Studio Code en la parte inferior de la ventana.
6.	Ejecutar: npm install

De esta forma ya podremos ejecutar nuestra aplicación.

# Ejecutar aplicación

Una vez abierta la terminal en visual studio code ejecutar ng serve, la terminal nos arrojara datos de ejecución y la ruta web de la aplicación.
en este caso la ruta es http://localhost:4200

# Build del proyecto

1. Ir al directorio de tu aplicación.
2. Abrir una consola Git Bash
3. Ejecutar: ng build
4. Verificar archivos generados en la carpeta dist del proyecto con el nombre dist/sales-date-prediction.




