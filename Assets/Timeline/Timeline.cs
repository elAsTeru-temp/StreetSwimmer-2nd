using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Timeline : MonoBehaviour
{
    float timer;


    private void Start()
    {
        this.GetComponent<PlayableDirector>().Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if( timer >= 16.0f || Input.GetKey(KeyCode.Escape) )
        {
            SceneManager.LoadScene("Stage");
        }
    }

    public void OpenStage()
    {
        SceneManager.LoadScene("Stage");
    }
}