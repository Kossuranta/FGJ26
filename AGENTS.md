# Agent Guidelines

> **Game Jam Project:** This is a game jam project. Prioritize fast, working solutions over long-term maintainability. Skip over-engineering, extensive abstractions, and premature optimization. Get things working quickly.

Before starting any work, read the [PLAN.md](./PLAN.md) file to understand the game design and mechanics.

## Technical Stack

- **Engine:** Godot 4.6
- **Runtime:** .NET 10
- **Language:** C# only (no GDScript)
- **Target Platform:** Windows PC (low-end hardware, keep performance lightweight)

## Code Standards

### General Rules

- Write all game logic in C#
- Never use GDScript for any functionality
- Follow C# naming conventions (PascalCase for public members, camelCase for private)
- Use Godot's C# API and patterns

### File Organization

- Place scene files (`.tscn`) in `Scenes/` or `Prefabs/` directories
- Place C# scripts in `Scripts/` directory
- Keep related scripts and scenes organized by feature when the project grows

### Godot-Specific

- Use `[Export]` attribute for exposing variables to the editor
- Inherit from appropriate Godot node types (`Node`, `Node2D`, `Node3D`, `CharacterBody2D`, etc.)
- Use signals for decoupled communication between nodes
- Prefer `GetNode<T>()` with proper null checks

## Agent Behavior

**Important:** When something is unclear or information is missing, always ask the developer clarifying questions before proceeding. Do not make assumptions about:

- Game mechanics that aren't documented
- Art style or visual requirements
- Sound/audio requirements
- Specific implementation details that could go multiple ways
