#include <stdio.h>
int main()
{
	int m;
	int s;
	int i;

	i = 1;
	s = 1;
	m = 0;
	printf("Введите число: ");
	scanf("%d\n",& m);
	while(m > 0)
	{
		s = s * i;
		i = i + 2;
		m--;
	}
	printf("%d", s);
		
}
