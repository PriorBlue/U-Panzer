using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    public Texture2D Map;
    public GameObject Tile;
    public List<TileSetting> TileSettings;

    [System.Serializable]
    public struct TileSetting
    {
        public Color Color;
        public Sprite Sprite;
        public bool Collision;
    }

    // Use this for initialization
    void Start()
    {
        for(var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (var i = 0; i < Map.height; i++)
        {
            for (var k = 0; k < Map.width; k++)
            {
                var tile = Instantiate(Tile, transform);
                tile.transform.position = new Vector3(k, i, 0f);

                var color = Map.GetPixel(k, i);
                var conf = TileSettings.FirstOrDefault(it => it.Color.r == color.r && it.Color.g == color.g && it.Color.b == color.b);

                tile.GetComponent<SpriteRenderer>().sprite = conf.Sprite;
            }
        }

        transform.position = new Vector3((Map.width - 1) * -0.5f, (Map.height - 3) * -0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
