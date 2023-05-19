using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Move : PlayerState
{
    private float originScale;
    public Move(int enumIndex,Player player) : base(enumIndex,player)
    {
        originScale = player.trans.localScale.x;
    }
    protected internal override void OnEnter(int enumIndex)
    {
        base.OnEnter(enumIndex);
    }

    public override void Update(float deltaTime)
    {
        
        
        // Vector2 v = new Vector2(InputData.moveValue.velocity.x * player.config.velocity, 0);
        // v.y = player.rigid.velocity.y;
        // player.rigid.velocity = v;
        base.Update(deltaTime);
        Vector2 v = new Vector2(InputData.moveValue.velocity.x * player.config.velocity, 0);
        VelocityInfo info = new VelocityInfo("Input", v);
        player.AddVelocity("Input",info);
    }

    protected override void SetConditions()
    {
        conditions = new List<ICondition>()
        {
            new VelocityChecker(EState.Idle,ValueOperator.AbsLess,ValueAxis.X,0.05f),
            new InputChecker(EState.Jump,InputEvent.Jump,false)
        };
    }

    protected internal override void OnExit(int enumIndex)
    {
        base.OnExit(enumIndex);
    }

    

    
}
