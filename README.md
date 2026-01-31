# Nukkumaski

Game jam prototype made with **Godot 4.6** + **C# (.NET)**.

You play as a **house elf** trying to keep the homeowner asleep (and alive) while a malfunctioning smart-home AI causes problems throughout the night.

## Gameplay

- **Goal**: Keep the homeowner asleep as long as possible.
- **How**: React to events and apply the correct mask to counter them.
- **Scoring**: Points accumulate while the person is asleep (deeper sleep = faster points).

## Events & masks (design)

The current design includes events like heater/lights/vacuum merchant/teams call/water leak/gas leak/CPAP failure/electrical malfunction, each countered by a specific mask.

Full design doc: `PLAN.md`.

## Controls

- **Move**: WASD (bound via Input Map actions: `move_forward`, `move_back`, `move_left`, `move_right`)

## Run locally

### Run from the editor

1. Install **Godot 4.6 (.NET / C# build)**.
2. Open `project.godot` in Godot.
3. Press **Play**.

### Build a Windows executable

1. In Godot, install export templates: `Editor → Manage Export Templates…`
2. Open `Project → Export…`
3. Add preset: `Windows Desktop`
4. Set an export path (example: `build/Nukkumaski.exe`)
5. Click **Export Project** (or **Export All**)

This produces an `.exe` plus a `.pck` (and possibly additional files). Run the `.exe` from the exported folder.

## Project structure

- `Scenes/`: main scenes (e.g. `MainMenu.tscn`, `game_level.tscn`)
- `Prefabs/`: reusable scenes (e.g. `player.tscn`, `house.tscn`)
- `Scripts/`: C# gameplay code

## License

See `LICENSE`.

