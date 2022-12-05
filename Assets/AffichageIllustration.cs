using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AffichageIllustration : MonoBehaviour
{

    [SerializeField] private List<GameObject> illustration;
    private int nbIllustration = 0;
    public string LevelToLoad;

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(LevelToLoad);

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
