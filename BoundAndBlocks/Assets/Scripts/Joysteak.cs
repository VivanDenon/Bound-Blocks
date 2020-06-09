using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joysteak : MonoBehaviour
{
    [SerializeField] Vector3 center;
    [SerializeField] bool block;
    [SerializeField] float last_rotation, new_rotation, max;
    public BoundMain bound_main;
    [SerializeField] Image joysteak;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !block)
        {
            /*if(Input.mousePosition.x > Screen.width/2)
                center.x = Input.mousePosition.x - max;
            else
                center.x = Input.mousePosition.x + max;
            if (Input.mousePosition.y > Screen.height / 2)
                center.y = Input.mousePosition.y - max;
            else
                center.y = Input.mousePosition.y + max;*/
            center.x = Screen.width / 2;
            center.y = Screen.height / 2;
            max = Screen.width / 2f;
            Debug.Log(max);
            block = true;
        }
        if (block && bound_main.is_started && !bound_main.sys.lose)
        {
            joysteak.enabled = true;
            float x = Input.mousePosition.x - center.x, y = Input.mousePosition.y - center.y;
            float c = (float)Math.Sqrt((Math.Pow(x, 2f) + (Math.Pow(y, 2f))));
            if (c > max)
            {
                x /= c / max;
                y /= c / max;
            }
            Vector3 xyz = new Vector3(x + center.x, y + center.y, 0f);
            gameObject.transform.position = xyz;
            /* if (x != 0 && y!= 0)
             {
                 if(last_rotation < 0)
                     new_rotation = (float)Math.Atan(y / x) * 57.3f - 90;
                 else
                     new_rotation = -(float)Math.Atan(y / x) * 57.3f - 90;*/
            //bound_main.gameObject.transform.Rotate(0f, 0f, -(last_rotation - new_rotation));
            if(y < 0)
                bound_main.gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, 1.5f*(x + center.x));
               // bound_main.gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(0f, 0f, (max - x) + center.x + max);

            //}
        }

        if (Input.GetMouseButtonUp(0))
        {
            joysteak.enabled = false;
            block = false;
        }
    }
}
