using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private Canvas canvas;

    public void DragHandler(BaseEventData data)
    {
        if (canvas == null) canvas = GetComponentInParent<Canvas>();

        PointerEventData pointerData = data as PointerEventData;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}
