﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CatTower
{

    public class Slot : MonoBehaviour
    {
        
        public int index;
        public Breed myBr;
        public Card card;
        
        void Start()
        {
            InGameManagers mg = InGameManagers.GetInstance();            
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
