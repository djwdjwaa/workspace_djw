﻿using UnityEngine;
using System.Collections;

public class Sound : Singleton<Sound>
{
    protected override void Awake()
    {
        base.Awake();
        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_bgSound.playOnAwake = false;//是否默认播放
        m_bgSound.loop = true;//是否循环

        m_effectSound = this.gameObject.AddComponent<AudioSource>();
    }

    public string ResourceDir = "";

    AudioSource m_bgSound;
    AudioSource m_effectSound;

    //音乐大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }

    //音效大小
    public float EffectVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }

    //播放音乐
    public void PlayBg(string audioName)
    {
        //当前正在播放的音乐文件
        string oldName;
        if (m_bgSound.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_bgSound.clip.name;
        }

        if (oldName != audioName)
        {
            //加载音乐文件
            string path;
            if (string.IsNullOrEmpty(ResourceDir))
            {
                path = "";
            }
            else
            {
                path = ResourceDir + "/" + audioName;
            }

            //加载音乐
            AudioClip clip = Resources.Load<AudioClip>(path);

            //播放
            if (clip != null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }

    //停止音乐-
    public void StopBg()
    {
        m_bgSound.Stop();
        m_bgSound.clip = null;
    }

    //播放音效
    public void PlayEffect(string audioName)
    {
        //路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
        {
            path = "";
        }
        else
        {
            path = ResourceDir + "/" + audioName;
        }

        //音频
        AudioClip clip = Resources.Load<AudioClip>(path);

        //播放
        m_effectSound.PlayOneShot(clip);
    }
}
