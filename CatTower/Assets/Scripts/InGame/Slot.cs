using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTower
{

    public class Slot : MonoBehaviour, IDropHandler
    {
        public int index;
        public Card.Breed br;
        // Start is called before the first frame update
        void Start()
        {
            Managers mg = Managers.GetInstance();            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDrop(PointerEventData eventData)
        {
            
        }
    }
}
