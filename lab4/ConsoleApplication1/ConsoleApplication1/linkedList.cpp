#include "linkedList.h"

LinkedList::Node::Node(int data) : Data(data), Next(nullptr) {}

LinkedList::LinkedList() {
	head = nullptr;
	createCount++;
}

LinkedList::~LinkedList() {
	clear();
	destroyCount++;
}

LinkedList::Node* LinkedList::find(int position) {
	if (position < 0 || position >= lenght) {
		return nullptr;
	}

	int i = 0;
	Node* currentNode = head;
	while (currentNode != nullptr && i < position) {
		currentNode = currentNode->Next;
		i++;
	}
	if (i == position) {
		return currentNode;
	}
	else {
		return nullptr;
	}
}

void LinkedList::add(int item) {
	if (head == nullptr) {
		head = new Node(item);
	}
	else {
		Node* tail = find(lenght - 1);
		tail->Next = new Node(item);
	}
	lenght++;
}

void LinkedList::insert(int item, int position) {
	
	if (position == lenght && position == 0) add(item);

	else if (position == lenght) add(item);

	else if (position < lenght)
	{
		if (position == 0)
		{
			Node* head_temp = head;
			head = new Node(item);
			head->Next = head_temp;
			lenght++;
		}

		else
		{
			Node* prev = find(position - 1);
			Node* curr = find(position);
			Node* insr = new Node(item);
			insr->Next = curr;
			prev->Next = insr;
			lenght++;
		}
	}
}

void LinkedList::deleteItem(int position) {
	if (position >= lenght || position < 0) {
		return;
	}
	if (position == 0 && head != nullptr) {
		head = head->Next;
		lenght--;
		return;
	}
	Node* prevNode = find(position - 1);
	Node* currentNode = find(position);
	if (currentNode->Next != nullptr) {
		prevNode->Next = currentNode->Next;
		delete currentNode;
	}
	else {
		prevNode->Next = nullptr;
		delete currentNode;
	}
	lenght--;
}

void LinkedList::clear() {
	while (head != nullptr) {
		Node* temp = head;
		head = head->Next;
		delete temp;
	}
	lenght = 0;
}

void LinkedList::print() {
	Node* currentNode = head;
	while (currentNode != nullptr) {
		std::cout << currentNode->Data << " ";
		currentNode = currentNode->Next;
	}
}

void LinkedList::sort() {
	Node* currentNode = head;
	for (int i = 0; i < lenght - 1; i++) {
		Node* nextNode = currentNode->Next;
		for (int j = i + 1; j < lenght; j++) {
			if (currentNode->Data > nextNode->Data) {
				int temp = currentNode->Data;
				currentNode->Data = nextNode->Data;
				nextNode->Data = temp;
			}
			nextNode = nextNode->Next;
		}
		currentNode = currentNode->Next;
	}
}

BaseList* LinkedList::emptyClone() {
	return new LinkedList;
}

int& LinkedList::operator[](int index) {
	static int invalidIndex = 0;
	if (index >= lenght || index < 0) {
		return invalidIndex;
	}
	Node* currentNode = find(index);
	return currentNode->Data;
}