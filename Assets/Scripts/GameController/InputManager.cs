using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    public Vector3 WorldClickPosition;

    public enum MOUSE_BUTTON_CLICK { NONE, LEFT, RIGHT }
    
    private MOUSE_BUTTON_CLICK mouseClickThisFrame;
    public MOUSE_BUTTON_CLICK MouseClick
    {
        get { return mouseClickThisFrame; }
    }

    Plane groundPlane;

    void Start()
    {
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        mouseClickThisFrame = MOUSE_BUTTON_CLICK.NONE;
        if (Input.GetMouseButtonDown(0))
            HandleLeftClick();
        if (Input.GetMouseButtonDown(1))
            HandleRightClick();
    }

    void HandleLeftClick()
    {
        WorldClickPosition = GetMouseClickPositionInWorldCoords();
        mouseClickThisFrame = MOUSE_BUTTON_CLICK.LEFT;
    }

    void HandleRightClick()
    {
        WorldClickPosition = GetMouseClickPositionInWorldCoords();
        mouseClickThisFrame = MOUSE_BUTTON_CLICK.RIGHT;
    }

    Vector3 GetMouseClickPositionInWorldCoords()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
            return ray.GetPoint(rayDistance);
        
        return new Vector3(0f, -1f, 0f);
    }
}
