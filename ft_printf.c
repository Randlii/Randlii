#include <stdarg.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include "ft_putchar.c"
void	ft_putchar(char c);
void ft_check(const char *c, ...)
{
	va_list args;
	char d;
	char s;
	va_start(args, c);
	if(*c == 'd')
	{
		va_arg(args, int);
		ft_putchar((char)va_arg(args, int) + 49);	
	}
	if(*c == 's')
	{
		s = va_arg(args, char);
		ft_putchar(s);	
	}
	if(*c == '%')
	{
		d = '%';
		ft_putchar('%');
	}
	va_end(args);
}
void ft_printf(const char *txt, ...)
{
	va_list args;
	char d;
	va_start(args, txt);
	while(*txt != '\0')
	{
		if(*txt == '%')
		{
			txt++;
			ft_check(txt, args);
		}

		else
			write(1,txt,1);
		txt++;
	}
				
	va_end(args);
}
int main()
{
	char d = '3';
	ft_printf("Hello %%", 'q');
}
