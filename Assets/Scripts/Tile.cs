using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string label;
    public int xPos;
    public int yPos;
    public int width;
    public int height;
    public Color color;

    public void OnBeginDrag()
    {
        Readable.Speak(this.label);
        Debug.Log("OnBeginDrag of a tile");
    }

    public Tile(string theLabel)
    {
        label = theLabel;
        // I had the constructor have int x, int y, int w, int h, 
        //GUI.Box(new Rect(70 + (horizontalOffset * 90), Screen.height / 3 + (verticalOffset * 40), 85, 30), label);
    }

    void Start()
    {
        label = "Spencer";
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