#include "baseList.h"
int BaseList::createCount = 0;
int BaseList::destroyCount = 0;

int BaseList::count() const {
	return lenght;
}

int BaseList::CreateCount() {
	return createCount;
}

int BaseList::DestroyCount() {
	return destroyCount;
}

void BaseList::Assign(BaseList& sourse) {
	clear();
	for (int i = 0; i < sourse.count(); i++) {
		add(sourse[i]);
	}
}

void BaseList::AssignTo(BaseList& dest) {
	dest.Assign(*this);
}

BaseList* BaseList::clone() {
	BaseList* clone = emptyClone();
	clone->Assign(*this);
	return clone;
}

void BaseList::sort() {
	int left = 0;
	int right = lenght - 1;

	while (left < right) {
		for (int i = left; i < right; i++) {
			if ((*this)[i] > (*this)[i + 1]) {
				int temp = (*this)[i];
				(*this)[i] = (*this)[i + 1];
				(*this)[i + 1] = temp;
			}
		}
		right--;

		for (int i = right; i > left; i--) {
			if ((*this)[i - 1] > (*this)[i]) {
				int temp = (*this)[i - 1];
				(*this)[i - 1] = (*this)[i];
				(*this)[i] = temp;
			}
		}
		left++;
	}
}

bool BaseList::equals(BaseList& list) {
	if (this->count() != list.count()) {
		return false;
	}
	for (int i = 0; i < lenght; i++) {
		if ((*this)[i] != list[i]) {
			return false;
		}
	}
	return true;
}