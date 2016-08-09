using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string label;
    //public GUIText text;
    public float width;
    public float height;

    public static float TILE_WIDTH = 350;
    public static float TILE_HEIGHT = 150;

    public void OnBeginDrag()
    {
        Readable.Speak(this.label);
        Debug.Log("OnBeginDrag of a tile");
    }

 
    public static Tile Create(string theLabel)
    {
        Object prefabTile = Resources.Load("BlueTile");
        GameObject newtile = Instantiate(prefabTile) as GameObject;
        Tile tile = newtile.GetComponent<Tile>();
        newtile.transform.GetChild(1).GetComponent<Text>().text = theLabel;
        //newtile.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(TILE_WIDTH, TILE_HEIGHT);
        tile.label = theLabel;
        tile.width = TILE_WIDTH;
        tile.height = TILE_HEIGHT;
       

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