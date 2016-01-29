using UnityEngine;

public class MainMenu : MonoBehaviour {

    public static string[] Users = {"Mr. Stark", "Mr. Rogers", "Mr. Banner", "Mr. Thor", "Mr. Romanoff", "Mr. Barton", "Mr. Coulson", "Mrs. Hill"};
    public static string currentUser;

    //void OnGUI()
    //{
    //    GUIStyle style = new GUIStyle();
    //    style.fontSize = 50;

    //    if (true)
    //    {
    //        GUI.Label(new Rect(Screen.width/2-50, Screen.height/2 - 100, 100, 60), "Story Builder", style);
    //    }

    //    int horizontalOffset = 0;
    //    int verticalOffset = 0;
    //    foreach (string user in Users)
    //    {
    //        if(Screen.width <= (horizontalOffset * 210) + 280)
    //        {
    //            verticalOffset++;
    //            horizontalOffset = 0;
    //        }
    //        if (GUI.Button(new Rect(70 + (horizontalOffset * 210), Screen.height / 2 + (verticalOffset * 70), 200, 60), user))
    //        {
    //            currentUser = user;
    //            Application.LoadLevel("main");
    //        }
    //        horizontalOffset++;
    //    }
    //}
           
}
