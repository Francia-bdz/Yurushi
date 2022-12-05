using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TextAppear : MonoBehaviour
{
    Text text;
    public float tpsAppear = 15;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.enabled = false;
        StartCoroutine(TextAppearCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextAppearCoroutine()
    {
        yield return new WaitForSeconds(tpsAppear);
        text.enabled = true;
        yield return null;
    }
}
