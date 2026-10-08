using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour
{
    public void GotoLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
