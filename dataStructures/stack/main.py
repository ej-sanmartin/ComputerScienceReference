"""Stack implementation in Python."""

from typing import Any, List


class Stack:
    """A stack data structure implemented using a list."""

    def __init__(self) -> None:
        """Initialize an empty stack."""
        self.items: List[Any] = []

    def push(self, item: Any) -> None:
        """Add an item to the top of the stack.

        Args:
            item: The item to add to the stack.
        """
        self.items.append(item)

    def pop(self) -> Any:
        """Remove and return the item from the top of the stack.

        Returns:
            The item from the top of the stack.

        Raises:
            IndexError: If the stack is empty.
        """
        return self.items.pop()

    def contains(self, item: Any) -> bool:
        """Check if the stack contains a specific item.

        Args:
            item: The item to search for.

        Returns:
            True if the item is in the stack, False otherwise.
        """
        return item in self.items

    def is_empty(self) -> bool:
        """Check if the stack is empty.

        Returns:
            True if the stack is empty, False otherwise.
        """
        return len(self.items) == 0

    def size(self) -> int:
        """Return the number of items in the stack.

        Returns:
            The number of items in the stack.
        """
        return len(self.items)

    def peek(self) -> Any:
        """Return the item at the top of the stack without removing it.

        Returns:
            The item at the top of the stack, or None if empty.
        """
        if not self.is_empty():
            return self.items[-1]
        return None

    def get_stack(self) -> List[Any]:
        """Return a copy of the stack items.

        Returns:
            A list containing all items in the stack.
        """
        return self.items.copy()
