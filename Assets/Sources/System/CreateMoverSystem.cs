using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class CreateMoverSystem : ReactiveSystem<InputEntity>
{

    readonly GameContext _context;

    public CreateMoverSystem (Contexts contexts) : base (contexts.input)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity  in entities)
        {
            GameEntity mover = _context.CreateEntity();
            mover.isMover = true;
            mover.AddPosition(entity.mouseDown.postion);
            mover.AddDirection(UnityEngine.Random.Range(0, 360));
            mover.AddSprite("mz-ui-blood");
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.MouseDown, InputMatcher.RightMouse));
    }
}
