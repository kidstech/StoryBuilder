using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Tile : UnityEngine.UI.Image, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string label;

    public void OnBeginDrag()
    {
        Readable.Speak(this.label);
        Debug.Log("OnBeginDrag of a tile");
    }

    public Tile(string theLabel, float w, float h)
    {
        label = theLabel;
        // Still not sure what I'm doing here, but I'm trying to give the tile some dimensions and something on them... this is not quite there
        this.sprite = Sprite.Create(null, new Rect(200, 200, w, h), new Vector2(0,0));
    }

    override public string ToString()
    {
        return this.label;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

}