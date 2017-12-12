using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class RenderDirectionSystem : ReactiveSystem<GameEntity> {


    public RenderDirectionSystem (Contexts contexts): base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity  in entities)
        {
            entity.view.go.transform.rotation = Quaternion.AngleAxis(entity.direction.value - 90, Vector3.forward);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDirection && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Direction);
    }
}
