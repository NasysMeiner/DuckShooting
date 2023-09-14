using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositionOrder : MonoBehaviour
{
    [SerializeField] List<CompositeRoot> _compositeRoots;

    private void Awake()
    {
        foreach(var compositeRoot in _compositeRoots)
        {
            compositeRoot.Compose();
        }
    }
}
