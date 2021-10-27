#include <stdio.h>
int main()
{
	int m;
	int s;
	int n;

	s = 0;
	m = 0;
	printf("Введите сколько рублей: ");
	scanf("%d",& m);
	n = m;
	if(m >= 100)
	{
		s = m % 10;
		m = m / 10;
		s  = s*10 + (m % 10);
	}
	if(m > 20)
	{
		s = m % 10;
		m = m / 10;
	}
	if(m < 20)
		s = m;
	if((s <= 20 && s >= 5) || s == 0)
		printf("%d Рублей\n", n);
	if(s == 1)
		printf("%d Рубль\n", n);
	if(s >= 2 && s < 5 )
		printf("%d Рубля\n", n);
	return(0);
		
}
