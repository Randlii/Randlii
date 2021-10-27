#include <stdio.h>
int main()
{
	int m;
	int s;
	int n;

	s = 0;
	m = 0;
	printf("Vvedite chislo Armstronga:\n");
	scanf("%d",& m);
	n = m;
	while(m > 0)
	{
		s = (m % 10)* (m % 10) * (m % 10) + s;
		m = m / 10;
	}
	if(s == n)
		printf("Da, eto chislo Armstronga %d\n", n);
	else
		printf("Net, eto ne chislo Armstronga\n");

}
