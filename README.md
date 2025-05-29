# Drone Simulation Test Task
## Implemented:
- Saving, loading and resetting game settings  
	- Number of drones per faction: 1-5  
	- Drone speed (1-10)  
	- Resource generation frequency  
	- Enable/disable drone path rendering  
	- Enable/disable resource counters per faction  
- Configurable spawning of faction bases and drones  
- Configurable resource spawning  

## Architecture  
### Key Components:  
1. **DroneManager** - Manages bases and drones:  
	- Spawns bases at specified positions  
	- Spawns drones around bases according to settings  
	- Assigns factions  
  
2. **ResourceManager** - Manages resources:  
	- Spawns resources on a timer in free space  
	- Finds nearest available resources  
	- Manages resource pooling  
  
3. **SettingsManager** - Manages game settings:  
	- Stores game configuration  
	- Responds to parameter changes  
	- Resets to default values  

### Logic  
1. Initialization  
	- Configure parameters via UI  
	- Spawn bases and drones  
	- Start resource generation  

And that's it.

## Tech Stack  
- Engine: Unity 6000.0.29f1 LTS  
- DI framework: Zenject  
- Event-driven architecture  

## TODO  
- Drone behavior using Finite State Machine