# Tower Of Colors - Senior Unity Game Dev - Case Study

#1. Implement two optimizations on the project. Even though the project runs
smoothly, make two classic optimizations.

● One Unity UI assets optimization. (Optimize Draw Calls)

- I have used a texture atlas to join all the UI textures in the same texture, so we can draw them in the same draw call.
- I have used the Frame Debug and the Profiler to see how I could reorder the Hierarchy to achive even less draw calls.
- I have untoggled the Raycast Target from where it wasn't needed to improve the performance.
- I have added a 2x2 pixels white texture in the atlas to be used instead of the Unity's default texture (which was drawn in a separate draw call).
- I have updated the fill-circle to be sliced and be re-used for squared images with rounded corners.
- I have turned off some texts behind textures to achieve less draw calls.

● Add a pooling system for the barrels

- I have reused the already existing FXPool to be a more generic ComponentPool using Generics. This way we reuse the current system without adding a new one.


#2. We would like to add missions to the game in order to improve the retention of our
players

- I have used ScriptableObjects to manage all the configurations and types (more robust, scalable and unity friendly than enums).
- I have used an event system to notify about the game events to decouple the specific implementation of each mission logic.
- I have used a mission factory to create missions from ScriptableObjects (configuration). In that way we separate the creation from the logic keeping the creation in another layer of abstraction.
- I have made the optional part of having different difficulties for the missions.

- Overall, I have tried to keep the project architecture as it is avoiding any big impact to the codebase.