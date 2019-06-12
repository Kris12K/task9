using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9__24_
{
    //двунаправленный список
    public class DoubleLinkedList<T> : IEnumerable<T>
        where T:IComparable<T>
    {
        private DoubleNode<T> head;//первый элемент списка
        private DoubleNode<T> tail;//последний элемент списка
        private int count;//количество элементов

        public int Count { get { return count; } }//количество элементов

        //добавление в начало списка
        public void AddInTheBeginning(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
            DoubleNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        //добавление в конец списка
        public void AddInTheEnd(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);

            if (count == 0)
            {
                head = node;
                tail = head;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
            count++;
        }

        //добавление в середину списка (в место, где следующий элемнт больше текущего
        public void AddInTheMiddle(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);

            if (count == 0)
            {
                head = node;
                tail = head;
            }
            else
            {
                DoubleNode<T> temp = head;

                if (count == 1)//неизвестно, был элемент положительный или отрицательный (добавим в конец)
                {
                    AddInTheEnd(data);
                }
                else
                {
                    while (temp.Data.CompareTo(temp.Next.Data) == 1)//находим место для вставки
                    {
                        if (temp.Next != null)
                            temp = temp.Next;
                        else
                            AddInTheEnd(data);
                    }

                    if (temp == head)
                        AddInTheBeginning(data);
                    else
                    {
                        DoubleNode<T> next = temp.Next;
                        temp.Next = node;
                        node.Previous = temp;
                        node.Next = next;
                        next.Previous = node;
                    }

                }
            }
            count++;
        }

        //удаление элемента
        public bool Remove(T data)
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        //проверка, содержится ли узел в списке
        public bool Contains(T data)
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        //поиск узла по значению
        public DoubleNode<T> Find(T data)
        {
            if (Contains(data))
            {
                DoubleNode<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        break;
                    current = current.Next;
                }
                return current;
            }
            else return null;
        }
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
    }
}
