using UnityEngine;

public class GameState
{
    public void Enter() { }
}

public class GameplayState : GameState
{
    public void Enter()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Entered play state");
    }
}

public class PauseState : GameState
{
    public void Enter()
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
            if (isPlaying)
            {
                pause.Enter();
                isPlaying = false;
            }
            else if (!isPlaying)
            {
                gameplay.Enter();
                isPlaying = true;
            }
        }
    }
}



/* https://peerdh.com/blogs/programming-insights/implementing-finite-state-machines-in-c */