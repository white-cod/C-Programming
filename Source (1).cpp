#include<iostream>
using namespace std;

int** Create2D(int n, int m)
{
	int** mas = (int**)malloc(n * sizeof(int*));
	for (int i = 0; i < n; i++)
	{
		mas[i] = (int*)malloc(m * sizeof(int));
	}
	return mas;
}

int*** Create3D(int n, int m, int k)
{
	int*** mas = (int***)malloc(n * sizeof(int**));
	for (int i = 0; i < n; i++)
	{
		/*mas[i] = Create2D(m, k);*/
		mas[i] = (int**)malloc(m * sizeof(int*));
		for (int j = 0; j < m; j++)
		{
			mas[i][j] = (int*)malloc(k * sizeof(int));
		}
	}
	return mas;
}
void Delete2D(int** mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		free(mas[i]);
	}
	free(mas);
}
void Delete3D(int*** mas, int n, int m)
{
	for (int i = 0; i < n; i++)
	{
		//Delete2D(mas[i], m);
		for (int j = 0; j < m; j++)
		{
			free(mas[i][j]);
		}
		free(mas[i]);
	}
	free(mas);
}
void Rand(int** mas, int n, int m)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			mas[i][j] = rand() % 25;//*(*(mas+i)+j)
		}
	}
}
void Print(int** mas, int n, int m)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			cout << mas[i][j] << "\t";
		}
		cout << "\n";
	}
	cout << "\n";
}
int** Ins_Row(int** mas, int& n, int m, int pos)
{
	mas = (int**)realloc(mas, (n + 1) * sizeof(int*));
	for (int i = n; i > pos; i--)
	{
		mas[i] = mas[i - 1];
	}
	mas[pos] = (int*)malloc(m * sizeof(int));
	for (int i = 0; i < m; i++)
	{
		mas[pos][i] = 1000;
	}
	n++;
	return mas;
}
int** Del_Row(int** mas, int& n, int m, int pos)
{
	free(mas[pos]);
	for (int i = pos; i < n - 1; i++)
	{
		mas[i] = mas[i + 1];
	}
	mas = (int**)realloc(mas, (n - 1) * sizeof(int*));
	n--;
	return mas;
}
int** Ins_Stb(int** mas, int n, int& m, int pos)
{
	for (int i = 0; i < n; i++)
	{
		mas[i] = (int*)realloc(mas[i], (m + 1) * sizeof(int));
		for (int j = m; j > pos; j--)
		{
			mas[i][j] = mas[i][j - 1];
		}
		mas[i][pos] = 1000;
	}
	m++;
	return mas;
}

int** Del_Stb(int** mas, int n, int& m, int pos)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = pos; j < m-1; j++)
		{
			mas[i][j] = mas[i][j + 1];
		}
		mas[i] = (int*)realloc(mas[i], (m - 1) * sizeof(int));
	}
	m--;
	return mas;
}
int main() 
{

	int n, m;
	cout << "Vvedite n,m: ";
	cin >> n >> m;
	int** mas = Create2D(n, m);
	Rand(mas, n, m);
	Print(mas, n, m);
	mas = Del_Stb(mas, n, m, 2);
	Print(mas, n, m);
	Delete2D(mas, n);

}