using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI logText;

    public void SetLog(string log)
    {
        logText.text = log;
    }

    public IEnumerator TypeLog(string log)
    {
        logText.text = "";
        foreach (char letter in log)
        {
            logText.text += letter;
            yield return new WaitForSeconds(1f / 100);
        }
    }
}