#pragma once
#include <iostream>

class BaseList {
protected: 
	int lenght = 0;
	virtual BaseList* emptyClone() = 0;

public:
	int count() const;
	virtual ~BaseList() {};

	virtual void add(int item) = 0;
	virtual void insert(int item, int position) = 0;
	virtual void deleteItem(int position) = 0;
	virtual void clear() = 0;
	virtual void print() = 0;
	virtual int& operator[](int index) = 0;

	void Assign(BaseList& sourse);
	void AssignTo(BaseList& dest);
	BaseList* clone();
	virtual void sort();
	bool equals(BaseList& list);
};