using TbsFramework.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleUnit : Unit
{
    public Color LeadingColor;
    public override void Initialize()
    {
        base.Initialize();
        GetComponentInChildren<Renderer>().material.color = LeadingColor;
    }

    public override void MarkAsFriendly()
    {
        GetComponentInChildren<Renderer>().material.color = new Color(0.8f, 1, 0.8f);
    }

    public override void MarkAsReachableEnemy()
    {
        GetComponentInChildren<Renderer>().material.color = Color.red;
    }

    public override void MarkAsSelected()
    {
        GetComponentInChildren<Renderer>().material.color = Color.green;
    }

    public override void MarkAsFinished()
    {
        GetComponentInChildren<Renderer>().material.color = Color.gray;
    }

    public override void UnMark()
    {
        GetComponentInChildren<Renderer>().material.color = LeadingColor;
    }
}
