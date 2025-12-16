using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    private string sceneName;
    [SerializeField] private PlayerBehavior player;
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button)
        {
            sceneName = "NavMeshScene";
            button.onClick.AddListener(SwitchScene);
        }        
    }

    void Update()
    {
        if (player.isDead)
        {
            sceneName = "GameOver";        
            SwitchScene();
        }

        if (sceneName == "NavMeshScene" && player.transform.position.y <=-200 )
        {
            sceneName = "GoodEndScene";
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
