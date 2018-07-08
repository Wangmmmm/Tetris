using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SignInFeedbackType
{
	Succeed,
	UsernameUnknown,

	WrongPassword,

	NullUserNameOrPassword,

	Unknown
}

public enum SignUpFeedbackType
{
	Succeed,

	NullMessage,

	UsernameRepeat,

	ConfirmPasswordWrong,

	Unknown

}
namespace  Tetris
{
	

public class MainMenuCtrl {

	private DataBaseManager DB
	{
		get{
		return Manager.DB;
		}
	}

	public SignInFeedbackType TrySignIn(string username,string password)
	{
		

		if(username==""||password==""||username==null||password==null)
		return SignInFeedbackType.NullUserNameOrPassword;

		
		if(!DB.FindUser(username))return SignInFeedbackType.UsernameUnknown;

		if(password!=DB.FindPassword(username))return SignInFeedbackType.WrongPassword;



		return SignInFeedbackType.Succeed;
	}


	public SignUpFeedbackType TrySignUp(string username,string password,string confirm)
	{
		if(username==null||password==null||confirm==null||username==""||password==""||confirm=="")
		return SignUpFeedbackType.NullMessage;

		if(DB.FindUser(username))return SignUpFeedbackType.UsernameRepeat;

		if(password!=confirm)return SignUpFeedbackType.ConfirmPasswordWrong;

		DB.Insert(username,password);
		return SignUpFeedbackType.Succeed;
	}
	//public 

}
}