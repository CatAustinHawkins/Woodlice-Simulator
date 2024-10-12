using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseTutorial : MonoBehaviour
{

    public void CloseTutorialButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
