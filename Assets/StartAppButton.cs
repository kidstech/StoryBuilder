using UnityEngine;
using System.Collections;

public class StartAppButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        Application.LoadLevel("main");
    }

}
