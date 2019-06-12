using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9__24_
{
    //узел двунаправленного списка
    public class DoubleNode<T>
    {
        //конструктор с параметром
        public DoubleNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }//значение узла
        public DoubleNode<T> Previous { get; set; } //ссылка на предыдущий узел
        public DoubleNode<T> Next { get; set; } //ссылка на следующий узел
    }
}
