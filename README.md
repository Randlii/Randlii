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
