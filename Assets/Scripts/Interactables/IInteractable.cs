using System;
using UnityEngine;

public interface IInteractable
{
    public void Interact(GameObject self, GameObject interactor);
}
