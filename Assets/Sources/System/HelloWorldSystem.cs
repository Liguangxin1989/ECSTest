using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
//using System;

public class HelloWorldSystem : IInitializeSystem
{
    readonly GameContext _context;

    public HelloWorldSystem(Contexts context)
    {
        _context = context.game;
    }

    public void Initialize()
    {
        _context.CreateEntity().AddDebugMessage("Hello World!");
    }
}
