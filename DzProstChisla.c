#include <stdio.h>
int main()
{
	int m;
	int i;
	int koldel;

	koldel = 0;
	printf("Введите до какого числа искать прост.числа ");
	scanf(" %d",&m);
	i = m;
	while(m != 0)
	{
		while(i != 0)
			{
				if(m % i == 0)
					koldel++;
			i--;
			}
		if(koldel <= 2)
			printf("число %d - простое \n",m);
		koldel = 0;
		m--;
		i = m;
	}	

}
