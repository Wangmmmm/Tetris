using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tetris{
/// <summary>
/// 音效控制器
/// </summary>
public class AudioManager : MonoBehaviour {
	#region Game Spesific
    public AudioClip dropSound;
    public AudioClip lineClearSound;
    #endregion

    #region Template Fields
    public AudioSource musicSource;
	public AudioSource soundSource;
        
	public AudioClip gameMusic;
	public AudioClip uiClick;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip popUpOpen;
    public AudioClip popUpClose;
    #endregion

	public bool IsOpen{get{return musicSource.volume!=0;}}

	public void SetAudioSwitch(bool target)
	{
		if(target)
		{musicSource.volume=1;soundSource.volume=1;}
		else{
			musicSource.volume=0;soundSource.volume=0;
		}

	}

    #region Sound FX Methods
    public void PlayLoseSound()
	{
		StopGameMusic ();
		soundSource.clip = loseSound;
		soundSource.Play ();
	}

	public void PlayUIClick()
	{
		soundSource.clip = uiClick;
		soundSource.Play ();
	}

	public void PlayWinSound()
	{
		StopGameMusic ();
		soundSource.clip = winSound;
		soundSource.Play ();
	}

    public void PlaySplashScreenSound()
    {

    }

    public void PlayPopUpOpenSound()
    {

    }

    public void PlayPopUpCloseSound()
    {

    }

    public void PlayDropSound()
	{
		soundSource.clip = dropSound;
		soundSource.Play ();
	}

    public void PlayLineClearSound()
    {
        soundSource.clip = lineClearSound;
        soundSource.Play();
    }

    public void SetSoundFxVolume(float value)
	{
		float temp = value + soundSource.volume;
		if (temp < 0 || temp > 1)
			return;
		else
			soundSource.volume += value;
	}
	#endregion

	#region Music Methods
	public void PlayGameMusic()
	{
		musicSource.clip = gameMusic;
		musicSource.Play ();
	}

	public void StopGameMusic()
	{
		musicSource.Stop ();
	}

	public void SetSoundMusicVolume(float value)
	{
		float temp = value + musicSource.volume;
		if (temp < 0 || temp > 1)
			return;
		else
			musicSource.volume += value;
	}
	#endregion


}
}