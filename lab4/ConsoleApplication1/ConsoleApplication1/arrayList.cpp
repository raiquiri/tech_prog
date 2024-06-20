#include "arrayList.h"

ArrayList::ArrayList() : size(4){
	buffer = new int[size];
	createCount++;
}

ArrayList::~ArrayList() {
	delete[] buffer;
	destroyCount++;
}

void ArrayList::add(int item) {
	if (lenght == size) {
		resize();
	}
	buffer[lenght] = item;
	lenght++;
}

void ArrayList::insert(int item, int position) {
	if (position == lenght && position == 0) add(item);

	else if (position == lenght) add(item);

	else if (position < lenght)
	{
		lenght++;
		if (lenght >= size) resize();

		for (int i = lenght - 1; i != position; i--)
		{
			buffer[i] = buffer[i - 1];
		}
		buffer[position] = item;
	}
}

void ArrayList::deleteItem(int position) {
	if (position >= lenght || position < 0) {
		return;
	}
	for (int i = position; i < lenght - 1; i++) {
		buffer[i] = buffer[i + 1];
	}
	lenght--;
}

void ArrayList::clear() {
	delete[] buffer;
	size = 4;
	buffer = new int[size];
	lenght = 0;
}

void ArrayList::print() {
	for (int i = 0; i < lenght; i++) {
		std::cout << buffer[i] << " ";
	}
}

BaseList* ArrayList::emptyClone() {
	return new ArrayList;
}

void ArrayList::resize() {
	size *= 2;
	int* newBuffer = new int[size];
	for (int i = 0; i < size / 2; i++) {
		newBuffer[i] = buffer[i];
	}
	delete[] buffer;
	buffer = newBuffer;
}

int& ArrayList::operator[] (int index) {
	static int invalidIndex = 0;
	if (index >= lenght || index < 0) {
		return invalidIndex;
	}
	return buffer[index];
}