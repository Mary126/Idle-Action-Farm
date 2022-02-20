using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTracker : MonoBehaviour
{
    private bool touchStart = false;
    private Vector2 joystickSpawnPoint;
    private Vector2 joystickHandlePoint;
    public Vector3 playerMovement;
    public bool playerMoving;

    public Camera cam;
    public GameObject controllCanvas;
    public GameObject joystickHandle;
    public GameObject joystickOuter;

    private GameObject jHandle;
    private GameObject jOuter;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(controllCanvas.transform as RectTransform, Input.mousePosition, cam, out joystickSpawnPoint);
            jHandle = Instantiate(joystickHandle);
            jHandle.transform.SetParent(controllCanvas.transform);
            jOuter = Instantiate(joystickOuter);
            jOuter.transform.SetParent(controllCanvas.transform);
            jHandle.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 110);
            jOuter.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
            jOuter.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            jHandle.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            jOuter.transform.position = controllCanvas.transform.TransformPoint(joystickSpawnPoint);
            jHandle.transform.position = controllCanvas.transform.TransformPoint(joystickSpawnPoint);
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(controllCanvas.transform as RectTransform, Input.mousePosition, cam, out joystickHandlePoint);
            playerMoving = true;
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = joystickHandlePoint - joystickSpawnPoint;
            Vector2 direction = Vector2.ClampMagnitude(offset, 10.0f);
            playerMovement = new Vector3(direction.x, 0, direction.y);
            Vector2 newPos = new Vector2(joystickSpawnPoint.x + direction.x, joystickSpawnPoint.y + direction.y);
            jHandle.transform.position = controllCanvas.transform.TransformPoint(newPos);
        }
        else
        {
            Destroy(jHandle);
            Destroy(jOuter);
            playerMoving = false;
        }

    }
}
