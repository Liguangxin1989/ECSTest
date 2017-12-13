using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class CommandMoveSystem : ReactiveSystem<InputEntity>
{
    readonly IGroup<GameEntity> _movers;

    public CommandMoveSystem (Contexts contexts) : base (contexts.input)
    {
        _movers = contexts.game.GetGroup(GameMatcher.Mover);
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity[] movers =  _movers.GetEntities();
            foreach (var mover in movers)
            {
                mover.ReplaceMove(entity.mouseDown.postion);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }
}
