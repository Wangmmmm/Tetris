using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tetris;
using DG.Tweening;
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

    public GameObject RankBoard;


  
  

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

    public Button SetBtn;
    public Button RankBtn;
    public Button CloseRankBtn;

    [Header("Pages")]
    public GameObject LoginPage;
    public GameObject SignUpPage;

    MainMenuCtrl mainMenuCtrl;
    void Start()
    {
        Instance = this;
        mainMenuCtrl=new MainMenuCtrl();
        OnOpen();
    }

    void OnOpen()
    {
        if(!Manager.Audio.IsOpen)
        {
            SetBtn.transform.Find("pic").GetComponent<Image>().color=new Color(0.5f,0.5f,0.5f,1);
        }
        else SetBtn.transform.Find("pic").GetComponent<Image>().color=new Color(1,1,1,1);
    }
    private Tetris.UIManager UI{get{return Tetris.Manager.UI;}}
    public void ComfirmForSignIn()
    {
        string tipText="";
        switch(mainMenuCtrl.TrySignIn(accountText.text,pwdText.transform.parent.GetComponent<InputField>().text))
        {
            case SignInFeedbackType.Succeed:tipText="登录成功，请选择游戏模式"; 
            TweenOpenWithScale(ChooseBoard.transform);
            LoginPage.SetActive(false);break;
            case SignInFeedbackType.WrongPassword:tipText="密码不正确";break;
            case SignInFeedbackType.NullUserNameOrPassword:tipText="输入信息不能为空";break;
            case SignInFeedbackType.UsernameUnknown:tipText="用户名不存在";break;
        }
        UI.AddTips(tipText);
      
    }

    public void ChangeToSignUpPage()
    {
        TweenOpenWithScale(SignUpPage.transform);
        LoginPage.SetActive(false);
    }

    public void ComfirmForSignUp()
    {
         string tipText="";
        switch(mainMenuCtrl.TrySignUp(accoutTextForSignUp.text,pwdTextForSignUp.transform.parent.GetComponent<InputField>().text,
        pwdTextForSignUpComfirm.transform.parent.GetComponent<InputField>().text))
        {
            case SignUpFeedbackType.Succeed:tipText="注册成功"; ChangeToSignIn();break;
            case SignUpFeedbackType.ConfirmPasswordWrong:tipText="两次输入密码不正确";break;
            case SignUpFeedbackType.NullMessage:tipText="输入信息不能为空";break;
            case SignUpFeedbackType.UsernameRepeat:tipText="用户名重复";break;
        }

        UI.AddTips(tipText);
        
    }


    public void ChangeToSignIn()
    {
        TweenOpenWithScale(LoginPage.transform);
        SignUpPage.SetActive(false);
    }

    public void OnRankBtn()
    {
        TweenOpenWithScale(RankBoard.transform);
        RankBtn.gameObject.SetActive(false);
        CloseRankBtn.gameObject.SetActive(true);
    }
    public void OnRankCloseBtn()
    {
        TweenCloseWithScale(RankBoard.transform);
        RankBtn.gameObject.SetActive(true);
        CloseRankBtn.gameObject.SetActive(false);
    }

    public void OnSetBtn()
    {
     
        Manager.Audio.SetAudioSwitch(!Manager.Audio.IsOpen);
       if(!Manager.Audio.IsOpen)
        {
            SetBtn.transform.Find("pic").GetComponent<Image>().color=new Color(0.5f,0.5f,0.5f,1);
        }
        else SetBtn.transform.Find("pic").GetComponent<Image>().color=new Color(1,1,1,1);
    }



    public void TweenOpenWithScale(Transform trans)
    {
        float scale=1;

        trans.localScale=new Vector3(0,0,0);
        trans.gameObject.SetActive(true);
        trans.DOScale(new Vector3(scale,scale,scale),0.5f);

    }
    public void TweenCloseWithScale(Transform trans)
    {
        float scale=1;

       
        trans.DOScale(new Vector3(0,0,0),0.5f).OnComplete(()=>{trans.gameObject.SetActive(false);trans.localScale=new Vector3(scale,scale,scale);});
    }

    public GameObject ChooseBoard;

    public void OnNormalClick()
    {
        Manager.Game.SetState(new Tetris.GamePlayState());
    }
    public void OnBarrierClick()
    {
        Manager.Game.SetState(new Tetris.BlockState());
    }
    public void OnRelayClick()
    {
        Manager.Game.SetState(new Tetris.CooperateState());
    }
    public void OnBackClick()
    {
        TweenOpenWithScale(LoginPage.transform);
        ChooseBoard.SetActive(false);
    }


}
