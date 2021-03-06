//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public MouseUpComponent mouseUp { get { return (MouseUpComponent)GetComponent(InputComponentsLookup.MouseUp); } }
    public bool hasMouseUp { get { return HasComponent(InputComponentsLookup.MouseUp); } }

    public void AddMouseUp(UnityEngine.Vector2 newPostion) {
        var index = InputComponentsLookup.MouseUp;
        var component = CreateComponent<MouseUpComponent>(index);
        component.postion = newPostion;
        AddComponent(index, component);
    }

    public void ReplaceMouseUp(UnityEngine.Vector2 newPostion) {
        var index = InputComponentsLookup.MouseUp;
        var component = CreateComponent<MouseUpComponent>(index);
        component.postion = newPostion;
        ReplaceComponent(index, component);
    }

    public void RemoveMouseUp() {
        RemoveComponent(InputComponentsLookup.MouseUp);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherMouseUp;

    public static Entitas.IMatcher<InputEntity> MouseUp {
        get {
            if (_matcherMouseUp == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.MouseUp);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMouseUp = matcher;
            }

            return _matcherMouseUp;
        }
    }
}
