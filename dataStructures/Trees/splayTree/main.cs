// S - O(n)
public class SplayTree {
    private class Node {
        public int key, value;
        public Node left, right;
        public Node(int key, int value){
            this.key = key;
            this.value = value;
        }
    }

    private Node root;

    public SplayTree(){ root = null; }

    public int Size(){ return SizeHelper(root); }

    private int SizeHelper(Node node){
        if(node == null){ return 0; }
        else { return 1 + SizeHelper(node.left) + SizeHelper(node.right); }
    }

    public int Height(){ return HeightHelper(root); }

    private int HeightHelper(Node node){
        if(node == null){ return -1; }
        return 1 + Math.Max(HeightHelper(node.left), HeightHelper(node.right));
    }

    private Node Splay(Node node, int key){
        if(node == null){ return null; }

        if(key < node.key){
            if(node.left == null){ return node; }
            if(key < node.left.key){
                node.left.left = Splay(node.left.left, key);
                node = RotateRight(node);
            } else if(key > node.left.key){
                node.left.right = Splay(node.left.right, key);
                if(node.left.right != null){
                    node.left = RotateLeft(node.left);
                }
            }
            if(node.left == null){ return node; }
            else { return RotateRight(node); }
        } else if(key > node.key){
            if(node.right == null){ return node; }
            if(key > node.right.key){
                node.right.left = Splay(node.right.left, key);
                if(node.right.left != null){
                    node.right = RotateRight(node.right);
                }
            } else if(key < node.right.key){
                node.right.right = Splay(node.right.right, key);
                node = RotateLeft(node);
            }

            if(node.right == null){ return node; }
            else { return RotateLeft(node); }
        } else {
            return node;
        }
    }

    private Node RotateRight(Node node){
        Node newNode = node.left;
        node.left = newNode.right;
        newNode.right = node;
        return newNode;
    }

    private Node RotateLeft(Node node){
        Node newNode = node.right;
        node.right = newNode.left;
        newNode.left = node;
        return newNode;
    }

    private Node FindMin(Node node){
        while(node.left != null){
            node = node.left;
        }
        return node;
    }

    private Node RemoveHelper(Node node, int key){
        if(node == null) return null;

        if(key < node.key){
            node.left = RemoveHelper(node.left, key);
        } else if(key > node.key){
            node.right = RemoveHelper(node.right, key);
        } else {
            if(node.left == null) return node.right;
            if(node.right == null) return node.left;

            Node minRight = FindMin(node.right);
            node.key = minRight.key;
            node.value = minRight.value;
            node.right = RemoveHelper(node.right, minRight.key);
        }

        return node;
    }

    // T - O(logn)
    public bool Find(int key){ return FindHelper(key) != null; }

    private int FindHelper(int key){
        root = Splay(root, key);
        if(key == root.key){ return root.value; }
        else { return null; }
    }

    // T - O(logn)
    public void Insert(int key, int value){
        if(root == null){
            root = new Node(key, value);
            return;
        }

        root = Splay(root, key);

        if(key < root.key){
            Node newNode = new Node(key, value);
            newNode.left= root.left;
            newNode.right = root;
            root.left = null;
            root.right = newNode;
            root = newNode;
        } else if(key > root.key){
            Node newNode = new Node(key, value);
            newNode.right = root.right;
            newNode.left = root;
            root.right = null;
            root = newNode;
        } else {
            root.value = value;
        }
    }

    // T - O(logn)
    public void Remove(int key){
        if(root == null){ return; }

        root = Splay(root, key);

        if(key == root.key){
            if(root.left == null){
                root = root.right;
            } else if(root.right == null){
                root = root.left;
            } else {
                Node minRight = FindMin(root.right);
                root.key = minRight.key;
                root.value = minRight.value;
                root.right = RemoveHelper(root.right, minRight.key);
            }
        }
    }
}