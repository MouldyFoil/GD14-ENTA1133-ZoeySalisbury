using System;
using UnityEngine;

public class UIModeManager : MonoBehaviour
{
    [SerializeField] GameObject[] modes;
    public void SwitchMode(int index)
    {
        Console.WriteLine("HIII HIII I GOT PRESSED");
        for (int i = 0; i < modes.Length; i++)
        {
            modes[index].SetActive(i == index);
        }
    }
    public void ActivateMode(int index)
    {
        SetModeActive(index, true);
    }
    public void DeactivateMode(int index)
    {
        SetModeActive(index, false);
    }
    public void ReverseModeActive(int index)
    {
        SetModeActive(index, !modes[index].activeSelf);
    }
    public void SetModeActive(int index, bool active)
    {
        if (index >= 0 && index < modes.Length)
        {
            modes[index].SetActive(active);
        }
        else
        {
            Debug.LogWarning("Attempted to deactivate mode that doesn't exist");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
