#ifndef STACK_H_
#define STACK_H_

#include <memory>
#include <stdexcept>

// Generalized implementation of the stack data structure.
// The stack is a structure that follows the Last-In-First-Out
// (LIFO) principle, similar to a stack of objects in real life.
// Elements are added and removed from the top of the stack.
// Stacks are commonly used in function calls for programming
// languages, expression evaluation, undo/redo functionality,
// and backtracking algorithms to name a few. They provide
// efficient insertions and removals and are a fundamental tool
// in Computer Science.
template <typename T> class Stack {
public:
  struct Node {
    T value;
    std::unique_ptr<Node> next;
  };

  Stack();
  Stack(const Stack&) = delete;
  Stack& operator=(const Stack&) = delete;
  ~Stack() = default;

  // T(1)
  // Check if stack is empty.
  bool IsEmpty();

  // T(1)
  // Returns the number of elements in the stack.
  int Count();

  // T(1)
  // Returns the element on the top of the stack without
  // removing said element.
  T Peak();

  // T(1)
  // Add an element to the top of the stack.
  void Push(T value);

  // T(1)
  // Returns the element on the top of the stack and
  // removes said element from the stack.
  T Pop();

  // T(n), n being the size of the stack.
  // Inconvenient since stacks are fastest when only
  // interacting with the top item of the stack.
  // However, worth having to ensure items are indeed
  // pushed onto the stack.
  bool Contains(T value);

private:
  std::unique_ptr<Node> head;
  int size;
};

template <typename T>
Stack<T>::Stack() {
  head = nullptr;
  size = 0;
}

template <typename T>
bool Stack<T>::IsEmpty() {
  return head == nullptr && size == 0;
}

template <typename T>
int Stack<T>::Count() {
  return size;
}

template <typename T>
T Stack<T>::Peak() {
  return head->value;
}

template <typename T>
void Stack<T>::Push(T value) {
  std::unique_ptr<Node> new_node = std::make_unique<Node>();
  new_node->value = value;
  size++;
  new_node->next = std::move(head);
  head = std::move(new_node);
}

template <typename T>
T Stack<T>::Pop() {
  if (IsEmpty()) {
    throw std::runtime_error("Stack is empty. Trying to retrieve"
      " a value from an empty stack.");
  }
  
  T top_data = head->value;
  head = std::move(head->next);
  size--;
  return top_data;
}

template <typename T>
bool Stack<T>::Contains(T value) {
  Node* iter = head.get();

  while (iter != nullptr) {
    if (iter->value == value) {
      return true;
    }
    iter = iter->next.get();
  }
  
  return false;
}

#endif // STACK_H_
