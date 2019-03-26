using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.UI;

public class LoginFacebook : MonoBehaviour
{

    public Button loginBtn;
    public Button logoutBtn;

    public Image avatarImg;
    public Image avatarHolder;

    // Start is called before the first frame update
    void Start()
    {
    }

    #region LoginFacebook

    public void FacebookLogin()
    {
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    public void FacebookLogout()
    {
        loginBtn.enabled = true;
        logoutBtn.enabled = false;

        avatarImg.sprite = null;
        Sprite textureAvatarDefault = Resources.Load<Sprite>("Icons/users");
        avatarHolder.enabled = true;
        avatarHolder.sprite = textureAvatarDefault;
        FB.LogOut();
    }

    private void GetPicture(IGraphResult result)
    {
        if (result.Error == null && result.Texture != null)
        {
            avatarImg.sprite = Sprite.Create(result.Texture, new Rect(0, 0, result.Texture.width, result.Texture.height), new Vector2());
            avatarHolder.enabled = false;
        }
    }

    private void DisplayName(IGraphResult result)
    {
       
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
            FB.API("/me?feilds=name", HttpMethod.GET, DisplayName);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetPicture);
            loginBtn.enabled = false;
            logoutBtn.enabled = true;
        }
        else
        {
            Debug.Log("User cancelled login");
            loginBtn.enabled = true;
            logoutBtn.enabled = false;
        }
    }

    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }

        if (FB.IsLoggedIn)
        {
            FB.API("/me?feilds=name", HttpMethod.GET, DisplayName);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetPicture);
            loginBtn.enabled = false;
            logoutBtn.enabled = true;
        }
        else
        {
            loginBtn.enabled = true;
            logoutBtn.enabled = false;
        }

    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    #endregion;

    #region FirebaseSettings

    #endregion
}


