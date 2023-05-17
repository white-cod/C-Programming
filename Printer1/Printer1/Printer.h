#pragma once
#ifndef PRINTER_H
#define PRINTER_H
#include "Client.h"
#include <iostream>
#include <stdlib.h>
using namespace std;

struct user
{
    int id;
    int time;
};

class Printer
{
public:
    Printer();
    Printer(int);
    virtual ~Printer();
    void setQueue(const Client);
    void resize();
    void print()const;
    void insert(const Client);
protected:
    Client* queue;
    user* users;
    int count;
    int max;
};
#endif 