using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Structure : MonoBehaviour
{
    public StructureSo structureSo; // can change to prefabs
    int level = 1;
    int levelUpePrice;
    float levelUpeTime;

    GameObject building;

    float timer = 0;

    public int LevelUpePrice { get => levelUpePrice; }
    public int Level { get => level; }
    public float LevelUpeTime { get => levelUpeTime; }

    private void Awake() //de pronto es un start. att: serna // culpa de serna
    {
        gameObject.name = structureSo.name;
        building = Instantiate(structureSo.building, transform);
        levelUpeTime = structureSo.initialLevelUpTime;
        levelUpePrice = structureSo.initialLevelUpPrice;
    }

    public void Demolish()
    {
        StartCoroutine(Demolish_());
    }
    private IEnumerator Demolish_()
    {
        //ParticleSystem .Play();
        //yield return new WaitWhile(() => ParticleSystem .isPlaying)

        yield return null;
        Destroy(gameObject);
    }

    public void LevelUp()
    {
        StartCoroutine(Demolish_());
    }
    private IEnumerator LevelUp_()
    {
        //lock production
        //set level up vfx

        while (levelUpeTime > timer)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        //ParticleSystem .Play();
        //change bulding mesh;
        //yield return new WaitWhile(() => ParticleSystem .isPlaying)

        yield return null;

        level++;
        levelUpePrice = (int)(levelUpePrice * 1.4f);
        levelUpeTime = levelUpeTime * 1.4f;

        timer = 0;
    }

    public void Action()
    {
         building.GetComponent<IAction>().Action();
    }
}