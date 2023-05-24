#ifndef QUEUE_H_
#define QUEUE_H_

#include <memory>
#include <stdexcept>

template <typename T> class Queue {
  public:
    struct Node {
      T value;
      std::unique_ptr<Node> next;
    };

    Queue();
    Queue(const Queue&) = delete;
    Queue& operator=(const Queue&) = delete;
    ~Queue() = default;

    // T(1)
    // Returns if Queue is empty.
    bool IsEmpty();

    // T(1)
    // Returns the size of the queue.
    int Count();

    // T(1)
    // Return the item in the front of the queue without
    // removing it from the structure.
    T Peak();

    // T(1)
    // Insert an item into the end of queue.
    void Enqueue(T value);

    // T(1)
    // Return the item from the front of the queue and removes
    // it from the structure.
    T Dequeue();

  private:
    std::unique_ptr<Node> head;

    // Tail is raw pointer for ease of manipulating pointer
    // logic with the unique_ptr head node.
    Node* tail;
    int size;
};

template <typename T>
Queue<T>::Queue() {
  head = nullptr;
  tail = nullptr;
  size = 0;
}

template <typename T>
bool Queue<T>::IsEmpty() {
  return size == 0 || head == nullptr || tail == nullptr;
}

template <typename T>
int Queue<T>::Count() {
  return size;
}

template <typename T>
T Queue<T>::Peak() {
  return head->value;
}

template <typename T>
void Queue<T>::Enqueue(T value) {
  std::unique_ptr<Node> new_node = std::make_unique<Node>();
  new_node->value = value;
  Node* new_node_ptr = new_node.get();

  if (tail) {
    tail->next = std::move(new_node);
    tail = new_node_ptr;
  } else {
    head = std::move(new_node);
    tail = head.get();
  }
  size++;
}

template <typename T>
T Queue<T>::Dequeue() {
  if (IsEmpty()) {
    throw std::runtime_error("Cannot dequeue from an empty"
      "queue.");
  }

  T out_data = head->value;
  head = std::move(head->next);

  if (head == nullptr) {
    tail = nullptr;
  }

  size--;
  return out_data;
}

#endif // QUEUE_H_
