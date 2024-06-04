#pragma once
#include "baseList.h"

class LinkedList : public BaseList {
private:
	class Node {
	public:
		int Data;
		Node* Next;
		
		
		Node(int data);
	};

	Node* head;
	Node* find(int position);

protected:
	BaseList* emptyClone() override;

public:
	LinkedList();
	~LinkedList() override;

	int& operator[](int index) override;
	void add(int item) override;
	void insert(int item, int position) override;
	void deleteItem(int position) override;
	void clear() override;
	void print() override;
	void sort() override;
};