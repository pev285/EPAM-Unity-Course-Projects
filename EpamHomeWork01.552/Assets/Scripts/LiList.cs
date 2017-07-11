using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiList {

    private GameObject data;
    private LiList previous;
    private LiList next;

    
    public LiList(GameObject go, LiList prev, LiList nxt)
    {
        this.data = go;
        this.previous = prev;
        this.next = nxt;
    }

    public GameObject  getData()
    {
        return this.data;
    }

    public LiList getNext()
    {
        return this.next;
    }

    public LiList getPrevious()
    {
        return this.previous;
    }

    public LiList getNodeAt(int index)
    {
        if (index < 0)
        {
            return null;
        }

        LiList cur = findHead();

        int i = 0; 

        while (i < index && cur != null)
        {
            cur = cur.next;
            i++;
        }

        return cur;
    }

    public int getSize()
    {
        LiList cur = findHead();
        int len = 0;

        while (cur != null)
        {
            len++;
            cur = cur.next;
        }

        return len;
    }

    public LiList findHead()
    {
        LiList el = this;
        LiList prev = el.previous;


        while (prev != null)
        {
            el = prev;
            prev = el.previous;
        }

        return el;
    }

    public LiList findTail()
    {
        LiList el = this;
        LiList nxt = el.next;

        while(nxt != null)
        {
            el = nxt;
            nxt = el.next;
        }

        return el;
    }



    public LiList AddFirst(GameObject go)
    {
        LiList head = this.findHead();

        LiList newHead = new LiList(go, null, head);

        head.previous = newHead;

        return newHead;
    }

    public LiList AddLast(GameObject go)
    {

        LiList tail = this.findTail();


        LiList head = this.findHead();

        LiList newTail = new LiList(go, tail, null);

        tail.next = newTail;

        return head;
    }

    public LiList DeleteFirst()
    {
        LiList head = findHead();
        head = head.next;
        head.previous = null;
        return head;
    }

    public LiList DeleteLast()
    {
        LiList head = findHead();
        LiList tail = findTail();

        tail = tail.previous;
        tail.next = null;

        return head;
    }

    public LiList AddAt(int index, GameObject go)
    {

        if (index == 0)
        {
            return AddFirst(go);
        }

        LiList prevNode = getNodeAt(index - 1);

        if (prevNode == null)
        {
            prevNode = findTail();
        }

        LiList nextNode = prevNode.next;

        LiList newEl = new LiList(go, prevNode, nextNode);
        prevNode.next = newEl;

        if (nextNode != null)
        {
            nextNode.previous = newEl;
        }

        return newEl.findHead();
    }

    public LiList DeleteAt(int index)
    {
        LiList node = getNodeAt(index);

        LiList head = findHead();
        
        if (node != null)
        {
            LiList prev = node.previous;
            LiList nx = node.next;

            if(prev != null)
            {
                prev.next = nx;
            } else
            { // if head is to be deleted //
                head = nx;
            }

            if (nx != null)
            {
                nx.previous = prev;
            }
        }

        return head;
    }


    public LiList AppendList(LiList lst)
    {
        LiList thisTail = this.findTail();
        LiList thisHead = this.findHead();

        if (lst != null)
        {
            LiList otherHead = lst.findHead();

            thisTail.next = otherHead;
            otherHead.previous = thisTail;
        }


        return thisHead;
    }



} // END OF CLASS LILIST //

