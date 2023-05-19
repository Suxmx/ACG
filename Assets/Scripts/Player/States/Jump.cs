using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Jump: PlayerState
{
    private bool hasPressJump;
    private bool leaveGround;
    private float jumpTimer;
    private float jumpSpeed = 5;
    public Jump(int enumIndex,Player player) : base(enumIndex,player)
    {
        
    }
    protected internal override void OnEnter(int enumIndex)
    {
        base.OnEnter(enumIndex);
        hasPressJump = true;
        leaveGround = false;
        jumpTimer = 0.3f;
        player.rigid.gravityScale = 0;
    }

    public override void Update(float deltaTime)
    {
        MovePart();
        JumpPart(deltaTime);
        base.Update(deltaTime);
    }

    private void JumpPart(float deltaTime)
    {
        if (hasPressJump)
        {
            
            if (InputData.HasEvent(InputEvent.Jump)&& jumpTimer>0)
            {
                jumpTimer = jumpTimer - deltaTime > 0 ? jumpTimer - deltaTime : 0;
                // player.rigid.velocity = new Vector2(0, jumpSpeed);
                Vector2 jump = new Vector2(0, jumpSpeed);
                player.AddVelocity(new VelocityInfo("Jump",jump));
            }
            else
            {
                hasPressJump = false;
                player.rigid.gravityScale = 1;
            }
            
        }

        if (player.isGround)
        {
            if (leaveGround)
            {
                stateMachine.StateIndex = (int)EState.Idle;
            }
        }
        else
        {
            leaveGround = true;
        }
    }

    private void MovePart()
    {
        Vector2 v = new Vector2(InputData.moveValue.velocity.x * player.config.velocity, 0);
        VelocityInfo info = new VelocityInfo("Input", v);
        player.AddVelocity("Input",info);
    }
    protected override void SetConditions()
    {
        conditions = new List<ICondition>()
        {
            //TODO 把Idle改成Fall
            new VelocityChecker(EState.Idle, ValueOperator.Less, ValueAxis.Y, 0)
        };
    }
}