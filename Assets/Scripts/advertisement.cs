using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class advertisement : MonoBehaviour
{
    [Tooltip("çLçêÇÃï∂éö")][SerializeField] private GameObject adv;

    private void Update()
    {
        adv.transform.position -= new Vector3(0, 4, 0);
        if(adv.transform.position.y <= -80)
        {
            OpenStage();
        }
    }

    public void OpenStage()
    {
        SceneManager.LoadScene("Stage");
    }
}
