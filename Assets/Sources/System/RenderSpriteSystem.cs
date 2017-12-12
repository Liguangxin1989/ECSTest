using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class RenderSpriteSystem : ReactiveSystem<GameEntity> {


    public RenderSpriteSystem (Contexts contexts ) : base (contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameObject go = entity.view.go;
            SpriteRenderer spRenderer = go.GetComponent<SpriteRenderer>();
            if(!spRenderer)
            {
                spRenderer = go.AddComponent<SpriteRenderer>();
            }
            spRenderer.sprite = Resources.Load<Sprite>(entity.sprite.name);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }
}
