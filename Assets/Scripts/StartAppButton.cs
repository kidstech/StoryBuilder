using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartAppButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("main");
    }

}
