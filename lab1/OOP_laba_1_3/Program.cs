using OOP_laba_1_3;

Node tree1 = new Node(1);
Node tree2 = new Node(11);
Node tree3 = new Node(12);
Node tree4 = new Node(13);
Node tree5 = new Node(111);
Node tree6 = new Node(1111);

tree1.AddChild(tree2);
tree1.AddChild(tree3);
tree1.AddChild(tree4);
tree2.AddChild(tree5);
tree5.AddChild(tree6);

tree1.PrintAllValues();