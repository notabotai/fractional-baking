using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour {
    public Vector2 dragStart;
    public Vector2 dragEnd;
    public LineRenderer lineRenderer;
    public SpriteRenderer cakeOverlay;
    public SpriteRenderer cakeBase;
    public Text ratioText;
    public void Update() {
        // convert mouse position to world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // set z to 0
        mousePosition.z = 0;
        
        if (Input.GetMouseButtonDown(0)) {
            // set drag start position
            dragStart = mousePosition;
        }
        if (Input.GetMouseButton(0)) {
            mousePosition.x = dragStart.x;
            // draw a line from dragStart to mousePosition using linerenderer
            lineRenderer.SetPositions(new Vector3[] { dragStart, mousePosition });
        }
        if (Input.GetMouseButtonUp(0)) {
            dragEnd = mousePosition;
            // calculate ratio of knife's current position to cake's width
            float ratio = (dragEnd.x + cakeBase.bounds.size.x / 2) / cakeBase.bounds.size.x;
            // set cake's fill amount to ratio
            Debug.Log("ratio: " + ratio);
            Debug.Log("cake width: " + cakeBase.bounds.size.x);
            Debug.Log("cake position: " + cakeBase.transform.position.x);
            Debug.Log("knife position: " + dragEnd.x);
            cakeOverlay.transform.localScale = new Vector3(ratio, 1, 0);
            cakeOverlay.transform.localPosition = new Vector3(-0.5f + ratio / 2, cakeOverlay.transform.position.y, 0);

            ratioText.text = (ratio * 100).ToString("0.00") + "%";
        }
        // set knife position to mouse position
        transform.position = mousePosition;
        // Debug.Log(mousePosition);

    }
}