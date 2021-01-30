using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPath : MonoBehaviour
{
    private PickSoul _soulPicker = null;

    private void Awake()
    {
        _soulPicker = GetComponent<PickSoul>();
        Debug.Assert(_soulPicker != null, "The player does not have a soul picker");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PathBlocker" && _soulPicker.HasSoul)
            UnblockPath();
    }

    private void UnblockPath()
    {
        //TODO
    }
}
