using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatTower {
    public class Card : MonoBehaviour
    {
        public  Breed br;
        public Image catImage;
        public bool special;
        public enum Breed
        {
            Siamese,
            RussianBlue,
            Mackerel,
            Persian,
            Ragdoll,
            Savanna,
            ThreeColor,
            Odd
        } 
    }
}
