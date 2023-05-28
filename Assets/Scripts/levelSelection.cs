using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked; // Default value is false
    public Image unlockImage;

    public void Update()
    {
        updateLevelImage();
    }

    private void updateLevelImage()
    {
        if (!unlocked) // if unlock is false means this level is locked!
        {
            unlockImage.gameObject.SetActive(true);
        }
        else // if unclock is true means this level can play
        {
            unlockImage.gameObject.SetActive(false);
        }
    }

    public void pressSelection(string _LevelName) // When we press this level, we can move to the corresponding Scene to play
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }
}
