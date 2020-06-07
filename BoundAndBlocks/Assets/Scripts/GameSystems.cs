using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Text cv;
    public int coin;
    void Win()
    {
        return;
    }

    [SerializeField] GameObject outer;

    float df;

    // Update is called once per frame
    void Update()
    {

        if (game&& ! lose)
        {
            t += Time.deltaTime;
            if (t >= interval && i < mass.Length)
            {
                mass[i].SetActive(true);
                mass[i].GetComponent<RectTransform>().localPosition = new Vector3(0, 900, 0);
                i++;
                t = 0;
            }
            else
            {
                Win();
            }
        }
        if(lose && game)
        {
            anims.SetBool("exit", true);
            for (int i = 0; i < mass.Length; i++)
            {
               // mass[i].transform.SetParent(null);
                mass[i].SetActive(true);
            }
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                mass[i].GetComponent<BoundMain>().FinishAll();
            }
            sd.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            sd.enabled = false;
            but.SetActive(true);
            game = false;
        }
        
    }

    bool game;
    int i;
    float t;
    public float interval;

    public GameObject[] mass;

    [SerializeField] Animator anims, b, ou;

    public GameObject str_bound, but;

    [SerializeField] BoundMain sd;

    public bool lose;

    public void Lose()
    {
        lose = true;
        //Time.timeScale = 0;\
        
    }

    IEnumerator st()
    {
        yield return new WaitForSeconds(0.9f);
        sd.enabled = true;
        b.enabled = false;
        //yield return new WaitForSeconds(1f);
        game = true;
    }

    IEnumerator sff()
    {
        ou.SetBool("cc", true);
        outer.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(0);
    }

    public void GoPlay()
    {
        if (!lose)
        {
            str_bound.SetActive(true);
            StartCoroutine(st());
            anims.SetBool("go", true);
            but.SetActive(false);
        }
        else
        {
            StartCoroutine(sff());
        }
        return;
    }
}
