// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
PowerCollections.Stack<int> stack = new PowerCollections.Stack<int>();
Console.WriteLine(stack.Count);
stack.Push(0);
stack.Push(1);
stack.Push(2);
Console.WriteLine(stack.Count);
Console.WriteLine(stack.Pop());

Console.WriteLine(stack.Capacity);

Console.WriteLine(stack.Count);