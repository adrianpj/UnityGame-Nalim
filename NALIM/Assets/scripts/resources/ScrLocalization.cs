using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------------------------------
/// SCR LOCALIZATION
/// Script gestió de la localització global
/// Cada idioma és distribuit per la seva categoria, estructurat per la denominació de la LLENGUA
/// Tots els components es troben dins de la carpeta ASSETS
/// 
///     Resources/localization/English.txt
///     Resources/localization/Spanish.txt
///     Resources/localization/Catalan.txt
/// 
/// El tipus de format per a text és el següent:
/// 
///     string=valor
/// 
/// On "string": el nom que acompanya a la variable.
///  
/// Versió 0.1
/// Carlos Serrano
/// Data 10-01-19
/// 
/// -----------------------------------------------------------------------
/// 
/// </summary>
[RequireComponent(typeof(Text))]
public class ScrLocalization : MonoBehaviour {

    #region Public Fields

    public string localizationKey;
    public static string localizationKey_inDialogue;

    #endregion Public Fields

    #region Private Fields

    private const string STR_LOCALIZATION_KEY = "locale";
    private const string STR_LOCALIZATION_PREFIX = "localization/";
    private static string currentLanguage;
    private static bool currentLanguageFileHasBeenFound = false;
    private static bool currentLanguageHasBeenSet = false;
    private static Dictionary<string, string> CurrentLanguageStrings = new Dictionary<string, string>();
    private static TextAsset currentlocalizationText;
    private Text text;

    #endregion Private Fields

    #region Public Properties

    public static bool CurrentLanguageHasBeenSet
    {
        get
        {
            return CurrentLanguageHasBeenSet;
        }
    }

    // La llengua del PLAYER. Si no és ajustat, li retorna a Application.systemLanguage

    public static SystemLanguage PlayerLanguage
    {
        get
        {
            return (SystemLanguage)PlayerPrefs.GetInt(STR_LOCALIZATION_KEY, (int)Application.systemLanguage);
        }
        set
        {
            PlayerPrefs.SetInt(STR_LOCALIZATION_KEY, (int)value);
            PlayerPrefs.Save();
        }
    }

    #endregion Public Properties

    #region Private Properties

    //Ajusta a l'idioma seleccionat. Predeterminat si fos per al cas contrari.

    private static string CurrentLanguage
    {
        get { return currentLanguage; }
        set
        {
            if (value != null && value.Trim() != string.Empty)
            {
                currentLanguage = value;
                currentlocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;
                if (currentlocalizationText == null)
                {
                    Debug.LogWarningFormat("ERROR. Missing locale, loading English", currentLanguage);
                    currentLanguage = SystemLanguage.English.ToString();
                    currentlocalizationText = Resources.Load(STR_LOCALIZATION_PREFIX + currentLanguage, typeof(TextAsset)) as TextAsset;

                }
                if (currentlocalizationText != null)
                {
                    currentLanguageFileHasBeenFound = true;
                    string[] lines = currentlocalizationText.text.Split(new string[] { "\r\n", "\n\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                    CurrentLanguageStrings.Clear();
                    for (int i=0; i < lines.Length; i++)
                    {
                        string[] pairs = lines[i].Split(new char[] { '\t', '=' }, 2);
                        if (pairs.Length == 2)
                        {
                            CurrentLanguageStrings.Add(pairs[0].Trim(), pairs[1].Trim());
                        }
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Locale language '{0}' not found!", currentLanguage);
                }
            }
        }
    }

    #endregion Private Properties

    #region Public Methods

    //Retorna els textos regionals mitjançant el codi ID de cada idioma

    public static string GetLocalizedStrring(string key)
    {
        if (CurrentLanguageStrings.ContainsKey(key))
            return CurrentLanguageStrings[key];
        else
            return string.Empty;
    }

    //Actualitza totes les components de l'idioma actual

    public static void SetCurrentLanguage(SystemLanguage language)
    {
        CurrentLanguage = language.ToString();
        PlayerLanguage = language;
        ScrLocalization[] allTexts = GameObject.FindObjectsOfType<ScrLocalization>();
        for (int i = 0; i < allTexts.Length; i++) allTexts[i].UpdateLocale();

    }

    //Actualitza tots els GameObject associats a Text

    public void UpdateLocale()
    {
        //Aquest imprimirà el text de llengua en les barres de text
        if (!text) return;
        if (!System.String.IsNullOrEmpty(localizationKey) && CurrentLanguageStrings.ContainsKey(localizationKey))
            text.text = CurrentLanguageStrings[localizationKey].Replace(@"\n", "" + '\n');

        //Aquest imprimirà el text de llengua en els diàlegs
        if (!System.String.IsNullOrEmpty(localizationKey_inDialogue) && CurrentLanguageStrings.ContainsKey(localizationKey_inDialogue))
            text.text = CurrentLanguageStrings[localizationKey_inDialogue].Replace(@"\n", "" + '\n');

    }

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        if (!currentLanguageHasBeenSet)
        {
            currentLanguageHasBeenSet = true;
            SetCurrentLanguage(PlayerLanguage);

        }
        UpdateLocale();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion Private Methods
}
