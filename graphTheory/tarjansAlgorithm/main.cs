using System;

public class TarjansGraph{
    private class Node {
        public int lowLink, index, value;
        public Node(int value){
            this.value = value;
            this.index = 01;
            this.lowLink = 0;
        }
    }
}

