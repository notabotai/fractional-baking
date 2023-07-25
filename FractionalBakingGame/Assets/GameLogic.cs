using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Vector3 dragStart;
    public GameObject knife;
    public LineRenderer sliceLine;
    
    // Update is called once per frame
    void Update()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        knife.transform.position = worldPosition;

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Pressed left click at " + Input.mousePosition);
            dragStart = worldPosition;
        }

        if (dragStart != Vector3.zero) {
            // draw a line from dragStart to worldPosition
            sliceLine.SetPositions(new Vector3[] { dragStart, worldPosition });
        }
    }
}
