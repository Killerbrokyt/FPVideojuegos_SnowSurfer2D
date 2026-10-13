using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        Transform levels = transform.GetChild(0);

        for (int i = 0; i < levels.childCount; i++) {
            levels.GetChild(i)
        }
    }
}
