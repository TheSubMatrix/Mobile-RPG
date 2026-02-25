using UnityEngine;
// ReSharper disable once InconsistentNaming
// ReSharper disable once IdentifierTypo
public interface INPCCommand
{
    void Execute(GameObject interacted, GameObject executionRequester);
}
