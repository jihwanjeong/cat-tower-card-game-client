using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatTower
{
    public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {

        public static Vector2 defaultposition;
        public Image myImage;
        public static Sprite mySprite;
        public bool dragAble;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (dragAble == false)
            {
                return;
            }
            else
            {
                defaultposition = this.transform.position;
                mySprite = this.GetComponent<MyCard>().card.catImage;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (dragAble == false)
            {
                return;
            }
            else
            {
                Vector2 currentPos = Input.mousePosition;
                this.transform.position = currentPos;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if(dragAble == true)
            {
                return;
            }
            else
            {
                myImage.sprite = mySprite;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (dragAble == false)
            {
                return;
            }
            else
            {
                this.transform.position = defaultposition;
            }
        }
    }
}
