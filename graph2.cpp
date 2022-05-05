#include <iostream>
#include <fstream>
using namespace std;

const int INF = 30000;

typedef int* pInt;
pInt* W;
int N;

void ReadMatrix()
{
    ifstream F;
    int i, j;
    F.open("kruskal.dat");
        F >> N;
    W = new pInt[N];
    for (i = 0; i < N; i++)
        W[i] = new int[N];
    cout << "Весовая матрица графа: \n";
    cout << "   ";
    for (j = 0; j < N; j++) {
        cout.width(4);
        cout << (char)(j+65);
    }
    cout << endl;
    cout << endl;
    for (i = 0; i < N; i++) {
        cout.width(2);
        cout << (char)(i + 65) << " ";
        for (j = 0; j < N; j++) {
            F >> W[i][j];
            if (W[i][j] < 0) {
                W[i][j] = INF;
                cout << "   .";
            }
            else {
                cout.width(4);
                cout << W[i][j];
            }
        }
        cout << endl;
    }
    F.close();
    cout << endl;;
}

int main()
{
    int i, j, k, c, minDist, iMin, jMin;
    int* col;
    pInt* ostov;

    ReadMatrix();
    col = new int[N];
    ostov = new pInt[N];
    for (i = 0; i < N; i++)
        ostov[i] = new int[2];

    for (i = 0; i < N; i++) col[i] = i;

    for (k = 0; k < N - 1; k++) {
        minDist = INF + 100;
        for (i = 0; i < N; i++)
            for (j = 0; j < N; j++)
                if (col[i] != col[j] && W[i][j] < minDist)
                {
                    iMin = i; jMin = j; minDist = W[i][j];
                }
        ostov[k][0] = iMin;
        ostov[k][1] = jMin;
        c = col[jMin];
        for (i = 1; i < N; i++)
            if (col[i] == c)
                col[i] = col[iMin];
    }

    cout << "Минимальное остовное дерево графа: \n";
    for (i = 0; i < N - 1; i++)
        cout << "(" << (char)(ostov[i][0]+65) << "," <<
        (char)(ostov[i][1] + 65) << ")" << endl;

}
