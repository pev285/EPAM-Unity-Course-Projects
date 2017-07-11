using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVLTree {


    private Node root = null;


    private class Node
    {
        public Node left;
        public Node right;
        public Node parent;

        public int height;

        public int key;
        public Data data;

        public Node(Node parent, int key, Data data)
        {
            this.parent = parent;
            this.key = key;
            this.data = data;
        }

    } // End class Node //

    public class Data
    {
        public string text;
    } // End class Data //




    public AVLTree()
    {
    }


    public int GetHeight()
    {
        if (root == null)
        {
            return 0;
        }

        return root.height;
    }


    public Data Find(int key)
    {
        Node node = FindNode(key);

        if (node == null)
        {
            return null;
        }


        return node.data;
    }



    public bool Insert(int key, Data data)
    {
        Node node = FindNode(key);

        if (node != null)
        {
            return false;
        }

        node = FindParentNode(key);

        if (node  == null)
        {
            root = new Node(null, key, data);

            UpdateHeights(root);

            return true;
        }
        else if (key <= node.key)
        {
            if (node.left == null)
            {
                node.left = new Node(node, key, data);

                UpdateHeights(node);
                Balance(node);

                return true;
            } else
            {
                return false;
            }
        }
        else // key > node.key
        {
            if (node.right == null)
            {
                node.right = new Node(node, key, data);

                UpdateHeights(node);
                Balance(node);

                return true;
            }
            else
            {
                return false;
            }
        }

    } // Insert() //


    public bool Delete(int key)
    {


        Node node = FindNode(key);

        if (node == null)
        {
            return false;
        }

        DeleteNode(node);

        return true;
    }


    /// # PRIVATE # /// ############################################################################################## ///

        // returns parent //
    private Node DeleteNode(Node node)
    {
        if(node == null)
        {
            return null;
        }

        Node parent = null;

        if (node.left == null && node.right == null)
        {
            parent = node.parent;

            if (parent == null)
            {
                root = null;
                return null;
            }
            else if (parent.left == node)
            {
                parent.left = null;
            }
            else if (parent.right == node)
            {
                parent.right = null;
            }

        }
        else
        {
            Node descendant = null;

            if (node.right != null)
            {
                descendant = FindLeftmostDescendant(node.right);
            }
            else
            {
                descendant = FindRightmostDescendant(node.left);
            }

            node.key = descendant.key;
            node.data = descendant.data;

            parent = DeleteNode(descendant);

        }

        UpdateHeights(parent);
        Balance(parent);


        return parent;

    } // DeleteNode () //


    private Node FindLeftmostDescendant(Node root)
    {
        if (root == null)
        {
            return null;
        }

        Node cur = root;

        while (cur.left != null)
        {
            cur = cur.left;
        }


        return cur;
    }

    private Node FindRightmostDescendant(Node root)
    {
        if (root == null)
        {
            return null;
        }

        Node cur = root;

        while (cur.right != null)
        {
            cur = cur.right;
        }


        return cur;
    }




    private void UpdateHeights(Node node)
    {
        Node cur = node;


        while (cur != null)
        {
            int h = MaxHeight(cur.left, cur.right);

            cur.height = h + 1;

            cur = cur.parent;
        }

    }


    private Node FindNode(int key)
    {
        Node cur = root;

        while (cur != null && cur.key != key)
        {
            if (key <= cur.key)
            {
                cur = cur.left;
            }
            else
            {
                cur = cur.right;
            }

        }

        return cur;
    }


    private Node FindParentNode(int key)
    {
        Node cur = root;

        Node next = null;

        while (cur != null)
        {
            if (key <= cur.key)
            {
                next = cur.left;
            }
            else
            {
                next = cur.right;
            }

            if (next == null || next.key == key)
            {
                break;
            }

            cur = next;

        }

        return cur;
    } // FindParentNode() //



    private void SmallLeftRotation (Node root)
    {
        if (root == null || root.left == null)
        {
            return;
        }

        Node nr = root.right;

        Node B = nr.left;

        Node parent = root.parent;

        if (parent != null)
        {
            if (parent.left == root)
            {
                parent.left = nr;
            }
            else
            {
                parent.right = nr;
            }
        }

        root.parent = nr;
        root.right = B;

        nr.parent = parent;
        nr.left = root;

    } // SmallLeftRotation() //

    private void SmallRightRotation (Node root)
    {
        if (root == null || root.left == null)
        {
            return;
        }

        Node nr = root.left;

        Node B = nr.right;

        Node parent = root.parent;

        if (parent != null)
        {
            if (parent.left == root)
            {
                parent.left = nr;
            }
            else
            {
                parent.right = nr;
            }
        }

        root.parent = nr;
        root.left = B;

        nr.parent = parent;
        nr.right = root;

    }// SmallrightRotation() //

    private void Balance(Node node)
    {
        if (node == null)
        {
            return;
        }


        Node cur = node;

        while(cur != null)
        {
            Node prnt = cur.parent;

            if ( (MaxHeight(cur.left, cur.right) - MinHeight(cur.left, cur.right)) > 1 )
            {
                int lh = NodeHeight(cur.left);
                int rh = NodeHeight(cur.right);


                if (lh < rh)
                {
                    int rlh = NodeHeight(cur.right.left);
                    int rrh = NodeHeight(cur.right.right);

                    if (rlh > rrh)
                    {
                        SmallRightRotation(cur.right);
                        SmallLeftRotation(cur);
                    }
                    else if (rlh < rrh)
                    {
                        SmallLeftRotation(cur);
                    }
                    else // rlh == rrh
                    {
                        SmallLeftRotation(cur);
                    }
                }
                else // if (lh > rh )
                {
                    int llh = NodeHeight(cur.left.left);
                    int lrh = NodeHeight(cur.left.right);

                    if (llh > lrh)
                    {
                        SmallRightRotation(cur);
                    }
                    else if (llh < lrh)
                    {
                        SmallLeftRotation(cur.left);
                        SmallRightRotation(cur);
                    }
                    else // llh == lrh
                    {
                        SmallRightRotation(cur);
                    }
                }

            }


            cur = prnt;
        }


    } // Balance() //


    /// Static ///////////////// ******************************************************** ///

    /**
     * -1, if node is null
     * height of node subtree else
     */
    private static int NodeHeight(Node node)
    {
        if (node == null)
        {
            return -1;
        }

        return node.height;
    }


    private static int MaxHeight(Node n1, Node n2)
    {

        int h1 = NodeHeight(n1);
        int h2 = NodeHeight(n2);

        return h1 > h2 ? h1 : h2;

    }

    private static int MinHeight(Node n1, Node n2)
    {

        int h1 = NodeHeight(n1);
        int h2 = NodeHeight(n2);

        return h1 < h2 ? h1 : h2;

    }


} // * End Of Class * //
