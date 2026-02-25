using System;
using UnityEngine;
[Serializable]
public class EmptyNPCCommand: INPCCommand
{
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        
    }
}
