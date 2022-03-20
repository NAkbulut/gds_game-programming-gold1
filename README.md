# State Machine

This is the first gold achievements for the Game Programming class in THUAS'
Game Development & Simulation minor.

## Instructions

Implement a state machine without using existing solutions for it.

### Application Requirements

- the player should be able to control an object and change its state
- the controls should always be visible on screen
- the controllable object must be a prefab
- at least 4 different states with unique aspects should be implemented
- at least one state must be reliant to another state
- the object should always be in-frame
- movements should be framerate-independent

### Submission Requirements

- submit the Unity project, including all code and assets
- submit a working build in addition to a web-build
- submit a state diagram depicting the different states for the object
- submit a text document containing a description of each state

## Result

### States

The implementation of the State Machine exists out of four different states, each with their own transitions into other states, and some with an exclusive transition to a reliant state.

Every state inherits from the `IState` interface, which includes abstract methods for the entry of a state, the actions of a state including its state transitions, and the exit of a state. The entry of a state is run before the first frame update, and used to prepare the state object for its actions. The actions of a state include both its update- and fixedupdate method. The state transitions define triggers for state transitions, such as the player giving input to jump while in the driving state. Finally, the exit method is run on the last frame of a state, before the state transitions. This method would be used to clean-up the state object, so we can use this object again at a later time.

The default state is `Driving`. Driving allows the player to input both acceleration and steering controls, in order for them to move the vehicle. These controls are also available in some other states, through the use of a static function within the `Driving` state. Even when the vehicle is not moving, the state would still be `Driving`, as it is the default state. From this state, the state may transition to `Spasming` or `Jumping`.

The `Spasming` state allows the player to trigger a spasm in the vehicle. When triggered, a relatively high amount of force is added to the Z-axis of the rigidbody component from the vehicle object. After this trigger, the vehicle becomes incontrollable and will stop moving until the player returns to the `Driving` state. The `Spasming` state is considered a toggle-state, which means the state transition back to `Driving` is not automatic, and has to be requested by the player through a toggle.

The `Jumping` state allows the player to make the vehicle go up in the air. When triggered, a balanced amount of force is added to the Y-axis of the rigidbody component from the vehicle object. After this trigger, the vehicle performs a jump. From this state, the state may be transitioned to `DoubleJumping` by performing another jump before a collission event has occured. When this collission event has occured, the state will transition back to default; `Driving`.

The `DoubleJumping` state allows the player to make the vehicle go up in the air another time, or soften its fall, dependent on when the state is triggered. When triggered, the balanced amount of force added by the `Jumping` state is added once more to the Y-axis of the rigidbody component form the vehicle object. The added force is a fixed amount, meaning that the sooner this state is triggered after the `Jumping` state, the more velocity the vehicle ends up with, and vice-versa. When a collission event has occured, the state will transition back to default; `Driving`.

### Diagrams

These diagrams prove a certain mastery within the concept of design patterns, and the implementation of various topics such as state machines.
<div align="center">
  <img width=600 src="Artifacts/Images/UML Diagram.png" alt="UML Diagram"/>
  <p align="center"><i>UML Diagram for the ConcreteStates namespace and its IState interface</i></p>
</div>

<div align="center">
  <img width=600 src="Artifacts/Images/State Diagram.png" alt="State Diagram"/>
  <p align="center"><i>State Diagram for the different states and state transitions</i></p>
</div>

## Credits

This project is the work of [Nehir Akbulut](https://github.com/neehier),
and the Game Programming class was given by Mathijs Koning.
