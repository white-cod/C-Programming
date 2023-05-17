#pragma once
#ifdef INTEGER
void IntFillArr(int*, int);
void IntPrintArr(int*, int);
void IntMinArr(int*, int);
void IntMaxArr(int*, int);
void IntSortArr(int*, int);
void IntChangeArr(int*);
#define Type int
#define Fill IntFillArr;
#define Print IntPrintArr;
#define Min IntMinArr;
#define Max IntMaxArr;
#define Sort IntSortArr;
#define Change IntChangeArr;
#endif
#ifdef DOUBLE
void FloatFillArr(double*, int);
void FloatPrintArr(double*, int);
void FloatMinArr(double*, int);
void FloatMaxArr(double*, int);
void FloatSortArr(double*, int);
void FloatChangeArr(double*);
#define Type double
#define Fill FloatFillArr;
#define Print FloatPrintArr;
#define Min FloatMinArr;
#define Max FloatMaxArr;
#define Sort FloatSortArr;
#define Change FloatChangeArr;
#endif
#ifdef CHAR
void CharFillArr(char*, int);
void CharPrintArr(char*, int);
void CharMinArr(char*, int);
void CharMaxArr(char*, int);
void CharSortArr(char*, int);
void CharChangeArr(char*);
#define Type char;
#define Fill CharFillArr;
#define Print CharPrintArr;
#define Min CharMinArr;
#define Max CharMaxArr;
#define Sort CharSortArr;
#define Change CharChangeArr;
#endif
