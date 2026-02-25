using System.Collections.Generic;
using MatrixUtils.Attributes;
using UnityEngine;

public class CharacterCoordinator : MonoBehaviour
{
    [SerializeReference, ClassSelector] List<ICapability> m_capabilities;
    void Awake() => m_capabilities.ForEach(capability => capability.Initialize());
    void OnDestroy() => m_capabilities.ForEach(capability => capability.Cleanup());
}