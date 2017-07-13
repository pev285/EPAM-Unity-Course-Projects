using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListHolder {

    // The list head //
    private LiList listHead;
    //private LiList listTail;


    // Position to move list to //
    // (position of the list's head) //
    private Vector3 targetPosition;

    // Smooth movement variables //
    private static float epsilon = 0.02f;
    private Vector3 listVelocity;
    private float smoothTime;

    private float unitSize;

    public ListHolder(LiList l, float unitSize)
    {
        this.unitSize = unitSize;

        SetList(l);
    }

    public Vector3 GetTargetPosition()
    {
        return targetPosition;
    }

    public LiList GetList()
    {
        return listHead;
    }

    public void SetList(LiList l)
    {
        if (l != null)
        {
            this.listHead = l.findHead();

            targetPosition = this.listHead.getData().transform.position;
        } else
        {
            this.listHead = null;
            targetPosition = Vector3.zero;
        }
    }

    public void AppendList(LiList l)
    {
        this.listHead.AppendList(l);
    }

    public LiList CloneList()
    {
        if (listHead == null)
        {
            return null;
        }

        LiList current = listHead;
        LiList newList = null;

        while (current != null)
        {
            GameObject o = current.getData();

            GameObject copy = Object.Instantiate(o);

            LiList newNode = new LiList(copy, null, null);
            
            if (newList != null)
            {
                newList = newList.AppendList(newNode);
            }
            else
            {
                newList = newNode;
            }

            current = current.getNext();
        }

        return newList;
    } // End of CloneList() //

    public void MoveListTo(Vector3 position, float smoothTime = 0)
    {
        this.listVelocity = Vector3.zero;

        this.smoothTime = smoothTime;

        this.targetPosition = position;
    }


    public bool Moving()
    {

        if (listHead == null)
        {
            return false;
        }

        LiList curEl = listHead;
        GameObject headObj = curEl.getData();


        if ((targetPosition - headObj.transform.position).magnitude <= epsilon)
        {
            return false;
        } else
        {

            
            Vector3 newPosition = Vector3.SmoothDamp(headObj.transform.position, targetPosition, ref listVelocity, smoothTime);

            float num = 0;

            while (curEl != null)
            {
                GameObject o = curEl.getData();

                o.transform.position = new Vector3(newPosition.x + num, newPosition.y, newPosition.z);

                num += unitSize;

                curEl = curEl.getNext();
            }
        }


        return true;
    }// End of MOVING() //
	

    public void Rearrange()
    {
        if (listHead == null)
        {
            return;
        }

        LiList current = listHead;
        float num = 0;

        while (current != null)
        {
            GameObject o = current.getData();

            o.transform.position = new Vector3(targetPosition.x+num, targetPosition.y, targetPosition.z);

            num += unitSize;
            current = current.getNext();
        }
    }


    //////////////////////// intermediate list methods ////////////////////////

    public void AddLast(GameObject o)
    {
        if (listHead == null)
        {
            listHead = new LiList(o, null, null);
        }
        else
        {
            listHead = listHead.AddLast(o);
        }
    }



    public void AddAt(int index, GameObject go)
    {
        if (listHead == null)
        {
            AddLast(go);
        } else
        {
            listHead = listHead.AddAt(index, go);
        }


    }

    public GameObject DeleteLast()
    {
        if (listHead == null)
        {
            return null;
        }

        int size = listHead.getSize();

        return DeleteAt(size - 1);

    }


    public GameObject DeleteAt(int index)
    {

        if (listHead == null)
        {
            return null;
        }

        GameObject o = GetObjectAt(index);

        listHead = listHead.DeleteAt(index);

        return o;
    }

    public GameObject GetObjectAt(int index)
    {
        if(listHead == null)
        {
            return null;
        } else
        {
            LiList node = listHead.getNodeAt(index);

            if (node == null)
            {
                return null;
            } else
            {
                return node.getData();
            }
        }
    } // End of GetObjectAt() //

    public int GetSize()
    {
        if(listHead == null)
        {
            return 0;
        }

        return listHead.getSize();
    }



}// End Of Class //
