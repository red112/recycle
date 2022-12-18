using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Rigidbody[] characters;
    public int type;

    float hit_power = 4f;


    Feeder feeder;
    // Start is called before the first frame update
    void Start()
    {
        feeder = GetComponentInParent<Feeder>();
        Init();
    }

    private void LateUpdate()
    {
        if (transform.position.z == 4)
        {
            transform.Translate(0, 0, feeder.blockCount * feeder.blockSize * -1);
            Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        type = Random.Range(0, 3);
        for (int index=0; index < characters.Length; index++)
        {
            characters[index].gameObject.SetActive(type == index);
        }
        StartCoroutine(InitPhysics());
    }

    IEnumerator InitPhysics()
    {
        characters[type].isKinematic = true;
        yield return new WaitForFixedUpdate();

        characters[type].velocity = Vector3.zero;
        characters[type].angularVelocity = Vector3.zero;
        yield return new WaitForFixedUpdate();

        characters[type].transform.localPosition = Vector3.zero;
        characters[type].transform.localRotation = Quaternion.identity;

    }

    public bool Check(int selectType)
    {
        bool resutl = type == selectType;

        if(true)//result)
            StartCoroutine(Hit());

        return resutl;
    }

    IEnumerator Hit()
    {
        characters[type].isKinematic = false;
        yield return new WaitForFixedUpdate();


        int ran = Random.Range(0, 2);
        Vector3 forceVec = Vector3.zero;
        Vector3 torqueVec = Vector3.zero;

        switch (ran)
        {
            case 0:
                forceVec = (Vector3.right + Vector3.up*2f) * hit_power;
                torqueVec = (Vector3.forward + Vector3.down) * hit_power;
                characters[type].AddForce(forceVec, ForceMode.Impulse);
                characters[type].AddTorque(torqueVec, ForceMode.Impulse);
                break;

            case 1:
                forceVec = (Vector3.left + Vector3.up*2f) * hit_power;
                torqueVec = (Vector3.back + Vector3.up) * hit_power;
                characters[type].AddForce(forceVec, ForceMode.Impulse);
                characters[type].AddTorque(torqueVec, ForceMode.Impulse);
                break;
        }
    }
}
