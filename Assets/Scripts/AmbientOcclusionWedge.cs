using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[ExecuteInEditMode]
public class AmbientOcclusionWedge : MonoBehaviour
{
    [SerializeField]
    Text textToUpdate;

    string displayString;

    public bool AOEnabled = false;
    public bool AOMaxDistance = false;
    public bool AOIndirect = false;
    public bool AODirect = false;

	private void Start()
	{
        if (textToUpdate !=null)
        {
            displayString = "Ambient Occlusion\n";
        }
	}

	// Update is called once per frame
	void Update()
    {
        if (textToUpdate != null)
        {
            displayString = "Ambient Occlusion";
            if (AOEnabled)
            {
                bool aoEnabled = LightmapEditorSettings.enableAmbientOcclusion;
                displayString = displayString + "\n     Enabled: " + aoEnabled;
            }

            if (AOMaxDistance)
            {
                float maxDistance = LightmapEditorSettings.aoMaxDistance;
                displayString = displayString + "\n     MaxDistance: " + maxDistance;
            }

            if (AOIndirect)
            {
                float indirect = LightmapEditorSettings.aoExponentIndirect;
                displayString = displayString + "\n     Indirect Contribution: " + indirect;
            }

            if (AODirect)
            {
                float direct = LightmapEditorSettings.aoExponentDirect;
                displayString = displayString + "\n     Direct Contribution: " + direct;
            }




            textToUpdate.text = displayString;
            //textToUpdate.text = "Ambient Occlusion \n    Enabled: " + aoEnabled +
                //"\n    MaxDistance:" + maxDistance +
                //"\n    Indirect: " + indirect +
                //"\n    Direct: " + direct;
        }
    }
}
