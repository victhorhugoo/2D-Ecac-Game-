using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        VFX_2
    }

    public List<VFXManagerSetup> vfxSetup;
}

[System.Serializable]

public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefb;
}
