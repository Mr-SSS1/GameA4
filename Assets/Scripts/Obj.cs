using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    Vector2 defPos;
    public bool set;
    [SerializeField]Player player;
    void Start()
    {
        set = true;
        defPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 Ppos = player.transform.position;
        Vector2 Vpos = defPos - pos;
        
        if (Ppos.x - pos.x > 15f && !set) 
        {
            ResetPos();
            set = true;
        }
        else if (Ppos.x - pos.x < 5f)
        { 
            set = false;
        }

        if (Vpos.x > 10f)
        {
            ResetPos();
        }
    }

    void ResetPos()
    {
        transform.position = defPos;
    }
}
