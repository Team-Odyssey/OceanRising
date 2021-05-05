using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using TMPro;

public class Authentication : MonoBehaviour
{
    [SerializeField] private GameObject signInDisplay = default;
    [SerializeField] private TMP_Text usernameInputField = default;
    [SerializeField] private TMP_Text passwordInputField = default;

    public static string SessionTicket;
    public static string EntityId;

    public void CreateAccount(string newScene)
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = usernameInputField.text,
            Password = passwordInputField.text,
            TitleId = PlayFabSettings.TitleId,
            RequireBothUsernameAndEmail = false
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            EntityId = result.EntityToken.Entity.Id;
            signInDisplay.SetActive(false);
            SceneManager.LoadScene(newScene);
        }, error =>
        {
            Debug.Log("Username: " + usernameInputField.text);
            Debug.Log("Password: " + passwordInputField.text);
            Debug.LogError(error.GenerateErrorReport());
            passwordInputField.text = "ERROR";
        });
    }

    public void SignIn(string newScene)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = usernameInputField.text,
            Password = passwordInputField.text
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            EntityId = result.EntityToken.Entity.Id;
            signInDisplay.SetActive(false);
            SceneManager.LoadScene(newScene);
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
            passwordInputField.text = "ERROR";
        });
    }
}