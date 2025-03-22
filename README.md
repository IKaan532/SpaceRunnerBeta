# Space-Themed Endless Runner Game

## Overview
This repository contains the script files for my first space-themed endless runner game. The game is still in development, and I will continue improving it by adding new ideas over time. The codebase follows design patterns such as **Observer**, **Command**, and **Prototype** to create a modular and maintainable structure.

## Script Descriptions

### 1. GameManager.cs
Manages the overall game state and event handling.
- Implements **Observer Pattern** to respond to game events.
- Handles game start and end events.
- Controls UI updates and game sound management.

### 2. UIManager.cs
Manages the user interface and interactions.
- Shows and hides start/end panels.
- Handles game restart and exit functions.
- Observes game events to update the UI accordingly.

### 3. GameEvents.cs
A static event manager that notifies observers when the game starts or ends.
- Implements **Observer Pattern**.
- Manages a list of observers and triggers their responses.
- Keeps track of whether the game has started or not.

### 4. AlienSpawner.cs
Handles the spawning of alien enemies at random positions.
- Uses the **Prototype Pattern** to clone alien instances instead of creating new ones.
- Spawns aliens at defined X positions at fixed intervals.
- Uses **OnDrawGizmosSelected** to visualize spawn points in the Unity editor.

### 5. AlienPrototype.cs
Defines the behavior of alien enemies.
- Implements **Prototype Pattern** with `Clone()` method.
- Moves forward and gets destroyed upon reaching a certain position.
- Rotates at the start to face the player.

### 6. PlayerController.cs
Manages player movement and interactions.
- Moves forward automatically and allows side movements using `A` and `D` keys.
- Uses **DOTween** for smooth lateral movement animations.
- Detects collisions with aliens or the finish line to trigger game over.

### 7. IObserver.cs
Defines an interface for the **Observer Pattern**.
- Provides `OnGameStart()` and `OnGameEnd()` methods for objects that need to react to game state changes.

### 8. ICommand.cs
Defines an interface for the **Command Pattern**.
- Provides an `Execute()` method that concrete command classes must implement.

### 9. ICloneable<T>.cs
Defines an interface for the **Prototype Pattern**.
- Provides a `Clone()` method for creating copies of objects.

### 10. GameStartCommand.cs
Handles the command to start the game.
- Implements the **Command Pattern**.
- Calls the `OnGameStart()` method on the `PlayerController` to start player movement and animations.

### 11. GameEndCommand.cs
Handles the command to end the game.
- Implements the **Command Pattern**.
- Calls `GameEnded()` in `GameManager` to trigger the end state and UI updates.

## Design Patterns Used
- **Observer Pattern**: Used for event-driven communication between game objects.
- **Command Pattern**: Encapsulates game start and end actions into command objects.
- **Prototype Pattern**: Efficiently clones alien objects instead of instantiating new ones.

## Future Plans
- Implement additional power-ups and obstacles.
- Improve AI behavior for aliens.
- Add more visual and sound effects.

---
This project is a work in progress, and I will continue refining it as new ideas emerge!

