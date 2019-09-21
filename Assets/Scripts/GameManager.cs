using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private string[] scenes;
    [SerializeField] private string deathScene;
    [SerializeField] private int lives = 3;
    private int _currentScene = 0;
    
    private void Awake()
    {
        if (Instance != null || Instance != this)
        {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(deathScene);
    }

    public void NextLevel()
    {
        if (++_currentScene < scenes.Length)
        {
            SceneManager.LoadScene(scenes[_currentScene]);
        }
    }
}
