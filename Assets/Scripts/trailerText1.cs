using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class trailerText1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Animator animator;
    public string[] lines;
    public float textSpeed;

    private int index;
    private int nextSceneToLoad;

    void Start()
    {
        textComponent.text = string.Empty;
        startTrailer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
                nextLine();
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                Invoke("FadeOut", 1);
                Invoke("LoadNextScene", 1);
            }
        }
    }

    void startTrailer()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
