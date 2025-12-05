using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GameState;

public class GameState
{
    public enum StateENUM { GAMEPLAY, PAUSE }
    public StateENUM state = StateENUM.GAMEPLAY;
     public void PlayEnter()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Entered play state");
        state = StateENUM.GAMEPLAY;
    }
     public void PauseEnter()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Entered pause state");
        state = StateENUM.PAUSE;
    }
}
public class GameManager : MonoBehaviour
{
    public GameState game = new GameState();
    public GameObject player;
    public GameObject checkpoint;
    public GameObject Inventory_UI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void LateUpdate()
    {
        if (game.state == GameState.StateENUM.GAMEPLAY)
        {
            Inventory_UI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else  if (game.state == GameState.StateENUM.PAUSE)
        {
            Inventory_UI.SetActive(true); 
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Respawn()
    {
        if (game.state == GameState.StateENUM.GAMEPLAY)
        {
            player.transform.position = checkpoint.transform.position;
            Physics.SyncTransforms();
        }
    }

    public void Pause()
    {
        switch (game.state)
        {
            case GameState.StateENUM.GAMEPLAY:
                game.PauseEnter();
                break;
            case GameState.StateENUM.PAUSE:
                game.PlayEnter();
                break;
        }
    }
}



/* https://peerdh.com/blogs/programming-insights/implementing-finite-state-machines-in-c */