#include "Header.h"

int main()
{ 
    myString ms1("String");
    myString ms2("String");
    cout << (ms1 == ms2) << endl;
    ms1 = "newString";
    cout << ms1 << endl;
    cout << (ms1 != ms2) << endl;
    ms1 = ms2;
    myBitStr mbs1("BitStr");
    cout << "Bit String created " << mbs1 << endl;
    myBitStr mbs2("0");
    cout << "Bit String 2 created " << mbs2 << endl;
    myBitStr mbs3;
    mbs3 = mbs1 + mbs2;
    cout << "summand of bit strings is " << mbs3 << endl;
    cout << (mbs1 == mbs2) << endl;
}