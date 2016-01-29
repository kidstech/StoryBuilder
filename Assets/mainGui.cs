//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using System.Collections;
//using System.Collections.Generic;

//public class SampleButton : MonoBehaviour
//{

//    public Button button;
//    public Text nameLabel;
//    public Image icon;
//    public Text typeLabel;
//    public Text rarityLabel;
//    public GameObject championIcon;
//}

//public class mainGui : MonoBehaviour
//{
//    public GameObject sampleButton;
//    public List<string> wordList;

//    public Transform contentPanel;

//    void Start()
//    {
//        PopulateList();
//    }

//    void PopulateList()
//    {
//        for (int i = 0; i < 100; i++)
//        {
//            wordList.Add("cat");
//        }

//        foreach (var item in wordList)
//        {
//            GameObject newButton = Instantiate(sampleButton) as GameObject;
//            SampleButton button = newButton.GetComponent<SampleButton>();
//            button.nameLabel.text = item;
//            //button.button.onClick = item.thingToDo;
//            newButton.transform.SetParent(contentPanel);
//        }
//    }
//}
