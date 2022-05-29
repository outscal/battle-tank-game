using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoudiniEngineUnity;

public class TestingGrounds : MonoBehaviour
{
    public GameObject houdiniAsset;
    private HEU_HoudiniAsset HoudiniAsset;

    private void Start()
    {
        HoudiniAsset = houdiniAsset.GetComponent<HEU_HoudiniAssetRoot>() != null ? houdiniAsset.GetComponent<HEU_HoudiniAssetRoot>()._houdiniAsset : null;
    }
}
