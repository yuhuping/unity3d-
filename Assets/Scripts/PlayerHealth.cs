using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth =100;
    public int currhealth;
    [Header("UI-part")]
    public ProgressBar Pb;
    public int Value = 60;
    //private GameObject playerBehurtUI;

    void Start()
    {
        currhealth = maxhealth;
        //playerBehurtUI = GameObject.FindGameObjectWithTag("BehurtUI");
    }

    // Update is called once per frame
    void Update()
    {
        Value = currhealth;
        Pb.BarValue = Value;
    }
    public void PlayerBehurt(int damage)
    {
        currhealth -= damage;
        //playerBehurtUI.SetActive(true);
        Invoke("setBehurtUifalse",1f);
    }
    private void setBehurtUifalse()
    {
        //playerBehurtUI.SetActive(false);
    }
}
