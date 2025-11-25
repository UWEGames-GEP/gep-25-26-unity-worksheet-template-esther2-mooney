using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCharacterController : ThirdPersonController
{
    public GameObject ParentManager;
    private GameManager gameManager; 
    private void OnPause(InputValue value)
    {
        gameManager = ParentManager.GetComponent<GameManager>();
        if (value.isPressed)
        {
            gameManager.Pause();
        }
    }

    private void OnRespawn(InputValue value)
    {
        gameManager = ParentManager.GetComponent<GameManager>();
        if (value.isPressed)
        {
            gameManager.Respawn();
        }
    }

    private void OnRemoveItem()
    {
       GetComponent<Inventory>().RemoveItem();
    }

}
