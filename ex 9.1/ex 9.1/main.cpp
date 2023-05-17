#include "Header.h"
#include "Tree.cpp"


int main()
{
    BinTree<string> data_base;

    data_base.add_penalty("KH-45-12", "Violation A");
    data_base.add_penalty("KH-45-12", "Violation B");
    data_base.add_penalty("LV-13-07", "Violation A");
    data_base.add_penalty("KP-09-98", "Violation C");

    data_base.add_penalty("KH-45-12", "Violation D");
    data_base.add_penalty("LV-13-07", "Violation A");
    data_base.add_penalty("OV-76-42", "Violation D");

    data_base.give_paymant("KP-09-98", "Violation C");


    cout << "Key output: \n";
    data_base.print_by_key("KH-45-12");

    cout << "Output in range: \n";
    data_base.pint_in_diapason("OV-76-42", "LV-13-07");

    cout << "Output of the entire list: \n";
    data_base.print();

    return 0;
}