using System;
using System.Collections.Generic;
using MatrixUtils.Attributes;
using UnityEngine;
[Serializable]
public class NPCChainCommand : INPCCommand
{
    [SerializeReference, ClassSelector] List<INPCCommand> m_commandsToChain = new();
    public void Execute(GameObject interacted, GameObject executionRequester)
    {
        foreach (INPCCommand command in m_commandsToChain)
        {
            command.Execute(interacted, executionRequester);
        }
    }
}
