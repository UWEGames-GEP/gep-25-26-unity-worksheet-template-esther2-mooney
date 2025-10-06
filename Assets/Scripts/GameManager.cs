using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        GAMEPLAY,
        PAUSE
    }
    GameState State;
    bool hasChangedState;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        State = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (State)
            {
                case GameState.GAMEPLAY:
                    State = GameState.PAUSE;
                    hasChangedState = true;
                    Debug.Log("paused");
                    break;
                case GameState.PAUSE:
                    State = GameState.GAMEPLAY;
                    hasChangedState = true;
                    Debug.Log("played");
                    break;
            }

        }
            /* ORIGINAL IF ELSE CODE
            if (State == GameState.GAMEPLAY)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    State = GameState.PAUSE;
                    hasChangedState = true;
                    Debug.Log("paused");
                }
            }
            else if (State == GameState.PAUSE)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    State = GameState.GAMEPLAY;
                    hasChangedState = true;
                    Debug.Log("played");
                }
            }
            */
    }

        

    void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;
            if (State == GameState.GAMEPLAY)
            {
                Time.timeScale = 1.0f;
            }
            else if (State == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
            }
        }
    }
    
}
