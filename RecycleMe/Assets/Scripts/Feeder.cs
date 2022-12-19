using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeder : MonoBehaviour
{
    public int blockCount;
    public float blockSize;
    public int nowBlock;

    Block[] blocks;

    // Start is called before the first frame update
    void Start()
    {

        blocks = GetComponentsInChildren<Block>();
        Align();
        
    }

    void Align()
    {
        blockCount = blocks.Length;
        if(blockCount == 0)
        {
            Debug.Log("Not founded Blocks!");
            return;
        }

        blockSize = blocks[0].GetComponentInChildren<BoxCollider>().transform.localScale.z;

        for(int index=0; index < blockCount; index++)
        {
            blocks[index].transform.Translate(0, 0, index * blockSize * -1);
        }
    }

    IEnumerator Move()
    {
        float nextZ = transform.position.z + 2;

        while(transform.position.z < nextZ)
        {
            yield return null;
            transform.Translate(0, 0, Time.deltaTime * 20f);
 
        }

        transform.position = Vector3.forward * nextZ;
        nowBlock = (nowBlock + 1) % blockCount;
    }

    //[ContextMenu("Do Move")]
    public void Select(int selectType)
    {
        bool result = blocks[nowBlock].Check(selectType);

        if(result)
        {
            StartCoroutine(Move());
        }
        else
        {

        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
