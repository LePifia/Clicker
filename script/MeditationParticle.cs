using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationParticle : MonoBehaviour
{
    
    [SerializeField] GameObject Particle;
    [SerializeField] ParticleSystem aura;
    [SerializeField] Clicker gameClicker;
    private bool activation;
    private int emissionValue;

    // Start is called before the first frame update
    void Start()
    {
        emissionValue = 5;
        StartCoroutine(DesactivateParticles());
    }

    private void Update()
    {
        
    }

    public IEnumerator DesactivateParticles()
    {
        
        yield return new WaitForSeconds(3f);

        if (activation == false)
        {
            Particle.SetActive(false);
        }
        

        StartCoroutine(DesactivateParticles());

    }

    public void Meditation()
    {
        activation = true;

        Particle.SetActive(true);
        

        if (gameClicker.currentScore % 10 == 0)
        {

            var emission = aura.emission;

            var main = aura.main;

            var shape = aura.shape;

            //main.startSizeXMultiplier = emissionValue / 2;
            main.startSize = new ParticleSystem.MinMaxCurve(emissionValue / 25f, emissionValue / 100f);

            shape.radius = emissionValue / 1000f;



            emission.rateOverTime = emissionValue;

            emissionValue++;
        }
    }


}
