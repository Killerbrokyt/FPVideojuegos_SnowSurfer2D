using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactersManager : MonoBehaviour
{
    public void SelectCharacter(int characterIndex)
    {
        // TODO: Seleccionar Personaje
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
