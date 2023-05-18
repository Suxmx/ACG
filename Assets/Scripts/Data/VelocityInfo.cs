using UnityEngine;

public class VelocityInfo
{
    public VelocityInfo(string name, Vector2 velocity, bool ifForce = false)
    {
        this.name = name;
        this.velocity = velocity;
        this.ifForce = ifForce;
    }

    public string name;
    public Vector2 velocity;
    public bool ifForce;

    public bool Compare(Vector2 rightValue, ValueOperator op, ValueAxis axis)
    {
        switch (axis)
        {
            case ValueAxis.XY:
                return ValueCheck(velocity.x, rightValue.x, op) && ValueCheck(velocity.y, rightValue.y, op);
            case ValueAxis.X:
                return ValueCheck(velocity.x, rightValue.x, op);
            case ValueAxis.Y:
                return ValueCheck(velocity.y, rightValue.y, op);
        }

        return true;
    }

    public bool Compare(float value, ValueOperator op, ValueAxis axis)
    {
        if (axis == ValueAxis.XY)
            Debug.LogError("在单值比较中输入双值比较操作符");
        if (axis == ValueAxis.X)
            return ValueCheck(velocity.x, value, op);
        else
            return ValueCheck(velocity.y, value, op);
    }

    static bool ValueCheck(float l, float r, ValueOperator op)
    {
        switch (op)
        {
            case ValueOperator.Equal:
                return Mathf.Abs(l - r) < 0.0001f;
            case ValueOperator.Greater:
                return l > r;
            case ValueOperator.Less:
                return l < r;
            case ValueOperator.AbsEqual:
                return Mathf.Abs(Mathf.Abs(l) - Mathf.Abs(r)) < 0.0001f;
            case ValueOperator.AbsGreater:
                return Mathf.Abs(l) > Mathf.Abs(r);
            case ValueOperator.AbsLess:
                return Mathf.Abs(l) < Mathf.Abs(r);
        }

        return true;
    }
}

public enum ValueOperator
{
    Less,
    Greater,
    Equal,
    AbsLess,
    AbsGreater,
    AbsEqual
}

public enum ValueAxis
{
    X,
    Y,
    XY
}