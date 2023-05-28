using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        
    }
    public void LoadNextLevel(string nameScene)
    {
        StartCoroutine(LoadLevel(nameScene));  
    }
    IEnumerator LoadLevel(string nameScene)
    {
        transition.SetTrigger("Start");


        // wait
        yield return new WaitForSeconds(transitionTime);


        // load scene
        SceneManager.LoadScene(nameScene);

    }
}
