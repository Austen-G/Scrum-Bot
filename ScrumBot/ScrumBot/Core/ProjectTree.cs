


using System.Collections.Generic;

namespace ScrumBot.Core
{
    public class Node<T>
    {
        // parent node
        public Node<T> parent = null;

        // inner class for a value
        public T Value { get; set; }

        // list of children
        private List<Node<T>> children = new List<Node<T>>();

        // constructor methods
        public Node(T value)
        {
            Value = value;
        }
        public Node() { }


        // method to remove node from children list 
        public Node<T> addChild(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.parent = this;
            children.Add(newNode);
            return newNode;
        }

        // method to remove a given node from the children list
        public void removeChild(Node<T> n)
        {
            this.children.Remove(n);
        }

        public T getValue()
        {
            return this.Value;
        }
        public void setValue(T value)
        {
            this.Value = value;
        }

        public Node<T> getParent()
        {
            return this.parent;
        }
        public void setParent(Node<T> par)
        {
            this.parent = par;
        }


    }
}