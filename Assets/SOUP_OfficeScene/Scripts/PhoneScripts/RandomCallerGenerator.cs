using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomCallerGenerator : MonoBehaviour
{
    //Replace TMP_Texts with Images
    //Replace String[]s with sprite arrays
    //Update script to read "Hair.sprite = HairOptions[HairChoice]" instead of text

    [Header("Hair")]
    public TMP_Text Hair;
    public string[] HairOptions;
    public int HairChoice;

    [Header("Eyes")]
    public TMP_Text Eyes;
    public string[] EyesOptions;
    public int EyesChoice;

    [Header("Nose")]
    public TMP_Text Nose;
    public string[] NoseOptions;
    public int NoseChoice;

    [Header("Mouth")]
    public TMP_Text Mouth;
    public string[] MouthOptions;
    public int MouthChoice;

    [Header("Details")]
    public TMP_Text SkinTone;
    public string[] SkinToneOptions;
    public int SkinToneChoice;
    public TMP_Text Gender;
    public string[] GenderOptions;
    public int GenderChoice;

    [Header("Dispatch Info")]
    public RandomDispatchGenerator dispatchCall;

    public void GenerateCaller()
    {
        HairChoice = Random.Range(0, HairOptions.Length);
        Hair.text = HairOptions[HairChoice];

        EyesChoice = Random.Range(0, EyesOptions.Length);
        Eyes.text = EyesOptions[EyesChoice];

        NoseChoice = Random.Range(0, NoseOptions.Length);
        Nose.text = NoseOptions[NoseChoice];

        MouthChoice = Random.Range(0, MouthOptions.Length);
        Mouth.text = MouthOptions[MouthChoice];

        SkinToneChoice = Random.Range(0, SkinToneOptions.Length);
        SkinTone.text = SkinToneOptions[SkinToneChoice];

        GenderChoice = Random.Range(0, GenderOptions.Length);
        Gender.text = GenderOptions[GenderChoice];

        dispatchCall.GenerateDispatch();
    }
}
