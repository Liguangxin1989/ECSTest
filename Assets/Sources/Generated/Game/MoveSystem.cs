using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class MoveSystem : IExecuteSystem  , ICleanupSystem{

    readonly IGroup<GameEntity> _movers;
    readonly IGroup<GameEntity> _moveCompletes;

    const float _speed = 4;

    public MoveSystem (Contexts contexts)
    {
        _movers = contexts.game.GetGroup(GameMatcher.AllOf ( GameMatcher.Mover ,GameMatcher.Move));
        _moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
    }

    public void Execute()
    {
        foreach (GameEntity entity in _movers.GetEntities())
        {
            //if (!entity.hasMove)
            //    continue;
            Vector2 dir = (entity.move.pos - entity.position.value)/*.normalized*/;

            Vector2 newPos = entity.position.value + dir * _speed * Time.deltaTime;

            entity.ReplacePosition(newPos);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            entity.ReplaceDirection(angle);

            float dist = (entity.move.pos - newPos).magnitude;
            if (dist < 0.1)
            {
                entity.RemoveMove();
                entity.isMoveComplete = true;
            }
        }
    }

    public void Cleanup()
    {
        foreach (var entity in _moveCompletes.GetEntities())
        {
            entity.isMoveComplete = false;
        }
    }
}
