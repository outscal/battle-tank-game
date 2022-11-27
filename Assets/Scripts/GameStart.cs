using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private int x = 10;

    [SerializeField]
    private int y = 20;

    public int z = 40;
    public string[] testArray;

    public List<string> testList;

    public Coroutine co;
    public List<Coroutine> coroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NormalCoroutine(10f));
        StopCoroutine(NormalCoroutine(10f));

        coroutine.Add(StartCoroutine(NormalCoroutine(10f)));
        StopCoroutine(coroutine[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator NormalCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    public int NormalFunction()
    {

        return 0;
    }


    //chaining coroutine
    IEnumerator RightUp()
    {

        yield return StartCoroutine(Right());
        yield return StartCoroutine(Up());

    }
    IEnumerator Right()
    {

        yield return null;

    }

    IEnumerator Up()
    {

        yield return null;
    }
}
//1vers.social@gmail.com
//1vers.tech@gmail.com
