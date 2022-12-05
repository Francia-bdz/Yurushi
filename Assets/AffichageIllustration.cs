using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffichageIllustration : MonoBehaviour
{

    [SerializeField] private List<GameObject> illustration;
    public int nbIllustration = 0;
    public int nbKeyDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { 
        ResetIllustrationDisplay();
        }


    }

    private void ResetIllustrationDisplay()
    {
        for (int i = 0; i < illustration.Count; i++)
        {
            illustration[i].SetActive(false);
        }
        illustration[nbIllustration].SetActive(true);
        nbIllustration++;

    }

    


}
