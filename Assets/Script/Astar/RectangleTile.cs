using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleTile : MonoBehaviour
{
    bool isWall = false;

    public bool IsWall { get => isWall; set => isWall = value; }

    private SpriteRenderer spRenderer = null;

    [SerializeField]
    private float tileSize = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();

        Vector2 size = spRenderer.bounds.size * tileSize;
        Vector3 target = transform.position - new Vector3(size.x, size.y, 0);
        isWall = IsTileWall(new Vector2(target.x, target.y));
        if (isWall == true) return;
        isWall = IsTileWall(new Vector2(target.x + size.x, target.y));
        if (isWall == true) return;
        isWall = IsTileWall(new Vector2(target.x, target.y + size.y));
        if (isWall == true) return;
        isWall = IsTileWall(new Vector2(target.x + size.x, target.y + size.y));
        if (isWall == true) return;
        isWall = IsTileWall(new Vector2(target.x + size.x * 0.5f, target.y + size.y * 0.5f));
        if (isWall == true) return;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWall)
            spRenderer.color = new Color(1, 0, 0, 0.5f);
    }

    bool IsTileWall(Vector2 target)
    {
        Ray2D ray2D = new Ray2D(target, Vector2.zero);
        RaycastHit2D[] hit = Physics2D.RaycastAll(ray2D.origin, ray2D.direction);

        int length = hit.Length;
        for (int i = 0; i < length; i++)
        {
            if (hit[i].collider != null && hit[i].collider.tag.Equals("Wall"))
            {
                return true;
            }
        }
        return false;
    }
}
