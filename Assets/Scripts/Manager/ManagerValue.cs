using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerValue : MonoBehaviour
{
    public bool playerSelect=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerSelectSomething()
    {
        playerSelect = true;
    }
    public void playerSelectNone()
    {
        playerSelect = false;
    }
    public bool GetNowSelect()
    {
        return playerSelect;
    }
}
