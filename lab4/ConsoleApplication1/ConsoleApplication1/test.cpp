#include "arrayList.h"
#include "linkedList.h"
#include "ctime"

int main() {
	BaseList* arrayList = new ArrayList();
	BaseList* linkedList = new LinkedList();

	srand(static_cast<unsigned int>(time(0)));

	for (int i = 1; i < 10000; i++) {
		int factor = rand() % 4;
		int number = rand() % 100;
		int index = rand() % i;

		switch (factor) {
		case 0:
			arrayList->add(number);
			linkedList->add(number);
			break;
		case 1:
 			arrayList->insert(number, index);
			linkedList->insert(number, index);
			break;
		/*case 2:
			arrayList->deleteItem(index);
			linkedList->deleteItem(index);
			break;*/
		/*case 3:
			arrayList->clear();
			linkedList->clear();
			break;*/
		}
		
	}
		if (arrayList->equals(*linkedList)) {
			std::cout << "Accept #1\n";
		}
		/*arrayList->print();
		std::cout << "\n";
		linkedList->print();
		std::cout << "\n";*/

		linkedList->clear();
		arrayList->sort();
		linkedList->Assign(*arrayList);

		BaseList* arrayClone = arrayList->clone();

		if (arrayClone->equals(*linkedList)) {
			std::cout << "Accept #2\n";
		}

		//arrayList->print();
}