using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigs : MonoBehaviour
{
    public float velocity=5f;

    public void SetVelocity(float v)
    {
        this.velocity = v;
    }
}
