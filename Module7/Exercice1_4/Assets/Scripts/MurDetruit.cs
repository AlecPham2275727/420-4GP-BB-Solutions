using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurDetruit : MonoBehaviour, IMortel
{
    public void FaireMourir()
    {
#if UNITY_EDITOR
        DestroyImmediate(gameObject);
#else
        Destroy(gameObject);
#endif
    }
}
