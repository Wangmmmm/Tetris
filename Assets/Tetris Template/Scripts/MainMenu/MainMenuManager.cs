using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    private static MainMenuManager _instance;
    public static MainMenuManager Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

  

    [Header("Login In")]
    public Text accountText;
    public Text pwdText;

    [Header("Sign Up")]
    public Text accoutTextForSignUp;
    public Text pwdTextForSignUp;
    public Text pwdTextForSignUpComfirm;

    [Header("Buttons")]
    public Button comfirmForSignIn;
    public Button changeToSignUpPage;
    public Button comfirmForSignUp;
    public Button resetForSignUp;
    public Button changeToSignIn;

    [Header("Pages")]
    public GameObject LoginPage;
    public GameObject SignUpPage;


    void Start()
    {
        Instance = this;

        comfirmForSignIn.onClick.AddListener(ComfirmForSignIn);
        changeToSignIn.onClick.AddListener(ChangeToSignIn);
        comfirmForSignUp.onClick.AddListener(ComfirmForSignUp);
        resetForSignUp.onClick.AddListener(ResetForSignUp);
        changeToSignUpPage.onClick.AddListener(ChangeToSignUpPage);
    }

    public void ComfirmForSignIn()
    {

    }

    public void ChangeToSignUpPage()
    {
        LoginPage.SetActive(false);
        SignUpPage.SetActive(true);
    }

    public void ComfirmForSignUp()
    {

    }

    public void ResetForSignUp()
    {

    }

    public void ChangeToSignIn()
    {
        LoginPage.SetActive(true);
        SignUpPage.SetActive(false);
    }

}
