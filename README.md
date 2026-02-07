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

## First-time setup (Git LFS)

Assets (audio, images, fonts, 3D models) are stored with **Git LFS**. After cloning, pull the real files:

```bash
# Install Git LFS once (macOS with Homebrew)
brew install git-lfs
git lfs install

# From the project root, pull LFS files
cd /path/to/FGJ26
git lfs pull
```

If you skip this, you'll see errors like **"Not a WAV file. File should start with 'RIFF', but found 'vers'"** because the repo will only have LFS pointer files instead of the actual assets.

## Run from the editor

1. Install **Godot 4.6 (.NET / C# build)**.
2. Open `project.godot` in Godot.
3. Press **Play**.

## Build for macOS

1. **Install export templates (one-time)**  
   In Godot: **Editor → Manage Export Templates**. Download and install the templates for **Godot 4.6 Mono**.

2. **Create an export preset**  
   - **Project → Export…**  
   - Click **Add…** → **macOS**.  
   - Leave defaults or set **Application/Name** and **Application/Icon** if you want.  
   - Under **Architectures**, enable **x86_64** and/or **arm64** (Apple Silicon).  
   - **Save** the preset (e.g. keep the name "macOS").

3. **Export the project**  
   - In the Export dialog, choose your **macOS** preset.  
   - Set **Export Path** to something like `Nukkumaski.app` or `build/Nukkumaski.app`.  
   - Click **Export Project**.  
   - Godot will produce a `.app` bundle you can run or distribute.

**Note:** Because the project uses **C#**, you must use the **Mono** (.NET) build of Godot and the **Mono** export templates. The standard (non-Mono) build will not export the game correctly.

## Project structure

- `Scenes/`: main scenes (e.g. `MainMenu.tscn`, `game_level.tscn`)
- `Prefabs/`: reusable scenes (e.g. `player.tscn`, `house.tscn`)
- `Scripts/`: C# gameplay code

## License

See `LICENSE`.

