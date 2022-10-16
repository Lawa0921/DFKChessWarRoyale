using TbsFramework.Cells;
using UnityEngine;

public class Plane : Hexagon
{
    public override Vector3 GetCellDimensions()
    {
        return new Vector3(2.56f, 2.61f, 0f);
    }
}
