using UnityEngine;
using UnityEngine.UI;

public class GameState
{
    public void Enter() { }
}
public class GameplayState : GameState
{   new public bool Enter()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Entered play state");
        return true;
    }
}
public class PauseState : GameState
{   new public bool Enter()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Entered pause state");
        return false;
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
                    isPlaying = pause.Enter();
                    textparent.SetActive(true);
                    break;
                case false:
                    
                    isPlaying = gameplay.Enter(); 
                    textparent.SetActive(false);
                    break;
            }
        }
    }
}



/* https://peerdh.com/blogs/programming-insights/implementing-finite-state-machines-in-c */