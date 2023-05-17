#include "Printer.h"

Printer::Printer() {}

Printer::Printer(int c)
{
    queue = (Client*)malloc(sizeof(Client) * c);
    users = (user*)malloc(sizeof(user) * c);
    count = 0;
    max = c;
}
Printer::~Printer()
{
    free(queue);
    free(users);
}

void Printer::resize()
{
    queue = (Client*)realloc(queue, max * 2 * sizeof(Client));
    users = (user*)realloc(users, max * 2 * sizeof(user));
    max *= 2;
}

void Printer::setQueue(const Client A)
{
    if (count == 0)
    {
        queue[0] = A;
        users[0].id = count + 1;
        users[0].time = A.pages;
        ++count;
    }
    else
    {
        if (count < max)
        {
            insert(A);
        }
        else
        {
            resize();
            insert(A);
        }
    }
}

void Printer::insert(const Client A)
{
    int indicator = 1;
    Client temp_client;
    user temp_user;
    for (int i = 0; i < count; ++i)
    {
        if (A.prior > queue[i].prior)
        {
            for (int j = count - 1; j >= i; --j)
            {
                queue[j + 1] = queue[j];
                users[j + 1] = users[j];
            }
            queue[i] = A;
            users[i].id = count + 1;
            users[i].time = A.pages;
            ++count;
            indicator = 0;
            break;
        }
    }
    if (indicator)
    {
        queue[count] = A;
        users[count].id = count + 1;
        users[count].time = A.pages;
        ++count;
    }
}
void Printer::print()const
{
    for (int i = 0; i < count; ++i)
    {
        cout << "id " << users[i].id << endl;
        cout << "priority " << queue[i].prior << endl;
        cout << "time " << users[i].time << endl;
        cout << endl;
    }
}