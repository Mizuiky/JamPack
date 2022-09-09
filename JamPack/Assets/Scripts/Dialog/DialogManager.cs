using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using System;
using UnityEngine.UI;

public class DialogManager : Singleton<DialogManager>
{
    #region Serializable Fields

    [Header("Dialog Setup")]

    [SerializeField]
    private DialogBox _dialogBox;

    [SerializeField]
    private SO_String _text;

    [SerializeField]
    private float _speed;

    #endregion

    #region Private Fields

    private bool _isWriting;

    private int _currentDialogIndex;

    private DialogData[] _dialogs;

    private EndDialogBase _endDialog;

    #endregion

    #region Properties

    public bool ISWriting
    {
        get => _isWriting;
    }

    #endregion

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _isWriting = false;
        _currentDialogIndex = 0;
    }

    public void Initialize(SO_Dialog data)
    {
        ClearPreviousData();
        Init();

        _dialogs = data._dialog.ToArray();

        _endDialog = data._endPrefab;

        _dialogBox.ActivateDialog(true);

        Write();
    }

    private void ClearPreviousData()
    {
        if(_dialogs != null && _dialogs.Length > 0)
        {
            _dialogs = null;
            GC.Collect();
        }

        _dialogBox.ClearFields();
    }

    public void Write()
    {
        _isWriting = true;

        StartCoroutine(WriteText());
    }

    private IEnumerator WriteText()
    {     
        var aux = _dialogs[_currentDialogIndex];

        _dialogBox.SetName(aux._characterName);
        _dialogBox.SetImage(aux._image);

        var dialog = aux._text.ToCharArray();

        foreach (char letter in dialog)
        {
            _text.value += letter;

            yield return new WaitForSeconds(_speed);
        }
       
        _isWriting = false;

        _dialogBox.EnableNextButton();
    }

    public void NextDialog()
    {
        if (!_isWriting)
        {
            _dialogBox.DisableNextButton();

            _currentDialogIndex++;

            if (_currentDialogIndex == _dialogs.Length)
            {
                if(_endDialog != null)
                    _endDialog.EndCallBack();

                _dialogBox.ActivateDialog(false);
                return;
            }
                
            _text.value = "";

            Write();
        }       
    }  
}
