#include <iostream>

typedef struct Node_tag {
    int ar[2];
    struct Node_tag *next;
    struct Node_tag *last;
} Node_t;

void push(Node_t **head, int num1,int num2) {
    Node_t *tmp = new Node_t;
    if (tmp == NULL) {
        exit(0);
    }

    tmp->next = *head;
    tmp->ar[0] = num1;
    tmp->ar[1] = num2;
    *head = tmp;
}

void printStack(const Node_t* head) {
    while (head) {
        std::cout << " " << head->ar[0] << " "<< head->ar[1];
        head = head->next;
    }
}
void check(Node_t* head,int num) {
    while (head) {
        int num1,num2;
        num1= (int) head->ar[0];
        num2= (int) head->ar[1];
        if((num1+num2)==num){
            head->ar[0]=0;
            head->ar[1]=0;
        }

        head = head->next;
    }
}

int main() {
    int i;
    Node_t *head = NULL;
    int kol,num1,num2,opr;
    std::cout << "Введите сумму:";
    std::cin >> opr;
    std::cout << "Введите количество пар: ";
    std::cin >> kol;
    for(int x=0;x<kol;x++){
        std::cout << "Введите пару: ";
        std::cin >> num1;
        std::cin >> num2;
        push(&head,num1,num2);
    }
    std::cout << "Изначальный стэк: ";
    printStack(head);
    check(head,opr);
    std::cout << "\nИзмененный стэк: ";
    printStack(head);
    return 0;
}
