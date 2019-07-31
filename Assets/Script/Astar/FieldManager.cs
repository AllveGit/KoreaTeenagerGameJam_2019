using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    private Vector2 tileSize = new Vector2(1, 1);
    Vector2 tileSpriteSize = new Vector2(1, 1);

    [SerializeField]
    private SpriteRenderer backgroundSprite = null;


    public List<List<GameObject>> TileList { get; set; } = new List<List<GameObject>>();


    // Start is called before the first frame update
    void Awake()
    {
    }

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// 일반 타일을 배치합니다.
    /// </summary>
    /// <param name="pivot">기준점</param>
    /// <param name="size">헥사곤 크기</param>
    /// <param name="hexagonSpriteSize">헥사곤 스프라이트 크기</param>
    void PlaceTiles(Vector3 pivot, Vector2 size, Vector2 hexagonSpriteSize)
    {
        Vector2 firstPosition = Vector2.zero - (size * hexagonSpriteSize * 0.5f);
        Vector2 lastPosition = Vector2.zero + (size * hexagonSpriteSize * 0.5f);
        Vector2 spriteSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;

        int indexX = 0;
        for (float x = firstPosition.x; x <= lastPosition.x; x += spriteSize.x, indexX += 1)
        {
            TileList.Add(new List<GameObject>());

            int indexY = 0;

            for (float y = firstPosition.y; y <= lastPosition.y; y += spriteSize.y, indexY += 1)
            {
                GameObject tile = Instantiate(tilePrefab, transform);

                Vector3 tilePosition = new Vector3(x, y);

                tile.transform.position = tilePosition;

                TileList[indexX].Add(tile);
            }
        }
    }
    public void PlaceTiles()
    {
        tileSize = backgroundSprite.sprite.bounds.size;
        PlaceTiles(transform.position, tileSize, tileSpriteSize);
    }
}
