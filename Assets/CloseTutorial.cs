using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseTutorial : MonoBehaviour
{

    public void CloseTutorialButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
