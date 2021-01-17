using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTower
{
    public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {

        public static Vector2 defaultposition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            defaultposition = this.transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
        }

        public void OnDrop(PointerEventData eventData)
        {

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.position = defaultposition;
        }
    }
}
