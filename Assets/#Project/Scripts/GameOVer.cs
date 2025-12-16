using Unity.VisualScripting;
using UnityEngine;

public class GameOVer : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit game");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
