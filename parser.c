#include "parser.h"
#include <stdio.h>
#include <unistd.h>

void	error(void)
{
	write(1,"Error\n", 6);
	exit(EXIT_SUCCESS);
}

void	free_arr(char **arr, int flag)
{
	int	i;

	i = -1;
	while (arr[++i])
		free(arr[i]);
	free(arr);
	if (flag)
		error();
}

void	check_arg(char **arr)
{
	int			i;
	int			j;

	i = -1;
	while (arr[++i])
	{
		j = 0;
		while (arr[i][j])
		{
			if (arr[i][j] == '-')
				j++;
			if (!(ft_isdigit(arr[i][j])))
				free_arr(arr, 1);
			j++;
		}
		printf("%d", ft_atoi(arr[i]));
	}
}

char	**gline(char **str)
{
	int		i;
	char	*line;
	char	*tmp;
	char	**arr;

	i = 1;
	line = ft_strdup(str[i]);
	while (str[++i])
	{
		tmp = line;
		line = ft_strjoin(line, " ");
		free(tmp);
		tmp = line;
		line = ft_strjoin(line, str[i]);
		free(tmp);
	}
	arr = ft_split(line, ' ');
	free(line);
	return (arr);
}

void double_check(char **arr)
{
	int i;	
	int num;
	int j;

	i = 0;
	j = 0;
	while(arr[i])
	{
		j = 0;
		while(arr[j])
		{
			if(ft_atoi(arr[i]) == ft_atoi(arr[j]) && j != i)
				free_arr(arr, 1);
			j++;
		}
		i++;
	}
}


t_all newstack(char **arr)
{
	t_all *stk;
	int i;
	i = 0;
	while(arr[i])
		i++;
	stk = malloc(sizeof(t_all));
	if(stk == NULL)
		return (NULL);
	stck->stack_a = NULL;
	stck->stack_b = NULL;
	stck->size_a = i;
	stck->size_b = 0;
	stck->min_a = 1;
	return(all);
}
void add_stack(char **arr)
{
	
}
int main(int argc, char *argv[])
{

	char** arr;
	arr = gline(argv);
	check_arg(arr);
	double_check(arr);

}
