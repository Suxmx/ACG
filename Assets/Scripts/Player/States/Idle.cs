using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Idle : PlayerState
{
    public Idle(int enumIndex,Player player) : base(enumIndex,player)
    {
        
    }
    protected override void SetConditions()
    {
        conditions = new List<ICondition>()
        {
            new VelocityChecker(EState.Move,ValueOperator.AbsGreater,ValueAxis.X,0.05f),
            new InputChecker(EState.Jump,InputEvent.Jump,false)
        };
    }
}
