using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
