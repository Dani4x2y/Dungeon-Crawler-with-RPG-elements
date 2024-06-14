using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        // Debugging information
        Debug.Log("Current Position: " + transform.position);
        Debug.Log("Start Position: " + startPosition);
        Debug.Log("Start Parent: " + startParent);

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(transform.root);
        itemBeingDragged = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        // Debugging information
        Debug.Log("Delta: " + eventData.delta);
        Debug.Log("Anchored Position Before: " + rectTransform.anchoredPosition);

        rectTransform.anchoredPosition += eventData.delta;

        // Debugging information
        Debug.Log("Anchored Position After: " + rectTransform.anchoredPosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        // Debugging information
        Debug.Log("Item Being Dragged: " + itemBeingDragged);
        Debug.Log("Current Parent: " + transform.parent);
        Debug.Log("Start Parent: " + startParent);

        itemBeingDragged = null;

        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
