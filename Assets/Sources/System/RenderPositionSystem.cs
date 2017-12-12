using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class RenderPositionSystem : ReactiveSystem<GameEntity>
{

    public RenderPositionSystem(Contexts contexts) : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.go.transform.position = entity.position.value;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }
}
