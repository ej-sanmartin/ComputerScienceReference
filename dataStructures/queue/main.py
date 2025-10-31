"""Queue implementation using a list in Python."""

from typing import Any, List


class Queue:
    """A queue data structure implemented using a list."""

    def __init__(self) -> None:
        """Initialize an empty queue."""
        self.items: List[Any] = []

    def enqueue(self, item: Any) -> None:
        """Add an item to the end of the queue.

        Args:
            item: The item to add to the queue.
        """
        self.items.insert(0, item)

    def dequeue(self) -> Any:
        """Remove and return the item from the front of the queue.

        Returns:
            The item from the front of the queue, or None if empty.
        """
        if not self.is_empty():
            return self.items.pop()
        return None

    def is_empty(self) -> bool:
        """Check if the queue is empty.

        Returns:
            True if the queue is empty, False otherwise.
        """
        return len(self.items) == 0

    def peek(self) -> Any:
        """Return the item at the front of the queue without removing it.

        Returns:
            The item at the front of the queue, or None if empty.
        """
        if not self.is_empty():
            return self.items[-1]
        return None

    def __len__(self) -> int:
        """Return the length of the queue."""
        return self.size()

    def size(self) -> int:
        """Return the number of items in the queue.

        Returns:
            The number of items in the queue.
        """
        return len(self.items)
