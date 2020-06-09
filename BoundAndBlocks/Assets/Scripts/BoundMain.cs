using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//test
public class BoundMain : MonoBehaviour
{
    bool block;
    float x, new_x, ox, d, old_d;

    public Transform tfr;

    public bool is_started;

    public bool Stop;

    float y_pos;

    [SerializeField] Rigidbody2D phis;

    public AddBound[] ass;
    public GameSystems sys;

    public void SetParents()
    {
        tfr.SetParent(sys.str_bound.transform);
        return;
    }

    public void FinishAll()
    {
        for(int i =0; i < ass.Length; i++)
        {
            ass[i].gameObject.SetActive(false);
        }
        return;
    }

    public void AddCoin()
    {
        sys.coin++;
        sys.cv.text = "Score: " + sys.coin.ToString();
        return;
    }

    void Start()
    {
        tfr = GetComponent<Transform>();
        ass = gameObject.GetComponentsInChildren<AddBound>();
        y_pos = gameObject.transform.position.y;
    }

    public void EnablePhys()
    {
        //phis.constraints = RigidbodyConstraints2D.None;
        sys.Lose();
    }

    public void Unblock()
    {
        Stop = true;
        for(int i = 0; i < ass.Length; i++)
        {
            ass[i].local_block = true;
            Debug.Log("fff");
        }
        return;
    }

    void Update()
    {
        /*if (is_started && !sys.lose)
        {
            if (joysteak.block)
            {
                gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, (float)Math.Sqrt((Math.Pow(joysteak.x_rotation, 2) + (Math.Pow(joysteak.y_rotation, 2)))));
            }
        }*/
        if (!Stop)
        {
            gameObject.transform.position = new Vector3(500, y_pos, 0);
            y_pos -= 800 * Time.deltaTime;
        }

        /*
        if (is_started && !sys.lose)
        {
            if (Input.GetMouseButtonDown(0))
            {
                x = Input.mousePosition.x;
                block = true;
            }

            if (block)
            {
                new_x = Input.mousePosition.x;
                d = x - new_x;
                if (d != 0)
                    gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, -((d/1.5f) + old_d)/1.5f);
            }


            if (Input.GetMouseButtonUp(0))
            {
                block = false;
                old_d = gameObject.GetComponent<Transform>().localRotation.z;
                d = 0;
            }
        }*/
    }

    public void Add_Bound(Transform axx)
    {
        transform.SetParent(axx);
        Stop = true;
    }

    public Transform GetTransform()
    {
        return GetComponent<Transform>();
    }
}
