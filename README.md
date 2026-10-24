# EcoRun 2D

Serious game 2D hecho en Unity en el que un personaje corre sin parar mientras el jugador aprende a **clasificar residuos** en la caneca correcta. Es un runner al estilo del juego del dinosaurio de Google, con arte pixel art y mecánicas de salto, recolección y clasificación.

> Proyecto del Previo 2 de la asignatura **Desarrollo de Contenidos Digitales y Multimedia**, UTS (Unidades Tecnológicas de Santander).

---

## Objetivo educativo

Enseñar de forma lúdica la **separación de residuos en la fuente** por colores. El jugador debe reconocer a qué caneca pertenece cada residuo y actuar rápido, reforzando el hábito de reciclar.

## Cómo se juega

1. Pulsa **Jugar** en el menú principal.
2. Presiona **D** o la **flecha derecha** para que el personaje empiece a correr. La velocidad aumenta poco a poco.
3. Van apareciendo residuos en el suelo. Tienes dos formas de resolverlos:
   - **Saltar** por encima para esquivarlos.
   - **Hacer clic en la caneca correcta** mientras el residuo está en pantalla: desaparece y aparece un mensaje de éxito.
4. Pierdes **una vida** (de 3, mostradas como corazones) si:
   - Chocas con un residuo.
   - Haces clic en la caneca equivocada.
5. Si pierdes las 3 vidas aparece la pantalla de **Game Over**, con las opciones **Reintentar** y **Menú**.



## Controles

| Acción | Tecla / entrada |
|---|---|
| Empezar a correr | `D` o `→` |
| Saltar | `Espacio`, `W` o `↑` |
| Depositar el residuo | Clic izquierdo sobre la caneca |

## Canecas y residuos

| Caneca | Tipo de residuo | Ejemplos |
|---|---|---|
| Blanca | Aprovechables (plástico, papel, vidrio, metales) | Botella, lata |
| Verde | Orgánicos | Cáscara de banano, restos de fruta |
| Negra | No aprovechables | Bolsa de papas, icopor |
| Roja | Peligrosos | Pilas, bombillos |

> Código de colores según la clasificación usada en Colombia. Ajusta esta tabla si tu juego usa una asignación distinta.

## HUD y menú

- **HUD en partida:** vidas en corazones, marcador de puntos y mensaje de éxito al acertar.
- **Menú principal:** botones **Jugar** y **Cómo jugar** (panel con instrucciones y explicación de las canecas).
- **Pantalla de Game Over:** botones **Reintentar** y **Menú**.

## Requisitos

- **Unity 6** (versión `6000.6.3f1`)
- Paquetes: **Input System**, **2D Tilemap**, **TextMeshPro**, **Universal Render Pipeline (2D)**

## Cómo ejecutar el proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/<TU-USUARIO>/<TU-REPOSITORIO>.git
   ```
2. Abre **Unity Hub** → **Add** → selecciona la carpeta clonada.
3. Abre el proyecto con la versión de Unity indicada arriba (la primera vez genera la carpeta `Library`, puede tardar unos minutos).
4. Abre la escena `Assets/Scenes/MainMenuScene` y pulsa **Play**.

Para generar un ejecutable: **File → Build Profiles**, confirma que `MainMenuScene` es la escena 0 y `GameScene` la 1, y pulsa **Build**.

## Build jugable

Enlace de descarga / versión WebGL: https://xiomara-mendoza.itch.io/ecorun-2d-serious-game

## Estructura del proyecto

```
Assets/
├── Animations/    Controlador y animaciones del personaje (Idle, Walk, Jump)
├── Prefabs/       Prefabs de los residuos
├── Scenes/        MainMenuScene, GameScene
├── Scripts/       Código C# del juego
├── Sprites/       Arte pixel art (personaje, canecas, residuos, fondo, UI)
└── Tilemaps/      Suelo y decoración del nivel
```

## Scripts principales

| Script | Función |
|---|---|
| `PlayerController2D` | Movimiento automático, aceleración progresiva, salto, detección de suelo y animaciones |
| `CameraFollow2D` | La cámara sigue al personaje manteniéndolo a la izquierda de la pantalla |
| `DecorationLooper` | Repite la decoración del fondo para crear un nivel infinito |
| `WasteSpawner` | Genera residuos aleatorios sobre el suelo a medida que el personaje avanza |
| `WasteItem` | Define el tipo de residuo y descuenta una vida si el jugador choca con él |
| `Bin` | Detecta el clic del jugador sobre cada caneca |
| `GameManager` | Lógica central: evaluación de aciertos, puntos, vidas, mensaje de éxito, Game Over y reinicio |
| `MainMenuManager` | Navegación del menú principal: jugar y panel "Cómo jugar" |

## Pruebas funcionales

| Caso | Procedimiento | Resultado esperado |
|---|---|---|
| Movimiento | Pulsar `D` | El personaje corre y la animación cambia de Idle a Walk |
| Salto | Pulsar `Espacio`, `W` o `↑` | El personaje salta y la animación cambia a Jump; no salta en el aire |
| Acierto | Clic en la caneca correcta | El residuo desaparece y aparece el mensaje de éxito |
| Error de caneca | Clic en la caneca incorrecta | El residuo desaparece y se pierde un corazón |
| Choque | Pasar por encima de un residuo sin saltar | Se pierde un corazón |
| Game Over | Perder las 3 vidas | Aparece el panel con Reintentar y Menú, y el juego se pausa |
| Reintentar | Pulsar Reintentar | La escena se reinicia con vidas  |
| Menú | Pulsar Menú en el Game Over | Se carga el menú principal |

## Trabajo futuro

- NPC guía con diálogos educativos.
- Objetos interactivos con la tecla `E` que muestren datos sobre reciclaje.
- Sección de créditos dentro del juego.
- Más tipos de residuos y niveles de dificultad.
- Conteo logros con puntaje.
- nivel con 250 puntos para pasar al siguiente.
- 
## Créditos

- **Desarrollo, diseño y programación:** `Xiomara Mendoza Guerrero`
- **Asignatura:** Desarrollo de Contenidos Digitales y Multimedia, UTS
- **Motor:** [Unity](https://unity.com/)

## Licencia

Proyecto académico sin fines comerciales. 
