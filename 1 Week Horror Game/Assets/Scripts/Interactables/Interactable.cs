using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Hold,
        Minigame
    }

    [Tooltip("Ignore as there is only one type implemented")]
    public InteractionType interactionType;
    public abstract string GetDescription();

    public abstract void Interact();
}