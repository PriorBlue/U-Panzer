using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    public Texture2D Map;
    public GameObject Tile;
    public List<TileSetting> TileSettings;
    public float UnitSize = 1f;

    [System.Serializable]
    public struct TileSetting
    {
        public Color Color;
        public Sprite Sprite;
        public bool Collision;
        public GameObject Obstacle;
        public bool Visible;
    }

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
                tile.transform.position = new Vector3(k * UnitSize, i * UnitSize, 0f);
                tile.transform.localScale = new Vector3(UnitSize, UnitSize, UnitSize);

                var color = Map.GetPixel(k, i);
                var conf = TileSettings.FirstOrDefault(it => it.Color == color);

                tile.GetComponent<SpriteRenderer>().sprite = conf.Sprite;

                if(conf.Obstacle != null)
                {
                    var obstacle = Instantiate(conf.Obstacle, tile.transform);
                    obstacle.transform.localPosition = Vector3.zero;
                }

                if(conf.Visible == false)
                {
                    tile.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
                }
            }
        }

        transform.position = new Vector3((Map.width * UnitSize - 1) * -0.5f, (Map.height * UnitSize - 3) * -0.5f, 0f);
    }
}
