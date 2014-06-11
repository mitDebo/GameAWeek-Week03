using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject SelectedPlayer;

    InputManager inputManager;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        if (inputManager.MouseClick == InputManager.MOUSE_BUTTON_CLICK.RIGHT)
            SelectedPlayer.SendMessage("MoveTowards", inputManager.WorldClickPosition);
    }
}
