using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CleanupDebugMessageSystem : ICleanupSystem
{

    readonly GameContext _context;
    readonly IGroup<GameEntity> _debugMessages;

    public CleanupDebugMessageSystem(Contexts context)
    {
        _context = context.game;
        _debugMessages = _context.GetGroup(GameMatcher.DebugMessage);
    }


    void ICleanupSystem.Cleanup()
    {
        foreach (var entity in _debugMessages.GetEntities())
        {
            entity.Destroy();
        }
    }
}
