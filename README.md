# Plantilla VR de Unity Limpia

Esta es una plantilla de inicio para proyectos de Realidad Virtual (VR) en Unity, diseñada para ser lo más simple y ligera posible. Ha sido optimizada eliminando todo el contenido de tutoriales y demos innecesarios, dejando una base sólida para el desarrollo de aplicaciones VR multi-escena.

## Características Principales

- **Escena Base Limpia**: Incluye `TemplateVR.unity`, una habitación 10x10 básica con suelo, paredes y configuraciones de VR listas.
- **XR Interaction Toolkit 3.3.1**: Configuración estándar para interactuar con objetos en VR.
- **Movimiento VR**: Soporte nativo para teletransportación y movimiento continuo.
- **Proyecto Estructurado**: Estructura de carpetas minimalista para facilitar el mantenimiento.

## Estructura del Proyecto

- `Assets/Scenes`: Contiene la escena base `TemplateVR.unity`.
- `Assets/Materials`: Materiales básicos (suelo y paredes).
- `Assets/VRTemplateAssets`: Prefabs y scripts esenciales para el funcionamiento de la VR.
- `Assets/Samples`: Starter Assets de XR Interaction Toolkit (configuraciones de entrada y modelos de controladores).

## Cómo Usar esta Plantilla

1. **Duplicar Escenas**: Abre `TemplateVR.unity` en la carpeta `Assets/Scenes` y úsala como base para tus nuevas escenas haciendo clic en `File > Save As...`.
2. **Configuración de VR**: El `XR Origin (XR Rig)` ya está configurado. Simplemente coloca tus objetos y asegúrate de que tengan `Collider` para las colisiones.
3. **Desarrollo**: Agrega tus propios scripts en la carpeta `Assets/Scripts`.

## Instalación y Configuración

Unity no usa un comando como `npm install`, sino que gestiona las dependencias automáticamente a través del **Package Manager**. Cuando alguien clona o descarga este repositorio, debe seguir estos pasos:

1.  **Abrir con Unity Hub**: Asegúrate de usar la versión recomendada **6000.3.11f1** para evitar errores de compatibilidad.
2.  **Carga de paquetes**: Al abrir el proyecto por primera vez, Unity detectará el archivo `manifest.json` y descargará automáticamente todos los paquetes de XR Interaction Toolkit y OpenXR. Esto puede tardar unos minutos.
3.  **TextMesh Pro Essentials**: Si Unity detecta que faltan los recursos base de TextMesh Pro, aparecerá una ventana emergente. Haz clic en **"Import TMP Essentials"**.
4.  **Configuración de XR**: Ve a `Edit > Project Settings > XR Plug-in Management` y asegúrate de que **OpenXR** esté seleccionado en la pestaña de PC o Android (según sea tu objetivo).

## Requisitos

- **Unity Version**: Recomendado 2022.3 LTS o superior (6000.3.11f1).
- **XR Plugin Management**: Configurado para **OpenXR** por defecto.

## Notas para GitHub

Este repositorio incluye un archivo `.gitignore` optimizado para Unity que excluye archivos temporales y la carpeta del sistema `Library`, asegurando que solo subas el código y los recursos necesarios.
