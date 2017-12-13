using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MiddleMouseClickSystem : IExecuteSystem {

	readonly IGroup<GameEntity> _movers;
	public MiddleMouseClickSystem (Contexts contexts)
	{
		_movers = contexts.game.GetGroup(GameMatcher.Mover);
	}

	public void Execute()
	{
		if(Input.GetMouseButtonDown(2))
		{
			foreach (var entity in _movers)
			{
				entity.ReplaceSprite("mz-ui-blind");
			}
		}
	}

}
 