using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BJGames.JAT
{
    public class HairPiece : MonoBehaviour, IDropHandler
    {
        public HairTypes hairType;

        public void OnDrop(PointerEventData eventData)
        {
            Tool droppedTool = eventData.pointerDrag.GetComponent<Tool>();

            if (droppedTool == null)
            {
                Debug.Log("Dropped object was not a tool.");
                return;
            }

            if (hairType != droppedTool.hairTypeToCut)
            {
                Debug.Log(droppedTool.name + " not valid for this hair type (" + hairType + ").");
                return;
            }

            Debug.Log("Dropped correct tool, cutting hair!");
        }
    }
}