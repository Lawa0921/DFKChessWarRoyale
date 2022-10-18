using TbsFramework.Cells;
using UnityEngine;
using UnityEngine.EventSystems;

public class Base : Square
{
    public string TileType;
    Vector3 dimensions = new Vector3(1.28f, 1.28f, 0f);

    public override Vector3 GetCellDimensions()
    {
        return dimensions;
    }

    protected override void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            base.OnMouseDown();
        }
    }

    protected override void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            base.OnMouseEnter();
        }
    }

    protected override void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            base.OnMouseExit();
        }
    }


    public override void SetColor(Color color)
    {
        var highlighter = transform.Find("marker");
        var spriteRenderer = highlighter.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}
