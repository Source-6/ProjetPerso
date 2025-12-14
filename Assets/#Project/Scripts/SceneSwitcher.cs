using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private PlayerBehavior player;
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button)
        {
            button.onClick.AddListener(SwitchScene);
        }        
    }

    void Update()
    {
        if (player.isDead)
        {
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
