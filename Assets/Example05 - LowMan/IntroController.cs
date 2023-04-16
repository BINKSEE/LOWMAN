using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    public InputField inputField;

    private static string username;

    public void SaveUsername()
    {
        username = inputField.text;
    }

    public void PlayButtonClicked()
    {
        // Save the username in player prefs
        PlayerPrefs.SetString("Username", username);

        // Load the next scene
        SceneManager.LoadScene("Game");
    }

    public static string GetUsername()
    {
        // Load the username from player prefs
        return PlayerPrefs.GetString("Username", "Player");
    }
}



