using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TutorialSystems : Feature {
    
    public TutorialSystems (Contexts contexts) : base ("Tutorial System")
    {
        Add(new LogMouseClickSystem(contexts));
        Add(new HelloWorldSystem(contexts));
        Add(new DebugMessageSystem(contexts));
        Add(new CleanupDebugMessageSystem(contexts));

        Add(new EmitInputSystem(contexts));
        Add(new CreateMoverSystem(contexts));
        Add(new AddViewSystem(contexts));

        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));
        Add(new RenderDirectionSystem(contexts));

    }
}
