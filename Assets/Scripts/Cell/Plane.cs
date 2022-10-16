using TbsFramework.Cells;
using UnityEngine;

public class Plane : Hexagon
{
    Vector3 dimensions = new Vector3(2.6f, 2.56f, 0f);

    public override Vector3 GetCellDimensions()
    {
        return dimensions;
    }
}
