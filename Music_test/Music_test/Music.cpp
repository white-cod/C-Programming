#include<iostream>
#include<Windows.h>
#include<conio.h>
using namespace std;
struct Music
{
	char Name[20];
	char Executor[20];
	char Album[20];
	double Long;
	int Year;
	char Ganr[20];					
	char Country[20];
};
Music Vvod()
{
	Music tmp;
	cout << "Enter the name of the song: ";
	gets_s(tmp.Name);
	cout << "Enter executor name: ";
	gets_s(tmp.Executor);
	cout << "Enter album name: ";
	gets_s(tmp.Album);
	cout << "Enter song length (min): ";
	cin >> tmp.Long;
	cin.ignore();
	cout << "Enter the year the song was released: ";
	cin >> tmp.Year;
	cin.ignore();
	cout << "Enter genre: ";
	gets_s(tmp.Ganr);
	cout << "Enter country: ";
	cin >> tmp.Country;
	return tmp;
}
void Add(Music*& mas, int& n)
{
	mas = (Music*)realloc(mas, (n + 1) * sizeof(Music));
	mas[n] = Vvod();
	n++;
}
void Show(Music tmp)
{
	cout << tmp.Name << "\t\t" << tmp.Executor << "\t\t" << tmp.Album << "\t\t" << tmp.Long << "\t\t" << tmp.Year << "\t\t" << tmp.Ganr << "\t\t" << tmp.Country << "\n";
}
void Print(Music* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		Show(mas[i]);
	}
}
void Find_Albom(Music* mas, int n, char* alb)
{
	bool f = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].Album, alb) == 0)
		{
			f = 1;
			Show(mas[i]);
			
		}
	}
	system("pause");
	if (f == 0)
	{
		cout << "No matches.\n";
	}
}
void Del(Music*& mas, int& n, char* Nazv)
{
	int k = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].Name, Nazv) == 0)
		{
			k = 1;
			for (int j = i; j < n - 1; j++)
			{
				mas[j] = mas[j + 1];
			}
			mas = (Music*)realloc(mas, (n - 1) * sizeof(Music));
			n--;
			i--;
		}
	}
	if (k == 0)
	{
		cout << "No matches.\n";
	}
	else
	{
		cout << "The deletion has taken place.\n";
	}
}

void Write_File(Music* mas, int n, const char* puth)
{
	FILE* pf;
	fopen_s(&pf, puth, "wb");
	if (pf)
	{
		fwrite(&n, sizeof(n), 1, pf);
		fwrite(mas, sizeof(mas[0]), n, pf);
		fclose(pf);
	}
	else
	{
		cout << "Error.\n";
	}
}
void Read_File(Music*& mas, int& n, const char* puth)
{
	FILE* pf;
	fopen_s(&pf, puth, "rb");
	if (pf)
	{
		fread(&n, sizeof(n), 1, pf);
		mas = (Music*)malloc(n * sizeof(Music));
		fread(mas, sizeof(mas[0]), n, pf);
		fclose(pf);
	}
	else
	{
		cout << "Error.\n";
	}
}
int main()
{
	setlocale(LC_ALL, "rus");
	char ch;
	int n = 0;
	Music* Catalog = NULL;
	char str[20];
	do
	{
		system("cls");
		cout << "MENU:\n";
		cout << "1-Adding a song.\n";
		cout << "2-Deleting a song.\n";
		cout << "3-Song base output.\n";
		cout << "4-Album Search\n";
		cout << "5-Write to file.\n";
		cout << "6-Reading from a file.\n";
		cout << "Esc-Exit\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");
			Add(Catalog, n);
			cout << "Song added.\n";
			Sleep(2000);
			break;
		case '2':system("cls");
			if (n != 0)
			{
				cout << "Enter the name of the song to be deleted: ";
				gets_s(str);
				Del(Catalog, n, str);
			}
			else
			{
				cout << "The directory is empty.\n";
			}
			Sleep(2000);
			break;
		case '3':system("cls");
			if (n != 0)
			{
				cout << "Name\t\t" << "Executor\t" << "Album\t\t" << "length (min)\t\t" << "Year\t\t" << "Ganr\t\t" << "Country\t\t" << endl;
				for (int i = 0; i < 115; i++)
				{
					cout << "=";
				}
				cout << endl;
				Print(Catalog, n);
				system("pause");
			}
			else
			{
				cout << "The directory is empty.\n";
				Sleep(2000);
			}
			break;
		case '4':system("cls");
			if (n != 0)
			{
				cout << "Album name: ";
				gets_s(str);
				Find_Albom(Catalog, n, str);
				break;
			}
			else
			{
				cout << "The directory is empty.\n";
			}
			system("pause");
			break;
		case '5':system("cls");
			if (n != 0)
			{
				Write_File(Catalog, n, "data.txt");
				cout << "The recording has been made.\n";
			}
			else
			{
				cout << "The directory is empty.\n";
			}
			Sleep(2000);
			break;
		case '6':system("cls");
			Read_File(Catalog, n, "data.txt");
			cout << "Reading done.\n";
			Sleep(2000);
			break;
		}
	} while (ch != 27);
	free(Catalog);
}