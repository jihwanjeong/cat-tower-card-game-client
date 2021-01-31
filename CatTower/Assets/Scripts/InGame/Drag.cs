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
        public static Sprite mySprite;

        public Image myImage;
        public int index;
        public static Breed br;

        public Slot mySlot;
        public GameObject gameObj;
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
                br = this.GetComponent<MyCard>().card.br;
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
            if(dragAble == false)
            {
                if (index < 8)
                {
                    if (gameObj.GetComponent<SlotManager>().arrSlotIndex[index] != 0)
                        return;
                    mySlot.myBr = br;
                    myImage.sprite = mySprite;
                    gameObj.GetComponent<SlotManager>().arrSlotIndex[index] = 1;
                    gameObj.GetComponent<SlotManager>().arrSlotBreed[index] = mySlot.myBr;
                }
                else
                {
                    if (gameObj.GetComponent<SlotManager>().arrSlotIndex[index-8] == 1 && gameObj.GetComponent<SlotManager>().arrSlotIndex[index-7] == 1 && (gameObj.GetComponent<SlotManager>().arrSlotBreed[index-8] == br || gameObj.GetComponent<SlotManager>().arrSlotBreed[index - 7] == br))
                    {
                        if (gameObj.GetComponent<SlotManager>().arrSlotIndex[index] != 0)
                            return;
                        mySlot.myBr = br;
                        myImage.sprite = mySprite;
                        gameObj.GetComponent<SlotManager>().arrSlotBreed[index] = mySlot.myBr;
                        gameObj.GetComponent<SlotManager>().arrSlotIndex[index] = 1;
                    }
                    else return;
                }
            }
            else
            { 
                return;
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
