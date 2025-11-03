using UnityEngine;
using UnityEngine.UI;

public class GameState
{
    public void Enter() { }
}
public class GameplayState : GameState
{   new public void Enter()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Entered play state");
    }
}
public class PauseState : GameState
{   new public void Enter()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Entered pause state");
    }
}
public class GameManagerCLASS : MonoBehaviour
{
    private PauseState pause = new PauseState();
    private GameplayState gameplay = new GameplayState();
    public bool isPlaying;
    public GameObject textparent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (isPlaying)
            {
                case true:
                    pause.Enter();
                    isPlaying = false;
                    Debug.Log("paused");
                    textparent.SetActive(true);
                    break;
                case false:
                    gameplay.Enter();
                    isPlaying = true;
                    Debug.Log("played");
                    textparent.SetActive(false);
                    break;
            }
        }
    }
}



/* https://peerdh.com/blogs/programming-insights/implementing-finite-state-machines-in-c */