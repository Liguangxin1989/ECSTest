using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class EmitInputSystem : IExecuteSystem , IInitializeSystem
{
    readonly InputContext _context;
    private InputEntity _leftMouseEntity;
    private InputEntity _rightMouseEntity;

    public EmitInputSystem (Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        _context.isLeftMouse = true;
        _context.isRightMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;
        _rightMouseEntity = _context.rightMouseEntity;
    }

    public void Execute()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x ,Input.mousePosition.y ,10f));
        Debug.Log(" pos = " + pos + "     mousePos = " + Input.mousePosition) ;
        replacePosProcess(_leftMouseEntity, 0, pos);
        replacePosProcess(_rightMouseEntity, 1, pos);

    }


    void replacePosProcess (InputEntity entity , int buttonNum , Vector2 pos )
    {
        if (Input.GetMouseButtonDown(buttonNum))
            entity.ReplaceMouseDown(pos);
        if (Input.GetMouseButton(buttonNum))
            entity.ReplaceMousePosition(pos);
        if (Input.GetMouseButtonUp(buttonNum))
            entity.ReplaceMouseUp(pos);
    }
   
}
