using Entitas;
using UnityEngine;

[Game]
public sealed class PositionComponent :IComponent
{
    public Vector2 value;
}

[Game]
public class DirectionComponent :IComponent
{
    public float value;
}

[Game]
public class ViewComponent :IComponent
{
    public GameObject go;
}

[Game]
public class SpriteComponent : IComponent
{
    public string name;
}

[Game]
public class MoverComponent :IComponent
{

}

[Game]
public class MoveComponent :IComponent
{
    public Vector2 pos;
}

[Game]
public class MoveCompleteComponent : IComponent
{

}
