# Nukkumaski - Game Design Document

## Concept

A game where the player controls a house elf trying to help keep the house owner asleep and alive throughout the night.

## Setting

The game takes place in a smart home controlled by an AI. The AI causes various problematic events during the night that threaten to wake or harm the sleeping house owner.

## Core Gameplay

### Objective

Keep the house owner asleep as long as possible by applying the correct masks to counter various events caused by the malfunctioning smart home AI.

### Win / Fail States

- The game ends when the house owner wakes up (**fail state**).
- The game ends when the night ends (**win state**).

### Player Character

- House elf that can move around the house
- Can pick up and apply masks to the sleeping house owner
- Must react quickly to events

### Sleep Meter

- Progress bar showing how deeply the person is sleeping
- During events, the meter starts to drain
- If it empties completely, the person wakes up (game ends)

### Scoring System

- Player earns points constantly while the person is asleep
- Deeper sleep = faster point accumulation
- If the person wakes up, the game ends and scoring stops

## Events and Masks

| Event | Description | Required Mask |
|-------|-------------|---------------|
| **Heater Malfunction** | Temperature starts rising in the house | Cooling mask (from fridge) |
| **Lights Go On** | Room becomes too bright | Sleep mask |
| **Vacuum Cleaner Merchant** | Salesperson knocks on bedroom window trying to sell vacuum cleaner | Scary mask (scares merchant away) |
| **Teams Call from Boss** | Work call comes in | Glasses with open eyes painted on them (makes person seem awake) |
| **Water Leak** | House starts to fill with water | Snorkel mask (prevents drowning) |
| **Gas Leak** | Gas stove turns on, filling house with gas | Gas mask |
| **CPAP Failure** | Person starts to suffocate | CPAP mask |
| **Electric Malfunction** | Electric device starts throwing sparks | Welding mask |

## Level Design

- Single house level (house owner's home)
- Bedroom where the house owner sleeps
- Various rooms where masks are stored
- Events can occur in different parts of the house

## Smart Home AI

- Acts as the antagonist
- Causes the various events throughout the night
- Escalates difficulty over time (more frequent/overlapping events)
