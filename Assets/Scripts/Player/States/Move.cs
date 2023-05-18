using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Move : State
{
    public Move(int enumIndex) : base(enumIndex)
    {
        
    }
    protected internal override void OnEnter(int enumIndex)
    {
        base.OnEnter(enumIndex);
    }

    public override void Update()
    {
    }
    protected internal override void OnExit(int enumIndex)
    {
        base.OnExit(enumIndex);
    }

    
}
