using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //allows the dragging of items in the inventory
    private RectTransform rectTransform;
    [SerializeField] private GameObject inventory;
    private CanvasGroup canvasGroup;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / inventory.GetComponent<RectTransform>().lossyScale;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }
}
