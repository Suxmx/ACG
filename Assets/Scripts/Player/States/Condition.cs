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
    public VelocityChecker(EState nextState, ValueOperator op, ValueAxis axis, Vector2 rightValue, VelocityInfo info) : base(nextState)
    {
        this.op = op;
        this.axis = axis;
        this.rightValue = rightValue;
        this.info = info;
        ifVector = true;
    }

    public VelocityChecker(EState nextState, ValueOperator op, ValueAxis axis, float rightValueF, VelocityInfo info) : base(nextState)
    {
        this.op = op;
        this.axis = axis;
        this.rightValueF = rightValueF;
        this.info = info;
        ifVector = false;
    }

    private ValueOperator op;
    private ValueAxis axis;
    private Vector2 rightValue;
    private float rightValueF;
    private VelocityInfo info;
    private bool ifVector;

    public override bool Excute()
    {
        if (ifVector)
            return info.Compare(rightValue, op, axis);
        else
            return info.Compare(rightValueF, op, axis);
    }
}