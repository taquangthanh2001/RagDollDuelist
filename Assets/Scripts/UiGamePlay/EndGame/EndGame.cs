using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

public class EndGame : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI statusTxt;
    [SerializeField] protected Button btnClose;

    private void Start()
    {
        btnClose.onClick.AddListener(OnClickClose);
    }

    private void OnClickClose()
    {
        Destroy(gameObject);
    }

    public void SetStatus(StatusGame statusGame)
    {
        statusTxt.text = statusGame.ToString();
    }
}
