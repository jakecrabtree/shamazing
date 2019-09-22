using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AudioMixer audioMixer;

    
    [SerializeField] private string[] scenes;
    [SerializeField] private int lives = 3;
    private int _currentScene = 0;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel()
    {
        if (++_currentScene < scenes.Length)
        {
            SceneManager.LoadScene(scenes[_currentScene]);
        }
    }
}
