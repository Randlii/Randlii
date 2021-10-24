#include <stdio.h>
int main()
{
	int m;
	int i;
	int s;
	int l;

	s = 1;
	i = 1;
	printf("Введите обратный факториал ");
	scanf(" %d",&m);
	if(m <= 0)
	{
		printf("Неверное значение");
		return 0;
	}
	while(m != i)
	{
		s = s * i;
		if(s == m)
			break;
		i++;
	}	
	if(s == m)
		printf("Это факториал %d", i);
	else
		printf("Это не факториал");
}
