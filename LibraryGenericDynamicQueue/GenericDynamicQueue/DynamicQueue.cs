using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtLibraries
{   
    public class DynamicQueue<T>
    {
        #region Atributes
        private Node First;
        private Node Last;
        private int Lenght;
        #endregion

        #region Constructor & destructor
        public DynamicQueue()
        {
            this.First = null;
            this.Last = null;
            this.Lenght = 0;
        }

        ~DynamicQueue()
        {

        }
        #endregion

        #region Methods  
        
        public T[] ToArray()
        {
            T[] _Array = new T[this.Lenght];
            for (int i = 1; i <= this.Lenght; i++)
            {
                Node auxnode = this.Find(i);

                _Array[i - 1] = auxnode.info;

            }

            return _Array;
        }

        private Node Find(int position)
        {
            Node auxnode = null;
            if (!Empty())
            {
                auxnode = this.First;
                for (int i = 1; i <= this.Lenght; i++)
                {
                    if (position == i)
                    {
                        break;
                    }
                    auxnode = auxnode.next;
                }
            }

            return auxnode;
        }

        public void Pop()
        {
            if (!Empty())
            {
                //Disassociates last node from the stack
                Node auxnode = this.First;
                this.First = this.First.next;
                auxnode.next = null;
                //deleted node in console
                //Console.Write(auxnode.info);
                //frees memory
                Release(auxnode);
                this.Lenght -= 1;
            }

        }

        //add a node to the stack
        public void Push(T value)
        {
            Node nw = new Node(value);
            nw.info = value;

            if (this.First == null)
            {
                //stack is empty
                nw.next = null;
                this.First = nw;
                this.Last = nw;

            }
            else
            {
                //there's an existing node
                this.Last.next = nw;
                this.Last = nw;
            }

            //Stack counter
            this.Lenght += 1;
        }

        public T Front()
        {

            Node auxnode = new Node();

            if (!Empty())
            {

                auxnode = this.First;

            }
            else
            {
                auxnode = null;
            }


            return auxnode.info;

        }

        public T Back()
        {
            Node auxnode = new Node();

            if (!Empty())
            {
                if (this.Lenght == 1)
                {
                    auxnode = this.First;
                }
                else
                {
                    auxnode = this.Last;
                }

            }
            else
            {
                auxnode = null;
            }


            return auxnode.info;

        }

        private void Release(Node node)
        {
            node = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        public void Print()
        {
            if (!Empty())
            {
                Node auxnode = this.First;
                // Iterate the queue
                while (auxnode != null)
                {
                    Console.WriteLine(auxnode.info);
                    // Take the next node
                    auxnode = auxnode.next;
                }
            }
            else
            {
                Console.WriteLine("There's not elements");
            }
        }

        public int StackLength()
        {
            return this.Lenght;
        }

        private bool Empty()
        {
            return (this.Lenght == 0);
        }
        #endregion

        private class Node
        {
            #region Atributes

            public Node(T info)
            {
                _next = null;
                _info = info;
            }

            public Node()
            {

            }

            private Node _next;
            public Node next
            {
                get { return _next; }
                set { _next = value; }
            }

            // T as private member data type.          
            private T _info;
            // T as return type of property.            
            public T info
            {
                get { return _info; }
                set { _info = value; }
            }

            #endregion

            #region Destructor
            ~Node()
            {
            }
            #endregion
        }

    }
}

