using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Utils
{
    public static class Inputs
    {
        public static bool IsMouseOverGameObject(Transform transform)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.transform == transform)
                {
                    return true;
                }
            }
            return false;
        }
        public static Vector2 PointerPosToCanvasPos(RectTransform canvas, Vector2 pointerPos)
        {
            Vector2 clickedPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pointerPos, Camera.main, out clickedPos);
            return clickedPos;
        }
        public static bool IsMouseOverUI(RectTransform UITransform)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResultList = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
            foreach (var raycast in raycastResultList)
            {
                if (raycast.gameObject.GetComponent<RectTransform>() == UITransform)
                    return true;
            }
            return false;
        }
        public static List<RectTransform> GetUIsUnderMouse()
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResultList = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

            List<RectTransform> uiList = new List<RectTransform>();
            foreach (var raycast in raycastResultList)
            {
                RectTransform rt = raycast.gameObject.GetComponent<RectTransform>();
                if (rt != null)
                    uiList.Add(rt);
            }
            return uiList;
        }
    }
}
