using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBound : MonoBehaviour
{
    public BoundMain temp;

    public bool local_block;

    void Start()
    {
        if(!temp.is_started)
        {
            local_block = false;
        }
        else
        {
            local_block = true;
        }
    }
    bool bl;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "go" &&!local_block)
        {
            Debug.Log("bound");            
            temp.Stop = true;
            Transform ss = collision.gameObject.GetComponent<AddBound>().temp.tfr;
            temp.Unblock();
            temp.SetParents();
            temp.AddCoin();
            
            //  bl = true;
        }
        if (collision.gameObject.tag == "lose" &&!local_block)
        {
            Debug.Log("lose");
            temp.EnablePhys();
            //collision.gameObject.GetComponent<AddBound>().temp.EnablePhys();
            //collision.gameObject.GetComponent<AddBound>().temp.Add_Bound(temp.gameObject.transform);
            temp.Stop = true;
           //Time.timeScale = 0;
            //Time.timeScale = 0;
        }
    }
}
