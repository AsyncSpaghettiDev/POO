# Ejercicio markdown
## Instalación de dotnet core 2.2.
*Nota puedes visitar el sig [link](https://dotnet.microsoft.com/download/dotnet-core) y saltar hasta el paso #5.*  
Paso 1: Buscar **dotnet core** <img src=./img/dnt.png width=3% length=3%> en el navegador de tu preferencia.  
<img src=./img/bus-dnt.png width=50% legth=50%>  
Paso 2: Entrar en la página oficial de Microsoft.  
Paso 3: Clickear en All .netCore Downloads.  
Paso 4: Seleccionar la versión 2.2.  
Paso 5: Selecciona el SDK más reciente.  
<img src=./img/vers-dnt.png width=50% length=50%>  
Paso 6: Elige tu Sistema operativo y su arquitectura.  
Paso 7: Esperar a que comience la descarga.  
Paso 8: Ejecutar el instalador.  
<img src=./img/ins-dnt.png width=50% length=50%>  
Paso 9: Comprobar que se instaló correctamente abriendo CMD y ejecutando "dotnet info".  
<img src=./img/terminal-dnt.png width=50% legth=50%>

## Instalación y configuración de Visual Studio Code para C#.
*Nota puedes visitar el sig [link](https://code.visualstudio.com/download) y saltar hasta el paso #4.*  
Paso 1: Buscar **Visual Studio Code** <img src=./img/vsc.png width=3% legth=3%> en el navegador de tu preferencia.  
<img src=./img/bus-vsc.png width=50% length=50%>  
Paso 2: Entrar en la página oficial de Microsoft.  
Paso 3: Da click en DOWNDLOAD  
Paso 4: Selecciona tu sistema operativo y su arquitectura.  
<img src=./img/vers-vsc.png width=50% length=50%>  
Paso 5: Esperar a que comience la descarga.  
Paso 6: Ejecutar el instalador  
<img src=./img/ins-vsc.png width=50% length=50%>

Paso 7: Abrir la consola (cmd/powershell/terminal) y escribir lo siguiente (dotnet new console -o "NombreProyecto").    
Paso 8: Escribir en la consola (cd "NombreProyecto") y (code .)  
<img src=./img/terminal-vsc.png width=50% length=50%>
Paso 9: Dirigirse a la cinta de opciones de la izq y dar click en el "Tetris" (Ctr+Shift+X) para instalar extensiones.  
Paso 10: En el recuadro de busqueda escribir **"C#"** y elegir el distribuido por Microsoft, y dar en Instalar.  
<img src=./img/ext-c.png>

## Instalar Git y Vincular con VSC
*Nota puedes visitar el sig [link](https://git-scm.com/downloads) y saltar hasta el paso #2*  
Paso 1: Buscar **git** <img src=./img/git.png width=3% legth=3%> en el navegador de tu preferencia.  
<img src=./img/bus-git.png width=50% length=50%>  
Paso 2: Seleccionar la opción donde solo diga Git. 
Paso 3: Clickear en Downloads, Seleccionar tu Sistema Operativo, y esperar a que se descargue.  
<img src=./img/vers-git.png width=50% length=50%>  
Paso 4: Ejecutar el instalador y dar siguiente y acepto.  
Paso 5: Abrir la consola (cmd/powershell/terminal) y escribir el sig comando (git --version)  
<img src=./img/terminal-git.png width=50% length=50%>

A continuación veremos como clonar y actualizar nuestro repositorio usando VSC <img src=./img/g+vsc.png width=3% length=3%>
### Clonar repo des git y usarlo en VSC  
Paso 1: Iniciar sesión en tu cuenta de GitHub y ubicar el repo a clonar.  
Paso 2: Dar click en la parte de **Clone or download** y copiar el link.  
<img src=./img/desk-git.png width=50% length=50%>  
Paso 3: Abrir la consola (cmd/powershell/terminal) y escribir el sig comando (git clone LINK-COPIADO-DEL-PASO-ANTERIOR)  
Paso 4: Cambiar al directorio copiado principal, en este caso POO (cd POO).  
Paso 5: Abrir Visual Studio Code desde este directorio usando el siguiente comando (code .).  
<img src=./img/terminal-git2.png width=50% length=50%>  
Listo ya clonamos y podemos modificar nuestro repositorio.

### Actualizar repositorio de gitHub desde VSC