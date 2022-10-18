using TbsFramework.Cells;
using UnityEngine;

public class Base : Square
{
    Vector3 dimensions = new Vector3(1.28f, 1.28f, 0f);

    public override Vector3 GetCellDimensions()
    {
        return dimensions;
    }
}
