using BinarySearchTree;

public class Program
{
    public static void Main()
    {
        BST tree = new BST();
        tree.InsertNode(50);
        tree.InsertNode(35);
        tree.InsertNode(40);
        tree.InsertNode(10);
        tree.InsertNode(55);
        tree.InsertNode(60);

        //Console.WriteLine(tree.DepthFinder(10));

        Console.WriteLine(tree.RoughBalance());
    }
}