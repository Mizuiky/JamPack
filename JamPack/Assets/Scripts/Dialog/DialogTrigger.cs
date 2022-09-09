using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private SO_Dialog _soNPCDialog;

    [SerializeField]
    private string tagToCompare;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enter Trigger");

        if(collider.CompareTag(tagToCompare))
        {
            if (!DialogManager.Instance.ISWriting)
                DialogManager.Instance.Initialize(_soNPCDialog);
        }
    }
}
