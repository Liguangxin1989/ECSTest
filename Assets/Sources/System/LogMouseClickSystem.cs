using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class LogMouseClickSystem : IExecuteSystem
{

    readonly GameContext _context;
    public LogMouseClickSystem(Contexts context)
    {
        _context = context.game;
    }

    public void Execute()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _context.CreateEntity().AddDebugMessage("Left Mouse Btn Down");
        }
        
        if(Input.GetMouseButtonDown(1))
        {
            _context.CreateEntity().AddDebugMessage("Rght Mouse Btn Down");
        }
    }
}
