using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToLevelSelectionScript : MonoBehaviour
{
    public void backToLevelSelection()
    {
        SceneManager.LoadScene("Level Selection");
    }
}
