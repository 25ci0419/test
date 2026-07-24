#include <iostream>
using namespace std;
bool isChecked(int x) {
	if (x % 2 != 1)
	{
		if (x % 3 == 0) {
			return false;
		}
		else {
			return true;
		}
	}
	else {
		return false;
	}
}
int main() {
		int a = 0;
		cin >> a;
		if (isChecked(a)) { cout << "OK" << endl; }
		else { cout << "NG" << endl; }
}