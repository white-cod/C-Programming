#include <iostream>
#include "Client.h"
#include "Printer.h"
using namespace std;

int main()
{
    Client Emily(3, 10);
    Client Michael(8, 7);
    Client JessicaC(1, 3);
    Client David(5, 10);
    Client Robert(9, 2);
    Client Jennifer(4, 6);
    Printer P(3);
    P.setQueue(Emily);
    P.setQueue(Michael);
    P.setQueue(JessicaC);
    P.setQueue(David);
    P.setQueue(Robert);
    P.setQueue(Jennifer);
    P.print();
    return 0;
}