using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject); 
        }
        for (int i = 0;i < m_AudioSource.Length; i++)
        {
            m_AudioSource[i] = GetComponent<AudioSource>();
        }
        
    }
    #endregion

    [SerializeField] AudioSource[] m_AudioSource;
    [SerializeField] AudioClip  m_Throw_Bomb, m_Throw_Fruits;
    [SerializeField] AudioClip m_Impat_Orange, m_Impact_Apple, m_Impact_Coconut, m_Impact_Pear, m_Impact_Watermelon;
    [SerializeField] AudioClip[] m_BladeCut;
    [SerializeField] AudioClip m_GameOver, m_GameStart, m_UI_Button_Press;

    public void GameOverPlay()
    {
        m_AudioSource[0].clip = m_GameOver;
        m_AudioSource[0].Play();
    }
    public void GameStartPlay()
    {
        m_AudioSource[0].clip = m_GameStart;
        m_AudioSource[0].Play();
    }
    public void BladeCutPlay()
    {
        //m_AudioSource.clip = m_BladeCut;
        m_AudioSource[0].Play();
    }

    #region FRUIT CUT EFFECTS
    public void OrangeCutPlay()
    {
        m_AudioSource[1].clip = m_Impat_Orange;
        m_AudioSource[1].Play();
    }
    public void AppleCutPlay()
    {
        m_AudioSource[1].clip = m_Impact_Apple;
        m_AudioSource[1].Play();
    }
    public void CoconutCutPlay()
    {
        m_AudioSource[1].clip = m_Impact_Coconut;
        m_AudioSource[1].Play();
    }
    public void PearCutPlay()
    {
        m_AudioSource[1].clip = m_Impact_Pear;
        m_AudioSource[1].Play();
    }
    public void WatermelonCutPlay()
    {
        m_AudioSource[1].clip = m_Impact_Watermelon;
        m_AudioSource[1].Play();
    }
    #endregion
    public void PlayFruitSound(string fruitName)
    {
        AudioClip clip = null;
        switch (fruitName)
        {
            case "Apple": 
                clip = m_Impact_Apple;
                break;
            case "Coconut":
                clip = m_Impact_Coconut;
                break;
            case "Orange":
                clip = m_Impat_Orange;
                break;
            case "Pear":
                clip = m_Impact_Pear;
                break;
            case "Watermelon":
                clip = m_Impact_Watermelon;
                break;
        }

        if (clip != null)
        {
            m_AudioSource[1].PlayOneShot(clip);
        }
    }
    public void BombThrowPlay()
    {
        m_AudioSource[0].clip = m_Throw_Bomb;
        m_AudioSource[0].Play();
    }
    public void FruitThrowPlay()
    {
        m_AudioSource[0].clip = m_Throw_Fruits;
        m_AudioSource[0].Play();
    }
}
