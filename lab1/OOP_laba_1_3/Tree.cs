using OOP_laba_1_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba_1_3
{
    class Node
    {
        // Свойство для хранения значения узла
        public double Value { get; set; }
        // Список дочерних узлов
        public List<Node> Children { get; set; }

        // Конструктор для узла без потомков
        public Node(double value)
        {
            Value = value;
            Children = new List<Node>();
        }

        // Конструктор для узла с потомками
        public Node(double value, List<Node> children)
        {
            Value = value;
            Children = children;
        }
        //Добавление потомка
        public void AddChild(Node node)
        {
            Children.Add(node);
        }

        // Метод для печати всех значений узла и его потомков
        public void PrintAllValues()
        {
            Console.WriteLine(Value);

            if(Children != null)
            {
                foreach (var child in Children)
                {
                    child.PrintAllValues();
                }
            }
        }
    }
}

