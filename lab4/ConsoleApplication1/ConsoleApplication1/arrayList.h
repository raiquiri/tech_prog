#pragma once
#include "baseList.h"

class ArrayList : public BaseList {
private:
	int size;
	int* buffer;
	void resize();

protected:
	BaseList* emptyClone() override;

public:
	ArrayList();
	~ArrayList() override;

	int& operator[](int index) override;
	void add(int item) override;
	void insert(int item, int positin) override;
	void deleteItem(int position) override;
	void clear() override;
	void print() override;
};