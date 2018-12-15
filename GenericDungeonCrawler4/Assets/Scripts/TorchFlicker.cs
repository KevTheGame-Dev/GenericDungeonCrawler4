using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour {

    //Credit to http://answers.unity.com/answers/1241501/view.html for base code. Personally modified.
    public float Reduction;
    public float Increase;
    public float RateDamping;
    public float Strength;
    public bool stopFlicker;

    Light lightSource;
    float baseIntensity;
    float baseRange;
    bool flickering;

	// Use this for initialization
	void Start () {
        this.lightSource = GetComponent<Light>();

        if(lightSource == null)
        {
            Debug.LogError("Can't find Light component!");
            return;
        }

        baseIntensity = lightSource.intensity;
        baseRange = lightSource.range;
        StartCoroutine(DoFlicker());
    
    }
	
	// Update is called once per frame
	void Update () {
		if(!stopFlicker && flickering)
        {
            StartCoroutine(DoFlicker());
        }
	}

    IEnumerator DoFlicker()
    {
        flickering = true;

        while (!stopFlicker)
        {
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, Random.Range(baseIntensity - Reduction, baseIntensity + Increase), Strength * Time.deltaTime);
            lightSource.range = Mathf.Lerp(lightSource.range, Random.Range(baseRange - Reduction, baseRange + Increase), Strength * Time.deltaTime);
            yield return new WaitForSeconds(RateDamping);
        }

        flickering = false;
    }
}
