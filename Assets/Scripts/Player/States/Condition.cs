using UnityEngine;

public abstract class ICondition
{
    public ICondition(EState nextState)
    {
        this.nextState = nextState;
    }

    public EState nextState;
    public abstract bool Excute();
}

public class VelocityChecker : ICondition
{
    public VelocityChecker(EState nextState, ValueOperator op, ValueAxis axis, Vector2 rightValue, Rigidbody2D rigid) : base(nextState)
    {
        this.op = op;
        this.axis = axis;
        this.rightValue = rightValue;
        this.rigid = rigid;
        ifVector = true;
        info = new VelocityInfo("Checker", Vector2.zero);
    }

    public VelocityChecker(EState nextState, ValueOperator op, ValueAxis axis, float rightValueF, Rigidbody2D rigid) : base(nextState)
    {
        this.op = op;
        this.axis = axis;
        this.rightValueF = rightValueF;
        this.rigid = rigid;
        ifVector = false;
        info = new VelocityInfo("Checker", Vector2.zero);
    }

    private ValueOperator op;
    private ValueAxis axis;
    private Vector2 rightValue;
    private float rightValueF;
    private Rigidbody2D rigid;
    private VelocityInfo info;
    private bool ifVector;

    public override bool Excute()
    {
        info.velocity = rigid.velocity;
        
        if (ifVector)
            return info.Compare(rightValue, op, axis);
        else
            return info.Compare(rightValueF, op, axis);
    }
}

public class InputChecker : ICondition
{
    private InputEvent checkInput;
    private bool fullMatch;
    public InputChecker(EState nextState,InputEvent checkInput,bool fullMatch=false) : base(nextState)
    {
        this.checkInput = checkInput;
        this.fullMatch = fullMatch;
    }

    public override bool Excute()
    {
        if (InputData.HasEvent(checkInput, fullMatch))
            return true;
        else
        {
            return false;
        }
    }
}