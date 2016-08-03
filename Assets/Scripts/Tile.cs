using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string label;
    //public GUIText text;
    public float width;
    public float height;

    public static float TILE_WIDTH = 150;
    public static float TILE_HEIGHT = 50;

    public void OnBeginDrag()
    {
        Readable.Speak(this.label);
        Debug.Log("OnBeginDrag of a tile");
    }

    public static Object prefabTile = Resources.Load("BlueTile");
    public static Tile Create(string theLabel)
    {
        GameObject newtile = Instantiate(prefabTile) as GameObject;
        Tile tile = newtile.GetComponent<Tile>();
        tile.label = theLabel;
        tile.width = TILE_WIDTH;
        tile.height = TILE_HEIGHT;

        // Still not sure what I'm doing here, but I'm trying to give the tile some dimensions and something on them... this is not quite there
        return tile;
    }

    override public string ToString()
    {
        return this.label;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Readable.Speak(this.label);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

}